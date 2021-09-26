using System;
using BepInEx;
using BepInEx.VRGIN;
using UnityEngine;
using VRGIN.Controls.Speech;
using VRGIN.Core;
using VRGIN.Visuals;

namespace DSP.VRGIN {

    public sealed class DspVrContext : IVRManagerContext
    {
        public DspVrContext(VRSettings settings)
        {
            Settings = settings;
        }

        public string GuiLayer { get; } = "UIRoot/Overlay Canvas";
        public string UILayer { get; } = "UIRoot/Overlay Canvas/In Game";
        public int UILayerMask { get; } = 0;
        public int IgnoreMask { get; } = 0;
        public Color PrimaryColor { get; } = Color.cyan;
        public IMaterialPalette Materials { get; } = new DefaultMaterialPalette();
        public VRSettings Settings { get; }
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