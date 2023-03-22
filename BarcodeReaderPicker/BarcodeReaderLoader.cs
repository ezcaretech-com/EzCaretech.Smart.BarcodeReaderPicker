using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BarcodeReaderPicker
{
    public class BarcodeReaderLoader
    {
        public static List<IBarcodeReaderPlugin> Plugins { get; set; }

        public static IBarcodeReaderPlugin GetPlugin(string name, string license = "")
        {
            IBarcodeReaderPlugin plugin = Plugins.Where(p => p.Name == name).FirstOrDefault();

            plugin?.SetLicense(license);

            return plugin ?? throw new Exception($"No plugin found with name '{name}'");
        }

        public void LoadPlugins(string path)
        {
            Plugins = new List<IBarcodeReaderPlugin>();

            LoadPluginAssemblyFile(path);

            LoadPluginInstance();
        }

        private void LoadPluginAssemblyFile(string path) =>
            Directory.GetFiles(path).ToList()
                .Where(file =>
                {
                    string fileName = Path.GetFileName(file);
                    return fileName.StartsWith("BarcodeReaderPicker.") && fileName.EndsWith("Adaptor.dll");
                })
                .ToList()
                .ForEach(file => Assembly.LoadFile(Path.GetFullPath(file)));

        private void LoadPluginInstance() =>
            AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(p => typeof(IBarcodeReaderPlugin).IsAssignableFrom(p) && p.IsClass)
                .ToList()
                .ForEach(type => Plugins.Add((IBarcodeReaderPlugin)Activator.CreateInstance(type)));
    }
}
