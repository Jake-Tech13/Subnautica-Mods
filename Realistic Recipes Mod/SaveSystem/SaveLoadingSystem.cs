using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using RRM.LoggerLines;
using RRM.MainMenu_GUI;

namespace RRM.SaveSystem
{
    internal class SaveLoadingSystem
    {
        public static void LoadingSystem()
        {
            // [not fully implemented yet]
            // if selected gamemode value ('gm') equals 'gamemode' value, ignores the rest of the statement and executes only its code...
            if (GUI_DifficultyPanel.gameModeIndex == 0)
            {
                Plugin.Logger.LogInfo(LogInfo_Lines.info_CR);

                ComplexRecipes.ComplexRecipesTable.RegisterAllRecipes();
                Plugin.Logger.LogMessage(LogMessage_Lines.message_CR_1);
            }

            // ..else, checks all of the following conditions until the values matches...
            else if (GUI_DifficultyPanel.gameModeIndex == 1)
            {
                Plugin.Logger.LogInfo(LogInfo_Lines.info_RR);

                RealisticRecipes.RealisticRecipesTable.RegisterAllRecipes();
                Plugin.Logger.LogMessage(LogMessage_Lines.message_RR_1);
            }

            else if (GUI_DifficultyPanel.gameModeIndex == 2)
            {
                Plugin.Logger.LogInfo(LogInfo_Lines.info_FR);

                FaithfulRecipes.FaithfulRecipesTable.RegisterAllRecipes();
                Plugin.Logger.LogMessage(LogMessage_Lines.message_FR_1);
                FaithfulRecipes.FaithfulResourcesTable.RegisterAllResources();
                Plugin.Logger.LogMessage(LogMessage_Lines.message_FR_2);
                FaithfulRecipes.FaithfulMaterialsTable.RegisterAllMaterials();
                Plugin.Logger.LogMessage(LogMessage_Lines.message_FR_3);
                FaithfulRecipes.FaithfulToolsTable.RegisterAllTools();
                Plugin.Logger.LogMessage(LogMessage_Lines.message_FR_4);
                FaithfulRecipes.FaithfulEquipmentsTable.RegisterAllEquipments();
                Plugin.Logger.LogMessage(LogMessage_Lines.message_FR_5);
            }

            else if (GUI_DifficultyPanel.gameModeIndex == 3)
            {
                Plugin.Logger.LogInfo(LogInfo_Lines.info_XR);

                XtremeRLRecipes.XtremeRLRecipesTable.RegisterAllRecipes();
                Plugin.Logger.LogMessage(LogMessage_Lines.message_XR_1);
                XtremeRLRecipes.XtremeRLResourcesTable.RegisterAllResources();
                Plugin.Logger.LogMessage(LogMessage_Lines.message_XR_2);
                XtremeRLRecipes.XtremeRLMaterialsTable.RegisterAllMaterials();
                Plugin.Logger.LogMessage(LogMessage_Lines.message_XR_3);
                XtremeRLRecipes.XtremeRLToolsTable.RegisterAllTools();
                Plugin.Logger.LogMessage(LogMessage_Lines.message_XR_4);
                XtremeRLRecipes.XtremeRLEquipmentsTable.RegisterAllEquipments();
                Plugin.Logger.LogMessage(LogMessage_Lines.message_XR_5);
            }

            else if (GUI_DifficultyPanel.gameModeIndex == 4)
            {
                Plugin.Logger.LogWarning(LogWarning_Lines.warning_Vanilla);
            }

            //..and if the values never matches, prints an error in logs
            else
            {
                Plugin.Logger.LogError(LogError_Lines.error_GM);
            }
        }
        public static void SaveSystem()
        {

        }
    }
}
