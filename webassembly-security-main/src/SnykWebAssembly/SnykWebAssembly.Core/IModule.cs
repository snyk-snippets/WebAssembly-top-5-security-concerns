using System;
using System.Collections.Generic;

namespace SnykWebAssembly.Core
{
    public interface IModule
    {
        string Name { get; }

        NavItem NavItem { get; }
    }
}
