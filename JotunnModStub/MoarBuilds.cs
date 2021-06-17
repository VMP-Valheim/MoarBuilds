using BepInEx;
using UnityEngine;
using BepInEx.Configuration;
using Jotunn.Utils;
using System.Reflection;
using Jotunn.Entities;
using Jotunn.Configs;
using Jotunn.Managers;
using System;

namespace MaorBuilds
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.None)]
    internal class MoarBuilds : BaseUnityPlugin
    {
        public const string PluginGUID = "com.zarboz.moarbuilds";
        public const string PluginName = "MoArBuIlDs";
        public const string PluginVersion = "1.0.6";
        private Sprite goblinfence;
        private Sprite goblinspike;
        private Sprite goblinribwall2m;
        private Sprite roof45;
        private Sprite roof45corner;
        private Sprite woodwall1m;
        private Sprite woodwall2m;
        private Sprite dungeongate1;
        private Sprite goblinbanner1;
        private Sprite goblinsmacker1;
        private AssetBundle spritebundle1;
        private Sprite capsprite;
        private Sprite barrelsprite;
        private Sprite basketsprite;
        private Sprite barrelaltsprite;
        private Sprite boxsprite;
        private Sprite chestsprite;
        private AssetBundle assetBundle;
        private ConfigEntry<bool> GoblinStick;
        private ConfigEntry<int> BarrelWidth;
        private ConfigEntry<int> chestheight;
        private ConfigEntry<int> chestwidth;
        private ConfigEntry<int> basketheight;
        private ConfigEntry<int> basketwidth;
        private ConfigEntry<int> altbarrelheight;
        private ConfigEntry<int> altbarrelwidth;
        private ConfigEntry<int> crateheight;
        private ConfigEntry<int> cratewidth;
        private ConfigEntry<int> BarrelHeight;
        private EffectList effectList;
        private AssetBundle clutterassets;
        private Container roundchest;
        private Container cratechest;
        private Container basketchest;
        private Container ctn;
        private Container barrell3chest;

        private void Awake()
        {
            ConfigThing();
            SpriteThings();
            ItemManager.OnVanillaItemsAvailable += GrabPieces;
              SynchronizationManager.OnConfigurationSynchronized += (obj, attr) =>
            {
                if (attr.InitialSynchronization)
                {
                    Jotunn.Logger.LogMessage("Initial Config sync event received");
                    configsyncheard();
                }
                else
                {
                    Jotunn.Logger.LogMessage("Config sync event received");
                }
            };
        }

        private void configsyncheard()
        {
            ctn.m_width = (int)chestwidth.Value;
            ctn.m_height = (int)chestheight.Value;
            basketchest.m_width = (int)basketwidth.Value;
            basketchest.m_height = (int)basketheight.Value;
            barrell3chest.m_width = (int)altbarrelwidth.Value;
            barrell3chest.m_height = (int)altbarrelheight.Value;
            cratechest.m_width = (int)cratewidth.Value;
            cratechest.m_height = (int)crateheight.Value;

        }

        private void ConfigThing()
        {
            GoblinStick =  Config.Bind("GoblinStick", "Turn Goblin Brute Weapon off and on", false, new ConfigDescription("Turn the goblin stick on or off", null, new ConfigurationManagerAttributes { IsAdminOnly = true }));
            
            BarrelHeight = Config.Bind("Barrel Size", "Barrel Container Height", 4, new ConfigDescription("Container Height for barrell", new AcceptableValueRange<int>(0, 10), null, new ConfigurationManagerAttributes { IsAdminOnly = true }));
            BarrelWidth = Config.Bind("Barrel Size", "Barrel Container Width", 4, new ConfigDescription("Container Width for barrell", new AcceptableValueRange<int>(0, 8), null, new ConfigurationManagerAttributes { IsAdminOnly = true }));
            
            chestheight = Config.Bind("Chest Size", "Chest Container Height", 4, new ConfigDescription("Container Height for Chest", new AcceptableValueRange<int>(0, 10), null, new ConfigurationManagerAttributes { IsAdminOnly = true }));
            chestwidth = Config.Bind("Chest Size", "Chest Container Width", 4, new ConfigDescription("Container Width for Chest", new AcceptableValueRange<int>(0, 8), null, new ConfigurationManagerAttributes { IsAdminOnly = true }));
            
            basketheight = Config.Bind("Basket Size", "Basket Container Height", 4, new ConfigDescription("Container Height for Basket", new AcceptableValueRange<int>(0, 10), null, new ConfigurationManagerAttributes { IsAdminOnly = true }));
            basketwidth = Config.Bind("Basket Size", "Basket Container Width", 4, new ConfigDescription("Container Width for Basket", new AcceptableValueRange<int>(0, 8), null, new ConfigurationManagerAttributes { IsAdminOnly = true }));
            
            altbarrelheight = Config.Bind("AltBarrel Size", "AltBarrel Container Height", 4, new ConfigDescription("Container Height for AltBarrel", new AcceptableValueRange<int>(0, 10), null, new ConfigurationManagerAttributes { IsAdminOnly = true }));
            altbarrelwidth = Config.Bind("AltBarrel Size", "AltBarrel Width", 4, new ConfigDescription("Container Width for AltBarrel", new AcceptableValueRange<int>(0, 8), null, new ConfigurationManagerAttributes { IsAdminOnly = true }));
            
            crateheight = Config.Bind("Crate Size", "Crate Container Height", 4, new ConfigDescription("Crate Height for barrell", new AcceptableValueRange<int>(0, 10), null, new ConfigurationManagerAttributes { IsAdminOnly = true }));
            cratewidth = Config.Bind("Crate Size", "Crate Container Width", 4, new ConfigDescription("Crate Width for barrell", new AcceptableValueRange<int>(0, 8), null, new ConfigurationManagerAttributes { IsAdminOnly = true }));
            
            }
        private void SpriteThings()
        {

            spritebundle1 = AssetUtils.LoadAssetBundleFromResources("capsprite", typeof(MoarBuilds).Assembly);
            assetBundle = AssetUtils.LoadAssetBundleFromResources("sprites", typeof(MoarBuilds).Assembly);
            goblinfence = assetBundle.LoadAsset<Sprite>("goblinfence");
            goblinspike = assetBundle.LoadAsset<Sprite>("goblinpsike");
            goblinribwall2m = assetBundle.LoadAsset<Sprite>("goblinribwall2m");
            roof45 = assetBundle.LoadAsset<Sprite>("roof45");
            roof45corner = assetBundle.LoadAsset<Sprite>("Roof45Corner");
            woodwall1m = assetBundle.LoadAsset<Sprite>("woodwall1m");
            woodwall2m = assetBundle.LoadAsset<Sprite>("woodwall2m");
            dungeongate1 = assetBundle.LoadAsset<Sprite>("dungeongate");
            goblinbanner1 = assetBundle.LoadAsset<Sprite>("goblinbanner");
            goblinsmacker1 = assetBundle.LoadAsset<Sprite>("goblinsmacker");
            capsprite = spritebundle1.LoadAsset<Sprite>("default");
            barrelsprite = spritebundle1.LoadAsset<Sprite>("barrel_icon");
            basketsprite = spritebundle1.LoadAsset<Sprite>("basket");
            barrelaltsprite = spritebundle1.LoadAsset<Sprite>("barrelalt");
            boxsprite = spritebundle1.LoadAsset<Sprite>("boxes");
            chestsprite = spritebundle1.LoadAsset<Sprite>("chest");
        }
          
        private void LoadAssets()
        {
            clutterassets = AssetUtils.LoadAssetBundleFromResources("containerclutter", typeof(MoarBuilds).Assembly);
            var chest1 = clutterassets.LoadAsset<GameObject>("TraderChest_static");
            var basket = clutterassets.LoadAsset<GameObject>("fi_vil_container_basket02_closed");
            var barrell3 = clutterassets.LoadAsset<GameObject>("fi_vil_container_barrel_small"); 
            var roundbarrel = clutterassets.LoadAsset<GameObject>("default");
            var crate = clutterassets.LoadAsset<GameObject>("fi_vil_container_crate_big_x4_01");

            #region Chest1
            chest1.AddComponent<Piece>();
            var transf = chest1.AddComponent<ZSyncTransform>();
            transf.m_syncRotation = true;
            transf.m_syncScale = true;
            transf.m_syncPosition = true;

            var view = chest1.AddComponent<ZNetView>();
            view.m_persistent = true;


            ctn = chest1.AddComponent<Container>();
            ctn.m_width = (int)chestwidth.Value;
            ctn.m_height = (int)chestheight.Value;
            ctn.m_name = "Trader Chest";
            ctn.m_checkGuardStone = true;

            var chestbox = new CustomPiece(chest1,
                new PieceConfig
                {
                    PieceTable = "_HammerPieceTable",
                    AllowedInDungeons = false,
                    Requirements = new[]
                    {
                             new RequirementConfig { Item = "Iron", Amount = 5, Recover = true},
                             new RequirementConfig { Item = "Wood", Amount = 10, Recover = true}
                    }
                });

            chestbox.Piece.m_name = "Trader Chest";
            chestbox.Piece.m_description = "Traders Chest for holding things";
            chestbox.Piece.m_canBeRemoved = true;
            chestbox.Piece.m_icon = chestsprite;
            chestbox.Piece.m_primaryTarget = false;
            chestbox.Piece.m_randomTarget = false;
            chestbox.Piece.m_category = Piece.PieceCategory.Building;
            chestbox.Piece.m_enabled = true;
            chestbox.Piece.m_clipEverything = true;
            chestbox.Piece.m_isUpgrade = false;
            chestbox.Piece.m_comfort = 0;
            chestbox.Piece.m_groundPiece = false;
            chestbox.Piece.m_allowAltGroundPlacement = false;
            chestbox.Piece.m_cultivatedGroundOnly = false;
            chestbox.Piece.m_waterPiece = false;
            chestbox.Piece.m_noInWater = false;
            chestbox.Piece.m_notOnWood = false;
            chestbox.Piece.m_notOnTiltingSurface = false;
            chestbox.Piece.m_noClipping = false;
            chestbox.Piece.m_onlyInTeleportArea = false;
            chestbox.Piece.m_allowedInDungeons = false;
            chestbox.Piece.m_spaceRequirement = 0;
            chestbox.Piece.m_placeEffect = effectList;

            var wearntear = chest1.AddComponent<WearNTear>();
            wearntear.m_health = 1000f;
            PieceManager.Instance.AddPiece(chestbox);
            #endregion

            #region Basket

            basket.transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);
            basket.AddComponent<Piece>();
            var znetview = basket.AddComponent<ZNetView>();
            znetview.m_persistent = true;
            znetview.m_type = ZDO.ObjectType.Solid;
            
            var transform4 = basket.AddComponent<ZSyncTransform>();
            transform4.m_syncRotation = true;
            transform4.m_syncScale = true;
            transform4.m_syncPosition = true;

            basketchest = basket.AddComponent<Container>();
            basket.transform.position = new Vector3(0f, 0f, 0f);
            basket.transform.localPosition = new Vector3(0f, 0f, 0f);
            basketchest.m_width = (int)basketwidth.Value;
            basketchest.m_height = (int)basketheight.Value;
            basketchest.m_name = "Traders Basket";
            basketchest.m_checkGuardStone = true;

            var BasketRecipe = new CustomPiece(basket,
                new PieceConfig
                {

                    PieceTable = "_HammerPieceTable",
                    AllowedInDungeons = false,
                    Requirements = new[]
                    {
                             new RequirementConfig { Item = "Iron", Amount = 5, Recover = true},
                             new RequirementConfig { Item = "Wood", Amount = 10, Recover = true}
                    }
                });
            BasketRecipe.Piece.m_name = "Traders Basket";
            BasketRecipe.Piece.m_description = "Traders Basket for holding things";
            BasketRecipe.Piece.m_canBeRemoved = true;
            BasketRecipe.Piece.m_icon = basketsprite;
            BasketRecipe.Piece.m_primaryTarget = false;
            BasketRecipe.Piece.m_randomTarget = false;
            BasketRecipe.Piece.m_category = Piece.PieceCategory.Building;
            BasketRecipe.Piece.m_enabled = true;
            BasketRecipe.Piece.m_clipEverything = true;
            BasketRecipe.Piece.m_isUpgrade = false;
            BasketRecipe.Piece.m_comfort = 0;
            BasketRecipe.Piece.m_groundPiece = false;
            BasketRecipe.Piece.m_allowAltGroundPlacement = false;
            BasketRecipe.Piece.m_cultivatedGroundOnly = false;
            BasketRecipe.Piece.m_waterPiece = false;
            BasketRecipe.Piece.m_noInWater = false;
            BasketRecipe.Piece.m_notOnWood = false;
            BasketRecipe.Piece.m_notOnTiltingSurface = false;
            BasketRecipe.Piece.m_noClipping = false;
            BasketRecipe.Piece.m_onlyInTeleportArea = false;
            BasketRecipe.Piece.m_allowedInDungeons = false;
            BasketRecipe.Piece.m_spaceRequirement = 0;
            BasketRecipe.Piece.m_placeEffect = effectList;
            PieceManager.Instance.AddPiece(BasketRecipe);
            #endregion

            #region Barrel3
            barrell3.AddComponent<Piece>();
            var testviiew = barrell3.AddComponent<ZNetView>();
            Vector3 scale =new Vector3(1.5f, 1.5f, 1.5f);
            testviiew.SetLocalScale(scale);
            testviiew.m_persistent = true;
            var transform5 = barrell3.AddComponent<ZSyncTransform>();
            transform5.m_syncRotation = true;
            transform5.m_syncScale = true;
            transform5.m_syncPosition = true;
            barrell3chest = barrell3.AddComponent<Container>();
            barrell3.transform.position = new Vector3(0f, 0f, 0f);
            barrell3.transform.localPosition = new Vector3(0f, 0f, 0f);
            barrell3.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

            barrell3chest.m_width = (int)altbarrelwidth.Value;
            barrell3chest.m_height = (int)altbarrelheight.Value;
            barrell3chest.m_name = "Trader round barrel";
            barrell3chest.m_checkGuardStone = true;

            var barrelrecip3 = new CustomPiece(barrell3,
                new PieceConfig
                {

                    PieceTable = "_HammerPieceTable",
                    AllowedInDungeons = false,
                    Requirements = new[]
                    {
                             new RequirementConfig { Item = "Iron", Amount = 5, Recover = true},
                             new RequirementConfig { Item = "Wood", Amount = 10, Recover = true}
                    }
                });
            barrelrecip3.Piece.m_name = "Trader round barrel";
            barrelrecip3.Piece.m_description = "Trader round barrel for holding things";
            barrelrecip3.Piece.m_canBeRemoved = true;
            barrelrecip3.Piece.m_icon = barrelaltsprite;
            barrelrecip3.Piece.m_primaryTarget = false;
            barrelrecip3.Piece.m_randomTarget = false;
            barrelrecip3.Piece.m_category = Piece.PieceCategory.Building;
            barrelrecip3.Piece.m_enabled = true;
            barrelrecip3.Piece.m_clipEverything = true;
            barrelrecip3.Piece.m_isUpgrade = false;
            barrelrecip3.Piece.m_comfort = 0;
            barrelrecip3.Piece.m_groundPiece = false;
            barrelrecip3.Piece.m_allowAltGroundPlacement = false;
            barrelrecip3.Piece.m_cultivatedGroundOnly = false;
            barrelrecip3.Piece.m_waterPiece = false;
            barrelrecip3.Piece.m_noInWater = false;
            barrelrecip3.Piece.m_notOnWood = false;
            barrelrecip3.Piece.m_notOnTiltingSurface = false;
            barrelrecip3.Piece.m_noClipping = false;
            barrelrecip3.Piece.m_onlyInTeleportArea = false;
            barrelrecip3.Piece.m_allowedInDungeons = false;
            barrelrecip3.Piece.m_spaceRequirement = 0;
            barrelrecip3.Piece.m_placeEffect = effectList;

            var thangg = barrell3.AddComponent<WearNTear>();
            thangg.m_health = 1000f;

            PieceManager.Instance.AddPiece(barrelrecip3);
            #endregion

            #region round barrel
            roundbarrel.AddComponent<Piece>();
            var netview = roundbarrel.AddComponent<ZNetView>();
            var transform2 = roundbarrel.AddComponent<ZSyncTransform>();
            transform2.m_syncPosition = true;
            transform2.m_syncScale = true;
            transform2.m_syncRotation = true;
            netview.m_syncInitialScale = true;
            netview.m_type = ZDO.ObjectType.Solid;
            netview.m_persistent = true;

            roundchest = roundbarrel.AddComponent<Container>();
            roundbarrel.transform.position = new Vector3(0f, 3f, 0f);
            roundbarrel.transform.localPosition = new Vector3(0f, 3f, 0f);
            roundchest.m_width = (int)BarrelWidth.Value;
            roundchest.m_height = (int)BarrelHeight.Value;
            roundchest.m_name = "Trader round2 barrel";
            roundchest.m_checkGuardStone = true;

            var roundchestrecipe = new CustomPiece(roundbarrel,
                new PieceConfig
                {

                    PieceTable = "_HammerPieceTable",
                    AllowedInDungeons = false,
                    Requirements = new[]
                    {
                             new RequirementConfig { Item = "Iron", Amount = 5, Recover = true},
                             new RequirementConfig { Item = "Wood", Amount = 10, Recover = true}
                    }
                });
            roundchestrecipe.Piece.m_name = "Trader round2 barrel";
            roundchestrecipe.Piece.m_description = "A Barrel for holding things";
            roundchestrecipe.Piece.m_canBeRemoved = true;
            roundchestrecipe.Piece.m_icon = barrelsprite;
            roundchestrecipe.Piece.m_primaryTarget = false;
            roundchestrecipe.Piece.m_randomTarget = false;
            roundchestrecipe.Piece.m_category = Piece.PieceCategory.Building;
            roundchestrecipe.Piece.m_enabled = true;
            roundchestrecipe.Piece.m_clipEverything = true;
            roundchestrecipe.Piece.m_isUpgrade = false;
            roundchestrecipe.Piece.m_comfort = 0;
            roundchestrecipe.Piece.m_groundPiece = false;
            roundchestrecipe.Piece.m_allowAltGroundPlacement = false;
            roundchestrecipe.Piece.m_cultivatedGroundOnly = false;
            roundchestrecipe.Piece.m_waterPiece = false;
            roundchestrecipe.Piece.m_noInWater = false;
            roundchestrecipe.Piece.m_notOnWood = false;
            roundchestrecipe.Piece.m_notOnTiltingSurface = false;
            roundchestrecipe.Piece.m_noClipping = false;
            roundchestrecipe.Piece.m_onlyInTeleportArea = false;
            roundchestrecipe.Piece.m_allowedInDungeons = false;
            roundchestrecipe.Piece.m_spaceRequirement = 0;
            roundchestrecipe.Piece.m_placeEffect = effectList;

            var tearnwear = roundbarrel.AddComponent<WearNTear>();
            tearnwear.m_health = 1000f;

            PieceManager.Instance.AddPiece(roundchestrecipe);
            #endregion

            #region Crates
            crate.AddComponent<Piece>();
            var cratenet = crate.AddComponent<ZNetView>();
            var cratesync = crate.AddComponent<ZSyncTransform>();
            cratesync.m_syncPosition = true;
            cratesync.m_syncScale = true;
            cratesync.m_syncRotation = true;

            cratenet.m_syncInitialScale = true;
            cratenet.m_type = ZDO.ObjectType.Solid;
            cratenet.m_persistent = true;

            cratechest = crate.AddComponent<Container>();
            crate.transform.position = new Vector3(0f, 0f, 0f);
            crate.transform.localPosition = new Vector3(0f, 0f, 0f);
            cratechest.m_width = (int)cratewidth.Value;
            cratechest.m_height = (int)crateheight.Value;
            cratechest.m_name = "Crates";
            cratechest.m_checkGuardStone = true;

            var craterecipe = new CustomPiece(crate,
                new PieceConfig
                {

                    PieceTable = "_HammerPieceTable",
                    AllowedInDungeons = false,
                    Requirements = new[]
                    {
                             new RequirementConfig { Item = "Iron", Amount = 5, Recover = true},
                             new RequirementConfig { Item = "Wood", Amount = 10, Recover = true}
                    }
                });
            craterecipe.Piece.m_name = "Crates";
            craterecipe.Piece.m_description = "Crates for holding things";
            craterecipe.Piece.m_canBeRemoved = true;
            craterecipe.Piece.m_icon = boxsprite;
            craterecipe.Piece.m_primaryTarget = false;
            craterecipe.Piece.m_randomTarget = false;
            craterecipe.Piece.m_category = Piece.PieceCategory.Building;
            craterecipe.Piece.m_enabled = true;
            craterecipe.Piece.m_clipEverything = true;
            craterecipe.Piece.m_isUpgrade = false;
            craterecipe.Piece.m_comfort = 0;
            craterecipe.Piece.m_groundPiece = false;
            craterecipe.Piece.m_allowAltGroundPlacement = false;
            craterecipe.Piece.m_cultivatedGroundOnly = false;
            craterecipe.Piece.m_waterPiece = false;
            craterecipe.Piece.m_noInWater = false;
            craterecipe.Piece.m_notOnWood = false;
            craterecipe.Piece.m_notOnTiltingSurface = false;
            craterecipe.Piece.m_noClipping = false;
            craterecipe.Piece.m_onlyInTeleportArea = false;
            craterecipe.Piece.m_allowedInDungeons = false;
            craterecipe.Piece.m_spaceRequirement = 0;
            craterecipe.Piece.m_placeEffect = effectList;

            var tear = crate.AddComponent<WearNTear>();
            tear.m_health = 1000f;
            PieceManager.Instance.AddPiece(craterecipe);
            #endregion

        }

        private void GrabPieces()
        {
            try
            {

                //todo add a child component transform to these objects in order to catch some snap points when placing the objects
                var sfxhammer = PrefabManager.Cache.GetPrefab<GameObject>("sfx_build_hammer_wood");
                var vfx_Place_wood_roof = PrefabManager.Cache.GetPrefab<GameObject>("vfx_Place_wood_roof");
                var vfx_Place_wood_wall_roof = PrefabManager.Cache.GetPrefab<GameObject>("vfx_Place_wood_wall_roof");
                var vfx_Place_wood_wall_half = PrefabManager.Cache.GetPrefab<GameObject>("vfx_Place_wood_wall_half");
                effectList = new EffectList { m_effectPrefabs = new EffectList.EffectData[2] { new EffectList.EffectData { m_prefab = sfxhammer }, new EffectList.EffectData { m_prefab = vfx_Place_wood_roof } } };
                EffectList effectList2 = new EffectList { m_effectPrefabs = new EffectList.EffectData[2] { new EffectList.EffectData { m_prefab = sfxhammer }, new EffectList.EffectData { m_prefab = vfx_Place_wood_wall_half } } };

                #region GoblinWoodwallribs
                var test = PrefabManager.Instance.CreateClonedPrefab("goblin_woodwall_2m_ribs1", "goblin_woodwall_2m_ribs");
                test.AddComponent<Piece>();
                DestroyImmediate(test.GetComponent<DropOnDestroyed>());
                var CP = new CustomPiece(test,
                    new PieceConfig
                    {
                        PieceTable = "_HammerPieceTable",
                        AllowedInDungeons = false,
                        Requirements = new[]
                        {
                             new RequirementConfig { Item = "Wood", Amount = 15, Recover = false}
                        }
                    });
               
                Jotunn.Logger.LogInfo("resetting vectors");
                test.transform.localPosition = new Vector3(0f, 0f, 0f);
                test.transform.position = new Vector3(0f, 0f, 0f);
                var piece = CP.Piece;
                piece.m_name = "Goblin RibWall";
                piece.m_description = "A cage of Lox ribs to use as a fence";
                piece.m_canBeRemoved = true;
                piece.m_icon = goblinribwall2m;
                piece.m_primaryTarget = false;
                piece.m_randomTarget = true;
                piece.m_category = Piece.PieceCategory.Building;
                piece.m_enabled = true;
                piece.m_isUpgrade = false;
                piece.m_comfort = 0;
                piece.m_groundPiece = false;
                piece.m_allowAltGroundPlacement = false;
                piece.m_cultivatedGroundOnly = false;
                piece.m_waterPiece = false;
                piece.m_noInWater = false;
                piece.m_notOnWood = false;
                piece.m_notOnTiltingSurface = false;
                piece.m_noClipping = false;
                piece.m_onlyInTeleportArea = false;
                piece.m_allowedInDungeons = false;
                piece.m_center = new Vector3(0f, 0f, 0f);
                piece.m_haveCenter = true;
                piece.m_spaceRequirement = 2;
                piece.m_placeEffect = effectList2;
                #endregion
                #region biggerstonefloor
                var stonefloornew = PrefabManager.Instance.CreateClonedPrefab("piece_stonefloor_2x2", "stone_floor");
                var CP2 = new CustomPiece(stonefloornew,
               new PieceConfig
               {
                   PieceTable = "_HammerPieceTable",
                   AllowedInDungeons = false,
                   Requirements = new[]
                        {
                             new RequirementConfig { Item = "Stone", Amount = 15, Recover = false}
                        }
               });
                #endregion
                #region GoblinFence1
                var fence = PrefabManager.Instance.CreateClonedPrefab("goblin_fence1", "goblin_fence");
                DestroyImmediate(fence.GetComponent<DropOnDestroyed>());
                fence.AddComponent<Piece>();

                var fencecustom = new CustomPiece(fence,
                    new PieceConfig
                    {
                        PieceTable = "_HammerPieceTable",
                        AllowedInDungeons = false,
                        Requirements = new[]
                        {
                             new RequirementConfig { Item = "Wood", Amount = 15, Recover = false}
                        }
                    });

                Jotunn.Logger.LogInfo("resetting vectors");
                fence.transform.localPosition = new Vector3(0f, 0f, 0f);
                fence.transform.position = new Vector3(0f, 0f, 0f);
                var fencepiece = fencecustom.Piece;
                fencepiece.m_name = "Goblin Fence";
                fencepiece.m_description = "Portions of fence from that last village you raided";
                fencepiece.m_canBeRemoved = true;
                fencepiece.m_icon = goblinfence;
                fencepiece.m_primaryTarget = false;
                fencepiece.m_randomTarget = true;
                fencepiece.m_category = Piece.PieceCategory.Building;
                fencepiece.m_enabled = true;
                fencepiece.m_isUpgrade = false;
                fencepiece.m_comfort = 0;
                fencepiece.m_groundPiece = false;
                fencepiece.m_allowAltGroundPlacement = false;
                fencepiece.m_cultivatedGroundOnly = false;
                fencepiece.m_waterPiece = false;
                fencepiece.m_noInWater = false;
                fencepiece.m_notOnWood = false;
                fencepiece.m_notOnTiltingSurface = false;
                fencepiece.m_noClipping = false;
                fencepiece.m_onlyInTeleportArea = false;
                fencepiece.m_allowedInDungeons = false;
                fencepiece.m_spaceRequirement = 2;
                fencepiece.m_placeEffect = effectList2;
                #endregion
                #region GoblinRoof45
                var goblinroof1 = PrefabManager.Instance.CreateClonedPrefab("goblin_roof_45d1", "goblin_roof_45d");
                goblinroof1.AddComponent<Piece>();
                DestroyImmediate(goblinroof1.GetComponent<DropOnDestroyed>());
                var goblinroof_1 = new CustomPiece(goblinroof1,
                    new PieceConfig
                    {
                        PieceTable = "_HammerPieceTable",
                        AllowedInDungeons = false,
                        Requirements = new[]
                        {
                             new RequirementConfig { Item = "Wood", Amount = 15, Recover = false}
                        }
                    });

                Jotunn.Logger.LogInfo("resetting vectors");
                goblinroof1.transform.localPosition = new Vector3(0f, 0f, 0f);
                goblinroof1.transform.position = new Vector3(0f, 0f, 0f);
                var goblinroofer = goblinroof_1.Piece;
                goblinroofer.m_name = "Goblin Roof 45";
                goblinroofer.m_description = "45 Degree Roof from a goblin hut";
                goblinroofer.m_canBeRemoved = true;
                goblinroofer.m_icon = roof45;
                goblinroofer.m_primaryTarget = false;
                goblinroofer.m_randomTarget = true;
                goblinroofer.m_category = Piece.PieceCategory.Building;
                goblinroofer.m_enabled = true;
                goblinroofer.m_isUpgrade = false;
                goblinroofer.m_comfort = 0;
                goblinroofer.m_groundPiece = false;
                goblinroofer.m_allowAltGroundPlacement = false;
                goblinroofer.m_cultivatedGroundOnly = false;
                goblinroofer.m_waterPiece = false;
                goblinroofer.m_noInWater = false;
                goblinroofer.m_notOnWood = false;
                goblinroofer.m_notOnTiltingSurface = false;
                goblinroofer.m_noClipping = false;
                goblinroofer.m_onlyInTeleportArea = false;
                goblinroofer.m_allowedInDungeons = false;
                goblinroofer.m_spaceRequirement = 2;
                goblinroofer.m_placeEffect = effectList;
                #endregion
                #region GoblinRoof45 corner
                var goblinroof2 = PrefabManager.Instance.CreateClonedPrefab("goblin_roof_45d_corner1", "goblin_roof_45d_corner");
                goblinroof2.AddComponent<Piece>();
                DestroyImmediate(goblinroof2.GetComponent<DropOnDestroyed>());
                var goblinroof_2 = new CustomPiece(goblinroof2,
                    new PieceConfig
                    {
                        PieceTable = "_HammerPieceTable",
                        AllowedInDungeons = false,
                        Requirements = new[]
                        {
                             new RequirementConfig { Item = "Wood", Amount = 15, Recover = false}
                        }
                    });

                Jotunn.Logger.LogInfo("resetting vectors");
                goblinroof2.transform.localPosition = new Vector3(0f, 0f, 0f);
                goblinroof2.transform.position = new Vector3(0f, 0f, 0f);
                var goblinroofer2 = goblinroof_2.Piece;
                goblinroofer2.m_name = "Goblin Roof Corner";
                goblinroofer2.m_description = "Corner piece for a Goblin roof";
                goblinroofer2.m_canBeRemoved = true;
                goblinroofer2.m_icon = roof45corner;
                goblinroofer2.m_primaryTarget = false;
                goblinroofer2.m_randomTarget = true;
                goblinroofer2.m_category = Piece.PieceCategory.Building;
                goblinroofer2.m_enabled = true;
                goblinroofer2.m_isUpgrade = false;
                goblinroofer2.m_comfort = 0;
                goblinroofer2.m_groundPiece = false;
                goblinroofer2.m_allowAltGroundPlacement = false;
                goblinroofer2.m_cultivatedGroundOnly = false;
                goblinroofer2.m_waterPiece = false;
                goblinroofer2.m_noInWater = false;
                goblinroofer2.m_notOnWood = false;
                goblinroofer2.m_notOnTiltingSurface = false;
                goblinroofer2.m_noClipping = false;
                goblinroofer2.m_onlyInTeleportArea = false;
                goblinroofer2.m_allowedInDungeons = false;
                goblinroofer2.m_spaceRequirement = 2;
                goblinroofer2.m_placeEffect = effectList;
                #endregion
                #region GoblinRoofwall2m
                var goblinwall2m = PrefabManager.Instance.CreateClonedPrefab("goblin_woodwall_2m1", "goblin_woodwall_2m");
                goblinwall2m.AddComponent<Piece>();
                DestroyImmediate(goblinwall2m.GetComponent<DropOnDestroyed>());
                var goblinwall_2m = new CustomPiece(goblinwall2m,
                    new PieceConfig
                    {
                        PieceTable = "_HammerPieceTable",
                        AllowedInDungeons = false,
                        Requirements = new[]
                        {
                             new RequirementConfig { Item = "Wood", Amount = 15, Recover = false}
                        }
                    });

                Jotunn.Logger.LogInfo("resetting vectors");
                goblinroof2.transform.localPosition = new Vector3(0f, 0f, 0f);
                goblinroof2.transform.position = new Vector3(0f, 0f, 0f);
                var goblinwallm2 = goblinwall_2m.Piece;
               goblinwallm2.m_name = "Goblin Wall 2m";
               goblinwallm2.m_description = "A 2m long section of wall recovered from the last village you raided";
               goblinwallm2.m_canBeRemoved = true;
               goblinwallm2.m_icon = woodwall2m;
               goblinwallm2.m_primaryTarget = false;
               goblinwallm2.m_randomTarget = true;
               goblinwallm2.m_category = Piece.PieceCategory.Building;
               goblinwallm2.m_enabled = true;
               goblinwallm2.m_isUpgrade = false;
               goblinwallm2.m_comfort = 0;
               goblinwallm2.m_groundPiece = false;
               goblinwallm2.m_allowAltGroundPlacement = false;
               goblinwallm2.m_cultivatedGroundOnly = false;
               goblinwallm2.m_waterPiece = false;
               goblinwallm2.m_noInWater = false;
               goblinwallm2.m_notOnWood = false;
               goblinwallm2.m_notOnTiltingSurface = false;
               goblinwallm2.m_noClipping = false;
               goblinwallm2.m_onlyInTeleportArea = false;
               goblinwallm2.m_allowedInDungeons = false;
               goblinwallm2.m_spaceRequirement = 2;
                goblinwallm2.m_placeEffect = effectList;
                #endregion
                #region GoblinRoofwall1m
                var goblinwall1m = PrefabManager.Instance.CreateClonedPrefab("goblin_woodwall_1m1", "goblin_woodwall_1m");
                goblinwall1m.AddComponent<Piece>();
                DestroyImmediate(goblinwall1m.GetComponent<DropOnDestroyed>());
                var goblinwall_1m = new CustomPiece(goblinwall1m,
                    new PieceConfig
                    {
                        PieceTable = "_HammerPieceTable",
                        AllowedInDungeons = false,
                        Requirements = new[]
                        {
                             new RequirementConfig { Item = "Wood", Amount = 15, Recover = false}
                        }
                    });

                Jotunn.Logger.LogInfo("resetting vectors");
                goblinwall1m.transform.localPosition = new Vector3(0f, 0f, 0f);
                goblinwall1m.transform.position = new Vector3(0f, 0f, 0f);
                var goblinwallm1 = goblinwall_1m.Piece;
                goblinwallm1.m_name = "Goblin Wall 1M";
                goblinwallm1.m_description = "A 1m section of goblin wall from the last village you raided...";
                goblinwallm1.m_canBeRemoved = true;
                goblinwallm1.m_icon = woodwall1m;
                goblinwallm1.m_primaryTarget = false;
                goblinwallm1.m_randomTarget = true;
                goblinwallm1.m_category = Piece.PieceCategory.Building;
                goblinwallm1.m_enabled = true;
                goblinwallm1.m_isUpgrade = false;
                goblinwallm1.m_comfort = 0;
                goblinwallm1.m_groundPiece = false;
                goblinwallm1.m_allowAltGroundPlacement = false;
                goblinwallm1.m_cultivatedGroundOnly = false;
                goblinwallm1.m_waterPiece = false;
                goblinwallm1.m_noInWater = false;
                goblinwallm1.m_notOnWood = false;
                goblinwallm1.m_notOnTiltingSurface = false;
                goblinwallm1.m_noClipping = false;
                goblinwallm1.m_onlyInTeleportArea = false;
                goblinwallm1.m_allowedInDungeons = false;
                goblinwallm1.m_spaceRequirement = 2;
                goblinwallm1.m_placeEffect = effectList;
                #endregion
                #region GoblinRoofpole
                var goblinpole = PrefabManager.Instance.CreateClonedPrefab("goblin_pole1", "goblin_pole");
                goblinpole.AddComponent<Piece>();
                DestroyImmediate(goblinpole.GetComponent<DropOnDestroyed>());
                var goblin_pole = new CustomPiece(goblinpole,
                    new PieceConfig
                    {
                        PieceTable = "_HammerPieceTable",
                        AllowedInDungeons = false,
                        Requirements = new[]
                        {
                             new RequirementConfig { Item = "Wood", Amount = 15, Recover = false}
                        }
                    });

                Jotunn.Logger.LogInfo("resetting vectors");
                goblinpole.transform.localPosition = new Vector3(0f, 0f, 0f);
                goblinpole.transform.position = new Vector3(0f, 0f, 0f);
                var GoblinPole = goblin_pole.Piece;
                GoblinPole.m_name = "Goblin Spike";
                GoblinPole.m_description = "A long spike recovered from that shamans hut";
                GoblinPole.m_canBeRemoved = true;
                GoblinPole.m_icon = goblinspike;
                GoblinPole.m_primaryTarget = false;
                GoblinPole.m_randomTarget = true;
                GoblinPole.m_category = Piece.PieceCategory.Building;
                GoblinPole.m_enabled = true;
                GoblinPole.m_isUpgrade = false;
                GoblinPole.m_comfort = 0;
                GoblinPole.m_groundPiece = false;
                GoblinPole.m_allowAltGroundPlacement = false;
                GoblinPole.m_cultivatedGroundOnly = false;
                GoblinPole.m_waterPiece = false;
                GoblinPole.m_noInWater = false;
                GoblinPole.m_notOnWood = false;
                GoblinPole.m_notOnTiltingSurface = false;
                GoblinPole.m_noClipping = false;
                GoblinPole.m_onlyInTeleportArea = false;
                GoblinPole.m_allowedInDungeons = false;
                GoblinPole.m_spaceRequirement = 2;
                GoblinPole.m_placeEffect = effectList;
                #endregion
                #region GoblinBanner
                var goblinbanner = PrefabManager.Instance.CreateClonedPrefab("goblin_banner1", "goblin_banner");
                goblinbanner.AddComponent<Piece>();
                DestroyImmediate(goblinbanner.GetComponent<DropOnDestroyed>());
                var goblin_banner = new CustomPiece(goblinbanner,
                    new PieceConfig
                    {
                        PieceTable = "_HammerPieceTable",
                        AllowedInDungeons = false,
                        Requirements = new[]
                        {
                             new RequirementConfig { Item = "Wood", Amount = 15, Recover = false}
                        }
                    });

                Jotunn.Logger.LogInfo("resetting vectors");
                goblinbanner.transform.localPosition = new Vector3(0f, 0f, 0f);
                goblinbanner.transform.position = new Vector3(0f, 0f, 0f);
                var GoblinBanner = goblin_banner.Piece;
                GoblinBanner.m_name = "Goblin Banner";
                GoblinBanner.m_description = "Hang their flag on your base....";
                GoblinBanner.m_canBeRemoved = true;
                GoblinBanner.m_icon = goblinbanner1;
                GoblinBanner.m_primaryTarget = false;
                GoblinBanner.m_randomTarget = true;
                GoblinBanner.m_category = Piece.PieceCategory.Building;
                GoblinBanner.m_enabled = true;
                GoblinBanner.m_isUpgrade = false;
                GoblinBanner.m_comfort = 0;
                GoblinBanner.m_groundPiece = false;
                GoblinBanner.m_allowAltGroundPlacement = false;
                GoblinBanner.m_cultivatedGroundOnly = false;
                GoblinBanner.m_waterPiece = false;
                GoblinBanner.m_noInWater = false;
                GoblinBanner.m_notOnWood = false;
                GoblinBanner.m_notOnTiltingSurface = false;
                GoblinBanner.m_noClipping = false;
                GoblinBanner.m_onlyInTeleportArea = false;
                GoblinBanner.m_allowedInDungeons = false;
                GoblinBanner.m_spaceRequirement = 2;
                GoblinBanner.m_placeEffect = effectList2;
                #endregion
                #region DungeonGate
                var dungeongate = PrefabManager.Instance.CreateClonedPrefab("dungeon_sunkencrypt_irongate1", "dungeon_sunkencrypt_irongate");
                dungeongate.AddComponent<Piece>();
                //Destroy(dungeongate.GetComponent<DropOnDestroyed>());
                var dungeon_gate = new CustomPiece(dungeongate,
                    new PieceConfig
                    {
                        PieceTable = "_HammerPieceTable",
                        AllowedInDungeons = false,
                        Requirements = new[]
                        {
                             new RequirementConfig { Item = "Iron", Amount = 5, Recover = false}
                        }
                    });

                Jotunn.Logger.LogInfo("resetting vectors");
                dungeongate.transform.localPosition = new Vector3(0f, 0f, 0f);
                dungeongate.transform.position = new Vector3(0f, 0f, 0f);
                var DungeonGate = dungeon_gate.Piece;
                DungeonGate.m_name = "Dungeon Gate";
                DungeonGate.m_description = "Another metal gate";
                DungeonGate.m_canBeRemoved = true;
                DungeonGate.m_icon = dungeongate1;
                DungeonGate.m_primaryTarget = false;
                DungeonGate.m_randomTarget = true;
                DungeonGate.m_category = Piece.PieceCategory.Building;
                DungeonGate.m_enabled = true;
                DungeonGate.m_isUpgrade = false;
                DungeonGate.m_comfort = 0;
                DungeonGate.m_groundPiece = false;
                DungeonGate.m_allowAltGroundPlacement = false;
                DungeonGate.m_cultivatedGroundOnly = false;
                DungeonGate.m_waterPiece = false;
                DungeonGate.m_noInWater = false;
                DungeonGate.m_notOnWood = false;
                DungeonGate.m_notOnTiltingSurface = false;
                DungeonGate.m_noClipping = false;
                DungeonGate.m_onlyInTeleportArea = false;
                DungeonGate.m_allowedInDungeons = false;
                DungeonGate.m_spaceRequirement = 0;
                DungeonGate.m_placeEffect = effectList;
                 
                #endregion
                #region Goblinroof
                var Goblinroof = PrefabManager.Instance.CreateClonedPrefab("goblin_roof_cap1", "goblin_roof_cap");
                Goblinroof.AddComponent<Piece>();
                DestroyImmediate(Goblinroof.GetComponent<DropOnDestroyed>());
                var Goblin_roof = new CustomPiece(Goblinroof,
                    new PieceConfig
                    {
                        PieceTable = "_HammerPieceTable",
                        AllowedInDungeons = false,
                        Requirements = new[]
                        {
                             new RequirementConfig { Item = "Iron", Amount = 5, Recover = false}
                        }
                    });

                Jotunn.Logger.LogInfo("resetting vectors");
                var zeropos = new Vector3(0f, 0f, 0f);
                Goblinroof.transform.localPosition = zeropos;
                Goblinroof.transform.position = zeropos;
                Goblin_roof.Piece.m_name = "Goblin Roof Cap";
                Goblin_roof.Piece.m_description = "A nice round roof cap from a Goblin camp";
                Goblin_roof.Piece.m_canBeRemoved = true;
                Goblin_roof.Piece.m_icon = capsprite;
                Goblin_roof.Piece.m_primaryTarget = false;
                Goblin_roof.Piece.m_randomTarget = false;
                Goblin_roof.Piece.m_category = Piece.PieceCategory.Building;
                Goblin_roof.Piece.m_enabled = true;
                Goblin_roof.Piece.m_clipEverything = true;
                Goblin_roof.Piece.m_isUpgrade = false;
                Goblin_roof.Piece.m_comfort = 0;
                Goblin_roof.Piece.m_groundPiece = false;
                Goblin_roof.Piece.m_allowAltGroundPlacement = false;
                Goblin_roof.Piece.m_cultivatedGroundOnly = false;
                Goblin_roof.Piece.m_waterPiece = false;
                Goblin_roof.Piece.m_noInWater = false;
                Goblin_roof.Piece.m_notOnWood = false;
                Goblin_roof.Piece.m_notOnTiltingSurface = false;
                Goblin_roof.Piece.m_noClipping = false;
                Goblin_roof.Piece.m_onlyInTeleportArea = false;
                Goblin_roof.Piece.m_allowedInDungeons = false;
                Goblin_roof.Piece.m_spaceRequirement = 0;
                Goblin_roof.Piece.m_placeEffect = effectList;
                #endregion
                #region Barrel
                var Barrel = PrefabManager.Instance.CreateClonedPrefab("Boxthing", "barrell");
                Barrel.AddComponent<Piece>();
                Barrel.AddComponent<ZSyncTransform>();
                var view = Barrel.AddComponent<ZNetView>();
                view.m_persistent = true;
                
                Barrel.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                Barrel.transform.position = new Vector3(0f, 2f, 0f);
                Barrel.transform.localPosition = new Vector3(0f, 2f, 0f);
                
                var ctn = Barrel.AddComponent<Container>();
                ctn.m_width = BarrelWidth.Value;
                ctn.m_height = BarrelHeight.Value;
                ctn.m_name = "Barrell";
                ctn.m_checkGuardStone = true;
                
                DestroyImmediate(Barrel.GetComponent<DropOnDestroyed>());
                var BarrelBox = new CustomPiece(Barrel,
                    new PieceConfig
                    {
                        PieceTable = "_HammerPieceTable",
                        AllowedInDungeons = false,
                        Requirements = new[]
                        {
                             new RequirementConfig { Item = "Iron", Amount = 5, Recover = true},
                             new RequirementConfig { Item = "Wood", Amount = 10, Recover = true}
                        }
                    });
                var wera = Barrel.AddComponent<WearNTear>();
                wera.m_health = 1000f;
                BarrelBox.Piece.m_name = "Barrel";
                BarrelBox.Piece.m_description = "A Barrel for holding things";
                BarrelBox.Piece.m_canBeRemoved = true;
                BarrelBox.Piece.m_icon = barrelsprite;
                BarrelBox.Piece.m_primaryTarget = false;
                BarrelBox.Piece.m_randomTarget = false;
                BarrelBox.Piece.m_category = Piece.PieceCategory.Building;
                BarrelBox.Piece.m_enabled = true;
                BarrelBox.Piece.m_clipEverything = true;
                BarrelBox.Piece.m_isUpgrade = false;
                BarrelBox.Piece.m_comfort = 0;
                BarrelBox.Piece.m_groundPiece = false;
                BarrelBox.Piece.m_allowAltGroundPlacement = false;
                BarrelBox.Piece.m_cultivatedGroundOnly = false;
                BarrelBox.Piece.m_waterPiece = false;
                BarrelBox.Piece.m_noInWater = false;
                BarrelBox.Piece.m_notOnWood = false;
                BarrelBox.Piece.m_notOnTiltingSurface = false;
                BarrelBox.Piece.m_noClipping = false;
                BarrelBox.Piece.m_onlyInTeleportArea = false;
                BarrelBox.Piece.m_allowedInDungeons = false;
                BarrelBox.Piece.m_spaceRequirement = 0;
                BarrelBox.Piece.m_placeEffect = effectList;
                #endregion
                

                #region GoblinSmacker
                var goblinsmacker = PrefabManager.Instance.CreateClonedPrefab("GoblinBrute_RageAttack1", "GoblinBrute_Attack");
                var smacker = new CustomItem(goblinsmacker, true,
                    new ItemConfig
                    {
                        Amount = 1,
                        Enabled = GoblinStick.Value,
                        Requirements = new[]
                        {
                            new RequirementConfig{Item = "Wood", Amount = 15, AmountPerLevel = 1 },
                            new RequirementConfig{Item = "Stone", Amount = 10, AmountPerLevel = 20 },
                            new RequirementConfig{Item = "LeatherScraps", Amount = 10, AmountPerLevel = 10}
                        }
                    });
                var itemDrop =smacker.ItemDrop;
                itemDrop.m_itemData.m_shared.m_icons = new Sprite[]
                    { goblinsmacker1 };
                itemDrop.m_itemData.m_shared.m_name = "Goblin Smacker";
                itemDrop.m_itemData.m_shared.m_description = "A brute dropped this in the plains.. Its heavy.. but man does it feel good to give them a taste of their own medicine";
                itemDrop.m_itemData.m_shared.m_itemType = ItemDrop.ItemData.ItemType.OneHandedWeapon;
                itemDrop.m_itemData.m_shared.m_animationState = ItemDrop.ItemData.AnimationState.OneHanded;
                itemDrop.m_itemData.m_shared.m_attack.m_attackType = Attack.AttackType.Horizontal;
                itemDrop.m_itemData.m_shared.m_attack.m_attackAnimation = "swing_longsword";
                itemDrop.m_itemData.m_shared.m_attack.m_currentAttackCainLevel = 2;
                itemDrop.m_itemData.m_shared.m_attack.m_attackRange = 5f;
                itemDrop.m_itemData.m_shared.m_attack.m_attackAngle = 70;
                itemDrop.m_itemData.m_shared.m_attack.m_attackRayWidth = 0.8f;
                itemDrop.m_itemData.m_shared.m_attack.m_attackHeight = 1.5f;
                itemDrop.m_itemData.m_shared.m_attack.m_forceMultiplier = 3;
                itemDrop.m_itemData.m_shared.m_attack.m_resetChainIfHit = DestructibleType.Tree;
                itemDrop.m_itemData.m_shared.m_attack.m_lastChainDamageMultiplier = 2;
                itemDrop.m_itemData.m_shared.m_attack.m_hitTerrain = true;
                itemDrop.m_itemData.m_shared.m_secondaryAttack.m_attackType = Attack.AttackType.Horizontal;
                itemDrop.m_itemData.m_shared.m_secondaryAttack.m_attackAnimation = "battleaxe_secondary";
                itemDrop.m_itemData.m_shared.m_maxQuality = 4;
                ItemManager.Instance.AddItem(smacker);
                #endregion
                #region Pieceadding
                PieceManager.Instance.AddPiece(CP);
                PieceManager.Instance.AddPiece(CP2);
                PieceManager.Instance.AddPiece(fencecustom);
                PieceManager.Instance.AddPiece(goblinroof_1);
                PieceManager.Instance.AddPiece(goblinroof_2);
                PieceManager.Instance.AddPiece(goblinwall_2m);
                PieceManager.Instance.AddPiece(goblinwall_1m);
                PieceManager.Instance.AddPiece(goblin_pole);
                PieceManager.Instance.AddPiece(dungeon_gate);
                PieceManager.Instance.AddPiece(goblin_banner);
                PieceManager.Instance.AddPiece(Goblin_roof);
                PieceManager.Instance.AddPiece(BarrelBox);
                #endregion


                LoadAssets();

            }
            catch (Exception ex)
            {
                Jotunn.Logger.LogError($"Error while adding cloned item: {ex.Message}");
            }
            finally
            {
                ItemManager.OnVanillaItemsAvailable -= GrabPieces;
            }

         

        }


    }
}