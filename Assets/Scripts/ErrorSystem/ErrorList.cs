public static class ErrorList 
{
    public static readonly InGameError DefaultError = new InGameError("Houve um problema no carregamento do jogo", -01);
    public static readonly InGameError CastError = new InGameError("Houve um problema no cast de variáveis", -02);
    public static readonly InGameError SubtitleDownloadError = new InGameError("Houve um problema ao baixar as legendas", -03);
    public static readonly InGameError MusicDownloadError = new InGameError("Houve um problema ao baixar a música", -04);
}
