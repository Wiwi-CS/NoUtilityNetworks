using System;
using HarmonyLib;
using UnityEngine;

namespace NoUtilityNetworks
{
    [HarmonyPatch(typeof(WaterManager))]
    [HarmonyPatch(nameof(WaterManager.CheckWater))]
    public static class CheckWaterPatch
    {
        public static bool Prefix(
            out bool water,
            out bool sewage,
            out byte waterPollution)
        {
            WaterManagerMod.CheckWater(
                out water,
                out sewage,
                out waterPollution);

            return false;
        }
    }

    // Pumpstationen / Wasserentnahme
    [HarmonyPatch(typeof(WaterManager))]
    [HarmonyPatch(nameof(WaterManager.TryDumpWater))]
    public static class TryDumpWaterPatch
    {
        public static bool Prefix(
            int rate,
            int max,
            byte waterPollution,
            ref int __result)
        {
            __result = WaterManagerMod.DumpWater(
                Math.Min(rate, max),
                waterPollution);

            return false;
        }
    }

    // Gebäude verbrauchen Wasser
    [HarmonyPatch(typeof(WaterManager))]
    [HarmonyPatch(nameof(WaterManager.TryFetchWater))]
    [HarmonyPatch(
        new Type[]
        {
            typeof(Vector3),
            typeof(int),
            typeof(int),
            typeof(byte)
        },
        new ArgumentType[]
        {
            ArgumentType.Normal,
            ArgumentType.Normal,
            ArgumentType.Normal,
            ArgumentType.Ref
        })]
    public static class TryFetchWaterVector3Patch
    {
        public static bool Prefix(
            Vector3 pos,
            int rate,
            int max,
            ref byte waterPollution,
            ref int __result)
        {
            __result = WaterManagerMod.FetchWater(
                Math.Min(rate, max),
                ref waterPollution);

            return false;
        }
    }

    // Wasserbauwerke
    [HarmonyPatch(typeof(WaterManager))]
    [HarmonyPatch(nameof(WaterManager.TryFetchWater))]
    [HarmonyPatch(
        new Type[]
        {
            typeof(ushort),
            typeof(int),
            typeof(int),
            typeof(byte)
        },
        new ArgumentType[]
        {
            ArgumentType.Normal,
            ArgumentType.Normal,
            ArgumentType.Normal,
            ArgumentType.Ref
        })]
    public static class TryFetchWaterUShortPatch
    {
        public static bool Prefix(
            int rate,
            int max,
            ref byte waterPollution,
            ref int __result)
        {
            __result = WaterManagerMod.FetchWater(
                Math.Min(rate, max),
                ref waterPollution);

            return false;
        }
    }

    // Gebäude erzeugen Abwasser
    [HarmonyPatch(typeof(WaterManager))]
    [HarmonyPatch(nameof(WaterManager.TryDumpSewage))]
    [HarmonyPatch(
        new Type[]
        {
            typeof(Vector3),
            typeof(int),
            typeof(int)
        })]
    public static class TryDumpSewageVector3Patch
    {
        public static bool Prefix(
            int rate,
            int max,
            ref int __result)
        {
            __result = WaterManagerMod.DumpSewage(
                Math.Min(rate, max));

            return false;
        }
    }

    // Pumpwerke
    [HarmonyPatch(typeof(WaterManager))]
    [HarmonyPatch(nameof(WaterManager.TryDumpSewage))]
    [HarmonyPatch(
        new Type[]
        {
            typeof(ushort),
            typeof(int),
            typeof(int)
        })]
    public static class TryDumpSewageUShortPatch
    {
        public static bool Prefix(
            int rate,
            int max,
            ref int __result)
        {
            __result = WaterManagerMod.DumpSewage(
                Math.Min(rate, max));

            return false;
        }
    }

    // Kläranlagen holen Abwasser
    [HarmonyPatch(typeof(WaterManager))]
    [HarmonyPatch(nameof(WaterManager.TryFetchSewage))]
    public static class TryFetchSewagePatch
    {
        public static bool Prefix(
            int rate,
            int max,
            ref int __result)
        {
            __result = WaterManagerMod.FetchSewage(
                Math.Min(rate, max));

            return false;
        }
    }
}