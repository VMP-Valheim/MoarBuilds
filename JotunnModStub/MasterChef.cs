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
    [NetworkCompatibilty(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class JotunnModStub : BaseUnityPlugin
    {
        public const string PluginGUID = "com.jotunn.masterchef";
        public const string PluginName = "MasterChef";
        public const string PluginVersion = "0.0.1";
        public static new Jotunn.Logger Logger;
        private AssetBundle embeddedResourceBundle;

        private void Awake()
        {

            LoadAssets();
            CreateFood();
            BoneReorder.ApplyOnEquipmentChanged();
        }



        private void LoadAssets()
        {
            Jotunn.Logger.LogInfo($"Embedded resources: {string.Join(",", Assembly.GetExecutingAssembly().GetManifestResourceNames())}");
            embeddedResourceBundle = AssetUtils.LoadAssetBundleFromResources("masterchef", Assembly.GetExecutingAssembly());
        }

        private void CreateFood()
        {
            var burger_prefab = embeddedResourceBundle.LoadAsset<GameObject>("turnipburger");
            var burger = new CustomItem(burger_prefab, fixReference: false,
                new ItemConfig
                {
                    Name = "Burger",
                    Amount = 1,
                    CraftingStation = null ,
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Bread", Amount = 1},
                        new RequirementConfig { Item = "CookdMeat", Amount = 2},
                        new RequirementConfig { Item = "Turnip", Amount = 1}
                    }
                });

            var sausage_prefab = embeddedResourceBundle.LoadAsset<GameObject>("BloodSausage");
            var sausage = new CustomItem(sausage_prefab, fixReference: false,
                new ItemConfig
                {
                    Name = "Blood Sausage",
                    Amount = 1,
                    CraftingStation = null,
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Entrails", Amount = 2},
                        new RequirementConfig { Item = "Bloodbag", Amount = 2},
                        new RequirementConfig { Item = "Turnip", Amount = 1}
                    }
                });

            var stew_prefab = embeddedResourceBundle.LoadAsset<GameObject>("brothbowl");
            var stew = new CustomItem(stew_prefab, fixReference: false,
                new ItemConfig
                {
                    Name = "Broth Bowl",
                    Amount = 1,
                    CraftingStation = null,
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "RawMeat", Amount = 2},
                        new RequirementConfig { Item = "Dandelion", Amount = 1}
                    }
                });

            var butter_prefab = embeddedResourceBundle.LoadAsset<GameObject>("carrotbutter");
            var butter = new CustomItem(butter_prefab, fixReference: false,
                new ItemConfig
                {
                    Name = "Carrot Butter",
                    Amount = 1,
                    CraftingStation = null,
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "CarrotSeeds", Amount = 1},
                        new RequirementConfig { Item = "Honey", Amount = 1}

                    }
                });

            var cbj_prefab = embeddedResourceBundle.LoadAsset<GameObject>("cbj_sandwich");
            var cbj = new CustomItem(cbj_prefab, fixReference: false,
                new ItemConfig
                {
                    Name = "CBJ Sandwich",
                    Amount = 1,
                    CraftingStation = null,
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Bread", Amount = 1},
                        new RequirementConfig { Item = "carrotbutter", Amount = 1},
                        new RequirementConfig { Item = "QueensJam", Amount = 1}

                    }
                });


            var omlette_prfab = embeddedResourceBundle.LoadAsset<GameObject>("dragonomletteprefab");
            var dragonomlette = new CustomItem(omlette_prfab, fixReference: false,
                new ItemConfig
                {
                    Name = "Dragon Omlette",
                    Amount = 1,
                    CraftingStation = null,
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "DragonEgg", Amount = 1},
                        new RequirementConfig { Item = "MushroomYellow", Amount = 2},
                        new RequirementConfig { Item = "Dandelion", Amount = 1}

                    }
                });

            var chef_prefab = embeddedResourceBundle.LoadAsset<GameObject>("chef_hat");
            var chefhat = new CustomItem(chef_prefab, fixReference: false,
                new ItemConfig
                {
                    Name = "Chefs Hat",
                    Amount = 1,
                    CraftingStation = null,
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "LinenThread", Amount = 1}
                    }
                });

            var fish_prefab = embeddedResourceBundle.LoadAsset<GameObject>("fishstew");
            var fish = new CustomItem(fish_prefab, fixReference: false,
                new ItemConfig
                {
                    Name = "Fish Stew",
                    Amount = 1,
                    CraftingStation = null,
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "RawFish", Amount = 1}
                    }
                });

            ItemManager.Instance.AddItem(burger);
            ItemManager.Instance.AddItem(sausage);
            ItemManager.Instance.AddItem(stew);
            ItemManager.Instance.AddItem(butter);
            ItemManager.Instance.AddItem(cbj);
            ItemManager.Instance.AddItem(dragonomlette);
            ItemManager.Instance.AddItem(chefhat);
            ItemManager.Instance.AddItem(fish);

        }

    }
}