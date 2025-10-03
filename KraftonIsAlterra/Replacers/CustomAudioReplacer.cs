using Nautilus.FMod;
using Nautilus.Utility;

namespace KraftonIsAlterra.Replacers
{
    public static class CustomAudioReplacer
    {
        public static void ReplaceAudio(string eventId, string audioFileName, string folderPath, string busPath)
        {
            var soundBuilder = new FModSoundBuilder(new ModFolderSoundSource(folderPath));
            soundBuilder.CreateNewEvent(eventId, busPath)
                .SetSound(audioFileName)
                .SetMode(AudioUtils.StandardSoundModes_2D)
                .Register();
            Plugin.Logger.LogInfo($"New sound event created: {audioFileName} (ID: {eventId})");
        }
    }
}
