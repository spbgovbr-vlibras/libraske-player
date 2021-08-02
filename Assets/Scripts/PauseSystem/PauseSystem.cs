public class PauseSystem : PauseSystemSubject
{
    private bool _isPaused;

    public void TriggerPause()
    {
        _isPaused = !_isPaused;
        NotifyObservers(_isPaused);
    }
}