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

            Container inputContainer = Builder.CreateContainer(window);

            // Percent input field
            InputWithLabel percentInput = Builder.CreateInputWithLabel(window, 380, 50, labelText: "Fill percent:", inputText: "100");
            inputContainer.CreateLayoutGroup(Type.Horizontal, spacing: 10f);

            // Refill button
            Builder.CreateButton(window, 230, 50, 0, 0, () => Refill(percentInput.textInput.Text), "Refill");
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