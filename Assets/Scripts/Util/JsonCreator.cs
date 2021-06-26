namespace Lavid.Libraske.Json
{
    public static class JsonCreator
    {
        public static string CreateGameSession(string songId, string userId)
        {
            string json = "{";
            json += $" \"{WebConstants.SongIdField}\": \"{songId}\"";
            json += $", \"{WebConstants.UserIdField}\": \"{userId}\"";
            json += "}";

            return json;
        }
    }
}