using ColossalFramework;
using HarmonyLib;
using UnityEngine;

namespace NoUtilityNetworks
{
    public static class WaterEffects
    {
        private static float GetMultiplier()
        {
            if (!Mod.WaterTemperatureEffect.value)
                return 1f;

            WeatherManager weather = Singleton<WeatherManager>.instance;

            if (weather == null)
                return 1f;

            float temp = weather.m_currentTemperature;

            if (temp >= 30f)
                return 1.10f;

            if (temp >= 20f)
                return 1.05f;

            return 1f;
        }

        // =====================================================
        // Residential
        // =====================================================

        [HarmonyPatch(typeof(Citizen))]
        [HarmonyPatch(nameof(Citizen.GetWaterConsumption))]
        public static class CitizenWaterPatch
        {
            public static void Postfix(ref int __result)
            {
                __result = Mathf.RoundToInt(
                    __result * GetMultiplier());
            }
        }

        [HarmonyPatch(typeof(Citizen))]
        [HarmonyPatch(nameof(Citizen.GetSewageAccumulation))]
        public static class CitizenSewagePatch
        {
            public static void Postfix(ref int __result)
            {
                __result = Mathf.RoundToInt(
                    __result * GetMultiplier());
            }
        }

        // =====================================================
        // Commercial
        // =====================================================

        [HarmonyPatch(typeof(CommercialBuildingAI))]
        [HarmonyPatch(nameof(CommercialBuildingAI.GetConsumptionRates))]
        public static class CommercialWaterPatch
        {
            public static void Postfix(
                ref int waterConsumption,
                ref int sewageAccumulation)
            {
                float multiplier = GetMultiplier();

                waterConsumption =
                    Mathf.RoundToInt(waterConsumption * multiplier);

                sewageAccumulation =
                    Mathf.RoundToInt(sewageAccumulation * multiplier);
            }
        }

        // =====================================================
        // Industrial
        // =====================================================

        [HarmonyPatch(typeof(IndustrialBuildingAI))]
        [HarmonyPatch(nameof(IndustrialBuildingAI.GetConsumptionRates))]
        public static class IndustrialWaterPatch
        {
            public static void Postfix(
                ref int waterConsumption,
                ref int sewageAccumulation)
            {
                float multiplier = GetMultiplier();

                waterConsumption =
                    Mathf.RoundToInt(waterConsumption * multiplier);

                sewageAccumulation =
                    Mathf.RoundToInt(sewageAccumulation * multiplier);
            }
        }

        // =====================================================
        // Office
        // =====================================================

        [HarmonyPatch(typeof(OfficeBuildingAI))]
        [HarmonyPatch(nameof(OfficeBuildingAI.GetConsumptionRates))]
        public static class OfficeWaterPatch
        {
            public static void Postfix(
                ref int waterConsumption,
                ref int sewageAccumulation)
            {
                float multiplier = GetMultiplier();

                waterConsumption =
                    Mathf.RoundToInt(waterConsumption * multiplier);

                sewageAccumulation =
                    Mathf.RoundToInt(sewageAccumulation * multiplier);
            }
        }
    }
}