// JotunnModStub
// a Valheim mod skeleton using JötunnLib
// 
// File:    JotunnModStub.cs
// Project: JotunnModStub

using BepInEx;
using UnityEngine;
using BepInEx.Configuration;
using Jotunn.Utils;
using System.Reflection;
using Jotunn.Entities;
using Jotunn.Configs;
using Jotunn.Managers;

namespace JotunnModStub
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    //[NetworkCompatibilty(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class JotunnModStub : BaseUnityPlugin
    {
        public const string PluginGUID = "com.jotunn.jotunnmodstub";
        public const string PluginName = "JotunnModStub";
        public const string PluginVersion = "0.0.1";
        public static new Jotunn.Logger Logger;
        private AssetBundle embeddedResourceBundle;

        public GameObject turnipburgerfab { get; private set; }

        private void Awake()
        {

            LoadAssets();
            CreateFood();
        }


        private void Update()
        {
  
        }


        private void LoadAssets()
        {
            Jotunn.Logger.LogInfo($"Embedded resources: {string.Join(",", Assembly.GetExecutingAssembly().GetManifestResourceNames())}");
            embeddedResourceBundle = AssetUtils.LoadAssetBundleFromResources("masterchef", Assembly.GetExecutingAssembly());
            //insert prefabs here
            turnipburgerfab = embeddedResourceBundle.LoadAsset<GameObject>("Assets/MasterChef/turnip_burger/turnipburger.prefab");


        }

        private void CreateFood()
        {
            var burger_prefab = embeddedResourceBundle.LoadAsset<GameObject>("turnipburger");
            var burger = new CustomItem(burger_prefab, fixReference: false,
                new ItemConfig
                {
                    Amount = 1,
                    CraftingStation = "piece_cauldron",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Honey", Amount = 1}
                    }
                });
            ItemManager.Instance.AddItem(burger);
        }

        //can clone a prefab from game with this but it duplicates CreateFood() in a non working way
        private void Foodrecipes()
        {
            CustomRecipe turnipburger = new CustomRecipe(new RecipeConfig()
            {
                Item = "turnipburger",
                CraftingStation = "piece_cauldron",
                Amount = 1,
                Requirements = new[]
                {
                    new RequirementConfig {Item = "Honey", Amount = 1}
                }
            });
            ItemManager.Instance.AddRecipe(turnipburger);

        }
    }
}