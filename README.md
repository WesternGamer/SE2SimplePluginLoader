# SE2SimplePluginLoader

A simple plugin loader for users to use until PluginLoader by [sepluginloader](https://github.com/sepluginloader) for Space Engineers 2 is released.

## Installation
1. Create a folder called `Plugins` in `%appdata%\SpaceEngineers2`
2. Add this the launch options `-plugins:C:\Users\YOUR_USERNAME\AppData\Roaming\SpaceEngineers2\Plugins\SE2SimplePluginLoader.dll`
3. To add plugins, put them in `%appdata%\SpaceEngineers2\Plugins`

Most plugins require Harmony in order to function; you can download it [here](https://github.com/pardeike/Harmony/releases/). Download the latest fat version and then put the `0Harmony.dll` file from the `net8.0` folder of the zip file in `%appdata%\SpaceEngineers2\Plugins`.

## Plugin Causing Game to Crash at Startup
The plugin may not be able to be loaded via this loader. Please use the `-plugins` arg instead. 

Ex: 
```
-plugins:C:\Users\YOUR_USERNAME\AppData\Roaming\SpaceEngineers2\Plugins\ThePlugin.dll
``` 

Ex 2: 
```
-plugins:C:\Users\YOUR_USERNAME\AppData\Roaming\SpaceEngineers2\Plugins\ThePlugin.dll;C:\Users\YOUR_USERNAME\AppData\Roaming\SpaceEngineers2\Plugins\TheSecondPlugin.dll
```
