using Keen.Game2.Game.Plugins;
using Keen.VRage.Core;
using Keen.VRage.Library.Diagnostics;
using Keen.VRage.Library.Utils;

namespace SE2SimplePluginLoader
{
    public class Plugin : IPlugin, IDisposable
    {
        public const string Name = "SE2SimplePluginLoader";

        private List<PluginInstance> plugins = new List<PluginInstance>();

        public Plugin(PluginHost host)
        {
            Log.Default.Info($"[{Name}] Loading plugins.");
            foreach(string plugin in Directory.EnumerateFiles(Path.Combine(Singleton<VRageCore>.Instance.AppDataPath, "Plugins"), "*.dll"))
            {
                if (plugin.Contains("SE2SimplePluginLoader.dll") || plugin.Contains("0Harmony.dll"))
                {
                    continue;
                }

                if (PluginInstance.Create(plugin, out PluginInstance instance))
                {
                    plugins.Add(instance);
                }
            }

            foreach(PluginInstance instance in plugins)
            {
                instance.LoadPlugin(host);
            }

            Log.Default.Info($"[{Name}] Finished loading plugins.");
        }

        public void Dispose()
        {
            Log.Default.Info($"[{Name}] Unloading plugins.");

            foreach (PluginInstance instance in plugins)
            {
                instance.Dispose();
            }

            plugins.Clear();
            Log.Default.Info($"[{Name}] Unloaded plugins.");
        }
    }
}
