using ICities;

namespace NoUtilityNetworks
{
    public class Threading : ThreadingExtensionBase
    {
        private readonly CapacityUpdater updater =
            new CapacityUpdater();

        public override void OnBeforeSimulationTick()
        {
            updater.OnBeforeSimulationTick();
        }
    }
}