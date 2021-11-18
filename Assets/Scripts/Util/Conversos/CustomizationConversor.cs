using Lavid.Libraske.DataStruct;
using Lavid.Libraske.Json;
using UnityEngine.Networking;

public static class CustomizationConversor
{
    private const string CastColorErrorMessage = "Failed to cast personalization colors to Wrapper";
    private const string CastGroupErrorMessage = "Failed to cast personalization group to Wrapper";

    public static Wrapper<CustomizationColor> FromRequestToColorWrapper(UnityWebRequest request)
    {
        Wrapper<CustomizationColor> colors;

        try
        {
            colors = FromStringToColorWrapper(request.downloadHandler.text);
        }
        catch
        {
            UnityEngine.Debug.LogError(CastColorErrorMessage);
            throw new System.Exception(CastColorErrorMessage);
        }

        return colors;
    }
    public static Wrapper<CustomizationColor> FromStringToColorWrapper(string data) => JsonArray.FromJson<CustomizationColor>(data);

    public static Wrapper<CustomizationGroup> FromRequestToGroupWrapper(UnityWebRequest request)
    {
        Wrapper<CustomizationGroup> groups;

        try
        {
            groups = FromStringToGroupWrapper(request.downloadHandler.text);
        }
        catch
        {
            throw new System.Exception(CastGroupErrorMessage);
        }

        return groups;
    }
    public static Wrapper<CustomizationGroup> FromStringToGroupWrapper(string data) => JsonArray.FromJson<CustomizationGroup>(data);
}