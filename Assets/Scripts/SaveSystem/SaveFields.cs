namespace Lavid.Libraske.SaveSystem
{
    internal struct SaveFields
    {
        // General
        public static string HasSavedAudioSettings { get => "HasSavedAudioSettings"; }
        public static string HasSavedSubtitleSettings { get => "HasSavedSubtitleSettings"; }
        public static string HasSavedAvatarSelection { get => "HasSavedAvatarSelection"; }

        // Subtitles
        public static string ShowSubtitles { get => "ShowSubtitles"; }
        public static string SubtitlesSize { get => "SubtitleSize"; }
        public static string SubtitlesColor { get => "SubtitlesColor"; }

        // Audio
        public static string MainVolume { get => "MainVolume"; }
        public static string SFXVolume { get => "SFXVolume"; }
        public static string MainMute { get => "MusicMute"; }
        public static string SFXMute { get => "SFXMute"; }

        // Customization
        public static string AvatarChoosed { get => "AvatarChoosed"; }
        public static string Icaro { get => "Icaro"; }
        public static string Hozana { get => "Hozana"; }
        public static string Guga { get => "Guga"; }
    }
}