using ColossalFramework;
using HarmonyLib;
using UnityEngine;

namespace NoUtilityNetworks
{
    public static class ElectricityEffects
    {
        private static float GetMultiplier()
        {
            if (!Mod.ElectricityTemperatureEffect.value)
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

        [HarmonyPatch(typeof(Citizen))]
        [HarmonyPatch(nameof(Citizen.GetElectricityConsumption))]
        public static class ResidentialElectricityPatch
        {
            public static void Postfix(ref int __result)
            {
                __result = Mathf.RoundToInt(
                    __result * GetMultiplier());
            }
        }

        [HarmonyPatch(typeof(CommercialBuildingAI))]
        [HarmonyPatch(nameof(CommercialBuildingAI.GetConsumptionRates))]
        public static class CommercialElectricityPatch
        {
            public static void Postfix(ref int electricityConsumption)
            {
                electricityConsumption = Mathf.RoundToInt(
                    electricityConsumption * GetMultiplier());
            }
        }

        [HarmonyPatch(typeof(IndustrialBuildingAI))]
        [HarmonyPatch(nameof(IndustrialBuildingAI.GetConsumptionRates))]
        public static class IndustrialElectricityPatch
        {
            public static void Postfix(ref int electricityConsumption)
            {
                electricityConsumption = Mathf.RoundToInt(
                    electricityConsumption * GetMultiplier());
            }
        }

        [HarmonyPatch(typeof(OfficeBuildingAI))]
        [HarmonyPatch(nameof(OfficeBuildingAI.GetConsumptionRates))]
        public static class OfficeElectricityPatch
        {
            public static void Postfix(ref int electricityConsumption)
            {
                electricityConsumption = Mathf.RoundToInt(
                    electricityConsumption * GetMultiplier());
            }
        }
    }
}