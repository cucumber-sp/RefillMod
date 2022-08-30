using HarmonyLib;
using ModLoader;
using ModLoader.Helpers;

namespace RefillMod
{
    public class Main : Mod
    {
        public override void Early_Load()
        {
            new Harmony("refillmod").PatchAll();
        }

        public override void Load()
        {
            SceneHelper.OnWorldSceneLoaded += GUI.SpawnGUI;
        }

        public override string ModNameID => "refillmod";
        public override string DisplayName => "RefillMod";
        public override string Author => "Andrey Onischenko";
        public override string MinimumGameVersionNecessary => "1.5.7";
        public override string ModVersion => "1.0";
        public override string Description => "Example mod";
    }
}