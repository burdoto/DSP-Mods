using BepInEx;
using BepInEx.VRGIN;
using BepInEx.VRGIN.Core;

namespace DSP.VRGIN
{
    [BepInPlugin("DSP.VRGIN", "VR Support for DSP using VRGIN", Version)]
    [BepInDependency(VRCore.ModGuid)]
    public class CompatModVR : BaseUnityPlugin
    {
        public const string Version = "0.0.1";
    }
}