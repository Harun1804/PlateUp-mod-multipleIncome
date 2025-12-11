using KitchenLib.Preferences;
using PreferenceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleIncome.src
{
    internal class PreferenceWrapper
    {
        internal object PrefManager = null;

        public PreferenceWrapper() {
            PrefManager = new PreferenceSystemManager(Main.MOD_GUID, Main.MOD_NAME);
        }

        public void SetupMenu() {
            if (PrefManager != null) {
                try {
                    int[] multipleOptions = GetInts(0, 5, 1);
                    string[] multipleLabels = GetLabels(multipleOptions, (d) => {
                        if (d == 0) {
                            return "Disabled";
                        }

                        return d + "x multiplier";
                    });

                    PreferenceSystemManager manager = (PreferenceSystemManager)PrefManager;

                    manager.AddLabel("Multiplier Earning Bonus Income")
                        .AddSpacer()
                        .AddLabel("Multiplier Earning")
                        .AddOption<int>("bonus_multiplier", Convert.ToInt32(PreferenceManager.DefaultPreferences["bonus_multiplier"].Value), multipleOptions, multipleLabels)
                        .AddSpacer()
                        .AddSpacer();
                    manager.RegisterMenu(PreferenceSystemManager.MenuType.MainMenu);
                    manager.RegisterMenu(PreferenceSystemManager.MenuType.PauseMenu);
                }
                catch { }
            }
        }

        public T Get<T>(string key)
        {
            if (PrefManager != null) {
                return ((PreferenceSystemManager)PrefManager).Get<T>(key);
            }

            return default;
        }

        public bool Set<T>(string key, T value)
        {
            if (PrefManager != null) {
                ((PreferenceSystemManager)PrefManager).Set(key, value);
                return true;
            }

            return false;
        }

        private int[] GetInts(int start, int end, int step)
        {
            if (step <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(step), "Step must be positive.");
            }

            List<int> result = new List<int>();

            for (int i = start; i <= end; i += step) {
                result.Add(i);
            }

            return result.ToArray();
        }

        private string[] GetLabels<T>(T[] list, Func<T, string> func)
        {
            string[] result = new string[list.Length];

            for (int i = 0; i < list.Length; i++) {
                result[i] = func(list[i]);
            }

            return result;
        }
    }
}
