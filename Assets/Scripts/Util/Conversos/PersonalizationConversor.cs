using Lavid.Libraske.DataStruct;
using Lavid.Libraske.Json;
using UnityEngine.Networking;

public static class PersonalizationConversor
{
    private const string CastColorErrorMessage = "Failed to cast personalization colors to Wrapper";
    private const string CastGroupErrorMessage = "Failed to cast personalization group to Wrapper";

    public static Wrapper<PersonalizationColor> FromRequestToColorWrapper(UnityWebRequest request)
    {
        Wrapper<PersonalizationColor> colors;

        try
        {
            colors = FromStringToColorWrapper(request.downloadHandler.text);
        }
        catch
        {
            throw new System.Exception(CastColorErrorMessage);
        }

        return colors;
    }
    public static Wrapper<PersonalizationColor> FromStringToColorWrapper(string data) => JsonArray.FromJson<PersonalizationColor>(data);

    public static Wrapper<PersonalizationGroup> FromRequestToGroupWrapper(UnityWebRequest request)
    {
        Wrapper<PersonalizationGroup> groups;

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
    public static Wrapper<PersonalizationGroup> FromStringToGroupWrapper(string data) => JsonArray.FromJson<PersonalizationGroup>(data);
}