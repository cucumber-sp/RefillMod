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
        public static Rocket rocket;

        private static GameObject holder;

        public static void SpawnGUI()
        {
            // If window already spawned
            if (holder != null)
                return;

            holder = new GameObject("RefillMod GUI Holder");
            
            Window window = Builder.CreateWindow(holder, 300, 180, 200, 200,
                true, 0.95f, "RefillMod");

            // Layout in window
            window.CreateLayoutGroup(LayoutType.Vertical).spacing = 20f;
            window.CreateLayoutGroup(LayoutType.Vertical).DisableChildControl();
            window.CreateLayoutGroup(LayoutType.Vertical).childAlignment = TextAnchor.MiddleCenter;

            // Position is (0, 0) because window has layout group
            Container inputContainer = Builder.CreateContainer(window.ChildrenHolder, 0, 0);

            // Layout in container
            inputContainer.CreateLayoutGroup(LayoutType.Horizontal).spacing = 10f;
            inputContainer.CreateLayoutGroup(LayoutType.Horizontal).DisableChildControl();
            inputContainer.CreateLayoutGroup(LayoutType.Horizontal).childAlignment = TextAnchor.MiddleCenter;

            // Elements in container
            Builder.CreateLabel(inputContainer.gameObject, 140, 50, 0, 0, "Fill percent:");
            TextInput textInput = Builder.CreateTextInput(inputContainer.gameObject, 120, 50, 0, 0, "100", style: Builder.Style.Blue);

            Builder.CreateButton(window.ChildrenHolder, 230, 50, 0, 0,
                () => Refill(float.Parse(textInput.Text, NumberStyles.Any, CultureInfo.InvariantCulture)),
                "Refill", Builder.Style.Blue);
            
            Builder.AttachToCanvas(holder, Builder.SceneToAttach.CurrentScene);
        }

        public static void DestroyGUI()
        {
            if (holder == null)
                return;
            
            Object.Destroy(holder);
            holder = null;
        }

        private static void Refill(float value)
        {
            foreach (ResourceModule module in rocket.partHolder.GetModules<ResourceModule>())
            {
                module.TakeResource(module.ResourceAmount);
                module.AddResource(module.TotalResourceCapacity * (value / 100f));
            }
        }
    }
}