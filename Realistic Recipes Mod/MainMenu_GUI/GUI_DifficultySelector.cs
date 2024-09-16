using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UWE;
using RRM;
using static RRM.SaveFileManager.SFM;

namespace RRM.MainMenu_GUI
{
    [HarmonyPatch(typeof(uGUI_MainMenu))]
    internal class GUI_DifficultyPanel
    {


        private static readonly Dictionary<string, string>
        buttonTexts = new()
        {
            { "Header", "Difficulty" },

            { "Scroll View/Viewport/NewGameOptions/0. Vanilla/TitleContainer/ModeTitle", "Vanilla Recipes" },
            { "Scroll View/Viewport/NewGameOptions/0. Vanilla/ModeDescription", "Starts the game with all the original crafting recipes, in case you changed your mind." },

            { "Scroll View/Viewport/NewGameOptions/1. Survival/TitleContainer/ModeTitle", "Complex Recipes" },
            { "Scroll View/Viewport/NewGameOptions/1. Survival/ModeDescription", "For players who want to add a little extra difficulty to their game.\r\n- This game mode makes vanilla recipes a little more demanding by increasing the quantity and diversity of the ingredients needed to craft them, or even by completely changing certain recipes for the sake of realism." },

            { "Scroll View/Viewport/NewGameOptions/2. Freedom/TitleContainer/ModeTitle", "Realistic Recipes" },
            { "Scroll View/Viewport/NewGameOptions/2. Freedom/ModeDescription", "For those who wish to experiment with a more tactical approach to the trade-off between resource gathering and the time spent on an objective. /!\\Not recommended for beginners or as a first playthrough/!\\ \r\n- The \"realistic\" factor is based on or inspired by manufacturing recipes from real-life counterparts (if a reference is available), or is the direct product from the imagination of yours truly ;P" },

            { "Scroll View/Viewport/NewGameOptions/3. Hardcore/TitleContainer/ModeTitle", "Faithful Recipes (W.I.P)" },
            { "Scroll View/Viewport/NewGameOptions/3. Hardcore/ModeDescription", "This gamemode is currently under development and might be available sometime in a futur update.\nFollow Realistic Recipes Mod's progress on the Discord server 'Subnautica Modding' for more informations !"},

            { "Scroll View/Viewport/NewGameOptions/4. Creative/TitleContainer/ModeTitle", "Extreme Realism (W.I.P++)" },
            { "Scroll View/Viewport/NewGameOptions/4. Creative/ModeDescription", "This gamemode is currently under development and might be available sometime in a futur update.\nFollow Realistic Recipes Mod's progress on the Discord server 'Subnautica Modding' for more informations !"}
        };

        public static int difficultyIndex;
        private static string gameModeIndex;

        [HarmonyPatch(nameof(uGUI_MainMenu.Start)), HarmonyPostfix]
        private static void Start_Postfix(uGUI_MainMenu __instance)
        {
            Transform NewGame = __instance.transform.Find("Panel/MainMenu/RightSide/NewGame");
            GameObject rrmDifficulty = GameObject.Instantiate(NewGame.gameObject, NewGame.parent);
            rrmDifficulty.name = "DifficultySelection";

            Transform difficultyButtons = __instance.transform.Find("Panel/MainMenu/RightSide/DifficultySelection/Scroll View/Viewport/NewGameOptions");
            GameObject rrmVanillaButton = GameObject.Instantiate(difficultyButtons.Find("1. Survival").gameObject, difficultyButtons);
            rrmVanillaButton.transform.SetSiblingIndex(0);
            rrmVanillaButton.name = "0. Vanilla";

            //GameObject rrmCRButton = GameObject.Instantiate(difficultyButtons.Find("1. Survival").gameObject, difficultyButtons);
            //rrmCRButton.name = "1. Complex";

            var rrmRightSide = __instance.GetComponentInChildren<MainMenuRightSide>();

            if (rrmRightSide.groups.Contains(rrmDifficulty.GetComponent<MainMenuGroup>()) == false)
            {
                rrmRightSide.groups.Add(rrmDifficulty.GetComponent<MainMenuGroup>());
                Plugin.Logger.LogWarning("Modded GUI panel 'DifficultySelection' has been created.");
            }

            foreach (var kvp in buttonTexts)
            {
                var text = rrmDifficulty.transform.Find(kvp.Key).GetComponent<TextMeshProUGUI>();
                text.text = kvp.Value;
            } 

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
                if (!button.transform.Find("TitleContainer"))
                {
                    continue;
                }

                GameObject.Destroy(button.transform.Find("TitleContainer/ModeIcons").gameObject);

                button.onClick.m_PersistentCalls.Clear();
                button.onClick.AddListener(() =>
                {
                    //Remove the number and space from the name
                    GameMode gameMode = (GameMode)Enum.Parse(typeof(GameMode), gameModeIndex.Split(' ')[1]); //Remove the number and space from the name
                    Plugin.Logger.LogWarning("Selected game mode: " + gameModeIndex);

                    //This sets your difficulty number depending on how far down the hierarchy the button is. 0 = the top (CR) and 3 = the bottom (XR)
                    difficultyIndex = button.transform.GetSiblingIndex();
                    Plugin.Logger.LogWarning("Selected difficulty: " + difficultyIndex);

                    CoroutineHost.StartCoroutine(__instance.StartNewGame(gameMode));

                    LoadModdedFiles();
                });
            }
        }
    }
}