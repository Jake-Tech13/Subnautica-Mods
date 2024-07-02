using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using Nautilus.Crafting;
using Nautilus.Handlers;
using Nautilus.Assets;


namespace RRM.XtremeRLRecipes
{
    public static class XtremeRLRecipesTable
    {
        //regroup all functions so they are called at the same time by RegisterAllRecipes() inside Plugin.cs
        public static void RegisterAllRecipes()
        {
            BasicMaterialsRecipes_XR();
            AdvancedMaterialsRecipes_XR();
            ElectronicsRecipes_XR();
            DeployablesRecipes_XR();
            EquipmentRecipes_XR();
            ToolsRecipes_XR();
            VehiclesRecipes_XR();
            VehiclesUpgradesRecipes_XR();
            BasePiecesRecipes_XR();
            BaseExteriorModulesRecipes_XR();
            BaseInteriorPiecesRecipes_XR();
            BaseInteriorModulesRecipes_XR();
            BaseDecorations_XR();
        }

        //items are listed by alphabetical order inside all functions
        public static void BasicMaterialsRecipes_XR()
        {
            //bleach recipe
            RecipeData bleachRecipe = new RecipeData(
                new CraftData.Ingredient(TechType.Titanium, 32));
            CraftDataHandler.SetRecipeData(TechType.Bleach, bleachRecipe);

            //enameled glass recipe
            RecipeData enameledGlassRecipe = new RecipeData(
                new CraftData.Ingredient(TechType.Titanium, 32));
            CraftDataHandler.SetRecipeData(TechType.EnameledGlass, enameledGlassRecipe);

            //fiber mesh recipe
            RecipeData fiberMeshRecipe = new RecipeData(
                new CraftData.Ingredient(TechType.Titanium, 32));
            CraftDataHandler.SetRecipeData(TechType.FiberMesh, fiberMeshRecipe);

            //glass recipe
            RecipeData glassRecipe = new RecipeData(
                new CraftData.Ingredient(TechType.Titanium, 32));
            CraftDataHandler.SetRecipeData(TechType.Glass, glassRecipe);

            //lubricant recipe
            RecipeData lubricantRecipe = new RecipeData(
                new CraftData.Ingredient(TechType.Titanium, 32));
            CraftDataHandler.SetRecipeData(TechType.Lubricant, lubricantRecipe);

            //plasteel ingot recipe
            RecipeData plasteelIngotRecipe = new RecipeData(
                new CraftData.Ingredient(TechType.Titanium, 32));
            CraftDataHandler.SetRecipeData(TechType.PlasteelIngot, plasteelIngotRecipe);

            //silicone rubber recipe
            RecipeData siliconeRecipe = new RecipeData(
                new CraftData.Ingredient(TechType.Titanium, 32));
            CraftDataHandler.SetRecipeData(TechType.Silicone, siliconeRecipe);

            //titanium recipe (from scrap metal)
            RecipeData titaniumRecipe = new RecipeData(
                new CraftData.Ingredient(TechType.Titanium, 32));
            CraftDataHandler.SetRecipeData(TechType.Titanium, titaniumRecipe);

            //titanium ingot recipe
            RecipeData titaniumIngotRecipe = new RecipeData(
                new CraftData.Ingredient(TechType.Titanium, 32));
            CraftDataHandler.SetRecipeData(TechType.TitaniumIngot, titaniumIngotRecipe);

            Plugin.Logger.LogInfo("BasicMaterialsRecipes_XR loaded successfully !");
        }

        public static void AdvancedMaterialsRecipes_XR()
        {
            //aerogel recipe
            RecipeData aerogelRecipe = new RecipeData(
                new CraftData.Ingredient(TechType.Titanium, 64));
            CraftDataHandler.SetRecipeData(TechType.Aerogel, aerogelRecipe);

            Plugin.Logger.LogInfo("AdvancedMaterialsRecipes_XR loaded successfully !");
        }

        public static void ElectronicsRecipes_XR()
        {
            //advanced wiring kit recipe
            RecipeData advancedWiringKitRecipe = new RecipeData(
                new CraftData.Ingredient(TechType.Titanium, 13));
            CraftDataHandler.SetRecipeData(TechType.AdvancedWiringKit, advancedWiringKitRecipe);
            Plugin.Logger.LogInfo("advancedWiringKitRecipe_XR loaded successfully !");


        }

        public static void DeployablesRecipes_XR()
        {


            Plugin.Logger.LogInfo("ElectronicsRecipes_XR loaded successfully !");
        }

        public static void EquipmentRecipes_XR()
        {


            Plugin.Logger.LogInfo("EquipmentRecipes_XR loaded successfully !");
        }

        public static void ToolsRecipes_XR()
        {


            Plugin.Logger.LogInfo("ToolsRecipes_XR loaded successfully !");
        }

        public static void VehiclesRecipes_XR()
        {


            Plugin.Logger.LogInfo("VehiclesRecipes_XR loaded successfully !");
        }

        public static void VehiclesUpgradesRecipes_XR()
        {


            Plugin.Logger.LogInfo("VehiclesUpgradeRecipes_XR loaded successfully !");
        }

        public static void BasePiecesRecipes_XR()
        {


            Plugin.Logger.LogInfo("BasePiecesRecipes_XR loaded successfully !");
        }

        public static void BaseExteriorModulesRecipes_XR()
        {


            Plugin.Logger.LogInfo("BaseExteriorModulesRecipes_XR loaded successfully !");
        }

        public static void BaseInteriorPiecesRecipes_XR()
        {


            Plugin.Logger.LogInfo("BaseInteriorPiecesRecipes_XR loaded successfully !");
        }

        public static void BaseInteriorModulesRecipes_XR()
        {


            Plugin.Logger.LogInfo("BaseInteriorModulesRecipes_XR loaded successfully !");
        }

        public static void BaseDecorations_XR()
        {


            Plugin.Logger.LogInfo("BaseDecorationsRecipes_XR loaded successfully !");
        }
    }
}