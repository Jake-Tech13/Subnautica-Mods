using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Nautilus.Handlers;
using Nautilus.Json;

using RRM.SFM;
using RRM.UI;
using RRM.LoggerLines;
using Nautilus.Utility;

namespace RRM
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private const string PLUGIN_GUID = "Jake_Tech13.RealisticRecipesMod";
        private const string PLUGIN_NAME = "Realistic Recipes Mod";
        private const string PLUGIN_VERSION = "0.9.0";

        public new static ManualLogSource Logger { get; private set; }
        private static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();
        internal static SaveData saveData;


        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Delete unused private members", Justification = "<Waiting>")]
        private void Awake()
        {
            // set project-scoped logger instance
            Logger = base.Logger;
            
            // register harmony patches, if there are any
            Harmony.CreateAndPatchAll(Assembly, $"{PluginInfo.PLUGIN_GUID}");
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");


            saveData = SaveDataHandler.RegisterSaveDataCache<SaveData>();

            // saves mod data to corresponding game save slot under "..\RealisticRecipesMod\RRM_SavedDifficulty.json"
            saveData.OnStartedSaving += (object sender, JsonFileEventArgs e) =>
            {
                if (uGUI_DifficultyPanel.difficultyIndex != default) // if player has selected a difficulty other than 'vanilla' (since 0 = default)
                {
                    SaveData data = e.Instance as SaveData;
                    data.SavedDifficulty = uGUI_DifficultyPanel.difficultyIndex; // save the difficulty index
                    uGUI_DifficultyPanel.wasLastDiffIndexSaved = true; // ...to indicate that the index from player's last game was saved (only if it's other than 0 though)
                }
                else
                {
                    uGUI_DifficultyPanel.wasLastDiffIndexSaved = false; // if player selected 'vanilla' difficulty, there's no point in saving the index since it is already equal to 0 by default
                }
            };
                        
            // loads mod data from the file it has been saved to
            saveData.OnFinishedLoading += (object sender, JsonFileEventArgs e) =>
            {
                SaveData data = e.Instance as SaveData;
                if (data.SavedDifficulty == -1) //literally checks (by extension) if the file fuckin exists
                {
                    Logger.LogInfo($"Loading modded recipes for the first time with index value: {uGUI_DifficultyPanel.difficultyIndex}");
                    SaveFileManager.LoadModdedFiles(uGUI_DifficultyPanel.difficultyIndex);
                }
                else
                {
                    Logger.LogInfo($"Loading recipes with saved value: {data.SavedDifficulty}, and index value (for reference): {uGUI_DifficultyPanel.difficultyIndex}");
                    SaveFileManager.LoadModdedFiles(data.SavedDifficulty);
                }
            };
        }
    }
}