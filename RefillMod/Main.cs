using ModLoader;

namespace RefillMod
{
    public class Main : Mod
    {
        public Main() : base("RefillMod", "RefillMod", "Andrey Onishchenko",
            "0.5.7", "v1.0", "Example mod") { }

        public override void Early_Load()
        {
            //
        }

        public override void Load()
        {
            throw new System.NotImplementedException();
        }

        public override void Unload()
        {
            throw new System.NotImplementedException();
        }
    }
}