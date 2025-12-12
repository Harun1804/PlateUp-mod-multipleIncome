using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleIncome.src
{
    internal struct PreferenceDefinition 
    {
        public Type Type;
        public object Value;
    }

    internal class PreferenceManager
    {
        internal static PreferenceWrapper Wrapper = null;

        internal static Dictionary<string, PreferenceDefinition> DefaultPreferences =
            new Dictionary<string, PreferenceDefinition>() {
                {
                    "bonus_multiplier",
                    new PreferenceDefinition {
                        Type = typeof(int),
                        Value = 2
                    }
                }
            };

        internal static void Initialize() {
            string[] KitchenLibModIdLists = new string[] {
                "2898069883",
                "KitchenLib",
                "2949018507",
                "PreferenceSystem"
            };

            if (KitchenMods.ModPreload.Mods.Exists(mod => KitchenLibModIdLists.Any(id => id.Equals(mod.Name, StringComparison.OrdinalIgnoreCase)))) {
                Wrapper = new PreferenceWrapper();
                Wrapper.SetupMenu();
            }
        }

        public static T Get<T>(string key)
        {
            if (Wrapper != null) {
                return Wrapper.Get<T>(key);
            }

            if (DefaultPreferences.TryGetValue(key, out PreferenceDefinition definition)) {
                return (T)definition.Value;
            } else {
                return default;
            }
        }

        public static bool Set<T>(string key, T value)
        {
            if (Wrapper != null) {
                return Wrapper.Set(key, value);
            }

            return false;
        }
    }
}
