using ICities;

namespace NoUtilityNetworks
{
    public class Loader : LoadingExtensionBase
    {
        public override void OnCreated(ILoading loading)
        {
            Patcher.PatchAll();

            WaterManagerMod.Init();
            HeatingManagerMod.Init();
            ElectricityManagerMod.Init();
        }

        public override void OnReleased()
        {
            Patcher.UnpatchAll();
        }
    }
}