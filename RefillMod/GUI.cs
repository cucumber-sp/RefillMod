using System.Globalization;
using SFS.Parts;
using SFS.Parts.Modules;
using SFS.UI.ModGUI;
using SFS.World;
using UnityEngine;

namespace RefillMod
{
    public static class GUI
    {
        static GameObject holder;
        static readonly int MainWindowID = Builder.GetRandomID();

        public static void SpawnGUI()
        {
            holder = Builder.CreateHolder(Builder.SceneToAttach.CurrentScene, "RefillMod GUI Holder");
            
            Window window = Builder.CreateWindow(holder.transform, MainWindowID, 300, 180, 200, 200,
                true, true,0.95f, "RefillMod");

            // Layout in window
            window.CreateLayoutGroup(Type.Vertical);

            // Doesnt set position because window has layout group
            Container inputContainer = Builder.CreateContainer(window);

            // Layout in container
            inputContainer.CreateLayoutGroup(Type.Horizontal, spacing: 10f);

            // Elements in container
            Builder.CreateLabel(inputContainer, 140, 50, 0, 0, "Fill percent:");
            TextInput input = Builder.CreateTextInput(inputContainer, 120, 50, 0, 0, "100");

            // Refill button
            Builder.CreateButton(window, 230, 50, 0, 0, () => Refill(input.Text), "Refill");
        }

        static void Refill(string _value)
        {
            if (!(PlayerController.main.player.Value is Rocket rocket))
                return;
            
            float value = float.Parse(_value, NumberStyles.Any, CultureInfo.InvariantCulture);
            foreach (ResourceModule module in rocket.partHolder.GetModules<ResourceModule>())
            {
                module.TakeResource(module.ResourceAmount);
                module.AddResource(module.TotalResourceCapacity * (value / 100f));
            }
        }
    }
}