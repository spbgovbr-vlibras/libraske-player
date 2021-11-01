public static class ErrorList 
{
    #region Constructor
    private const int InitialIndex = 800;
    private static int CurrentIndex = -1;
    private static InGameError NewError(string msg)
    {
        CurrentIndex++;
        return new InGameError(msg, InitialIndex + CurrentIndex);
    }
    #endregion

    #region Local Errors
    public static readonly InGameError DefaultError = NewError("Houve um problema no carregamento do jogo.");
    public static readonly InGameError CastMusicListError = NewError("Houve um problema ao tratar as músicas.");
    #endregion

    #region Donwload Errors
    public static readonly InGameError DownloadMusicListError = NewError("Houve um problema ao baixar as músicas.");
    public static readonly InGameError DownloadSubtitleError = NewError("Houve um problema ao baixar as legendas.");
    public static readonly InGameError DownloadMusicError = NewError("Houve um problema ao baixar a música.");
    public static readonly InGameError DownloadBundleError = NewError("Houve um problema ao baixar as animações.");
    #endregion
}