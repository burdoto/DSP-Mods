using System;
using BepInEx;
using HarmonyLib;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace FirstPersonMod
{
    [BepInPlugin("de.kaleidox.dsp.fpm", Strings.Name, Strings.Version)]
    public class FirstPersonMod : BaseUnityPlugin
    {
        private static Player Player => GameMain.data?.mainPlayer;
        private static bool _active;
        private static float _modifier = 1.3f;
        private Harmony _harmony;

        public void Awake()
        {
            _harmony = new Harmony(typeof(FirstPersonMod).FullName);
        }

        public void Start()
        {
            _harmony.PatchAll(typeof(FirstPersonMod));
            FirstPersonDebug.Log("Started!");
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.F5))
                _active = !_active;
            if (Input.GetKeyDown(KeyCode.F6) && _modifier > 1.09)
                _modifier -= 0.05f;
            if (Input.GetKeyDown(KeyCode.F7) && _modifier < 4.01)
                _modifier += 0.05f;
        }

        [HarmonyPatch(typeof(GameCamera), "LateUpdate"), HarmonyPostfix]
        public static void GameCameraLateUpdatePostfix(GameCamera __instance)
        {
            if (!_active || Player == null)
                return;
            var cam = GameCamera.main;
            var camera = cam.transform;
            var player = Player.transform;
            var up = player.up;
            var fwd = player.forward;
            var position = player.position;
            var rotation = player.rotation;
            FirstPersonDebug.LogVerbose($"Player pos,rot,fwd: {position} ; {rotation} ; {fwd}");
            camera.position = position + up.normalized * (1.5f * (_modifier * 5));
            cam.fieldOfView = 160 * (_modifier * 0.3f);
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