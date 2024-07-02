using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Nautilus.Assets;
using Nautilus.Assets.PrefabTemplates;
using UnityEngine;

namespace RRM.XtremeRLRecipes
{
    public static class XtremeRLToolsTable
    {
        public static void RegisterAllTools()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes()
                                .Where(t => t.Namespace == "RRM.RealisticRecipes.Items.Tools" && t.IsClass);

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