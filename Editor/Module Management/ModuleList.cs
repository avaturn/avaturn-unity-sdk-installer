using System.Collections.Generic;
using System.Linq;
using UnityEditor.PackageManager;

namespace Avaturn.Base.Editor
{
    /// <summary>
    ///     Class <c>ModuleList</c> is a static class that can be referenced to get the latest module version.
    /// </summary>
    public static class ModuleList
    {
        /// <summary>
        ///     A static list of all the required modules represented in an array of <c>ModuleInfo</c>.
        /// </summary>
        public static readonly ModuleInfo[] Modules =
        {
            new ModuleInfo
            {
                name = "com.attender.gltfast",
                gitUrl = "https://github.com/avaturn/glTFast.git",
                branch = "",
                version = "5.0.5"
            },
            new ModuleInfo
            {
                name = "com.avaturn.core",
                gitUrl = "https://github.com/avaturn/avaturn-unity-sdk-core.git",
                branch = "",
                version = "0.3.0"
            }
        };

        /// <summary>
        ///     Get installed modules from Modules list.
        /// </summary>
        /// <returns>A <see cref="Dictionary"/> of installed Unity Module information in the format of <c>Dictionary&lt;string: name, string: version&gt;</c>. </returns>
        public static Dictionary<string, string> GetInstalledModuleVersionDictionary()
        {
            PackageInfo[] packageList = ModuleInstaller.GetPackageList();

            var installedModules = new Dictionary<string, string>();

            foreach (ModuleInfo module in Modules)
            {
                if (packageList.Any(x => x.name == module.name))
                {
                    installedModules.Add(module.name, module.version);
                }
            }

            return installedModules;
        }
    }
}
