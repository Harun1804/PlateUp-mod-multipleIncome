using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;

namespace MultipleIncome.src
{
    internal class References
    {
        public static Item EarningBonus => Find<Item, EarningBonus>();

        internal static T Find<T>(int id) where T : GameDataObject
        {
            return (T)GDOUtils.GetExistingGDO(id) ?? (T)GDOUtils.GetCustomGameDataObject(id)?.GameDataObject;
        }

        internal static T Find<T, C>() where T : GameDataObject where C : CustomGameDataObject
        {
            return GDOUtils.GetCastedGDO<T, C>();
        }
    }
}
