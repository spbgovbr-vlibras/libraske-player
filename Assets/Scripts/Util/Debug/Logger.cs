using UnityEngine;

public static class Logger
{
    private static string ApplyColor(string color, string msg) => $"<color={color}>{msg}</color>";

    private static Color SuccessColor = new Color(0.2f, 1f, 0.2f);// Color.green;
    private static Color ErrorColor = Color.red;

    public static void Log(ILoggable loggable, string msg) => Debug.Log($"[{loggable.InLogName}]: {msg}");
    public static void Log(ILoggable loggable, object msg) => Log(loggable, msg.ToString());

    public static void LogWithColor(ILoggable loggable, string msg, Color color)
    {
        string richText = $"[{loggable.InLogName}]: {msg}";
        string hexaColor = $"#{ColorUtility.ToHtmlStringRGB(color)}";
        richText = ApplyColor(hexaColor, richText);
        Debug.Log(richText);
    }

    public static void LogSuccess(ILoggable loggable, object msg) => LogSuccess(loggable, msg.ToString());
    public static void LogSuccess(ILoggable loggable, string msg) => LogWithColor(loggable, msg, SuccessColor);

    public static void LogError(ILoggable loggable, object msg) => LogSuccess(loggable, msg.ToString());
    public static void LogError(ILoggable loggable, string msg) => LogWithColor(loggable, msg, ErrorColor);
}

public interface ILoggable
{
    string InLogName { get; }
}