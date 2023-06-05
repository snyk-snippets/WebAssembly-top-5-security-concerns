﻿using SnykWebAssembly.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

public static class ModuleDiscovery
{

    public static List<Assembly> GetAssemblies()
    {

        var assemblies = new List<Assembly>();

        string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        var files = Directory.GetFiles(path, "*.dll");

        foreach (string dll in files.Where(x => Path.GetFileName(x).StartsWith("SnykWebAssembly")))
        {
            assemblies.Add(Assembly.LoadFile(dll));
        }

        var returnAssemblies = assemblies
            .Where(w => w.GetTypes().Any(a => a.GetInterfaces().Contains(typeof(IModule))));

        return returnAssemblies.ToList();


    }

    public static IEnumerable<TypeInfo> GetTypes<T>()
    {
        return GetAssemblies().SelectMany(a => a.DefinedTypes.Where(x => x.GetInterfaces().Contains(typeof(T))));
    }

    public static IEnumerable<T> GetInstances<T>()
    {
        List<T> instances = new List<T>();

        foreach (Type implementation in GetTypes<T>())
        {
            if (!implementation.GetTypeInfo().IsAbstract)
            {
                T instance = (T)Activator.CreateInstance(implementation);

                instances.Add(instance);
            }
        }

        return instances;
    }

}


