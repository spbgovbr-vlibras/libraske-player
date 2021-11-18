using Lavid.Libraske.DataStruct;
using UnityEngine;

namespace Lavid.Libraske.Json
{
    public static class JsonArray
    {
        private const string InitFormat = "{" + "\"Items\":";
        private const string EndFormat = "}";

        private static bool ShouldWrap(string str) => !str.StartsWith(InitFormat);
        private static string WrapString(string str) => InitFormat + str + EndFormat;

        public static Wrapper<T> FromJson<T>(string json)
        {
            if (ShouldWrap(json))
                json = WrapString(json);

            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper;
        }

        public static string ToJson<T>(Wrapper<T> wrapper)
        {
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>(array);
            return JsonUtility.ToJson(wrapper);
        }
    }
}