using Lavid.Libraske.UnlockSystem;

public interface IUnlockable
{
    bool IsUnlocked { get; }
    int Price { get; }
    UnlockController Controller {get;}

    void Lock();
    void Unlock();
    void RefreshStatus();
}