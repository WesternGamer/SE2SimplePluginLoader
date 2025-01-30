using Keen.Game2.Game.Plugins;
using Keen.VRage.Library.Diagnostics;
using System.Reflection;

namespace SE2SimplePluginLoader
{
    internal class PluginInstance
    {
        private readonly Type entryPointType;
        private IPlugin pluginInstance;

        private PluginInstance(Type entryPointType) 
        {
            this.entryPointType = entryPointType;
        }

        public void LoadPlugin(PluginHost host)
        {
            try
            {
                pluginInstance = (IPlugin)Activator.CreateInstance(entryPointType, new object[] { host });
            }
            catch (MissingMethodException)
            {
                pluginInstance = (IPlugin)Activator.CreateInstance(entryPointType);
            }
        }

        public void Dispose()
        {
            if ((pluginInstance as IDisposable) != null)
            {
                (pluginInstance as IDisposable).Dispose();
            }
        }

        public static bool Create(string assemblyPath, out PluginInstance pluginInstance)
        {
            pluginInstance = null;

            Assembly assembly = Assembly.LoadFile(assemblyPath);

            Type entryPointType = assembly.GetTypes().FirstOrDefault(t => typeof(IPlugin).IsAssignableFrom(t));

            if (entryPointType == null)
            {
                Log.Default.Error($"[{Plugin.Name}]Skipping {assemblyPath} as it does not have a IPlugin");
                return false;
            }

            pluginInstance = new PluginInstance(entryPointType);
            return true;
        }
       
    }
}
