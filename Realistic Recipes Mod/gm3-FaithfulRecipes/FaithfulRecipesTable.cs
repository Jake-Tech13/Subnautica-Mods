using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using Nautilus.Crafting;
using Nautilus.Handlers;
using Nautilus.Assets;

namespace RRM.FaithfulRecipes
{
    public static class FaithfulRecipesTable
    {
        //regroup all functions so they are called at the same time by RegisterAllRecipes() inside Plugin.cs
        public static void RegisterAllRecipes()
        {
            BasicMaterialsRecipes_FR();
            AdvancedMaterialsRecipes_FR();
            ElectronicsRecipes_FR();
            DeployablesRecipes_FR();
            EquipmentRecipes_FR();
            ToolsRecipes_FR();
            VehiclesRecipes_FR();
            VehiclesUpgradesRecipes_FR();
            BasePiecesRecipes_FR();
            BaseExteriorModulesRecipes_FR();
            BaseInteriorPiecesRecipes_FR();
            BaseInteriorModulesRecipes_FR();
            BaseDecorations_FR();
        }

        //items are listed by alphabetical order inside all functions
        public static void BasicMaterialsRecipes_FR()
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

            Plugin.Logger.LogInfo("BasicMaterialsRecipes_FR loaded successfully !");
        }

        public static void AdvancedMaterialsRecipes_FR()
        {
            //aerogel recipe
            RecipeData aerogelRecipe = new RecipeData(
                new CraftData.Ingredient(TechType.Titanium, 32));
            CraftDataHandler.SetRecipeData(TechType.Aerogel, aerogelRecipe);

            Plugin.Logger.LogInfo("AdvancedMaterialsRecipes_FR loaded successfully !");
        }

        public static void ElectronicsRecipes_FR()
        {
            //advanced wiring kit recipe
            RecipeData advancedWiringKitRecipe = new RecipeData(
                new CraftData.Ingredient(TechType.Titanium, 13));
            CraftDataHandler.SetRecipeData(TechType.AdvancedWiringKit, advancedWiringKitRecipe);
            Plugin.Logger.LogInfo("advancedWiringKitRecipe_FR loaded successfully !");


        }

        public static void DeployablesRecipes_FR()
        {


            Plugin.Logger.LogInfo("ElectronicsRecipes_FR loaded successfully !");
        }

        public static void EquipmentRecipes_FR()
        {


            Plugin.Logger.LogInfo("EquipmentRecipes_FR loaded successfully !");
        }

        public static void ToolsRecipes_FR()
        {


            Plugin.Logger.LogInfo("ToolsRecipes_FR loaded successfully !");
        }

        public static void VehiclesRecipes_FR()
        {


            Plugin.Logger.LogInfo("VehiclesRecipes_FR loaded successfully !");
        }

        public static void VehiclesUpgradesRecipes_FR()
        {


            Plugin.Logger.LogInfo("VehiclesUpgradeRecipes_FR loaded successfully !");
        }

        public static void BasePiecesRecipes_FR()
        {


            Plugin.Logger.LogInfo("BasePiecesRecipes_FR loaded successfully !");
        }

        public static void BaseExteriorModulesRecipes_FR()
        {


            Plugin.Logger.LogInfo("BaseExteriorModulesRecipes_FR loaded successfully !");
        }

        public static void BaseInteriorPiecesRecipes_FR()
        {


            Plugin.Logger.LogInfo("BaseInteriorPiecesRecipes_FR loaded successfully !");
        }

        public static void BaseInteriorModulesRecipes_FR()
        {


            Plugin.Logger.LogInfo("BaseInteriorModulesRecipes_FR loaded successfully !");
        }

        public static void BaseDecorations_FR()
        {


            Plugin.Logger.LogInfo("BaseDecorationsRecipes_FR loaded successfully !");
        }
    }
}