using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Nautilus.Json.Converters;
using Nautilus.Utility;
using Newtonsoft.Json;
using System.Collections;
using System.IO;
using RRM.MainMenu_GUI;
using RRM.LoggerLines;
using RRM.SaveFileManager;
using static RRM.SaveFileManager.SFM;
using Nautilus.Handlers;
using RRM.RealisticRecipes;
using Nautilus.Commands;
using Nautilus.Json;
using Nautilus.Json.Attributes;
using Nautilus.Options;
using Nautilus.Options.Attributes;
using static OVRHaptics;
using static FlexibleGridLayout;
using RRM.ComplexRecipes;
using RRM.FaithfulRecipes;
using RRM.XtremeRLRecipes;

namespace RRM
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private const string PLUGIN_GUID = "Jake_Tonic.RealisticRecipesMod";
        private const string PLUGIN_NAME = "Realistic Recipes Mod";
        private const string PLUGIN_VERSION = "1.0.0";

        public new static ManualLogSource Logger { get; private set; }
        private static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();

        // calls and patches any modified/added code inside Subnautica's code
        private void Awake()
        {
            // set project-scoped logger instance
            Logger = base.Logger;

            // register harmony patches, if there are any
            Harmony.CreateAndPatchAll(Assembly, $"{PluginInfo.PLUGIN_GUID}");
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}