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
    internal class MaorBuilds : BaseUnityPlugin
    {
        public const string PluginGUID = "com.zarboz.MaorBuilds";
        public const string PluginName = "MaorBuilds";
        public const string PluginVersion = "1.0.0";
        public static new Jotunn.Logger Logger;
        private Piece piece;
        private Texture2D testTex;
        private Sprite testSprite;
        private Texture2D suckit;
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
                var test = PrefabManager.Instance.CreateClonedPrefab("goblin_roof_cap1", "goblin_roof_cap");
                test.AddComponent<Piece>();
                test.AddComponent<Transform>();

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
                Transform transform = test.transform;
                transform.localPosition = new Vector3(0f, 0f, 0f);
                transform.position = new Vector3(0f, 0f, 0f);
                var piece = CP.Piece;
                piece.m_name = "goblin_roof_cap1";
                piece.m_description = "testing";
                piece.m_canBeRemoved = true;
                piece.m_icon = testSprite;
                piece.m_primaryTarget = true;
                piece.m_randomTarget = true;
                piece.m_category = Piece.PieceCategory.Building;
                piece.m_enabled = true;
                PieceManager.Instance.AddPiece(CP);

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