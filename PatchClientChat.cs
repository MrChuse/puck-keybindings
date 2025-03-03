using System;
using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KeyBindings;

public class PatchClientChat
{
    
    [HarmonyPatch(typeof(PlayerInput), nameof(PlayerInput.Start))]
    class PatchPlayerInputStart
    {
        static void Postfix(PlayerInput __instance)
        {
            Dictionary<string, InputAction> bindings = new Dictionary<string, InputAction>();
            bindings["moveForwardAction"] = __instance.moveForwardAction;
            bindings["moveBackwardAction"] = __instance.moveBackwardAction;
            bindings["moveLeftAction"] = __instance.moveLeftAction;
            bindings["moveRightAction"] = __instance.moveRightAction;
            bindings["jumpAction"] = __instance.jumpAction;
            bindings["lookAction"] = __instance.lookAction;
            bindings["trackAction"] = __instance.trackAction;
            bindings["stopAction"] = __instance.stopAction;
            bindings["slideAction"] = __instance.slideAction;
            bindings["talkAction"] = __instance.talkAction;
            bindings["stickAction"] = __instance.stickAction;
            bindings["sprintAction"] = __instance.sprintAction;
            bindings["dashLeftAction"] = __instance.dashLeftAction;
            bindings["dashRightAction"] = __instance.dashRightAction;
            bindings["twistLeftAction"] = __instance.twistLeftAction;
            bindings["twistRightAction"] = __instance.twistRightAction;
            bindings["extendLeftAction"] = __instance.extendLeftAction;
            bindings["extendRightAction"] = __instance.extendRightAction;
            bindings["bladeAngleUpAction"] = __instance.bladeAngleUpAction;
            bindings["bladeAngleDownAction"] = __instance.bladeAngleDownAction;
            bindings["randomizeInputsAction"] = __instance.randomizeInputsAction;

            // useful :)
            Plugin.Log.LogInfo($"Default action controls:");
            foreach (var kvp in bindings){ 
                foreach(var binding in kvp.Value.bindings.ToArray()){
                    Plugin.Log.LogInfo($"{kvp.Key} - {binding.path}");
                }
            }
            Plugin.Log.LogInfo($"Possible <mouse>/* controls:");
            var controls = InputSystem.FindControls("<mouse>/*");
            foreach(var binding in controls.ToArray()){
                Plugin.Log.LogInfo($"Found <mouse>/{binding.name} controls");
            }

            foreach (var kvp in Plugin.bindings_from_config){ // bruh I hate c#. Why can't I unpack key-value-pairs? literally spent 30 mins googling for it :(
                bindings[kvp.Key].ChangeBinding(0).Erase();
                bindings[kvp.Key].AddBinding(kvp.Value.BoxedValue.ToString());
            }
        }
    }
}