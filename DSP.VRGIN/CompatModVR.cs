using BepInEx;

namespace DSP.VRGIN
{
    [BepInPlugin("DSP.VIRGIN", "VR Support for DSP using VRGIN", Version)]
    [BepInDependency("BepInEx.VRGIN")]
    public class CompatModVR : BaseUnityPlugin
    {
        public const string Version = "0.0.1";
    }
}