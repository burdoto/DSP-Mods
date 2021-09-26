using System;
using BepInEx;
using BepInEx.VRGIN;
using BepInEx.VRGIN.Core;
using UnityEngine;
using VRGIN.Controls.Speech;
using VRGIN.Core;
using VRGIN.Visuals;

namespace DSP.VRGIN
{
    [BepInPlugin(VRCore.ModGuid_Context, "DSP Context Mappings for VRGIN", VRCore.Version)]
    public class DspVrContextProvider : BaseUnityPlugin
    {
        private void Awake()
        {
            VRCore.VrContextType = typeof(DspVrContext);
            VRCore.GameInterpreterFactory = ctx => VRManager.Create<DspGameInterpreter>(ctx);
        }
    }

    public sealed class DspVrContext : IVRManagerContext
    {
        public string GuiLayer { get; } = "UIRoot/Overlay Canvas";
        public string UILayer { get; } = "UIRoot/Overlay Canvas/In Game";
        public int UILayerMask { get; } = 0;
        public int IgnoreMask { get; } = 0;
        public Color PrimaryColor { get; } = Color.cyan;
        public IMaterialPalette Materials { get; } = new DefaultMaterialPalette();
        public VRSettings Settings { get; } = VRCore.LoadVrSettings();
        public string InvisibleLayer { get; } = string.Empty;
        public bool SimulateCursor { get; } = true;
        public bool GUIAlternativeSortingMode { get; } = false;
        public Type VoiceCommandType { get; } = typeof(VoiceCommand);
        public float GuiNearClipPlane { get; } = 0;
        public float GuiFarClipPlane { get; } = 1000;
        public float NearClipPlane { get; } = 0;
        public float UnitToMeter { get; } = 1;
        public bool EnforceDefaultGUIMaterials { get; } = false;
        public bool ConfineMouse { get; } = false;
        public GUIType PreferredGUI { get; } = GUIType.uGUI;
    }
}