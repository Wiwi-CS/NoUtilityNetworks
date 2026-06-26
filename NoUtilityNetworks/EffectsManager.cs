using ColossalFramework;

namespace NoUtilityNetworks
{
    public static class EffectsManager
    {
        public static bool EnableEffects = true;

        public static bool EnableWaterTemperatureEffect = true;

        public static float WaterTemperatureThreshold = 20f;

        public static float WaterConsumptionMultiplier = 1.10f;

        public static float CurrentTemperature
        {
            get
            {
                WeatherManager weather = Singleton<WeatherManager>.instance;

                return weather != null
                    ? weather.m_currentTemperature
                    : 20f;
            }
        }

        public static int ModifyWaterConsumption(int consumption)
        {
            if (!EnableEffects)
                return consumption;

            if (!EnableWaterTemperatureEffect)
                return consumption;

            if (CurrentTemperature < WaterTemperatureThreshold)
                return consumption;

            return UnityEngine.Mathf.RoundToInt(
                consumption * WaterConsumptionMultiplier);
        }
    }
}