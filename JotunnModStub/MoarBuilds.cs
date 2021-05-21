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
    internal class MoarBuilds : BaseUnityPlugin
    {
        public const string PluginGUID = "com.zarboz.goblinbuilds";
        public const string PluginName = "GoblinBuilds";
        public const string PluginVersion = "1.0.0";
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
        private AssetBundle assetBundle;
        private ConfigEntry<bool> GoblinStick;
        //private GameObject sfxhammer;
        private void Awake()
        {
            SpriteThings();
            ItemManager.OnVanillaItemsAvailable += GrabPieces;
        }

        private void SpriteThings()
        {
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

        }
        private void GrabPieces()
        {
            try
            {

                //sfx_build_hammer_wood
                //vfx_Place_wood_wall_half
                //vfx_Place_wood_wall_roof
                //vfx_Place_wood_roof
                //vfx_Place_wood_roof
                //
                var sfxhammer = PrefabManager.Cache.GetPrefab<GameObject>("sfx_build_hammer_wood");
                #region GoblinWoodwallribs
                var test = PrefabManager.Instance.CreateClonedPrefab("goblin_woodwall_2m_ribs1", "goblin_woodwall_2m_ribs");
                test.AddComponent<Piece>();
               
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
                piece.m_primaryTarget = true;
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
                             new RequirementConfig { Item = "Wood", Amount = 15, Recover = false}
                   }
               });
                #endregion
                #region GoblinFence1
                var fence = PrefabManager.Instance.CreateClonedPrefab("goblin_fence1", "goblin_fence");
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
                fencepiece.m_primaryTarget = true;
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
                #endregion
                #region GoblinRoof45
                var goblinroof1 = PrefabManager.Instance.CreateClonedPrefab("goblin_roof_45d1", "goblin_roof_45d");
                goblinroof1.AddComponent<Piece>();

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
                #endregion
                #region GoblinRoof45 corner
                var goblinroof2 = PrefabManager.Instance.CreateClonedPrefab("goblin_roof_45d_corner1", "goblin_roof_45d_corner");
                goblinroof2.AddComponent<Piece>();

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
                #endregion
                #region GoblinRoofwall2m
                var goblinwall2m = PrefabManager.Instance.CreateClonedPrefab("goblin_woodwall_2m1", "goblin_woodwall_2m");
                goblinwall2m.AddComponent<Piece>();

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
                #endregion
                #region GoblinRoofwall1m
                var goblinwall1m = PrefabManager.Instance.CreateClonedPrefab("goblin_woodwall_1m1", "goblin_woodwall_1m");
                goblinwall1m.AddComponent<Piece>();

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
                goblinwallm1.m_primaryTarget = true;
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
                #endregion
                #region GoblinRoofpole
                var goblinpole = PrefabManager.Instance.CreateClonedPrefab("goblin_pole1", "goblin_pole");
                goblinpole.AddComponent<Piece>();

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
                #endregion
                #region GoblinBanner
                var goblinbanner = PrefabManager.Instance.CreateClonedPrefab("goblin_banner1", "goblin_banner");
                goblinbanner.AddComponent<Piece>();

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
                #endregion
                #region DungeonGate
                var dungeongate = PrefabManager.Instance.CreateClonedPrefab("dungeon_sunkencrypt_irongate1", "dungeon_sunkencrypt_irongate");
                dungeongate.AddComponent<Piece>();

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
                EffectList effectList = new EffectList { m_effectPrefabs = new EffectList.EffectData[1] { new EffectList.EffectData { m_prefab = sfxhammer } } };
                DungeonGate.m_placeEffect = effectList;

                #endregion
               
                #region GoblinSmacker
                var goblinsmacker = PrefabManager.Instance.CreateClonedPrefab("GoblinBrute_RageAttack1", "GoblinBrute_Attack");
                var smacker = new CustomItem(goblinsmacker, true,
                    new ItemConfig
                    {
                        Amount = 1,
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
                #endregion



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