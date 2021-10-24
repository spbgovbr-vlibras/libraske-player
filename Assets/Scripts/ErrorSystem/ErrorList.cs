public static class ErrorList 
{
    private const int InitialRange = 800;

    public static readonly InGameError DefaultError = new InGameError("Houve um problema no carregamento do jogo.", InitialRange + 0);
    public static readonly InGameError CastError = new InGameError("Houve um problema ao adquirir as músicas.", InitialRange + 1);
    public static readonly InGameError SubtitleDownloadError = new InGameError("Houve um problema ao baixar as legendas.", InitialRange + 2);
    public static readonly InGameError MusicDownloadError = new InGameError("Houve um problema ao baixar a música.", InitialRange + 3);
    public static readonly InGameError BundleDownloadError = new InGameError("Houve um problema ao baixar as animações.", InitialRange + 3);
}