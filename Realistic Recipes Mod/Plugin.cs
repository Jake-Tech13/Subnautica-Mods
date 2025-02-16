using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Nautilus.Handlers;
using Nautilus.Json;

using RRM.SaveFileManager;
using RRM.UI_files;
using RRM.LoggerLines;

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
        static int getSavedDifficulty;


        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Delete unused private members", Justification = "<Waiting>")]
        private void Awake()
        {
            // set project-scoped logger instance
            Logger = base.Logger;
            
            // register harmony patches, if there are any
            Harmony.CreateAndPatchAll(Assembly, $"{PluginInfo.PLUGIN_GUID}");
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");


            saveData = SaveDataHandler.RegisterSaveDataCache<SaveData>();

            // resets the cached saved difficulty so it can be used again
            saveData.OnStartedLoading += (object sender, JsonFileEventArgs e) =>
            {
                SaveData data = e.Instance as SaveData;
                data.SavedDifficulty = default;
                Logger.LogWarning($"[RESETTING] 'SavedDifficulty' resetted value: {data.SavedDifficulty}");
            };

            if (!uGUI_DifficultyPanel.isDifficultyButtonPressed)
            {
                // loads mod data from the file it has been saved to
                saveData.OnFinishedLoading += (object sender, JsonFileEventArgs e) =>
                {
                    SaveData data = e.Instance as SaveData;
                    getSavedDifficulty = data.SavedDifficulty;
                    Logger.LogWarning($"[LOADING] 'SavedDifficulty' saved value: {data.SavedDifficulty}");
                    Logger.LogWarning($"[LOADING] 'getSavedDifficulty' retrieved value: {getSavedDifficulty}");

                    SFM.LoadModdedFiles(getSavedDifficulty);

                    //uGUI_DifficultyPanel.difficultyIndex = default;
                    //Logger.LogWarning($"[LOADING] 'difficultyIndex' var set to: {uGUI_DifficultyPanel.difficultyIndex}");
                    //Logger.LogWarning("[LOADING] Saved game successfully loaded with modded files!");
                };
            }


            // saves mod data to corresponding game save slot under "..\RealisticRecipesMod\RRM_SavedDifficulty.json"
            saveData.OnStartedSaving += (object sender, JsonFileEventArgs e) =>
            {
                SaveData data = e.Instance as SaveData;
                data.SavedDifficulty = uGUI_DifficultyPanel.difficultyIndex;
                Logger.LogWarning($"[SAVING] SavedDifficulty value being saved: {data.SavedDifficulty}");

                //uGUI_DifficultyPanel.difficultyIndex = default;
                //Logger.LogWarning($"[SAVING] 'difficultyIndex' var set to: {uGUI_DifficultyPanel.difficultyIndex}");
            };
        }
    }
}