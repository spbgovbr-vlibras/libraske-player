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
    public static readonly InGameError CastPersonalizationColorError = NewError("Houve um problema ao adquirir as cores.");
    public static readonly InGameError CastPersonalizationGroupError = NewError("Houve um problema ao adquirir os grupos de cores.");
    public static readonly InGameError SelectColorError = NewError("Houve um problema ao selecionar cor.");
    public static readonly InGameError WebcamAuthError = NewError("Sem permissão para acessar a webcam");
    #endregion

    #region Download Errors
    public static readonly InGameError DownloadMusicListError = NewError("Houve um problema ao baixar as músicas.");
    public static readonly InGameError DownloadSubtitleError = NewError("Houve um problema ao baixar as legendas.");
    public static readonly InGameError DownloadMusicError = NewError("Houve um problema ao baixar a música.");
    public static readonly InGameError DownloadBundleError = NewError("Houve um problema ao baixar as animações.");
    public static readonly InGameError DownloadPersonalizationColorsError = NewError("Houve um problema ao baixar as paletas de cores.");
    public static readonly InGameError DownloadPersonalizationGroupsError = NewError("Houve um problema ao baixar os grupos de cores.");
    #endregion

    #region Buy Errors
    public static readonly InGameError UnlockColorSetError = NewError("Houve um problema ao comprar paleta de cor.");
    public static readonly InGameError OutOfCreditsError = NewError("Não há créditos suficientes para a compra.");
    #endregion
}