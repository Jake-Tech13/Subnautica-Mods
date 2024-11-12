using Nautilus.Json;

using RRM.LoggerLines;
using RRM.VanillaRecipes;
using RRM.ComplexRecipes;
using RRM.RealisticRecipes;
using RRM.FaithfulRecipes;
using RRM.XtremeRLRecipes;
using RRM.UI_files;
using Nautilus.Handlers;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using static CraftData;
using System.Reflection;
using System.IO;


namespace RRM.SaveFileManager
{
    public class SaveData : SaveDataCache
    {
        public int Difficulty { get; set; }
    }

    public class SFM
    {
        // this method allows the caller to choose between 5 cases among which components specific to the difficulty will be registered
        public static void LoadModdedFiles(int index)
        {
            switch (index)
            {
                case 0:
                    if (uGUI_DifficultyPanel.StartNewGameCalled)//ajouter un listener au bouton Vanilla qui vérifie s'il a été cliqué ou non afin de décider si les recettes vanilla doivent être chargées après une autre difficulté
                    {
                        Plugin.Logger.LogWarning("'StartNewGame()' method was called.");
                        break;
                    }
                    else
                    {
                        Plugin.Logger.LogWarning(LogWarning_Lines.warning_Vanilla);

                        VanillaRecipesTable.RegisterAll();
                    }
                break;

                case 1:
                    Plugin.Logger.LogInfo(LogInfo_Lines.info_CR);

                    ComplexRecipesTable.RegisterAll();
                    Plugin.Logger.LogMessage(LogMessage_Lines.message_CR_1);
                break;

                case 2:
                    Plugin.Logger.LogInfo(LogInfo_Lines.info_RR);

                    RealisticRecipesTable.RegisterAll();
                    Plugin.Logger.LogMessage(LogMessage_Lines.message_RR_1);
                break;

                case 99:
                    Plugin.Logger.LogInfo(LogInfo_Lines.info_FR);

                    FaithfulRecipesTable.RegisterAll();
                    Plugin.Logger.LogMessage(LogMessage_Lines.message_FR_1);
                    FaithfulResourcesTable.RegisterAll();
                    Plugin.Logger.LogMessage(LogMessage_Lines.message_FR_2);
                    FaithfulMaterialsTable.RegisterAll();
                    Plugin.Logger.LogMessage(LogMessage_Lines.message_FR_3);
                    FaithfulToolsTable.RegisterAll();
                    Plugin.Logger.LogMessage(LogMessage_Lines.message_FR_4);
                    FaithfulEquipmentsTable.RegisterAll();
                    Plugin.Logger.LogMessage(LogMessage_Lines.message_FR_5);
                break;

                case 999:
                    Plugin.Logger.LogInfo(LogInfo_Lines.info_XR);

                    XtremeRLRecipesTable.RegisterAll();
                    Plugin.Logger.LogMessage(LogMessage_Lines.message_XR_1);
                    XtremeRLResourcesTable.RegisterAll();
                    Plugin.Logger.LogMessage(LogMessage_Lines.message_XR_2);
                    XtremeRLMaterialsTable.RegisterAll();
                    Plugin.Logger.LogMessage(LogMessage_Lines.message_XR_3);
                    XtremeRLToolsTable.RegisterAll();
                    Plugin.Logger.LogMessage(LogMessage_Lines.message_XR_4);
                    XtremeRLEquipmentsTable.RegisterAll();
                    Plugin.Logger.LogMessage(LogMessage_Lines.message_XR_5);
                break;
            }
        }
    }
}