using KitchenMods;

namespace MultipleIncome.src
{
    public class Main : IModInitializer
    {
        public static readonly string MOD_GUID = "harun.plateup.multipleincome";
        public static readonly string MOD_NAME = "Multiple Income";

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
