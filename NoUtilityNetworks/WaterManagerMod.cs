using System;
using UnityEngine;

namespace NoUtilityNetworks
{
    public static class WaterManagerMod
    {
        public static int CurrentWater;
        public static int CurrentSewage;
        public static int CurrentWaterTotalPollution;

        public static int WaterCapacity;

        public static void Init()
        {
            CurrentWater = 0;
            CurrentSewage = 0;
            CurrentWaterTotalPollution = 0;

            WaterCapacity = 100000;
        }

        public static void CheckWater(
            out bool water,
            out bool sewage,
            out byte waterPollution)
        {
            water = CurrentWater > 0;
            sewage = CurrentSewage < WaterCapacity;

            if (CurrentWater == 0)
            {
                waterPollution = 0;
            }
            else
            {
                waterPollution = (byte)Mathf.Clamp(
                    CurrentWaterTotalPollution / CurrentWater,
                    byte.MinValue,
                    byte.MaxValue);
            }
        }

        public static int DumpWater(
            int rate,
            byte waterPollution)
        {
            rate = Math.Min(rate, WaterCapacity - CurrentWater);
            rate = Math.Max(rate, 0);

            CurrentWater += rate;

            CurrentWaterTotalPollution = Math.Min(
                CurrentWaterTotalPollution + waterPollution * rate,
                CurrentWater * byte.MaxValue);

            return rate;
        }

        public static int FetchWater(
            int rate,
            ref byte waterPollution)
        {
            if (CurrentWater == 0)
            {
                waterPollution = 0;
            }
            else
            {
                waterPollution = (byte)Mathf.Clamp(
                    CurrentWaterTotalPollution / CurrentWater,
                    byte.MinValue,
                    byte.MaxValue);
            }

            rate = Math.Min(rate, CurrentWater);

            CurrentWater -= rate;

            CurrentWaterTotalPollution = Math.Max(
                CurrentWaterTotalPollution - waterPollution * rate,
                0);

            return rate;
        }

        public static int DumpSewage(int rate)
        {
            rate = Math.Min(rate, WaterCapacity - CurrentSewage);
            rate = Math.Max(rate, 0);

            CurrentSewage += rate;

            return rate;
        }

        public static int FetchSewage(int rate)
        {
            rate = Math.Min(rate, CurrentSewage);

            CurrentSewage -= rate;

            return rate;
        }
    }
}