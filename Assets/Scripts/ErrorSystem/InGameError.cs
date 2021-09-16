[System.Serializable]
public struct InGameError
{
    [UnityEngine.SerializeField] private int _code;
    [UnityEngine.SerializeField] private string _msg;

    public InGameError(string msg, int code = -1)
    {
        _code = code;
        _msg = msg;
    }

    public readonly bool HasCode() => _code != -1;
    public readonly int Code { get => _code; }
    public readonly string Message { get => _msg; }
}
