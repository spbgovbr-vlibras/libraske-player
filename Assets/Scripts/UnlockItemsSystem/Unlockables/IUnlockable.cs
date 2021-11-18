using Lavid.Libraske.UnlockSystem;

public interface IUnlockable
{
    bool IsUnlocked { get; }
    int Price { get; }
    UnlockController Controller {get;}
    int Id { get; }

    void Lock();
    void Unlock();
    void RefreshStatus();
}