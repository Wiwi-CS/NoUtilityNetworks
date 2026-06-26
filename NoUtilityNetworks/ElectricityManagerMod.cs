using System;

namespace NoUtilityNetworks
{
    public static class ElectricityManagerMod
    {
        public static int CurrentElectricity;
        public static int ElectricityCapacity;

        public static void Init()
        {
            CurrentElectricity = 0;
        }

        public static void CheckElectricity(out bool electricity)
        {
            electricity = CurrentElectricity > 0;
        }

        public static int DumpElectricity(int rate)
        {
            rate = Math.Min(rate, ElectricityCapacity - CurrentElectricity);
            rate = Math.Max(rate, 0);

            CurrentElectricity += rate;

            return rate;
        }

        public static int FetchElectricity(int rate)
        {
            rate = Math.Min(rate, CurrentElectricity);

            CurrentElectricity -= rate;

            return rate;
        }
    }
}