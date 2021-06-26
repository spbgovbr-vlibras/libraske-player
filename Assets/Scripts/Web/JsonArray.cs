using Lavid.Libraske.DataStruct;
using UnityEngine;

namespace Lavid.Libraske.Json
{
    public static class JsonArray
    {
        public static Wrapper<T> FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>(array);
            return JsonUtility.ToJson(wrapper);
        }
    }
}