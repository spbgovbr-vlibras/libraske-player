using UnityEngine;

public static class Logger
{
    public static void Log(ILoggable loggable, string msg) => Debug.Log($"[{loggable.InLogName}]: {msg}");
}

public interface ILoggable
{
    string InLogName { get; }
}