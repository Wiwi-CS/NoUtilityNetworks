using System;
using ColossalFramework;
using ICities;

namespace NoUtilityNetworks
{
    public class CapacityUpdater : ThreadingExtensionBase
    {
        public override void OnBeforeSimulationTick()
        {
            var district =
                Singleton<DistrictManager>
                .instance
                .m_districts
                .m_buffer[0];

            // Wasser

            int weeklyWaterConsumption =
                district.GetWaterConsumption();

            int dailyWaterConsumption =
                weeklyWaterConsumption / 7;

            WaterManagerMod.WaterCapacity =
                dailyWaterConsumption * 2;

            // Heizung

            int weeklyHeatingConsumption =
                district.GetHeatingConsumption();

            int dailyHeatingConsumption =
                weeklyHeatingConsumption / 7;

            HeatingManagerMod.HeatingCapacity =
                dailyHeatingConsumption * 2;

            // Strom

            int weeklyElectricityConsumption =
                district.GetElectricityConsumption();

            int dailyElectricityConsumption =
                weeklyElectricityConsumption / 7;

            ElectricityManagerMod.ElectricityCapacity =
                Math.Max(
                    dailyElectricityConsumption,
                    1000);
        }
    }
}