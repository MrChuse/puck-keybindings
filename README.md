# About
This is a BepInEx plugin that allows you to rebind your keys.
Keybindings may be configured in BepInEx\config\plugins.keybindings.cfg

# Installation
1. Have BepInEx installed on your Puck client. Instructions are in the Toaster's Rink Discord server.
2. Place the KeyBindings.dll file into your `Puck/BepInEx/plugins/` folder.

# Usage
Configure BepInEx\config\plugins.keybindings.cfg
Default entries:
- moveForwardAction - <Keyboard>/w
- moveBackwardAction - <Keyboard>/s
- moveLeftAction - <Keyboard>/a
- moveRightAction - <Keyboard>/d
- jumpAction - <Keyboard>/space
- lookAction - <Mouse>/rightButton
- trackAction - <Mouse>/leftButton
- stopAction - <Keyboard>/alt
- slideAction - <Keyboard>/leftCtrl
- talkAction - <Keyboard>/c
- stickAction - <Mouse>/delta
- sprintAction - <Keyboard>/leftShift
- dashLeftAction - <Keyboard>/a
- dashRightAction - <Keyboard>/d
- twistLeftAction - <Keyboard>/a
- twistRightAction - <Keyboard>/d
- extendLeftAction - <Keyboard>/q
- extendRightAction - <Keyboard>/e
- bladeAngleUpAction - <Mouse>/scroll/up
- bladeAngleDownAction - <Mouse>/scroll/down
- randomizeInputsAction - <Keyboard>/f1

# Compilation
- Create a lib folder inside repo folder
- Copy contents of BepInEx/interop into it
- `dotnet build`
- Alternatively, `build_and_move.bat` assumes that repo folder is inside your modded Puck folder. It builds, copies and starts Puck.exe.

## Get Involved
Want to get involved with the Puck modding scene? Join Toaster's Rink - http://discord.puckstats.io/