using HarmonyLib;
using Nautilus.Utility;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using KraftonIsAlterra.Replacers;

namespace KraftonIsAlterra.Patches
{
    [HarmonyPatch(typeof(PDALog), nameof(PDALog.Initialize))]
    internal static class PDALogPatch
    {
        internal static readonly string PDABusPath = AudioUtils.BusPaths.PDAVoice;

        [HarmonyPostfix]
        internal static void ReplaceMapping()
        {
            // create new FMODAssets
            FMODAsset newGoalBiomeMushroomForestAsset = new()
            {
                path = "event:/player/story/Goal_BiomeMushroomForest",
                id = "Goal_BiomeMushroomForest-Krafton-Override" //"a1b2c3d4-5e6f-7a8b-9c10-111213141516"
            };
            FMODAsset newGoalDiamondAsset = new()
            {
                path = "event:/player/story/Goal_Diamond",
                id = "Goal_Diamond-Krafton-Override" //"b1c2d3e4-5f6a-7b8c-9d10-111213141516"
            };

            // register the new PDA voice lines
            var PDAvoicelineIds = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("BepInEx/plugins/KraftonIsAlterra/datafiles/PDA_voiceline_ids.json"));

            foreach (var kvp in PDAvoicelineIds)
            {
                CustomAudioReplacer.ReplaceAudio(kvp.Key, kvp.Value, "audio", PDABusPath);
            }
            Plugin.Logger.LogDebug("All PDA voicelines have been successfuly replaced.");

            // replace some voiceline keys and FMODAssets in 'PDALog.mapping' dictionary
            ReplaceMappingValue("Goal_BiomeMushroomForest", newGoalBiomeMushroomForestAsset);
            ReplaceMappingValue("Goal_Diamond", newGoalDiamondAsset);
        }

        internal static void ReplaceMappingValue(string key, FMODAsset asset)
        {
            if (PDALog.mapping.TryGetValue(key, out PDALog.EntryData value))
            {
                value.key = key;
                value.sound = asset;
                PDALog.mapping[key] = value;

                Plugin.Logger.LogDebug($"Value '{value.key}' from key '{key}' has been successfuly edited.");
                return;
            }
            Plugin.Logger.LogError($"Cannot find key '{key}' in 'PDALog.mapping' dictionary.");
        }
    }
}
