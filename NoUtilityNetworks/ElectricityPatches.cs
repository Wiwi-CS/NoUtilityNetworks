using HarmonyLib;
using System;
using UnityEngine;

namespace NoUtilityNetworks
{
    [HarmonyPatch(typeof(ElectricityManager))]
    [HarmonyPatch(nameof(ElectricityManager.CheckElectricity))]
    public static class CheckElectricityPatch
    {
        public static bool Prefix(out bool electricity)
        {
            ElectricityManagerMod.CheckElectricity(out electricity);
            return false;
        }
    }

    [HarmonyPatch(typeof(ElectricityManager))]
    [HarmonyPatch(nameof(ElectricityManager.TryDumpElectricity))]
    [HarmonyPatch(new Type[]
    {
        typeof(Vector3),
        typeof(int),
        typeof(int)
    })]
    public static class TryDumpElectricityVector3Patch
    {
        public static bool Prefix(int rate, int max, ref int __result)
        {
            __result = ElectricityManagerMod.DumpElectricity(
                Math.Min(rate, max));

            return false;
        }
    }

    // Natural Disasters DLC
    [HarmonyPatch(typeof(ElectricityManager))]
    [HarmonyPatch(nameof(ElectricityManager.TryDumpElectricity))]
    [HarmonyPatch(new Type[]
    {
        typeof(int),
        typeof(int),
        typeof(int),
        typeof(int)
    })]
    public static class TryDumpElectricityIntPatch
    {
        public static bool Prefix(int rate, int max, ref int __result)
        {
            __result = ElectricityManagerMod.DumpElectricity(
                Math.Min(rate, max));

            return false;
        }
    }

    [HarmonyPatch(typeof(ElectricityManager))]
    [HarmonyPatch(nameof(ElectricityManager.TryFetchElectricity))]
    public static class TryFetchElectricityPatch
    {
        public static bool Prefix(int rate, int max, ref int __result)
        {
            __result = ElectricityManagerMod.FetchElectricity(
                Math.Min(rate, max));

            return false;
        }
    }
}