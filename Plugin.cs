using System;
using System.Collections.Generic;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using HarmonyLib.Tools;
using Unity.Networking.Transport.Error;
using UnityEngine.InputSystem;

namespace KeyBindings;

[BepInPlugin("plugins.keybindings", "KeyBindings", "0.1.0.0")]
public class Plugin : BasePlugin
{
    // the "configurable" things
    private readonly Harmony _harmony = new Harmony("plugins.keybindings");
    
    // plugin managers
    public static new ManualLogSource Log;

    public static Dictionary<string, string> bindings_from_config_default = new Dictionary<string, string>{
        {"moveForwardAction", "<Keyboard>/w"},
        {"moveBackwardAction", "<Keyboard>/s"},
        {"moveLeftAction", "<Keyboard>/a"},
        {"moveRightAction", "<Keyboard>/d"},
        {"jumpAction", "<Keyboard>/space"},
        {"lookAction", "<Mouse>/rightButton"},
        {"trackAction", "<Mouse>/leftButton"},
        {"stopAction", "<Keyboard>/alt"},
        {"slideAction", "<Keyboard>/leftCtrl"},
        {"talkAction", "<Keyboard>/c"},
        {"stickAction", "<Mouse>/delta"},
        {"sprintAction", "<Keyboard>/leftShift"},
        {"dashLeftAction", "<Keyboard>/a"},
        {"dashRightAction", "<Keyboard>/d"},
        {"twistLeftAction", "<Keyboard>/a"},
        {"twistRightAction", "<Keyboard>/d"},
        {"extendLeftAction", "<Keyboard>/q"},
        {"extendRightAction", "<Keyboard>/e"},
        {"bladeAngleUpAction", "<Mouse>/scroll/up"},
        {"bladeAngleDownAction", "<Mouse>/scroll/down"},
        {"randomizeInputsAction", "<Keyboard>/f1"}
    };

    public static Dictionary<string, ConfigEntry<string>> bindings_from_config;
    public override void Load()
    {
        HarmonyFileLog.Enabled = true;

        
        bindings_from_config = new Dictionary<string, ConfigEntry<string>>();
        foreach(var kvp in bindings_from_config_default){
            bindings_from_config[kvp.Key] = Config.Bind(
                "QuickChat",   // The section under which the option is shown
                $"{kvp.Key}",  // The key of the configuration option in the configuration file
                kvp.Value,     // The default value
                $"{kvp.Key}"); // Description of the option to show in the config file
        }

        // Plugin startup logic
        Log = base.Log;
        Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded! Patching methods...");
        _harmony.PatchAll();
        Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is all patched! Patched methods:");
        
        var originalMethods = Harmony.GetAllPatchedMethods();
        foreach (var method in originalMethods)
        {
            Log.LogInfo($" - {method.DeclaringType.FullName}.{method.Name}");
        }
    }
}