using KitchenMods;

namespace MultipleIncome.src
{
    public class Main : IModInitializer
    {
        public static readonly string MOD_GUID = "harun.plateup.multipleincome";
        public static readonly string MOD_NAME = "Multiple Income";
        public const string MOD_VERSION = "0.0.2";
        public const string MOD_AUTHOR = "Harun";
        public const string MOD_GAMEVERSION = ">=1.3.0";

        public Main() { }

        public void PostActivate(Mod mod)
        {
            PreferenceManager.Initialize();
        }

        public void PostInject()
        {
        }

        public void PreInject()
        {
            
        }
    }
}
