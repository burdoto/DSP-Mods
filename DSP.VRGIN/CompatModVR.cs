using System;
using BepInEx;
using BepInEx.VRGIN;
using VRGIN.Core;

namespace DSP.VRGIN
{
    [BepInPlugin(ModGuid, ModGuid, Version)]
    public class CompatModVR : VRPlugin
    {
        public const string ModGuid = "DSP.VRGIN";
        public const string Version = "0.0.1";

        public override IVRManagerContext CreateVRContext() => new DspVrContext(Settings);

        public override string GetPathPrefix() => "";

        public override VRManager CreateVRManager(IVRManagerContext ctx) => VRManager.Create<DspGameInterpreter>(ctx);
    }
}