using Newtonsoft.Json;

namespace WindowsFormsAppUI.Helpers
{
    public class JsonHelper
    {
        public static T Deserialize<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch { return default(T); }
        }

        public static string Serialize<T>(T obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch { return ""; }
        }
    }
}