using HarmonyLib;

namespace NoUtilityNetworks
{
    public static class Patcher
    {
        private const string HarmonyId =
            "Pionier.NoUtilityNetworks";

        private static bool patched;

        public static void PatchAll()
        {
            if (patched)
                return;

            var harmony = new Harmony(HarmonyId);

            harmony.PatchAll();

            patched = true;
        }

        public static void UnpatchAll()
        {
            if (!patched)
                return;

            var harmony = new Harmony(HarmonyId);

            harmony.UnpatchAll(HarmonyId);

            patched = false;
        }
    }
}