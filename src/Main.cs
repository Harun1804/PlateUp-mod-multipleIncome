using KitchenLib;
using KitchenMods;
using System.Reflection;
using UnityEngine;

namespace MultipleIncome.src
{
    public class Main : BaseMod
    {
        public static readonly string MOD_GUID = "com.harun.multipleincome";
        public static readonly string MOD_NAME = "Multiple Income";
        public const string MOD_VERSION = "0.1.3";
        public const string MOD_AUTHOR = "Harun";
        public const string MOD_GAMEVERSION = ">=1.3.0";

        public Main(): base(MOD_GUID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_GAMEVERSION, Assembly.GetExecutingAssembly()) { }

        protected override void OnInitialise()
        {
            // Optional: Log initialization
            Debug.LogWarning($"{MOD_NAME} v{MOD_VERSION} in use!");
        }

        protected override void OnPostActivate(Mod mod)
        {
            // *** 4. Call your GDO registration method here ***
            AddGameData();

            // Your original PostActivate logic goes here, e.g.:
             PreferenceManager.Initialize();
        }

        // *** 3. Add the registration method from the example ***
        private void AddGameData()
        {
            LogInfo("Attempting to register custom GDOs...");

            // THIS IS THE CORRECT, HIGHLY-STABLE BULK REGISTRATION CALL
            // This will register your EarningBonus class automatically
            //ModGDOs.RegisterModGDOs(this, Assembly.GetExecutingAssembly());
            AddGameDataObject<EarningBonus>();

            LogInfo("Done loading game data.");
        }

        // You also need to keep a LogInfo method for the AddGameData to compile
        public static void LogInfo(string _log) { Debug.Log($"[{MOD_NAME}] " + _log); }

        protected override void OnUpdate() { }
        protected override void OnPostInject() { }
    }
}
