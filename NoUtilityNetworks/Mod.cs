using ICities;
using ColossalFramework;
using ColossalFramework.IO;
using ColossalFramework.PlatformServices;
using ColossalFramework.UI;

namespace NoUtilityNetworks
{
    public class Mod : IUserMod
    {
        public static readonly SavedBool WaterTemperatureEffect =
            new SavedBool(
                "WaterTemperatureEffect",
                Settings.gameSettingsFile,
                true,
                true);

        public static readonly SavedBool ElectricityTemperatureEffect =
            new SavedBool(
                "ElectricityTemperatureEffect",
                Settings.gameSettingsFile,
                true,
                true);

        public string Name => "No Utility Networks";

        public string Description =>
            "Removes the need for utility networks.";

        public void OnSettingsUI(UIHelperBase helper)
        {
            UIHelper group = helper as UIHelper;

            group.AddGroup("No Utility Networks");

            group.AddSpace(10);

            group.AddGroup(
    "No water pipes, power lines or heating networks required.\n" +
    "Optional temperature effects for water and electricity demand.");

            group.AddSpace(10);

            UICheckBox waterBox = (UICheckBox)group.AddCheckbox(
                "Temperature affects water and sewage demand (Snowfall)",
                WaterTemperatureEffect.value,
                b => WaterTemperatureEffect.value = b);

            UICheckBox electricityBox = (UICheckBox)group.AddCheckbox(
                "Temperature affects electricity demand (Snowfall)",
                ElectricityTemperatureEffect.value,
                b => ElectricityTemperatureEffect.value = b);

            bool hasSnowfall =
                SteamHelper.IsDLCOwned(SteamHelper.DLC.SnowFallDLC);

            waterBox.isEnabled = hasSnowfall;
            electricityBox.isEnabled = hasSnowfall;
        }
    }
}