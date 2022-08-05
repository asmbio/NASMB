using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NASMB.GO
{
    public static class RuntimeInformationEx
    {

      public  static readonly OSPlatform[] SupportedPlatforms = { OSPlatform. Windows, OSPlatform.OSX, OSPlatform.Linux };
        //static string SupportedPlatformDescriptions() => string.Join("\n", PlatformPaths.Keys.Select(GetPlatformDesc));

        //static string GetPlatformDesc((OSPlatform OS, Architecture Arch) info) => $"{info.OS}; {info.Arch}";

       public static readonly OSPlatform CurrentOSPlatform = SupportedPlatforms.FirstOrDefault(RuntimeInformation. IsOSPlatform);
    }
}
