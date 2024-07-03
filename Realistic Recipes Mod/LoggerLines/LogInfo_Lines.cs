using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRM.LoggerLines
{
     public class LogInfo_Lines
    {
        public static string info_PluginGUID = $"Plugin {PluginInfo.PLUGIN_GUID} is loaded!";
        public static string info_CR = "'Complex Recipes' mode has been selected. The corresponding components are now loading...";
        public static string info_RR = "'Realistic Recipes' mode has been selected. The corresponding components are now loading...";
        public static string info_FR = "'Faithful Recipes' mode has been selected. The corresponding components are now loading...";
        public static string info_XR = "'Extreme Realism' mode has been selected. The corresponding components are now loading...";
    }
}
