﻿using Newtonsoft.Json;

namespace Common.Helpers
{
    public static class JsonHelper
    {
        public static string SerializeJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T DeserializeJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}