using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;
using RRM.SaveFileManager;
using Nautilus.Handlers;
using Nautilus.Json;
using RRM.UI_files;
using RRM.LoggerLines;
using System.Net;
using System.Net.Sockets;

namespace RRM
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private const string PLUGIN_GUID = "Jake_Tonic.RealisticRecipesMod";
        private const string PLUGIN_NAME = "Realistic Recipes Mod";
        private const string PLUGIN_VERSION = "0.9.0";

        public new static ManualLogSource Logger { get; private set; }
        private static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();

        internal static SaveData saveData;

        public static bool isAlreadyPrinted;

        private void Awake()
        {
            // set project-scoped logger instance
            Logger = base.Logger;

            // register harmony patches, if there are any
            Harmony.CreateAndPatchAll(Assembly, $"{PluginInfo.PLUGIN_GUID}");
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            // saves mod data to corresponding game save slot under "\RealisticRecipesMod\RealisticRecipesMod.json"
            saveData = SaveDataHandler.RegisterSaveDataCache<SaveData>();
            saveData.OnStartedSaving += (object sender, JsonFileEventArgs e) =>
            {
                SaveData data = e.Instance as SaveData;
                data.Difficulty = uGUI_DifficultyPanel.difficultyIndex;
                Logger.LogWarning($"Difficulty value: {data.Difficulty}");
            };

            // loads mod data from the file it has been saved to
            saveData.OnFinishedLoading += (object sender, JsonFileEventArgs e) =>
            {
                SaveData data = e.Instance as SaveData;
                int savedDifficulty = data.Difficulty;
                Logger.LogWarning($"savedDifficulty value: {savedDifficulty}");

                // if saved value not in range, throws an error; else, passes the variable to the method parameter
                if (savedDifficulty > 4 || savedDifficulty < 0)
                {
                    Logger.LogError(LogError_Lines.error_GM);
                }
                else
                {
                    SFM.LoadModdedFiles(savedDifficulty);
                    Logger.LogWarning("Saved game successfully loaded with modded files!");
                }
            };
        }
    }
}