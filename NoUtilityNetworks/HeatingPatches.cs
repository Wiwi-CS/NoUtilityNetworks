using System;
using HarmonyLib;

namespace NoUtilityNetworks
{
    [HarmonyPatch(typeof(WaterManager))]
    [HarmonyPatch(nameof(WaterManager.CheckHeating))]
    public static class CheckHeatingPatch
    {
        public static bool Prefix(
            out bool heating)
        {
            HeatingManagerMod.CheckHeating(
                out heating);

            return false;
        }
    }

    [HarmonyPatch(typeof(WaterManager))]
    [HarmonyPatch(nameof(WaterManager.TryDumpHeating))]
    public static class TryDumpHeatingPatch
    {
        public static bool Prefix(
            int rate,
            int max,
            ref int __result)
        {
            __result = HeatingManagerMod.DumpHeating(
                Math.Min(rate, max));

            return false;
        }
    }

    [HarmonyPatch(typeof(WaterManager))]
    [HarmonyPatch(nameof(WaterManager.TryFetchHeating))]
    public static class TryFetchHeatingPatch
    {
        public static bool Prefix(
            int rate,
            int max,
            out bool connected,
            ref int __result)
        {
            __result = HeatingManagerMod.FetchHeating(
                Math.Min(rate, max),
                out connected);

            return false;
        }
    }
}