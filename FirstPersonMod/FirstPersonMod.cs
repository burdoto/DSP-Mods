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
        public void CameraUserInputPostfix(EasyCamera __instance)
        {
            __instance.distance = -10;
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