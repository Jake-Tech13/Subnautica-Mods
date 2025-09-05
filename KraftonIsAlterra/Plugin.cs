using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Nautilus.Handlers;
using KraftonIsAlterra.Replacers;


namespace KraftonIsAlterra
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]    
    public class Plugin : BaseUnityPlugin
    {
        private const string PLUGIN_GUID = "Jake_Tech13.KraftonIsAlterra";
        private const string PLUGIN_NAME = "Krafton Is Alterra";
        private const string PLUGIN_VERSION = "1.0.0";

        public new static ManualLogSource Logger { get; private set; }

        private static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();

        public static List<string> localizedAlterra = new();
        public static List<string> localizedKrafton = new();
        public static string userLanguage;
        public static string localizationFilePath;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Delete unused private members", Justification = "<Waiting>")]
        private void Awake()
        {
            // set project-scoped logger instance
            Logger = base.Logger;

            // register harmony patches, if there are any
            Harmony.CreateAndPatchAll(Assembly, $"{PluginInfo.PLUGIN_GUID}");
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            // plus tard, faire en sorte que l'exécution du code de remplacement se fasse lors de chaque sauvegarde, au cas où la langue aurait été changée en cours de partie
            // (ou le faire uniquement si on détecte une modification du fichier 'options.json')
        }

        public static void InitializeLocalization()
        {
            // retrieve user's language setting + determine the corresponding localization file
            userLanguage = Language.main.currentLanguage;
            localizationFilePath = $"Subnautica_Data/StreamingAssets/SNUnmanagedData/LanguageFiles/{userLanguage}.json";

            // check for the lists, clear them if they contain data. Usefull if user decides to change language mid-game
            if (localizedAlterra.Count > 0 && localizedAlterra != null)
                localizedAlterra.Clear();
            if (localizedKrafton.Count > 0 && localizedKrafton != null)
                localizedKrafton.Clear();

            // populate the lists with localized words
            SetLocalizedLists();

            // deserialize both 'alterra_entries.json' and user's localized json files into dictionnaries
            var alterraKeysDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("BepInEx/plugins/KraftonIsAlterra/datafiles/alterra_entries.json"));
            var localizedValuesDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(localizationFilePath));

            // combining both dictionaries, kepping the keys from 'alterraKeysDictionary' and adding the values from 'localizedValuesDictionary' if the key exists, otherwise keeping the value of 'alterraKeysDictionary'.
            var combinedDictionary = alterraKeysDictionary.ToDictionary(
                kvp => kvp.Key,
                kvp => localizedValuesDictionary.TryGetValue(kvp.Key, out var localizedValue) ? localizedValue : kvp.Value
            );

            // get each key and value from 'combinedDictionary', replace every instance of "Alterra" with "Krafton" in current value and add it back into the game to its respective key
            foreach (var kvp in combinedDictionary)
            {
                LanguageHandler.SetLanguageLine(kvp.Key, CustomStringReplacer.ReplaceWords(kvp.Key, kvp.Value, localizedAlterra, localizedKrafton), userLanguage);
            }
            Logger.LogDebug("All localized strings containing keyword 'Alterra' have been successfuly replaced.");
        }

        public static void SetLocalizedLists()
        {
            switch (userLanguage)
            {
                case "Russian":
                    localizedAlterra = new() { "Альтерра", "Альтерранцы", "3" };
                    localizedKrafton = new() { "Крафтон", "Крафтонианцы", "250" };
                    break;

                case "Korean":
                    localizedAlterra = new() { "알테라", "알테라인", "3백만" };
                    localizedKrafton = new() { "크래프톤", "크래프토니안", "2억 5천만" };
                    break;

                case "Japanese":
                    localizedAlterra = new() { "アルテラ", "アルテラン", "300万" };
                    localizedKrafton = new() { "クラフトン", "クラフトニアン", "2億5千万" };
                    break;

                case "Chinese (Simplified)":
                    localizedAlterra = new() { "阿尔特拉", "阿尔特拉人", "3百万" };
                    localizedKrafton = new() { "克拉夫顿", "克拉夫顿人", "2.5亿" };
                    break;

                case "Chinese (Traditional)":
                    localizedAlterra = new() { "阿爾特拉", "阿爾特拉人", "三百萬" };
                    localizedKrafton = new() { "克拉夫頓", "克拉夫頓人", "兩億五千萬" };
                    break;

                default:
                    localizedAlterra = new() { "Alterra", "Alterrans", "3" };
                    localizedKrafton = new() { "Krafton", "Kraftonians", "250" };
                    break;
            }
        }
    }
}