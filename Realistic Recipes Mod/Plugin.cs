using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;
using System;
using System.Linq;
using System.Collections.Generic;
using RRM.MainMenu;


namespace RRM
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]

    public class Plugin : BaseUnityPlugin
    {
        public new static ManualLogSource Logger { get; private set; }
        private static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();

        private void Awake()
        {
            Logger = base.Logger; // set project-scoped logger instance

            InitializePrefabs(); // Initialize custom prefabs

            // register harmony patches, if there are any
            Harmony.CreateAndPatchAll(Assembly, $"{PluginInfo.PLUGIN_GUID}");
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }

        
        public int gamemode = GM_SelectorUI.gm;

        public void InitializePrefabs()
        {
            if (gamemode == 1)
            {
                Logger.LogInfo("'Complex Recipes' mode has been selected. The corresponding components are being loaded...");

                ComplexRecipes.ComplexRecipesTable.RegisterAllRecipes();
                Logger.LogMessage("[CR] Modded recipes loaded successfully!");
            }

            else if (gamemode == 2)
            {
                Logger.LogInfo("'Realistic Recipes' mode has been selected. The corresponding components are being loaded...");
                
                RealisticRecipes.RealisticRecipesTable.RegisterAllRecipes();
                Logger.LogMessage("[RR] Modded Recipes loaded successfully!");

                /*bool WasCalled = 
                if (WasCalled == true)
                {
                    
                }
                else
                {
                    Logger.LogError("Component 'RealisticRecipesTable' failed to load. PLease restart Subnautica and try again. If error persists, make sure you meet the requirements to run RRM at: https://www.nexusmods.com/subnautica/search/");
                    Logger.LogWarning("Modded components which failed to load have been replaced by their vanilla counterparts.");
                }*/
            }

            else if (gamemode == 3)
            {
                Logger.LogInfo("'Faithful Recipes' mode has been selected. The corresponding components are being loaded...");

                FaithfulRecipes.FaithfulRecipesTable.RegisterAllRecipes();
                Logger.LogMessage("[FR] Modded Recipes loaded successfully!");
                FaithfulRecipes.FaithfulResourcesTable.RegisterAllResources();
                Logger.LogMessage("[FR] Modded Resources loaded successfully!");
                FaithfulRecipes.FaithfulToolsTable.RegisterAllTools();
                Logger.LogMessage("[FR] Modded Tools loaded successfully!");
            }

            else if (gamemode == 4)
            {
                Logger.LogInfo("'Extreme Realism' mode has been selected. The corresponding components are being loaded...");

                XtremeRLRecipes.XtremeRLRecipesTable.RegisterAllRecipes();
                Logger.LogMessage("[XR] Modded Recipes loaded successfully!");
                XtremeRLRecipes.XtremeRLResourcesTable.RegisterAllResources();
                Logger.LogMessage("[XR] Modded Resources loaded successfully!");
                XtremeRLRecipes.XtremeRLToolsTable.RegisterAllTools();
                Logger.LogMessage("[XR] Modded Tools loaded successfully!");
            }
            else if (gamemode == 0)
            {
                Logger.LogWarning("'Vanilla Recipes' has been selected. No further modifications applied.");
            }

            else
            {
                Logger.LogError("CANNOT SELECT AN EXISTING GAME MODE; GAME MODE VALUES MUST RANGE FROM 0 TO 4.\n" +
                    "How the fuck did you get that error ? Either you messed with the mod's code or your computer's memory has been hit by a gamma ray. Very misfortunate in the second case.\n" +
                    "Anyway, to fix the problem try restarting. If you see this message again or if you already restarted your PC, delete the mod from your device and then re-download it. If this KEEPS happening, send a message to the maker of the mod (myself) on Discord at: https://discord.com/channels/324207629784186882/324210292194279424 (copy-paste it on your internet browser), feel free to ping me -> @JacquyAnto - however, I cannot garantee a quick response time.");
            }
        }
    }
}