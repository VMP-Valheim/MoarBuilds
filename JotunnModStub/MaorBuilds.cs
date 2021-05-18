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
        private AssetBundle embeddedResourceBundle;


        private void Awake()
        {
            ItemManager.OnVanillaItemsAvailable += GrabPieces;
        }


        private void GrabPieces()
        {
            try
            {
                var test = PrefabManager.Instance.CreateClonedPrefab("goblin_roof_cap1", "goblin_roof_cap");
               
                
                PrefabManager.Instance.AddPrefab(test);


                //Make piece->hammer
                var foo = PrefabManager.Instance.GetPrefab("goblin_roof_cap1");
                var CP = new CustomPiece(foo,
                    new PieceConfig
                    {
                        PieceTable = "_HammerPieceTable",
                        AllowedInDungeons = false,
                        Requirements = new[]
                        {
                             new RequirementConfig { Item = "Wood", Amount = 1, Recover = false}
                        }
                    });
                var testpiece = CP.Piece;
                testpiece.m_canBeRemoved = true;
                testpiece.m_category = Piece.PieceCategory.Building;
                testpiece.m_enabled = true;
                testpiece.m_randomTarget = true;
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