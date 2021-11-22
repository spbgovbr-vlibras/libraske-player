public class PauseSystem : PauseSystemSubject
{
    private bool _isPaused;

    public void SetPause(bool pause)
    {
        _isPaused = pause;
        NotifyObservers(_isPaused);
    }

    public void TriggerPause()
    {
        _isPaused = !_isPaused;
        NotifyObservers(_isPaused);
    }
}