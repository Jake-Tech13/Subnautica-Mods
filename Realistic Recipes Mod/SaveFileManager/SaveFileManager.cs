using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics.Eventing.Reader;
using Nautilus.Json;

using RRM.LoggerLines;
using RRM.MainMenu_GUI;
using RRM.ComplexRecipes;
using RRM.RealisticRecipes;
using RRM.FaithfulRecipes;
using RRM.XtremeRLRecipes;
using RRM;


namespace RRM.SaveFileManager
{
    internal class SFM
    {
        public static void LoadModdedFiles()
        {
            // [not fully implemented yet]
            // if selected gamemode value 'difficultyIndex' returns 'x' OR if ###, loads corresponding components
            if (GUI_DifficultyPanel.difficultyIndex == 0)
            {
                Plugin.Logger.LogInfo(LogInfo_Lines.info_CR);

                ComplexRecipesTable.RegisterAllRecipes();
                Plugin.Logger.LogMessage(LogMessage_Lines.message_CR_1);
            }
            else if (GUI_DifficultyPanel.difficultyIndex == 1)
            {
                Plugin.Logger.LogInfo(LogInfo_Lines.info_RR);

                RealisticRecipesTable.RegisterAllRecipes();
                Plugin.Logger.LogMessage(LogMessage_Lines.message_RR_1);
            }

            else if (GUI_DifficultyPanel.difficultyIndex == 2)
            {
                Plugin.Logger.LogInfo(LogInfo_Lines.info_FR);

                FaithfulRecipesTable.RegisterAllRecipes();
                Plugin.Logger.LogMessage(LogMessage_Lines.message_FR_1);
                FaithfulResourcesTable.RegisterAllResources();
                Plugin.Logger.LogMessage(LogMessage_Lines.message_FR_2);
                FaithfulMaterialsTable.RegisterAllMaterials();
                Plugin.Logger.LogMessage(LogMessage_Lines.message_FR_3);
                FaithfulToolsTable.RegisterAllTools();
                Plugin.Logger.LogMessage(LogMessage_Lines.message_FR_4);
                FaithfulEquipmentsTable.RegisterAllEquipments();
                Plugin.Logger.LogMessage(LogMessage_Lines.message_FR_5);
            }

            else if (GUI_DifficultyPanel.difficultyIndex == 3)
            {
                Plugin.Logger.LogInfo(LogInfo_Lines.info_XR);

                XtremeRLRecipesTable.RegisterAllRecipes();
                Plugin.Logger.LogMessage(LogMessage_Lines.message_XR_1);
                XtremeRLResourcesTable.RegisterAllResources();
                Plugin.Logger.LogMessage(LogMessage_Lines.message_XR_2);
                XtremeRLMaterialsTable.RegisterAllMaterials();
                Plugin.Logger.LogMessage(LogMessage_Lines.message_XR_3);
                XtremeRLToolsTable.RegisterAllTools();
                Plugin.Logger.LogMessage(LogMessage_Lines.message_XR_4);
                XtremeRLEquipmentsTable.RegisterAllEquipments();
                Plugin.Logger.LogMessage(LogMessage_Lines.message_XR_5);
            }

            else if (GUI_DifficultyPanel.difficultyIndex == 4)
            {
                Plugin.Logger.LogWarning(LogWarning_Lines.warning_Vanilla);
            }

            else
            {
                Plugin.Logger.LogError(LogError_Lines.error_GM);
            }
        }

        public class SavingSystem : SaveDataCache
        {
            public string DifficultyName { get; set; }
        }
    }
}