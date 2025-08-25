using HarmonyLib;
using JetBrains.Annotations;
using RRM.LoggerLines;
using RRM.SFM;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UWE;

namespace RRM.UI
{
    [HarmonyPatch(typeof(uGUI_MainMenu))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Styles d'affectation de noms", Justification = "<En attente>")]
    internal class uGUI_DifficultyPanel
    {
        public static int difficultyIndex = default;
        public static bool wasLastDiffIndexSaved = false;
        internal static string gameModeIndex;

        // dictionary in which modded buttons names and decriptions are stored to be later written on the Difficulty UI panel in the Main Menu
        private static readonly Dictionary<string, string>
        buttonTexts = new()
        {
            { "Header", "Difficulty" },

            { "Scroll View/Viewport/NewGameOptions/0. Vanilla/TitleContainer/ModeTitle", "Vanilla Recipes" },
            { "Scroll View/Viewport/NewGameOptions/0. Vanilla/ModeDescription", "Launch the game with all the original crafting recipes, in case you changed your mind." },

            { "Scroll View/Viewport/NewGameOptions/1. Complex/TitleContainer/ModeTitle", "Complex Recipes" },
            { "Scroll View/Viewport/NewGameOptions/1. Complex/ModeDescription", "For players who want to add a little extra difficulty to their game.\r\n- This game mode makes vanilla recipes a little more demanding by slightly increasing the quantity and diversity of the ingredients needed to craft them. Some recipes can be completely changed for the sake of realism." },

            { "Scroll View/Viewport/NewGameOptions/2. Realistic/TitleContainer/ModeTitle", "Realistic Recipes" },
            { "Scroll View/Viewport/NewGameOptions/2. Realistic/ModeDescription", "For those who wish to experiment with a more tactical approach to the trade-off between resource gathering and the time spent on an objective.\r\n/!\\Not recommended for beginners or as a first playthrough/!\\\r\n- The \"realistic\" factor is based on or inspired by manufacturing recipes from real-life counterparts (if a reference is available), or is the direct product from the imagination of yours truly ;p" },

            { "Scroll View/Viewport/NewGameOptions/3. Faithful/TitleContainer/ModeTitle", "Faithful Recipes (W.I.P)" },
            { "Scroll View/Viewport/NewGameOptions/3. Faithful/ModeDescription", "This gamemode is currently under development and might be available sometime in a futur update.\r\nFollow Realistic Recipes Mod's progress on the Discord server 'Subnautica Modding' for more informations !"},

            { "Scroll View/Viewport/NewGameOptions/4. Extreme/TitleContainer/ModeTitle", "Extreme Realism (very much W.I.P)" },
            { "Scroll View/Viewport/NewGameOptions/4. Extreme/ModeDescription", "This gamemode is currently under development (way more than the other one) and might be available sometime in a futur update.\r\nFollow Realistic Recipes Mod's progress on the Discord server 'Subnautica Modding' for more informations !"}
        };

        [HarmonyPatch(nameof(uGUI_MainMenu.Start)), HarmonyPostfix]
        private static void Start_Postfix(uGUI_MainMenu __instance)
        {
            //wasLastDiffIndexSaved = false; // reset the unsaved index flag at the start of the game

            // instantiates and renames the gamemode selection UI panel
            Transform NewGame = __instance.transform.Find("Panel/MainMenu/RightSide/NewGame");
            GameObject rrmDifficulty = UnityEngine.Object.Instantiate(NewGame.gameObject, NewGame.parent);
            rrmDifficulty.name = "DifficultySelection";

            // instantiates, changes the index (button position on the UI) and renames the first gamemode button (Survival) from the gamemode selection UI panel
            Transform difficultyButtons = __instance.transform.Find("Panel/MainMenu/RightSide/DifficultySelection/Scroll View/Viewport/NewGameOptions");
            GameObject rrmVanillaButton = UnityEngine.Object.Instantiate(difficultyButtons.Find("1. Survival").gameObject, difficultyButtons);
            rrmVanillaButton.transform.SetSiblingIndex(0);
            rrmVanillaButton.name = "0. Vanilla";

            // renames button containers of the 'DifficultySelection' panel
            GameObject rrmCRButton = difficultyButtons.transform.Find("1. Survival").gameObject;
            rrmCRButton.name = "1. Complex";

            GameObject rrmRRButton = difficultyButtons.transform.Find("2. Freedom").gameObject;
            rrmRRButton.name = "2. Realistic";

            GameObject rrmFRButton = difficultyButtons.transform.Find("3. Hardcore").gameObject;
            rrmFRButton.name = "3. Faithful";

            GameObject rrmXRButton = difficultyButtons.transform.Find("4. Creative").gameObject;
            rrmXRButton.name = "4. Extreme";
            
            // pass dictionary keys to the corresponding modded buttons in the 'DifficultySelection' panel
            foreach (var kvp in buttonTexts)
            {
                var text = rrmDifficulty.transform.Find(kvp.Key).GetComponent<TextMeshProUGUI>();
                text.text = kvp.Value;
            }

            // instantiates the sliding animation the original UI panel has
            var rrmRightSide = __instance.GetComponentInChildren<MainMenuRightSide>();

            // checks if modded UI panel is already part of the animation group and, if not, adds the panel to it
            if (!rrmRightSide.groups.Contains(rrmDifficulty.GetComponent<MainMenuGroup>()))
            {
                rrmRightSide.groups.Add(rrmDifficulty.GetComponent<MainMenuGroup>());
                Plugin.Logger.LogWarning("Modded GUI panel 'DifficultySelection' has been created.");
            }

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

                // listener that temporarily removes the method that launch the game after clicking on a gamemode button
                button.onClick.m_PersistentCalls.Clear();
                button.onClick.AddListener(() =>
                {

                    // removes the number and space from the gamemodes name (i.e., "1 Survival" will become "Survival")
                    GameMode gameMode = (GameMode)Enum.Parse(typeof(GameMode), gameModeIndex.Split(' ')[1]);

                    // This sets your difficulty number depending on how far down the hierarchy the button is. 0 = the top (Vanilla Recipes) and 4 = the bottom (Hardcore Realism)
                    difficultyIndex = button.transform.GetSiblingIndex();
                    Plugin.Logger.LogWarning($"Selected difficulty: {difficultyIndex}");

                    // finally launch the game after clicking on a Difficulty button
                    CoroutineHost.StartCoroutine(__instance.StartNewGame(gameMode));

                    //SaveFileManager.LoadModdedFiles(difficultyIndex); // this is now done in the SaveFileManager class, so that it can be called from the SaveDataHandler
                });
            }
        }
    }
}