using System;
using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace FirstPersonMod
{
    [BepInPlugin("de.kaleidox.dsp.fpm", Strings.Name, Strings.Version)]
    public class FirstPersonMod : BaseUnityPlugin
    {
        private Harmony _harmony;
        private static Player Player => GameMain.data?.mainPlayer;
        
        public void Awake()
        {
            _harmony = new Harmony(typeof(FirstPersonMod).FullName);
        }

        public void Start()
        {
            _harmony.PatchAll(typeof(FirstPersonMod));
            FirstPersonDebug.Log("Started!");
        }

        [HarmonyPatch(typeof(EasyCamera), "UserInput"), HarmonyPostfix]
        public static void EasyCameraDisableScrolling(EasyCamera __instance)
        {
            __instance.sens = 0;
        }

        [HarmonyPatch(typeof(GameCamera), "LateUpdate"), HarmonyPostfix]
        public static void GameCameraLateUpdatePostfix(GameCamera __instance)
        {
            if (Player == null)
                return;
            var cam = GameCamera.main;
            var camera = cam.transform;
            var player = Player.transform;
            var up = player.up;
            var fwd = player.forward;
            var position = player.position;
            var rotation = player.rotation;
            FirstPersonDebug.LogVerbose($"Player pos,rot,fwd: {position} ; {rotation} ; {fwd}");
            camera.position = position + up.normalized * 7;
            cam.fieldOfView = 75;
            //camera.rotation = rotation;
        }

        public void Reset()
        {
            _harmony.UnpatchAll();
        }
    }

    public static class FirstPersonDebug
    {
        private static readonly bool debug = true;
        internal static bool verbose = false;
        public static ILogger log => Debug.unityLogger;

        internal static void Log(string tagname, object message, Exception exception = null)
        {
            log?.Log($"[{Strings.LogPrefix} - {tagname}]", message + (exception == null
                ? string.Empty
                : "\nSource: " + exception.Source + "\nException:\n" + exception));
        }

        public static void Log(object message, Exception exception = null)
        {
            Log("Info", message, exception);
        }

        public static void LogDebug(object message, Exception exception = null)
        {
            if (!debug)
                return;
            Log("Debug", message, exception);
        }

        public static void LogVerbose(object message, Exception exception = null)
        {
            if (!verbose)
                return;
            Log("Verbose", message, exception);
        }
    }

    public static class Strings
    {
        public const string Name = "FirstPerson";
        public const string Version = "2.4.0";
        public const string LogPrefix = "[" + Name + "]";
    }
}