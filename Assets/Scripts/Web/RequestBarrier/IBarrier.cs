using System;

public interface IBarrier
{
    public bool IsUnlocked { get; }
    public event Action OnUnlockBarrier;
    public bool ShouldUnlock();
    public void TryUnlock();
}