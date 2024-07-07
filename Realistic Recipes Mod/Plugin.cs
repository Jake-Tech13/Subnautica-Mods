using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;
using System;
using System.Linq;
using System.Collections.Generic;
using RRM.MainMenu_GUI;
using RRM.LoggerLines;


namespace RRM
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]

    public class Plugin : BaseUnityPlugin
    {
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
        private readonly int gamemode = GUI_GameModeSelector.gm;

        // this function groups together custom prefabs, function, classes,... so they can all be called inside 'Awake()'
        public void InitializePrefabs()
        {
            // [not fully implemented yet]
            // if selected gamemode value ('gm') equals 'gamemode' value, ignores the rest of the statement and executes only its code...
            if (gamemode == 1)
            {
                Logger.LogInfo(LogInfo_Lines.info_CR);

                ComplexRecipes.ComplexRecipesTable.RegisterAllRecipes();
                Logger.LogMessage(LogMessage_Lines.message_CR_1);
            }

            // ..else, checks all of the following conditions until the values matches...
            else if (gamemode == 2)
            {
                Logger.LogInfo(LogInfo_Lines.info_RR);
                
                RealisticRecipes.RealisticRecipesTable.RegisterAllRecipes();
                Logger.LogMessage(LogMessage_Lines.message_RR_1);

                /*bool WasCalled = 
                if (WasCalled == true)
                {
                    message_CR_1                }
                else
                {
                    Logger.LogError(LogError_Lines.error_RR);
                    Logger.LogWarning(LogWarning_Lines.warning_RR);
                }*/
            }

            else if (gamemode == 3)
            {
                Logger.LogInfo(LogInfo_Lines.info_FR);

                FaithfulRecipes.FaithfulRecipesTable.RegisterAllRecipes();
                Logger.LogMessage(LogMessage_Lines.message_FR_1);
                FaithfulRecipes.FaithfulResourcesTable.RegisterAllResources();
                Logger.LogMessage(LogMessage_Lines.message_FR_2);
                FaithfulRecipes.FaithfulMaterialsTable.RegisterAllMaterials();
                Logger.LogMessage(LogMessage_Lines.message_FR_3);
                FaithfulRecipes.FaithfulToolsTable.RegisterAllTools();
                Logger.LogMessage(LogMessage_Lines.message_FR_4);
                FaithfulRecipes.FaithfulEquipmentsTable.RegisterAllEquipments();
                Logger.LogMessage(LogMessage_Lines.message_FR_5);
            }

            else if (gamemode == 4)
            {
                Logger.LogInfo(LogInfo_Lines.info_XR);

                XtremeRLRecipes.XtremeRLRecipesTable.RegisterAllRecipes();
                Logger.LogMessage(LogMessage_Lines.message_XR_1);
                XtremeRLRecipes.XtremeRLResourcesTable.RegisterAllResources();
                Logger.LogMessage(LogMessage_Lines.message_XR_2);
                XtremeRLRecipes.XtremeRLMaterialsTable.RegisterAllMaterials();
                Logger.LogMessage(LogMessage_Lines.message_XR_3);
                XtremeRLRecipes.XtremeRLToolsTable.RegisterAllTools();
                Logger.LogMessage(LogMessage_Lines.message_XR_4);
                XtremeRLRecipes.XtremeRLEquipmentsTable.RegisterAllEquipments();
                Logger.LogMessage(LogMessage_Lines.message_XR_5);
            }

            else if (gamemode == 0)
            {
                Logger.LogWarning(LogWarning_Lines.warning_Vanilla);
            }
            
            //..and if the values never matches, prints an error in logs
            else
            {
                Logger.LogError(LogError_Lines.error_GM);
            }
        }
    }
}