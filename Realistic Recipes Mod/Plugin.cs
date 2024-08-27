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
using RRM.SaveSystem;

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

            // initialize custom prefabs
            InitializePrefabs();

            // register harmony patches, if there are any
            Harmony.CreateAndPatchAll(Assembly, $"{PluginInfo.PLUGIN_GUID}");
            Logger.LogInfo(LogInfo_Lines.info_PluginGUID);
        }
        
        // [temporary]
        // declares an integer that is used to select a specific gamemode (as shown below)
        //private readonly int gamemode = GUI_DifficultyPanel.gameModeIndex;

        // this function groups together custom prefabs, function, classes,... so they can all be called inside 'Awake()'
        public void InitializePrefabs()
        {
            if (GUI_DifficultyPanel.gameModeIndex ==)
            {

            }
            else if ()
            {

            }
            SaveLoadingSystem.LoadingNewGame();
            SaveLoadingSystem.LoadingSavedGame();
        }
    }
}