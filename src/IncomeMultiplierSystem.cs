using Kitchen;
using KitchenData;
using KitchenMods;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace MultipleIncome.src
{
    [UpdateBefore(typeof(UpdateMoneyTracker))]
    [UpdateBefore(typeof(DestroyAppliancesAtNight))]
    [UpdateBefore(typeof(EndOfDayProgressionGroup))]
    public class IncomeMultiplierSystem : RestaurantSystem, IModSystem
    {
        private SMoney StartingMoney;

        protected override void Initialise()
        {
            base.Initialise();
        }

        protected override void OnUpdate()
        {
            // At the first update of the day, record starting money
            if (HasSingleton<SIsDayFirstUpdate>()) {
                StartingMoney = GetSingleton<SMoney>();
                Log($"Recorded starting money: {(int)StartingMoney}");
            }
            // At the first update of night (end of day), compute earnings and award bonus
            else if (HasSingleton<SIsNightFirstUpdate>()) {
                SMoney currentMoney = GetSingleton<SMoney>();
                int earningsToday = (int)(currentMoney - StartingMoney);
                int defaultMultiplier = PreferenceManager.Get<int>("bonus_multiplier");

                Log($"Starting: {(int)StartingMoney}, Current: {(int)currentMoney}, Earned: {earningsToday}");
                MultiplyBonus(earningsToday, defaultMultiplier);
            } else if (HasSingleton<SIsDayTime>()) {
                // No action needed during day time
            }
        }

        private void MultiplyBonus(int earnings, int multiplier)
        {
            if (multiplier > 1 && earnings > 0) {
                SMoney currentMoney = GetSingleton<SMoney>();
                int bonus = earnings * multiplier;

                Set<SMoney>(currentMoney + bonus);

                TrackMoney(bonus);
                Log($"Awarded bonus of {bonus} for {multiplier}x multiplier on earnings of {earnings}. New total: {(int)(currentMoney + bonus)}");
            }
        }

        private void TrackMoney(int money)
        {
            Entity e = EntityManager.CreateEntity(typeof(CMoneyTrackEvent));
            EntityManager.SetComponentData(e, new CMoneyTrackEvent { 
                Amount = money,
                Identifier = References.EarningBonus.ID
            });
        }

        private void Log(string message)
        {
            Debug.Log($"[{Main.MOD_NAME}] [IncomeMultiplier] {message}");
        }
    }
}
