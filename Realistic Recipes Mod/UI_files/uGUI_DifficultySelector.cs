using HarmonyLib;
using RRM.LoggerLines;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UWE;
using RRM.SaveFileManager;

namespace RRM.UI_files
{
    [HarmonyPatch(typeof(uGUI_MainMenu))]
    internal class uGUI_DifficultyPanel
    {
        public static int difficultyIndex;
        internal static string gameModeIndex;

        public static bool StartNewGameCalled = false; // [TEMP] bool var for when a new game is launched
        //public static event EventHandler IsCalled;

        // dictionary in which modded buttons names and decriptions are stored to be later written on the modded Difficulty UI panel in the Main Menu
        private static readonly Dictionary<string, string>
        buttonTexts = new()
        {
            { "Header", "Difficulty" },

            { "Scroll View/Viewport/NewGameOptions/0. Vanilla/TitleContainer/ModeTitle", "Vanilla Recipes" },
            { "Scroll View/Viewport/NewGameOptions/0. Vanilla/ModeDescription", "Starts the game with all the original crafting recipes, in case you changed your mind." },

            { "Scroll View/Viewport/NewGameOptions/1. Complex/TitleContainer/ModeTitle", "Complex Recipes" },
            { "Scroll View/Viewport/NewGameOptions/1. Complex/ModeDescription", "For players who want to add a little extra difficulty to their game.\r\n- This game mode makes vanilla recipes a little more demanding by increasing the quantity and diversity of the ingredients needed to craft them, or even by completely changing certain recipes for the sake of realism." },

            { "Scroll View/Viewport/NewGameOptions/2. Realistic/TitleContainer/ModeTitle", "Realistic Recipes" },
            { "Scroll View/Viewport/NewGameOptions/2. Realistic/ModeDescription", "For those who wish to experiment with a more tactical approach to the trade-off between resource gathering and the time spent on an objective. /!\\Not recommended for beginners or as a first playthrough/!\\ \r\n- The \"realistic\" factor is based on or inspired by manufacturing recipes from real-life counterparts (if a reference is available), or is the direct product from the imagination of yours truly ;P" },

            { "Scroll View/Viewport/NewGameOptions/3. Faithful/TitleContainer/ModeTitle", "Faithful Recipes (W.I.P)" },
            { "Scroll View/Viewport/NewGameOptions/3. Faithful/ModeDescription", "This gamemode is currently under development and might be available sometime in a futur update.\nFollow Realistic Recipes Mod's progress on the Discord server 'Subnautica Modding' for more informations !"},

            { "Scroll View/Viewport/NewGameOptions/4. Extreme/TitleContainer/ModeTitle", "Extreme Realism (very much W.I.P)" },
            { "Scroll View/Viewport/NewGameOptions/4. Extreme/ModeDescription", "This gamemode is currently under development (way more than the other one-) and might be available sometime in a futur update.\nFollow Realistic Recipes Mod's progress on the Discord server 'Subnautica Modding' for more informations !"}
        };

        [HarmonyPatch(nameof(uGUI_MainMenu.Start)), HarmonyPostfix]
        private static void Start_Postfix(uGUI_MainMenu __instance)
        {
            // instantiates and renames the gamemode selection UI panel
            Transform NewGame = __instance.transform.Find("Panel/MainMenu/RightSide/NewGame");
            GameObject rrmDifficulty = UnityEngine.Object.Instantiate(NewGame.gameObject, NewGame.parent);
            rrmDifficulty.name = "DifficultySelection";

            // instantiates, changes the index (button position on the UI) and renames the first gamemode button (Survival) from the gamemode selection UI panel
            Transform difficultyButtons = __instance.transform.Find("Panel/MainMenu/RightSide/DifficultySelection/Scroll View/Viewport/NewGameOptions");
            GameObject rrmVanillaButton = UnityEngine.Object.Instantiate(difficultyButtons.Find("1. Survival").gameObject, difficultyButtons);
            rrmVanillaButton.transform.SetSiblingIndex(0);
            rrmVanillaButton.name = "0. Vanilla";

            // instantiates the sliding animation the original UI panel has
            var rrmRightSide = __instance.GetComponentInChildren<MainMenuRightSide>();

            // checks if modded UI panel is already part of the animation group and, if not, adds the panel to it
            if (!rrmRightSide.groups.Contains(rrmDifficulty.GetComponent<MainMenuGroup>()))
            {
                rrmRightSide.groups.Add(rrmDifficulty.GetComponent<MainMenuGroup>());
                Plugin.Logger.LogWarning("Modded GUI panel 'DifficultySelection' has been created.");
            }

            // actually passes dictionary keys to all of the modded buttons in the panel
            foreach (var kvp in buttonTexts)
            {
                var text = rrmDifficulty.transform.Find(kvp.Key).GetComponent<TextMeshProUGUI>();
                text.text = kvp.Value;
            }
            
            // changes some containers name of the instantiated UI panel
            GameObject rrmCRButton = difficultyButtons.transform.Find("1. Survival").gameObject;
            rrmCRButton.name = "1. Complex";

            GameObject rrmRRButton = difficultyButtons.transform.Find("2. Freedom").gameObject;
            rrmRRButton.name = "2. Realistic";

            GameObject rrmFRButton = difficultyButtons.transform.Find("3. Hardcore").gameObject;
            rrmFRButton.name = "3. Faithful";

            GameObject rrmXRButton = difficultyButtons.transform.Find("4. Creative").gameObject;
            rrmXRButton.name = "4. Extreme";

            // removes the ability to launch the game for each game mode buttons, then opens up the modded UI panel
            foreach (var button in NewGame.GetComponentsInChildren<Button>(true))
            {
                Button rrmNGButton = NewGame.GetComponent<Button>();
                button.onClick.m_PersistentCalls.Clear();
                button.onClick.AddListener(() =>
                {
                    gameModeIndex = button.gameObject.name;
                    rrmRightSide.OpenGroup("DifficultySelection");
                });
            }
            
            foreach (var button in rrmDifficulty.GetComponentsInChildren<Button>(true))
            {
                // fail-safe because another container exists in the same area, but with a different name
                if (!button.transform.Find("TitleContainer"))
                {
                    continue;
                }

                // destroys game modes icons (such as the thirst, food, health, oxygen and skull icons)
                UnityEngine.Object.Destroy(button.transform.Find("TitleContainer/ModeIcons").gameObject);

                // listener that temporarily removes the method that launch the game after clicking on a game mode button
                button.onClick.m_PersistentCalls.Clear();
                button.onClick.AddListener(() =>
                {
                    // removes the number and space from the game modes name (i.e., "1 Survival" will become "Survival")
                    GameMode gameMode = (GameMode)Enum.Parse(typeof(GameMode), gameModeIndex.Split(' ')[1]);

                    // This sets your difficulty number depending on how far down the hierarchy the button is. 0 = the top (Vanilla Recipes) and 4 = the bottom (Hardcore Realism)
                    difficultyIndex = button.transform.GetSiblingIndex();
                    Plugin.Logger.LogWarning($"Selected difficulty: {difficultyIndex}");

                    // finally launch the game after clicking on a Difficulty button
                    CoroutineHost.StartCoroutine(__instance.StartNewGame(gameMode));

                    Plugin.Logger.LogWarning("'StartNewGame()' method called.");//here

                    StartNewGameCalled = true;
                    //IsCalled.Invoke(null, EventArgs.Empty);//envoie feu vert a LoadData()
                    Plugin.Logger.LogWarning("'StartNewGame()' method has been called.");//here

                    if (difficultyIndex > 4 || difficultyIndex < 0)
                    {
                        Plugin.Logger.LogError(LogError_Lines.error_GM);
                    }
                    else
                    {
                        SFM.LoadModdedFiles(difficultyIndex);
                        Plugin.Logger.LogWarning("New game successfully loaded with modded files!");//here
                    }
                });
            }
        }
    }
}