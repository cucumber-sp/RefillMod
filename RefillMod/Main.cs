using HarmonyLib;
using ModLoader;
using ModLoader.Helpers;

namespace RefillMod
{
    public class Main : Mod
    {
        public Main() : base("refillmod", "RefillMod", "Andrey Onishchenko",
            "0.5.7", "v1.0", "Example mod") { }

        public override void Early_Load()
        {
            new Harmony("refillmod").PatchAll();
        }

        public override void Load()
        {
            SceneHelper.OnSceneLoaded += (x) =>
            {
                if (x.name == "World_PC")
                    GUI.SpawnGUI();
                else
                    GUI.DestroyGUI();
            };
        }

        public override void Unload() { GUI.DestroyGUI(); }
    }
}