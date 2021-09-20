namespace Lavid.Libraske.SaveSystem
{
    internal struct SaveFields
    {
        // General
        public static string HasSavedAudioSettings { get => "HasSavedAudioSettings"; }
        public static string HasSavedSubtitleSettings { get => "HasSavedSubtitleSettings"; }

        // Subtitles
        public static string ShowSubtitles { get => "ShowSubtitles"; }
        public static string SubtitlesSize { get => "SubtitleSize"; }
        public static string SubtitlesColor { get => "SubtitlesColor"; }

        // Audio
        public static string MainVolume { get => "MainVolume"; }
        public static string SFXVolume { get => "SFXVolume"; }
        public static string MusicMute { get => "MusicMute"; }
        public static string SFXMute { get => "SFXMute"; }
    }
}