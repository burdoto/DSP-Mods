using System;
using BepInEx;
using BepInEx.VRGIN;
using BepInEx.VRGIN.Core;
using UnityEngine;
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
        }
    }

    public sealed class DspVrContext : IVRManagerContext
    {
        public string GuiLayer { get; }
        public string UILayer { get; }
        public int UILayerMask { get; }
        public int IgnoreMask { get; }
        public Color PrimaryColor { get; }
        public IMaterialPalette Materials { get; }
        public VRSettings Settings { get; }
        public string InvisibleLayer { get; }
        public bool SimulateCursor { get; }
        public bool GUIAlternativeSortingMode { get; }
        public Type VoiceCommandType { get; }
        public float GuiNearClipPlane { get; }
        public float GuiFarClipPlane { get; }
        public float NearClipPlane { get; }
        public float UnitToMeter { get; }
        public bool EnforceDefaultGUIMaterials { get; }
        public bool ConfineMouse { get; }
        public GUIType PreferredGUI { get; }
    }
}