using HarmonyLib;

namespace KraftonIsAlterra.Patches
{
    [HarmonyPatch(typeof(Language), nameof(Language.SetCurrentLanguage))]
    internal static class SetCurrentLanguagePatch
    {
        private static string lastLanguage;
        private static string currentLanguage;

        [HarmonyPostfix]
        internal static void AfterSetCurrentLanguage()
        {
            currentLanguage = Language.main.currentLanguage;
            if (lastLanguage == currentLanguage)
            {
                Plugin.Logger.LogInfo($"Language remains the same ({lastLanguage}), skipping re-initialization.");
                return;
            }
            else if (lastLanguage == null)
            {
                Plugin.Logger.LogMessage($"Initialization of the user's game language: {currentLanguage}.");
            }
            else
            {
                Plugin.Logger.LogMessage($"Language changed from '{lastLanguage}' to '{currentLanguage}', re-initializing localization.");
            }
            lastLanguage = currentLanguage;
            Plugin.InitializeLocalization();
        }
    }
}
