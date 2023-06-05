using SnykWebAssembly.Core;
using System.Collections.Generic;

namespace SnykWebAssembly.ModuleOne
{
    public class Module : IModule
    {
        public string Name => "Marketing";
        public NavItem NavItem =>
            new NavItem { Name = "Marketing", Path = "/marketing" };
    }
}
