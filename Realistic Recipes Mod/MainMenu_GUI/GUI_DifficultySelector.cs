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

namespace RRM.MainMenu_GUI
{
    [HarmonyPatch(typeof(uGUI_MainMenu))]
    internal class GUI_DifficultyPanel
    {
        private static Dictionary<string, string>
        buttonTexts = new()
        {
            { "Header", "Difficulty" },

            { "Scroll View/Viewport/NewGameOptions/1. Survival/TitleContainer/ModeTitle", "Complex Recipes" },
            { "Scroll View/Viewport/NewGameOptions/1. Survival/ModeDescription", "test ballz haha" },

            { "Scroll View/Viewport/NewGameOptions/2. Freedom/TitleContainer/ModeTitle", "Realistic Recipes" },
            { "Scroll View/Viewport/NewGameOptions/2. Freedom/ModeDescription", "test ballz haha" },

            { "Scroll View/Viewport/NewGameOptions/3. Hardcore/TitleContainer/ModeTitle", "Faithful Recipes (W.I.P)" },
            { "Scroll View/Viewport/NewGameOptions/3. Hardcore/ModeDescription", "This gamemode is currently under development and might be available sometime in a futur update." +
                " "},

            { "Scroll View/Viewport/NewGameOptions/4. Creative/TitleContainer/ModeTitle", "Extreme Realism (W.I.P)" },
            { "Scroll View/Viewport/NewGameOptions/4. Creative/ModeDescription", "test ballz haha" },
        };

        public static string lastGameModeName;
        public static int gameModeIndex;
        

        [HarmonyPatch(nameof(uGUI_MainMenu.Start)), HarmonyPostfix]
        private static void Start_Postfix(uGUI_MainMenu __instance)
        {
            Transform NewGame = __instance.transform.Find("Panel/MainMenu/RightSide/NewGame");
            GameObject rrmNewGame = GameObject.Instantiate(NewGame.gameObject, NewGame.parent);
            rrmNewGame.name = "DifficultySelection";
            
            var rrmRightSide = __instance.GetComponentInChildren<MainMenuRightSide>();

            if (rrmRightSide.groups.Contains(rrmNewGame.GetComponent<MainMenuGroup>()) == false)
            {
                rrmRightSide.groups.Add(rrmNewGame.GetComponent<MainMenuGroup>());
                Plugin.Logger.LogWarning("Modded GUI panel 'DifficultySelection' has been created.");

                foreach (var kvp in buttonTexts)
                {
                    var text = rrmNewGame.transform.Find(kvp.Key).GetComponent<TextMeshProUGUI>();
                    text.text = kvp.Value;
                } 

                foreach (var button in NewGame.GetComponentsInChildren<Button>(true))
                {
                    Button rrmNButton = NewGame.GetComponent<Button>();
                    button.onClick.m_PersistentCalls.Clear();
                    button.onClick.AddListener(() =>
                    {
                        lastGameModeName = button.gameObject.name;
                        rrmRightSide.OpenGroup("DifficultySelection");
                    });
                }

                foreach (var button in rrmNewGame.GetComponentsInChildren<Button>(true))
                {
                    button.onClick.m_PersistentCalls.Clear();
                    button.onClick.AddListener(() =>
                    {
                        GameObject.Destroy(button.transform.Find("Scroll View/Viewport/NewGameOptions/1. Survival/TitleContainer/ModeIcons").gameObjecty));

                        //Remove the number and space from the name
                        GameMode gameMode = (GameMode)Enum.Parse(typeof(GameMode), lastGameModeName.Split(' ')[1]);
                        Plugin.Logger.LogMessage("Gamemode name : " + lastGameModeName);

                        //This sets your game mode number depending on how far down the hierarchy the button is. 0 = the top (Survival) and 3 = the bottom (Creative)
                        gameModeIndex = button.transform.GetSiblingIndex();
                        Plugin.Logger.LogMessage("Chosen gamemode : " + gameModeIndex);
                        CoroutineHost.StartCoroutine(__instance.StartNewGame(gameMode));
                    });
                }
            }
        }
    }
}