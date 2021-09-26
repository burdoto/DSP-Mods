using UnityEngine;
using VRGIN.Core;

namespace DSP.VRGIN
{
    public class DspGameInterpreter : GameInterpreter
    {
        public override Camera FindCamera() => GameCamera.main;

        public override bool IsIrrelevantCamera(Camera blueprint) => blueprint != GameCamera.main;
    }
}