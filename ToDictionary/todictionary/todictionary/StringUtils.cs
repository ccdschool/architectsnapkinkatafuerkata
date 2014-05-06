using System.Collections.Generic;
using System.Linq;

namespace todictionary
{
    public static class StringUtils
    {
        public static IDictionary<string, string> ToDictionary(string configuration) {
            var settings = In_Settings_zerlegen(configuration);
            var name_wert_Paare = In_Name_und_Wert_zerlegen(settings);
            return Dictionary_erzeugen(name_wert_Paare);
        }

        internal static IEnumerable<string> In_Settings_zerlegen(string configuration) {
            return configuration.Split(';');
        }

        internal static IEnumerable<KeyValuePair<string, string>> In_Name_und_Wert_zerlegen(IEnumerable<string> settings) {
            return settings.Select(setting => {
                var kv_pair = setting.Split('=');
                return new KeyValuePair<string, string>(kv_pair[0], kv_pair[1]);
            });
        }

        internal static IDictionary<string, string> Dictionary_erzeugen(IEnumerable<KeyValuePair<string, string>> name_wert_Paare) {
            var result = new Dictionary<string, string>();
            foreach (var keyValuePair in name_wert_Paare) {
                result.Add(keyValuePair.Key, keyValuePair.Value);
            }
            return result;
        }
    }
}