using HarmonyLib;
using SFS.World;

namespace RefillMod
{
    public static class Patcher
    {
        [HarmonyPatch(typeof(Rocket), "Awake")]
        public static class Rocket_Awake
        {
            [HarmonyPostfix]
            static void Postfix(ref Rocket __instance)
            {
                GUI.rocket = __instance;
            }
        }
    }
}