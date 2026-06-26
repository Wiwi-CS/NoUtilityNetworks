using System;

namespace NoUtilityNetworks
{
    public static class HeatingManagerMod
    {
        public static int CurrentHeating;

        public static int HeatingCapacity;

        public static void Init()
        {
            CurrentHeating = 0;
            HeatingCapacity = 100000;
        }

        public static void CheckHeating(
            out bool heating)
        {
            heating = CurrentHeating > 0;
        }

        public static int DumpHeating(int rate)
        {
            rate = Math.Min(
                rate,
                HeatingCapacity - CurrentHeating);

            rate = Math.Max(rate, 0);

            CurrentHeating += rate;

            return rate;
        }

        public static int FetchHeating(
            int rate,
            out bool connected)
        {
            rate = Math.Min(
                rate,
                CurrentHeating);

            CurrentHeating -= rate;

            connected = true;

            return rate;
        }
    }
}