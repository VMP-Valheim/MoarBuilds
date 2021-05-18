using BepInEx;
using UnityEngine;
using BepInEx.Configuration;
using Jotunn.Utils;
using System.Reflection;
using Jotunn.Entities;
using Jotunn.Configs;
using Jotunn.Managers;

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
            LoadAssets();

        }



        private void LoadAssets()
        {
            Jotunn.Logger.LogInfo($"Embedded resources: {string.Join(",", Assembly.GetExecutingAssembly().GetManifestResourceNames())}");
            embeddedResourceBundle = AssetUtils.LoadAssetBundleFromResources("masterchef", Assembly.GetExecutingAssembly());
        }


       
    }
} 