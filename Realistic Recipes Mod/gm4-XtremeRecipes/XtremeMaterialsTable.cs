﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Nautilus.Assets;
using Nautilus.Assets.PrefabTemplates;
using UnityEngine;

namespace RRM.XtremeRLRecipes
{
    public class XtremeRLMaterialsTable
    {
        public static void RegisterAllMaterials()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes()
                                .Where(t => t.Namespace == "RRM.gm4-XtremeRecipes.Items.Materials" && t.IsClass);
            foreach (var type in types)
            {
                var methodInfo = type.GetMethod("Register", BindingFlags.Public | BindingFlags.Static);
                methodInfo?.Invoke(null, null);
            }
        }
    }
}