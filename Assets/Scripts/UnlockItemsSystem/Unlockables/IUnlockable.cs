public interface IUnlockable
{
    bool IsUnlocked { get; }
    int Price { get; }

    void Lock();
    void Unlock();
    void RefreshStatus();
}