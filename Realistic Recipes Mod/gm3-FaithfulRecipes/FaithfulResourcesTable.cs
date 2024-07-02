using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Nautilus.Assets;
using Nautilus.Assets.PrefabTemplates;
using UnityEngine;

namespace RRM.FaithfulRecipes
{
    public static class FaithfulResourcesTable
    {
        public static void RegisterAllResources()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes()
                                .Where(t => t.Namespace == "RRM.RealisticRecipes.Items.Resources" && t.IsClass);

            foreach (var type in types)
            {
                var methodInfo = type.GetMethod("Register", BindingFlags.Public | BindingFlags.Static);
                if (methodInfo != null)
                {
                    methodInfo.Invoke(null, null);
                }
            }
        }
    }
}