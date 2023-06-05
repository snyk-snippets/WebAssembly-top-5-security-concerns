using SnykWebAssembly.Core;
using System.Collections.Generic;

namespace SnykWebAssembly.ModuleHumanResources
{
    public class Module : IModule
    {
        public string Name => "Human Resources";
        public NavItem NavItem =>
            new NavItem { Name = "Human Resources", Path = "/humanresources" };
    }
}
