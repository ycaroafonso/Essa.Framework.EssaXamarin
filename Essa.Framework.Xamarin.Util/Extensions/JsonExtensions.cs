namespace Essa.Framework.XamarinUtil.Extensions
{
    using Newtonsoft.Json;


    public static class JsonExtensions
    {

        public static string ToJson<T>(this T obj)
        {
            return obj.ToJson(new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore,
            });
        }

        public static string ToJson<T>(this T lista, JsonSerializerSettings jsonSerializerSettings)
        {
            return JsonConvert.SerializeObject(lista, jsonSerializerSettings);
        }

        public static string ToJson<T>(this T lista, Formatting formatting)
        {
            return lista.ToJson(new JsonSerializerSettings
            {
                Formatting = formatting,
                DefaultValueHandling = DefaultValueHandling.Ignore
            });
        }

        public static string ToJson<T>(this T lista, ReferenceLoopHandling referenceLoopHandling)
        {
            return lista.ToJson(new JsonSerializerSettings
            {
                ReferenceLoopHandling = referenceLoopHandling
            });
        }



        public static string ToJson<T>(this T obj, DefaultValueHandling defaultValueHandling)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                DefaultValueHandling = defaultValueHandling
            });
        }





        public static object ToOjectFromJson(this string obj, System.Type type)
        {
            return JsonConvert.DeserializeObject(obj, type);
        }
        public static T ToOjectFromJson<T>(this string obj)
        {
            return JsonConvert.DeserializeObject<T>(obj);
        }


    }
}
