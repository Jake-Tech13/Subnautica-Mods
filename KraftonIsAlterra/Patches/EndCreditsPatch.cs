using FMOD;
using HarmonyLib;
using KraftonIsAlterra.Replacers;
using Nautilus.FMod;
using Nautilus.Handlers;
using Nautilus.Utility;
using UnityEngine;

namespace KraftonIsAlterra.Patches
{
    [HarmonyPatch(typeof(EndCreditsManager))]
    internal static class Patch_EndCreditsManager_Start
    {
        private static bool easterPlayed;
        private static EndCreditsManager.Phase? lastPhase = null;

        [HarmonyPostfix]
        [HarmonyPatch(nameof(EndCreditsManager.Start))]
        static void ReplaceEasterEggVO(EndCreditsManager __instance)
        {
            // set and reset flag (in case of multiple credits played in one session)
            easterPlayed = false;

            FModSoundBuilder builder = new(new ModFolderSoundSource("audio"));
            builder.CreateNewEvent("Story_EndingZinger-Krafton-Override", AudioUtils.BusPaths.PDAVoice)
                .SetSound("PDA_Ending")
                .SetMode(AudioUtils.StandardSoundModes_2D)
                .Register();

            __instance.easterEggVO.path = "Story_EndingZinger-Krafton-Override";
            __instance.easterEggVO.id = __instance.easterEggVO.path;

            Plugin.Logger.LogInfo($"easterEggVO has been replaced: {__instance.easterEggVO.path} | {__instance.easterEggVO.id}");
        }

        [HarmonyPostfix]
        [HarmonyPatch(nameof(EndCreditsManager.OnLateUpdate))]
        static void Patch_EndCreditsManager_OnLateUpdate(EndCreditsManager __instance)
        {
            if (lastPhase != __instance.phase)
            {
                Plugin.Logger.LogInfo($"Current phase: {__instance.phase}");
                lastPhase = __instance.phase;
            }

            if (!easterPlayed && __instance.phase == EndCreditsManager.Phase.Easter)
            {
                FMODUWE.PlayOneShot(__instance.easterEggVO, Player.main.lastPosition, 2f);
                Plugin.Logger.LogInfo($"easterEggVO played at {Player.main.lastPosition}");
                easterPlayed = true;
            }
        }
    }
}