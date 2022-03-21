// DungeonFinder
// a Valheim mod skeleton using Jötunn
// 
// File:    DungeonFinder.cs
// Project: DungeonFinder

using BepInEx;
using Jotunn.Entities;
using Jotunn.Managers;
using System;
using DungeonFinder.Languages;
using BepInEx.Logging;

namespace DungeonFinder
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    //[NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class DungeonFinder : BaseUnityPlugin
    {
        public const string PluginGUID = "com.jotunn.DungeonFinder";
        public const string PluginName = "DungeonFinder";
        public const string PluginVersion = "0.0.1";

        public static ManualLogSource logger;

        private CustomLocalization Localization;

        private void Awake()
        {
            logger = Logger;
            AddLocalizations();
            PrefabManager.OnVanillaPrefabsAvailable += GenerateItems;
        }
        private void AddLocalizations()
        {
            Localization = new CustomLocalization();
            LocalizationManager.Instance.AddLocalization(Localization);

            new English().AddLocalization(Localization);
            new Brazilian().AddLocalization(Localization);
        }

        private void GenerateItems()
        {
            try
            {
                var skeletonBelt = new SkeletonBelt();
                skeletonBelt.GenerateItem();
            }
            catch (Exception ex)
            {
                Jotunn.Logger.LogError($"Error while adding cloned item: {ex.Message}");
            }
            finally
            {
                // You want that to run only once, Jotunn has the item cached for the game session
                PrefabManager.OnVanillaPrefabsAvailable -= GenerateItems;
            }
        }
    }
}

