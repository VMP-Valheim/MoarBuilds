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
        public const string PluginGUID = "com.zarboz.MaorBuilds";
        public const string PluginName = "MaorBuilds";
        public const string PluginVersion = "1.0.0";
        public static new Jotunn.Logger Logger;
        private Piece piece;
        private Texture2D testTex;
        private Sprite testSprite;
        private AssetBundle assetBundle;
        private void Awake()
        {
            SpriteThings();
            ItemManager.OnVanillaItemsAvailable += GrabPieces;
        }

        private void SpriteThings()
        {
            testTex = AssetUtils.LoadTexture("MaorBuilds/Assets/test_tex.jpg");
            testSprite = Sprite.Create(testTex, new Rect(0f, 0f, testTex.width, testTex.height), Vector2.zero);
        }
        private void GrabPieces()
        {
            try
            {
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
                             new RequirementConfig { Item = "Wood", Amount = 1, Recover = false}
                        }
                    });
               
                Jotunn.Logger.LogInfo("resetting vectors");
                test.transform.localPosition = new Vector3(0f, 0f, 0f);
                test.transform.position = new Vector3(0f, 0f, 0f);
                var piece = CP.Piece;
                piece.m_name = "goblin_woodwall_2m_ribs1";
                piece.m_description = "testing";
                piece.m_canBeRemoved = true;
                piece.m_icon = testSprite;
                piece.m_primaryTarget = false;
                piece.m_randomTarget = false;
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
                piece.m_haveCenter = false;
                piece.m_spaceRequirement = 0;
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
                             new RequirementConfig { Item = "Wood", Amount = 1, Recover = false}
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
                             new RequirementConfig { Item = "Wood", Amount = 1, Recover = false}
                        }
                    });

                Jotunn.Logger.LogInfo("resetting vectors");
                fence.transform.localPosition = new Vector3(0f, 0f, 0f);
                fence.transform.position = new Vector3(0f, 0f, 0f);
                var fencepiece = fencecustom.Piece;
                fencepiece.m_name = "goblin_fence1";
                fencepiece.m_description = "testing";
                fencepiece.m_canBeRemoved = true;
                fencepiece.m_icon = testSprite;
                fencepiece.m_primaryTarget = false;
                fencepiece.m_randomTarget = false;
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
                fencepiece.m_center = new Vector3(0f, 0f, 0f);
                fencepiece.m_haveCenter = false;
                fencepiece.m_spaceRequirement = 0;
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
                             new RequirementConfig { Item = "Wood", Amount = 1, Recover = false}
                        }
                    });

                Jotunn.Logger.LogInfo("resetting vectors");
                goblinroof1.transform.localPosition = new Vector3(0f, 0f, 0f);
                goblinroof1.transform.position = new Vector3(0f, 0f, 0f);
                var goblinroofer = goblinroof_1.Piece;
                goblinroofer.m_name = "goblin_roof_45d1";
                goblinroofer.m_description = "testing";
                goblinroofer.m_canBeRemoved = true;
                goblinroofer.m_icon = testSprite;
                goblinroofer.m_primaryTarget = false;
                goblinroofer.m_randomTarget = false;
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
                goblinroofer.m_center = new Vector3(0f, 0f, 0f);
                goblinroofer.m_haveCenter = false;
                goblinroofer.m_spaceRequirement = 0;
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
                             new RequirementConfig { Item = "Wood", Amount = 1, Recover = false}
                        }
                    });

                Jotunn.Logger.LogInfo("resetting vectors");
                goblinroof2.transform.localPosition = new Vector3(0f, 0f, 0f);
                goblinroof2.transform.position = new Vector3(0f, 0f, 0f);
                var goblinroofer2 = goblinroof_2.Piece;
                goblinroofer2.m_name = "goblin_roof_45d_corner1";
                goblinroofer2.m_description = "testing";
                goblinroofer2.m_canBeRemoved = true;
                goblinroofer2.m_icon = testSprite;
                goblinroofer2.m_primaryTarget = false;
                goblinroofer2.m_randomTarget = false;
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
                goblinroofer2.m_center = new Vector3(0f, 0f, 0f);
                goblinroofer2.m_haveCenter = false;
                goblinroofer2.m_spaceRequirement = 0;
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
                             new RequirementConfig { Item = "Wood", Amount = 1, Recover = false}
                        }
                    });

                Jotunn.Logger.LogInfo("resetting vectors");
                goblinroof2.transform.localPosition = new Vector3(0f, 0f, 0f);
                goblinroof2.transform.position = new Vector3(0f, 0f, 0f);
                var goblinwallm2 = goblinwall_2m.Piece;
               goblinwallm2.m_name = "goblin_woodwall_2m1";
               goblinwallm2.m_description = "testing";
               goblinwallm2.m_canBeRemoved = true;
               goblinwallm2.m_icon = testSprite;
               goblinwallm2.m_primaryTarget = false;
               goblinwallm2.m_randomTarget = false;
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
               goblinwallm2.m_center = new Vector3(0f, 0f, 0f);
               goblinwallm2.m_haveCenter = false;
               goblinwallm2.m_spaceRequirement = 0;
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
                             new RequirementConfig { Item = "Wood", Amount = 1, Recover = false}
                        }
                    });

                Jotunn.Logger.LogInfo("resetting vectors");
                goblinwall1m.transform.localPosition = new Vector3(0f, 0f, 0f);
                goblinwall1m.transform.position = new Vector3(0f, 0f, 0f);
                var goblinwallm1 = goblinwall_1m.Piece;
                goblinwallm1.m_name = "goblin_woodwall_1m1";
                goblinwallm1.m_description = "testing";
                goblinwallm1.m_canBeRemoved = true;
                goblinwallm1.m_icon = testSprite;
                goblinwallm1.m_primaryTarget = false;
                goblinwallm1.m_randomTarget = false;
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
                goblinwallm1.m_center = new Vector3(0f, 0f, 0f);
                goblinwallm1.m_haveCenter = false;
                goblinwallm1.m_spaceRequirement = 0;
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
                             new RequirementConfig { Item = "Wood", Amount = 1, Recover = false}
                        }
                    });

                Jotunn.Logger.LogInfo("resetting vectors");
                goblinpole.transform.localPosition = new Vector3(0f, 0f, 0f);
                goblinpole.transform.position = new Vector3(0f, 0f, 0f);
                var GoblinPole = goblin_pole.Piece;
                GoblinPole.m_name = "goblin_pole1";
                GoblinPole.m_description = "testing";
                GoblinPole.m_canBeRemoved = true;
                GoblinPole.m_icon = testSprite;
                GoblinPole.m_primaryTarget = false;
                GoblinPole.m_randomTarget = false;
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
                GoblinPole.m_center = new Vector3(0f, 0f, 0f);
                GoblinPole.m_haveCenter = false;
                GoblinPole.m_spaceRequirement = 0;
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
                             new RequirementConfig { Item = "Wood", Amount = 1, Recover = false}
                        }
                    });

                Jotunn.Logger.LogInfo("resetting vectors");
                goblinbanner.transform.localPosition = new Vector3(0f, 0f, 0f);
                goblinbanner.transform.position = new Vector3(0f, 0f, 0f);
                var GoblinBanner = goblin_banner.Piece;
                GoblinBanner.m_name = "goblin_banner1";
                GoblinBanner.m_description = "testing";
                GoblinBanner.m_canBeRemoved = true;
                GoblinBanner.m_icon = testSprite;
                GoblinBanner.m_primaryTarget = false;
                GoblinBanner.m_randomTarget = false;
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
                GoblinBanner.m_center = new Vector3(0f, 0f, 0f);
                GoblinBanner.m_haveCenter = false;
                GoblinBanner.m_spaceRequirement = 0;
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
                             new RequirementConfig { Item = "Wood", Amount = 1, Recover = false}
                        }
                    });

                Jotunn.Logger.LogInfo("resetting vectors");
                dungeongate.transform.localPosition = new Vector3(0f, 0f, 0f);
                dungeongate.transform.position = new Vector3(0f, 0f, 0f);
                var DungeonGate = dungeon_gate.Piece;
                DungeonGate.m_name = "dungeon_sunkencrypt_irongate1";
                DungeonGate.m_description = "testing";
                DungeonGate.m_canBeRemoved = true;
                DungeonGate.m_icon = testSprite;
                DungeonGate.m_primaryTarget = false;
                DungeonGate.m_randomTarget = false;
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
                DungeonGate.m_center = new Vector3(0f, 0f, 0f);
                DungeonGate.m_haveCenter = false;
                DungeonGate.m_spaceRequirement = 0;
                #endregion

                #region GoblinSmacker
                var goblinsmacker = PrefabManager.Instance.CreateClonedPrefab("GoblinBrute_RageAttack1", "GoblinBrute_RageAttack");
                var smacker = new CustomItem(goblinsmacker, true,
                    new ItemConfig
                    {
                        Amount = 1,
                        Requirements = new[]
                        {
                            new RequirementConfig{Item = "Wood", Amount = 1, AmountPerLevel =1}
                        }
                    });
                var itemDrop = smacker.ItemDrop;
                itemDrop.m_itemData.m_shared.m_icons = new Sprite[]
                    { testSprite };
                itemDrop.m_itemData.m_shared.m_attack.m_attackType = Attack.AttackType.Horizontal;
                itemDrop.m_itemData.m_shared.m_attack.m_attackAnimation = "battleaxe_attack";
                itemDrop.m_itemData.m_shared.m_attack.m_currentAttackCainLevel = 3;
                itemDrop.m_itemData.m_shared.m_attack.m_attackRange = 4f;
                itemDrop.m_itemData.m_shared.m_attack.m_forceMultiplier = 3;
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