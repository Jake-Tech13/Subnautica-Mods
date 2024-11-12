//using BepInEx;
//using BepInEx.Logging;
//using HarmonyLib;
//using System.Reflection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TMPro;
//using UnityEngine;
//using UnityEngine.UI;
//using UWE;
//using Nautilus.Json;
//using RRM;
//using RRM.SaveFileManager;
//using Sentry;

//namespace RRM.UI_files
//{
//    [HarmonyPatch(typeof(IngameMenu))]
//    internal class uGUI_SaveButton
//    {
//        public static int difficulty = uGUI_DifficultyPanel.difficultyIndex;

//        [HarmonyPatch(nameof(IngameMenu.SaveGame)), HarmonyPostfix]
//        private static void Start_Postfix(uGUI_SaveButton __instance)
//        {
//            GameObject pauseMenu = GameObject.Find("IngameMenu(Clone)/Main/ButtonLayout");
//            Plugin.Logger.LogWarning("'ButtonSave' location successfully found.");

//            Button saveButton = pauseMenu.transform.Find("ButtonSave").GetComponentInChildren<Button>();
//            if (saveButton != null)
//            {
//                Plugin.Logger.LogWarning("'ButtonSave' button successfully accessed.");
//            }
//            else
//            {
//                Plugin.Logger.LogWarning("Failed to access 'ButtonSave' button.");
//            }

//            saveButton.onClick.AddListener(() =>
//            {
//                Plugin.Logger.LogWarning("Listener successfully added to 'ButtonSave' button.");
//                Plugin.SaveData.Difficulty = uGUI_DifficultyPanel.difficultyIndex;
//                Plugin.Logger.LogWarning("Modded save file has been created. Chosen difficulty should be saved in file.\ndifficultyIndex = " + difficulty);
//            });    
//        }
//    }
//}