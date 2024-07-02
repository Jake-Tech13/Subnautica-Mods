using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using Nautilus.Crafting;
using Nautilus.Handlers;
using Nautilus.Assets;

namespace RRM.RealisticRecipes
{
    public static class RealisticRecipesTable
    {
        public static bool RegisterAllRecipes()
        {
            BasicMaterialsRecipes_RR();
            AdvancedMaterialsRecipes_RR();
            ElectronicsRecipes_RR();
            DeployablesRecipes_RR();
            EquipmentRecipes_RR();
            ToolsRecipes_RR();
            VehiclesRecipes_RR();
            UpgradeModulesRecipes_RR();
            BasePiecesRecipes_RR();
            BaseExteriorModulesRecipes_RR();
            BaseInteriorPiecesRecipes_RR();
            BaseInteriorModulesRecipes_RR();
            BaseDecorationsRecipes_RR();

            return false;
        }

        public static void BasicMaterialsRecipes_RR()
        {
            //bleach recipe
            RecipeData bleachRecipe = new(
                new CraftData.Ingredient(TechType.Salt),
                new CraftData.Ingredient(TechType.CoralChunk));
            CraftDataHandler.SetRecipeData(TechType.Bleach, bleachRecipe);

            //enameled glass recipe
            RecipeData enameledGlassRecipe = new(
                new CraftData.Ingredient(TechType.StalkerTooth),
                new CraftData.Ingredient(TechType.Glass));
            CraftDataHandler.SetRecipeData(TechType.EnameledGlass, enameledGlassRecipe);

            //fiber mesh recipe
            RecipeData fiberMeshRecipe = new(
                new CraftData.Ingredient(TechType.CreepvinePiece, 2));
            CraftDataHandler.SetRecipeData(TechType.FiberMesh, fiberMeshRecipe);

            //glass recipe
            RecipeData glassRecipe = new(
                new CraftData.Ingredient(TechType.Quartz, 2));
            CraftDataHandler.SetRecipeData(TechType.Glass, glassRecipe);

            //lubricant recipe
            RecipeData lubricantRecipe = new()
            {
                craftAmount = 0,
                Ingredients =
                {
                    new CraftData.Ingredient(TechType.CreepvineSeedCluster)
                },
                LinkedItems = Enumerable.Repeat(TechType.Lubricant, 2).ToList()
            };
            CraftDataHandler.SetRecipeData(TechType.Lubricant, lubricantRecipe);

            //plasteel ingot recipe
            RecipeData plasteelIngotRecipe = new(
                new CraftData.Ingredient(TechType.TitaniumIngot),
                new CraftData.Ingredient(TechType.Lithium, 3));
            //new CraftData.Ingredient(TechType.Lithium, 2),
            //new CraftData.Ingredient(TechType.Lead, 2));
            CraftDataHandler.SetRecipeData(TechType.PlasteelIngot, plasteelIngotRecipe);

            //silicone rubber recipe
            RecipeData siliconeRecipe = new()
            {
                craftAmount = 0,
                Ingredients =
                {
                    new CraftData.Ingredient(TechType.CreepvineSeedCluster)
                },
                LinkedItems = Enumerable.Repeat(TechType.Silicone, 2).ToList()
            };
            CraftDataHandler.SetRecipeData(TechType.Silicone, siliconeRecipe);

            //titanium ingot recipe
            RecipeData titaniumIngotRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 9));
            CraftDataHandler.SetRecipeData(TechType.TitaniumIngot, titaniumIngotRecipe);

            //titanium recipe (from scrap metal)
            RecipeData titaniumRecipe = new()
            {
                craftAmount = 0,
                Ingredients =
                {
                    new CraftData.Ingredient(TechType.ScrapMetal)
                },
                LinkedItems = Enumerable.Repeat(TechType.Titanium, 6).ToList()
            };
            CraftDataHandler.SetRecipeData(TechType.Titanium, titaniumRecipe);
            Plugin.Logger.LogInfo("BasicMaterialsRecipes_RR loaded successfully!");
        }

        public static void AdvancedMaterialsRecipes_RR()
        {
            //aerogel recipe
            RecipeData aerogelRecipe = new(
                new CraftData.Ingredient(TechType.JellyPlant),
                new CraftData.Ingredient(TechType.AluminumOxide));
            CraftDataHandler.SetRecipeData(TechType.Aerogel, aerogelRecipe);

            //benzene recipe
            RecipeData benzeneRecipe = new(
                new CraftData.Ingredient(TechType.BloodOil, 3),
                new CraftData.Ingredient(TechType.Glass));
            CraftDataHandler.SetRecipeData(TechType.Benzene, benzeneRecipe);

            //hatching enzyme recipe
            RecipeData hatchingEnzymesRecipe = new(
                new CraftData.Ingredient(TechType.EyesPlantSeed),
                new CraftData.Ingredient(TechType.TreeMushroomPiece),
                new CraftData.Ingredient(TechType.RedGreenTentacleSeed),
                new CraftData.Ingredient(TechType.SeaCrownSeed),
                new CraftData.Ingredient(TechType.KooshChunk),
                new CraftData.Ingredient(TechType.Glass));
            CraftDataHandler.SetRecipeData(TechType.HatchingEnzymes, hatchingEnzymesRecipe);

            //hydrocloric acid recipe
            RecipeData hydrocloricAcidRecipe = new(
                new CraftData.Ingredient(TechType.WhiteMushroom, 3),
                new CraftData.Ingredient(TechType.Salt),
                new CraftData.Ingredient(TechType.Glass));
            CraftDataHandler.SetRecipeData(TechType.HydrochloricAcid, hydrocloricAcidRecipe);

            //polyaniline recipe
            RecipeData polyanilineRecipe = new(
                new CraftData.Ingredient(TechType.Gold),
                new CraftData.Ingredient(TechType.HydrochloricAcid),
                new CraftData.Ingredient(TechType.Glass));
            CraftDataHandler.SetRecipeData(TechType.Polyaniline, polyanilineRecipe);

            //synthetic fibers recipe
            RecipeData syntheticFibersRecipe = new(
                new CraftData.Ingredient(TechType.Benzene),
                new CraftData.Ingredient(TechType.FiberMesh));
            CraftDataHandler.SetRecipeData(TechType.AramidFibers, syntheticFibersRecipe);

            Plugin.Logger.LogInfo("AdvancedMaterialsRecipes_RR loaded successfully!");
        }

        public static void ElectronicsRecipes_RR()
        {
            //advanced wiring kit recipe
            RecipeData advancedWiringKitRecipe = new(
                new CraftData.Ingredient(TechType.WiringKit),
                new CraftData.Ingredient(TechType.Gold, 2),
                new CraftData.Ingredient(TechType.ComputerChip));
            CraftDataHandler.SetRecipeData(TechType.AdvancedWiringKit, advancedWiringKitRecipe);

            //battery recipe
            RecipeData batteryRecipe = new(
                new CraftData.Ingredient(TechType.AcidMushroom, 2),
                new CraftData.Ingredient(TechType.Copper),
                new CraftData.Ingredient(TechType.Titanium));
            CraftDataHandler.SetRecipeData(TechType.Battery, batteryRecipe);

            //computer chip recipe
            RecipeData computerChipRecipe = new(
                new CraftData.Ingredient(TechType.JeweledDiskPiece, 2),
                new CraftData.Ingredient(TechType.Gold),
                new CraftData.Ingredient(TechType.CopperWire));
            CraftDataHandler.SetRecipeData(TechType.ComputerChip, computerChipRecipe);

            //copper wire recipe
            RecipeData copperWireRecipe = new(
                new CraftData.Ingredient(TechType.Copper, 2),
                new CraftData.Ingredient(TechType.Silicone));
            CraftDataHandler.SetRecipeData(TechType.CopperWire, copperWireRecipe);

            //ion battery recipe
            RecipeData ionBatteryRecipe = new(
                new CraftData.Ingredient(TechType.PrecursorIonCrystal),
                new CraftData.Ingredient(TechType.Gold),
                new CraftData.Ingredient(TechType.Silver),
                new CraftData.Ingredient(TechType.Titanium));
            CraftDataHandler.SetRecipeData(TechType.PrecursorIonBattery, ionBatteryRecipe);

            //ion power cell recipe
            RecipeData ionPowerCellRecipe = new(
                new CraftData.Ingredient(TechType.PrecursorIonBattery, 2),
                new CraftData.Ingredient(TechType.Silicone),
                new CraftData.Ingredient(TechType.Titanium, 2));
            CraftDataHandler.SetRecipeData(TechType.PrecursorIonPowerCell, ionPowerCellRecipe);

            //lithium-ion battery recipe
            RecipeData lithiumIonBatteryRecipe = new(
                new CraftData.Ingredient(TechType.AcidMushroom, 2),
                new CraftData.Ingredient(TechType.Copper),
            new CraftData.Ingredient(TechType.Lithium),
                new CraftData.Ingredient(TechType.Titanium));
            CraftDataHandler.SetRecipeData(TechType.LithiumIonBattery, lithiumIonBatteryRecipe);


            //power cell battery recipe
            RecipeData powerCellRecipe = new(
                new CraftData.Ingredient(TechType.Battery, 2),
                new CraftData.Ingredient(TechType.Silicone),
                new CraftData.Ingredient(TechType.Titanium));
            CraftDataHandler.SetRecipeData(TechType.PowerCell, powerCellRecipe);

            //reactor rod recipe
            RecipeData reactorRodRecipe = new(
                new CraftData.Ingredient(TechType.UraniniteCrystal, 3),
                new CraftData.Ingredient(TechType.Lead, 2),
                new CraftData.Ingredient(TechType.Titanium, 2),
                new CraftData.Ingredient(TechType.EnameledGlass, 2));
            CraftDataHandler.SetRecipeData(TechType.ReactorRod, reactorRodRecipe);

            //wiring kit recipe
            RecipeData wiringKitRecipe = new(
                new CraftData.Ingredient(TechType.Silver, 2),
                new CraftData.Ingredient(TechType.Copper),
                new CraftData.Ingredient(TechType.Titanium));
            CraftDataHandler.SetRecipeData(TechType.WiringKit, wiringKitRecipe);

            Plugin.Logger.LogInfo("ElectronicsRecipes_RR loaded successfully!");
        }

        public static void DeployablesRecipes_RR()
        {
            //beacon recipe
            RecipeData beaconRecipe = new(
                new CraftData.Ingredient(TechType.CopperWire),
                new CraftData.Ingredient(TechType.Titanium));
            CraftDataHandler.SetRecipeData(TechType.Beacon, beaconRecipe);

            //camera drone recipe
            RecipeData cameraDroneRecipe = new(
                new CraftData.Ingredient(TechType.ComputerChip),
                new CraftData.Ingredient(TechType.Battery),
                new CraftData.Ingredient(TechType.Glass),
                new CraftData.Ingredient(TechType.Titanium),
                new CraftData.Ingredient(TechType.CopperWire));
            CraftDataHandler.SetRecipeData(TechType.MapRoomCamera, cameraDroneRecipe);

            //creature decoy recipe
            RecipeData creatureDecoyRecipe = new()
            {
                craftAmount = 0,
                Ingredients =
                {
                    new CraftData.Ingredient(TechType.Titanium, 6),
                    new CraftData.Ingredient(TechType.WiringKit, 2)
                },
                LinkedItems = Enumerable.Repeat(TechType.CyclopsDecoy, 3).ToList()
            };
            CraftDataHandler.SetRecipeData(TechType.CyclopsDecoy, creatureDecoyRecipe);

            //grav trap recipe
            RecipeData gravTrapRecipe = new(
                new CraftData.Ingredient(TechType.Battery),
                new CraftData.Ingredient(TechType.Copper),
                new CraftData.Ingredient(TechType.Titanium, 2));
            CraftDataHandler.SetRecipeData(TechType.Gravsphere, gravTrapRecipe);

            //mobile vehicle bay recipe
            RecipeData mobileVehicleBayRecipe = new(
                new CraftData.Ingredient(TechType.TitaniumIngot),
                new CraftData.Ingredient(TechType.Lubricant),
                new CraftData.Ingredient(TechType.PowerCell),
                new CraftData.Ingredient(TechType.WiringKit),
                new CraftData.Ingredient(TechType.ComputerChip),
                new CraftData.Ingredient(TechType.Silicone, 4));
            CraftDataHandler.SetRecipeData(TechType.Constructor, mobileVehicleBayRecipe);

            //seaglide recipe
            RecipeData seaglideRecipe = new(
                new CraftData.Ingredient(TechType.Battery),
                new CraftData.Ingredient(TechType.Lubricant),
                new CraftData.Ingredient(TechType.CopperWire, 2),
                new CraftData.Ingredient(TechType.Titanium),
                new CraftData.Ingredient(TechType.Glass));
            CraftDataHandler.SetRecipeData(TechType.Seaglide, seaglideRecipe);

            //waterproof locker recipe
            RecipeData waterproofLockerRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 4),
                new CraftData.Ingredient(TechType.Silicone, 2));
            CraftDataHandler.SetRecipeData(TechType.SmallStorage, waterproofLockerRecipe);

            Plugin.Logger.LogInfo("DeployablesRecipes_RR loaded successfully!");
        }

        public static void EquipmentRecipes_RR()
        {
            //blue tablet recipe
            RecipeData blueTabletRecipe = new(
                new CraftData.Ingredient(TechType.PrecursorIonCrystal),
                new CraftData.Ingredient(TechType.Kyanite, 2));
            CraftDataHandler.SetRecipeData(TechType.PrecursorKey_Blue, blueTabletRecipe);

            //compass recipe
            RecipeData compassRecipe = new(
                new CraftData.Ingredient(TechType.CopperWire),
                new CraftData.Ingredient(TechType.WiringKit));
            CraftDataHandler.SetRecipeData(TechType.Compass, compassRecipe);

            //fins recipe
            RecipeData finsRecipe = new(
                new CraftData.Ingredient(TechType.Silicone, 2));
            CraftDataHandler.SetRecipeData(TechType.Fins, finsRecipe);

            //fire extinguisher recipe
            RecipeData fireExtinguisherRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 3));
            CraftDataHandler.SetRecipeData(TechType.FireExtinguisher, fireExtinguisherRecipe);

            //first aid kit recipe
            RecipeData firstAidKitRecipe = new(
                new CraftData.Ingredient(TechType.FiberMesh));
            CraftDataHandler.SetRecipeData(TechType.FirstAidKit, firstAidKitRecipe);

            //floating air pump recipe
            RecipeData floatingAirPumpRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 2));
            CraftDataHandler.SetRecipeData(TechType.PipeSurfaceFloater, floatingAirPumpRecipe);

            //gas torpedo recipe
            RecipeData gasTorpedoRecipe = new(
                new CraftData.Ingredient(TechType.Titanium),
                new CraftData.Ingredient(TechType.GasPod));
            CraftDataHandler.SetRecipeData(TechType.GasTorpedo, gasTorpedoRecipe);

            //high capacity O2 tank recipe
            RecipeData highCapacityTankRecipe = new(
                new CraftData.Ingredient(TechType.Tank),
                new CraftData.Ingredient(TechType.Glass, 2),
                new CraftData.Ingredient(TechType.Titanium, 4),
                new CraftData.Ingredient(TechType.Silver));
            CraftDataHandler.SetRecipeData(TechType.DoubleTank, highCapacityTankRecipe);

            //lightweight high capacity tank recipe
            RecipeData lightweightHighCapacityTankRecipe = new(
                new CraftData.Ingredient(TechType.DoubleTank),
                new CraftData.Ingredient(TechType.PlasteelIngot));
            CraftDataHandler.SetRecipeData(TechType.PlasteelTank, lightweightHighCapacityTankRecipe);

            //orange tablet recipe
            RecipeData orangeTabletRecipe = new(
                new CraftData.Ingredient(TechType.PrecursorIonCrystal),
                new CraftData.Ingredient(TechType.Nickel, 2));
            CraftDataHandler.SetRecipeData(TechType.PrecursorKey_Orange, orangeTabletRecipe);

            //pipe recipe
            RecipeData pipeRecipe = new()
            {
                craftAmount = 0,
                Ingredients =
                {
                    new CraftData.Ingredient(TechType.Titanium, 2)
                },
                LinkedItems = Enumerable.Repeat(TechType.Pipe, 5).ToList()
            };
            CraftDataHandler.SetRecipeData(TechType.Pipe, pipeRecipe);

            //purple tablet recipe
            RecipeData purpleTabletRecipe = new(
                new CraftData.Ingredient(TechType.PrecursorIonCrystal),
                new CraftData.Ingredient(TechType.Diamond, 2));
            CraftDataHandler.SetRecipeData(TechType.PrecursorKey_Purple, purpleTabletRecipe);

            //radiation suit recipe
            RecipeData radiationSuitRecipe = new()
            {
                craftAmount = 0,
                Ingredients =
                {
                    new CraftData.Ingredient(TechType.FiberMesh, 2),
                    new CraftData.Ingredient(TechType.Lead, 2)
                },
                LinkedItems =
                {
                    TechType.RadiationSuit,
                    TechType.RadiationGloves,
                    TechType.RadiationHelmet
                }
            };
            CraftDataHandler.SetRecipeData(TechType.RadiationSuit, radiationSuitRecipe);

            //rebreather recipe
            RecipeData rebreatherRecipe = new(
                new CraftData.Ingredient(TechType.WiringKit),
                new CraftData.Ingredient(TechType.FiberMesh));
            CraftDataHandler.SetRecipeData(TechType.Rebreather, rebreatherRecipe);

            //reinforced dive suit recipe
            RecipeData reinforcedDiveSuitRecipe = new()
            {
                craftAmount = 0,
                Ingredients =
                {
                    new CraftData.Ingredient(TechType.AramidFibers),
                    new CraftData.Ingredient(TechType.Diamond, 2),
                    new CraftData.Ingredient(TechType.Titanium, 2)
                },
                LinkedItems =
                {
                    TechType.ReinforcedDiveSuit,
                    TechType.ReinforcedGloves
                }
            };
            CraftDataHandler.SetRecipeData(TechType.ReinforcedDiveSuit, reinforcedDiveSuitRecipe);

            //scanner room HUD chip recipe
            RecipeData scannerRoomChipRecipe = new(
                new CraftData.Ingredient(TechType.ComputerChip),
                new CraftData.Ingredient(TechType.Magnetite));
            CraftDataHandler.SetRecipeData(TechType.MapRoomHUDChip, scannerRoomChipRecipe);

            //standard O2 tank recipe
            RecipeData standardTankRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 3));
            CraftDataHandler.SetRecipeData(TechType.Tank, standardTankRecipe);

            //swim charge fins recipe
            RecipeData swimChargeFinsRecipe = new(
                new CraftData.Ingredient(TechType.Fins),
                new CraftData.Ingredient(TechType.Polyaniline),
                new CraftData.Ingredient(TechType.WiringKit));
            CraftDataHandler.SetRecipeData(TechType.SwimChargeFins, swimChargeFinsRecipe);

            //ultra glide fins recipe
            RecipeData ultraGlideFinsRecipe = new(
                new CraftData.Ingredient(TechType.Fins),
                new CraftData.Ingredient(TechType.Silicone, 2),
                new CraftData.Ingredient(TechType.Titanium),
                new CraftData.Ingredient(TechType.Lithium));
            CraftDataHandler.SetRecipeData(TechType.UltraGlideFins, ultraGlideFinsRecipe);

            //ultra high capacity tank recipe
            RecipeData ultraHighCapacityTankRecipe = new(
                new CraftData.Ingredient(TechType.DoubleTank),
                new CraftData.Ingredient(TechType.Lithium, 4));
            CraftDataHandler.SetRecipeData(TechType.HighCapacityTank, ultraHighCapacityTankRecipe);

            //vortex torpedo recipe
            RecipeData vortexTorpedoRecipe = new(
                new CraftData.Ingredient(TechType.Titanium),
                new CraftData.Ingredient(TechType.Magnetite));
            CraftDataHandler.SetRecipeData(TechType.WhirlpoolTorpedo, vortexTorpedoRecipe);

            //water filtration suit recipe
            RecipeData waterFiltrationSuitRecipe = new(
                new CraftData.Ingredient(TechType.AramidFibers),
                new CraftData.Ingredient(TechType.Aerogel),
                new CraftData.Ingredient(TechType.CopperWire));
            CraftDataHandler.SetRecipeData(TechType.WaterFiltrationSuit, waterFiltrationSuitRecipe);

            Plugin.Logger.LogInfo("EquipmentRecipes_RR loaded successfully!");
        }

        public static void ToolsRecipes_RR()
        {
            //air bladder recipe
            RecipeData airBladderRecipe = new(
                new CraftData.Ingredient(TechType.Silicone),
                new CraftData.Ingredient(TechType.Bladderfish));
            CraftDataHandler.SetRecipeData(TechType.AirBladder, airBladderRecipe);

            //flare recipe
            RecipeData flareRecipe = new()
            {
                craftAmount = 0,
                Ingredients =
                {
                    new CraftData.Ingredient(TechType.Titanium, 2)
                },
                LinkedItems = Enumerable.Repeat(TechType.Flare, 5).ToList()
            };
            CraftDataHandler.SetRecipeData(TechType.Flare, flareRecipe);

            //flashlight recipe
            RecipeData flashlightRecipe = new(
                new CraftData.Ingredient(TechType.Battery),
                new CraftData.Ingredient(TechType.Glass));
            CraftDataHandler.SetRecipeData(TechType.Flashlight, flashlightRecipe);

            //habitat builder recipe
            RecipeData habitatBuilderRecipe = new(
                new CraftData.Ingredient(TechType.WiringKit),
                new CraftData.Ingredient(TechType.ComputerChip),
                new CraftData.Ingredient(TechType.Battery));
            CraftDataHandler.SetRecipeData(TechType.Builder, habitatBuilderRecipe);

            //laser cutter recipe
            RecipeData laserCutterRecipe = new(
                new CraftData.Ingredient(TechType.Diamond, 2),
                new CraftData.Ingredient(TechType.Battery),
                new CraftData.Ingredient(TechType.Titanium),
                new CraftData.Ingredient(TechType.CrashPowder));
            CraftDataHandler.SetRecipeData(TechType.LaserCutter, laserCutterRecipe);

            //light stick recipe
            RecipeData lightStickRecipe = new(
                new CraftData.Ingredient(TechType.Battery),
                new CraftData.Ingredient(TechType.Titanium),
                new CraftData.Ingredient(TechType.Glass));
            CraftDataHandler.SetRecipeData(TechType.LEDLight, lightStickRecipe);

            //pathfinder tool recipe
            RecipeData pathfinderToolRecipe = new(
                new CraftData.Ingredient(TechType.CreepvineSeedCluster, 2),
                new CraftData.Ingredient(TechType.CopperWire),
                new CraftData.Ingredient(TechType.Titanium));
            CraftDataHandler.SetRecipeData(TechType.DiveReel, pathfinderToolRecipe);

            //propulsion canon recipe
            RecipeData propulsionCanonRecipe = new(
                new CraftData.Ingredient(TechType.WiringKit),
                new CraftData.Ingredient(TechType.Battery),
                new CraftData.Ingredient(TechType.Titanium));
            CraftDataHandler.SetRecipeData(TechType.PropulsionCannon, propulsionCanonRecipe);

            //repair tool recipe
            RecipeData repairToolRecipe = new(
                new CraftData.Ingredient(TechType.Silicone),
                new CraftData.Ingredient(TechType.CrashPowder),
                new CraftData.Ingredient(TechType.Titanium));
            CraftDataHandler.SetRecipeData(TechType.Welder, repairToolRecipe);

            //repulsion canon recipe
            RecipeData repulsionCanonRecipe = new(
                new CraftData.Ingredient(TechType.PropulsionCannon),
                new CraftData.Ingredient(TechType.ComputerChip),
                new CraftData.Ingredient(TechType.Magnetite, 2));
            CraftDataHandler.SetRecipeData(TechType.RepulsionCannon, repulsionCanonRecipe);

            //scanner recipe
            RecipeData scannerRecipe = new(
                new CraftData.Ingredient(TechType.Battery),
                new CraftData.Ingredient(TechType.Titanium));
            CraftDataHandler.SetRecipeData(TechType.Scanner, scannerRecipe);

            //stasis rifle recipe
            RecipeData stasisRifleRecipe = new(
                new CraftData.Ingredient(TechType.ComputerChip),
                new CraftData.Ingredient(TechType.Battery),
                new CraftData.Ingredient(TechType.Titanium),
                new CraftData.Ingredient(TechType.Magnetite, 2));
            CraftDataHandler.SetRecipeData(TechType.StasisRifle, stasisRifleRecipe);

            //survival knife recipe
            RecipeData survivalKnifeRecipe = new(
                new CraftData.Ingredient(TechType.Silicone),
                new CraftData.Ingredient(TechType.Titanium));
            CraftDataHandler.SetRecipeData(TechType.Knife, survivalKnifeRecipe);

            //thermoblade recipe
            RecipeData thermobladeRecipe = new(
                new CraftData.Ingredient(TechType.Knife),
                new CraftData.Ingredient(TechType.Battery));
            CraftDataHandler.SetRecipeData(TechType.HeatBlade, thermobladeRecipe);

            Plugin.Logger.LogInfo("ToolsRecipes_RR loaded successfully!");
        }

        public static void VehiclesRecipes_RR()
        {
            //cyclops recipe
            RecipeData cyclopsRecipe = new(
                new CraftData.Ingredient(TechType.PlasteelIngot, 3),
                new CraftData.Ingredient(TechType.EnameledGlass, 3),
                new CraftData.Ingredient(TechType.Lubricant),
                new CraftData.Ingredient(TechType.AdvancedWiringKit),
                new CraftData.Ingredient(TechType.Lead, 3));
            CraftDataHandler.SetRecipeData(TechType.Cyclops, cyclopsRecipe);

            //PRAWN suit recipe
            RecipeData prawnSuitRecipe = new(
                new CraftData.Ingredient(TechType.PlasteelIngot, 2),
                new CraftData.Ingredient(TechType.Aerogel, 2),
                new CraftData.Ingredient(TechType.EnameledGlass),
                new CraftData.Ingredient(TechType.Diamond, 2),
                new CraftData.Ingredient(TechType.Lead, 2));
            CraftDataHandler.SetRecipeData(TechType.Exosuit, prawnSuitRecipe);

            //seamoth recipe
            RecipeData seamothRecipe = new(
                new CraftData.Ingredient(TechType.TitaniumIngot),
                new CraftData.Ingredient(TechType.PowerCell),
                new CraftData.Ingredient(TechType.Glass, 2),
                new CraftData.Ingredient(TechType.Lubricant),
                new CraftData.Ingredient(TechType.Lead));
            CraftDataHandler.SetRecipeData(TechType.Seamoth, seamothRecipe);

            //neptune launch platform recipe
            RecipeData rocketBaseRecipe = new(
                new CraftData.Ingredient(TechType.Lead, 4),
                new CraftData.Ingredient(TechType.TitaniumIngot, 2),
                new CraftData.Ingredient(TechType.ComputerChip));
            CraftDataHandler.SetRecipeData(TechType.RocketBase, rocketBaseRecipe);

            //neptune gantry recipe
            RecipeData rocketGantryRecipe = new(
                new CraftData.Ingredient(TechType.PlasteelIngot),
                new CraftData.Ingredient(TechType.CopperWire),
                new CraftData.Ingredient(TechType.Lubricant));
            CraftDataHandler.SetRecipeData(TechType.RocketBaseLadder, rocketGantryRecipe);

            //neptune boosters recipe
            RecipeData rocketBoostersRecipe = new(
                new CraftData.Ingredient(TechType.PlasteelIngot),
                new CraftData.Ingredient(TechType.Nickel, 3),
                new CraftData.Ingredient(TechType.Aerogel, 2),
                new CraftData.Ingredient(TechType.AdvancedWiringKit));
            CraftDataHandler.SetRecipeData(TechType.RocketStage1, rocketBoostersRecipe);

            //neptune fuel reserve recipe
            RecipeData rocketFuelReserveRecipe = new(
                new CraftData.Ingredient(TechType.PlasteelIngot),
                new CraftData.Ingredient(TechType.Sulphur, 4),
                new CraftData.Ingredient(TechType.Kyanite, 4),
                new CraftData.Ingredient(TechType.PrecursorIonPowerCell, 2));
            CraftDataHandler.SetRecipeData(TechType.RocketStage2, rocketFuelReserveRecipe);

            //neptune cockpit recipe
            RecipeData rocketCockpitRecipe = new(
                new CraftData.Ingredient(TechType.CyclopsShieldModule),
                new CraftData.Ingredient(TechType.PlasteelIngot),
                new CraftData.Ingredient(TechType.EnameledGlass),
                new CraftData.Ingredient(TechType.ComputerChip));
            CraftDataHandler.SetRecipeData(TechType.RocketStage3, rocketCockpitRecipe);

            Plugin.Logger.LogInfo("VehiclesRecipes_RR loaded successfully!");
        }

        public static void UpgradeModulesRecipes_RR()
        {
            //cyclops decoy tube upgrade recipe
            RecipeData cyclopsDecoyTubeUpgradeRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 3),
                new CraftData.Ingredient(TechType.Lithium, 2),
                new CraftData.Ingredient(TechType.Aerogel));
            CraftDataHandler.SetRecipeData(TechType.CyclopsDecoyModule, cyclopsDecoyTubeUpgradeRecipe);

            //cyclops depth module MK1 recipe
            RecipeData cyclopsDepthModuleMK1Recipe = new(
                new CraftData.Ingredient(TechType.PlasteelIngot),
                new CraftData.Ingredient(TechType.AluminumOxide, 3));
            CraftDataHandler.SetRecipeData(TechType.CyclopsHullModule1, cyclopsDepthModuleMK1Recipe);

            //cyclops depth module MK2 recipe
            RecipeData cyclopsDepthModuleMK2Recipe = new(
                new CraftData.Ingredient(TechType.CyclopsHullModule1),
            new CraftData.Ingredient(TechType.PlasteelIngot),
                new CraftData.Ingredient(TechType.Nickel, 3));
            CraftDataHandler.SetRecipeData(TechType.CyclopsHullModule2, cyclopsDepthModuleMK2Recipe);

            //cyclops depth module MK3 recipe
            RecipeData cyclopsDepthModuleMK3Recipe = new(
                new CraftData.Ingredient(TechType.CyclopsHullModule2),
            new CraftData.Ingredient(TechType.PlasteelIngot),
                new CraftData.Ingredient(TechType.Kyanite, 3));
            CraftDataHandler.SetRecipeData(TechType.CyclopsHullModule3, cyclopsDepthModuleMK3Recipe);

            //cyclops docking bay repair module recipe
            RecipeData cyclopsDockingBayRepairModuleRecipe = new(
                new CraftData.Ingredient(TechType.Welder),
                new CraftData.Ingredient(TechType.CopperWire));
            CraftDataHandler.SetRecipeData(TechType.CyclopsSeamothRepairModule, cyclopsDockingBayRepairModuleRecipe);

            //cyclops engine efficiency module recipe
            RecipeData cyclopsEngineEfficiencyModuleRecipe = new(
                new CraftData.Ingredient(TechType.ComputerChip),
                new CraftData.Ingredient(TechType.Benzene),
                new CraftData.Ingredient(TechType.Polyaniline));
            CraftDataHandler.SetRecipeData(TechType.PowerUpgradeModule, cyclopsEngineEfficiencyModuleRecipe);

            //cyclops fire suppression module recipe
            RecipeData cyclopsFireSuppressionModuleRecipe = new(
                new CraftData.Ingredient(TechType.Aerogel, 2),
                new CraftData.Ingredient(TechType.Sulphur, 2));
            CraftDataHandler.SetRecipeData(TechType.CyclopsFireSuppressionModule, cyclopsFireSuppressionModuleRecipe);

            //cyclops shield generator recipe
            RecipeData cyclopsShieldGeneratorRecipe = new(
                new CraftData.Ingredient(TechType.AdvancedWiringKit),
                new CraftData.Ingredient(TechType.Polyaniline),
                new CraftData.Ingredient(TechType.PowerCell));
            CraftDataHandler.SetRecipeData(TechType.CyclopsShieldModule, cyclopsShieldGeneratorRecipe);

            //cyclops sonar upgrade recipe
            RecipeData cyclopsSonarUpgradeRecipe = new(
                new CraftData.Ingredient(TechType.ComputerChip),
                new CraftData.Ingredient(TechType.Magnetite));
            CraftDataHandler.SetRecipeData(TechType.CyclopsSonarModule, cyclopsSonarUpgradeRecipe);

            //cyclops thermal reactor module recipe
            RecipeData cyclopsThermalReactorModuleRecipe = new(
                new CraftData.Ingredient(TechType.Polyaniline, 2),
                new CraftData.Ingredient(TechType.Kyanite, 4),
                new CraftData.Ingredient(TechType.WiringKit));
            CraftDataHandler.SetRecipeData(TechType.CyclopsThermalReactorModule, cyclopsThermalReactorModuleRecipe);

            //(seamoth/PRAWN) engine efficiency module recipe
            RecipeData engineEfficiencyModuleRecipe = new(
                new CraftData.Ingredient(TechType.ComputerChip),
                new CraftData.Ingredient(TechType.Polyaniline));
            CraftDataHandler.SetRecipeData(TechType.VehiclePowerUpgradeModule, engineEfficiencyModuleRecipe);

            //hull reinforcement recipe
            RecipeData hullReinforcementRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 3),
                new CraftData.Ingredient(TechType.Lithium),
                new CraftData.Ingredient(TechType.Diamond));
            CraftDataHandler.SetRecipeData(TechType.VehicleArmorPlating, hullReinforcementRecipe);

            //PRAWN suit depth module MK1 recipe
            RecipeData prawnSuitDepthModuleMK1Recipe = new(
                new CraftData.Ingredient(TechType.PlasteelIngot),
                new CraftData.Ingredient(TechType.Nickel, 3),
                new CraftData.Ingredient(TechType.AluminumOxide, 2));
            CraftDataHandler.SetRecipeData(TechType.ExoHullModule1, prawnSuitDepthModuleMK1Recipe);

            //PRAWN suit depth module MK2 recipe
            RecipeData prawnSuitDepthModuleMK2Recipe = new(
                new CraftData.Ingredient(TechType.ExoHullModule1),
                new CraftData.Ingredient(TechType.Titanium, 5),
                new CraftData.Ingredient(TechType.Lithium, 2),
                new CraftData.Ingredient(TechType.Kyanite, 3));
            CraftDataHandler.SetRecipeData(TechType.ExoHullModule2, prawnSuitDepthModuleMK2Recipe);

            //PRAWN suit drill arm recipe
            RecipeData prawnSuitDrillArmRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 5),
                new CraftData.Ingredient(TechType.Lithium),
                new CraftData.Ingredient(TechType.Diamond, 4));
            CraftDataHandler.SetRecipeData(TechType.ExosuitDrillArmModule, prawnSuitDrillArmRecipe);

            //PRAWN suit grappling arm recipe
            RecipeData prawnSuitGrapplingArmRecipe = new(
                new CraftData.Ingredient(TechType.AdvancedWiringKit),
                new CraftData.Ingredient(TechType.Titanium, 5),
                new CraftData.Ingredient(TechType.Lithium),
                new CraftData.Ingredient(TechType.Benzene));
            CraftDataHandler.SetRecipeData(TechType.ExosuitGrapplingArmModule, prawnSuitGrapplingArmRecipe);

            //PRAWN suit jump jet recipe
            RecipeData prawnSuitJumpJetRecipe = new(
                new CraftData.Ingredient(TechType.Nickel, 2),
                new CraftData.Ingredient(TechType.Sulphur, 3),
                new CraftData.Ingredient(TechType.Titanium, 5),
                new CraftData.Ingredient(TechType.Lithium));
            CraftDataHandler.SetRecipeData(TechType.ExosuitJetUpgradeModule, prawnSuitJumpJetRecipe);

            //PRAWN suit propulsion cannon recipe
            RecipeData prawnSuitPropulsionCanonRecipe = new(
                new CraftData.Ingredient(TechType.ComputerChip),
                new CraftData.Ingredient(TechType.Titanium, 5),
                new CraftData.Ingredient(TechType.Lithium),
                new CraftData.Ingredient(TechType.Magnetite, 2));
            CraftDataHandler.SetRecipeData(TechType.ExosuitPropulsionArmModule, prawnSuitPropulsionCanonRecipe);

            //PRAWN suit thermal reactor recipe
            RecipeData prawnSuitThermalReactorRecipe = new(
                new CraftData.Ingredient(TechType.Kyanite, 2),
                new CraftData.Ingredient(TechType.Polyaniline, 2),
                new CraftData.Ingredient(TechType.WiringKit));
            CraftDataHandler.SetRecipeData(TechType.ExosuitThermalReactorModule, prawnSuitThermalReactorRecipe);

            //PRAWN suit torpedo arm recipe
            RecipeData prawnSuitTorpedoArmRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 5),
                new CraftData.Ingredient(TechType.Lithium),
                new CraftData.Ingredient(TechType.Aerogel));
            CraftDataHandler.SetRecipeData(TechType.ExosuitTorpedoArmModule, prawnSuitTorpedoArmRecipe);

            //scanner room range upgrade recipe
            RecipeData scannerRoomRangeUpgradeRecipe = new(
                new CraftData.Ingredient(TechType.Copper),
                new CraftData.Ingredient(TechType.Magnetite));
            CraftDataHandler.SetRecipeData(TechType.MapRoomUpgradeScanRange, scannerRoomRangeUpgradeRecipe);

            //scanner room speed upgrade recipe
            RecipeData scannerRoomSpeedUpgradeRecipe = new(
                new CraftData.Ingredient(TechType.Silver),
                new CraftData.Ingredient(TechType.Gold));
            CraftDataHandler.SetRecipeData(TechType.MapRoomUpgradeScanSpeed, scannerRoomSpeedUpgradeRecipe);

            //seamoth depth module MK1 recipe
            RecipeData seamothDepthModuleMK1Recipe = new(
                new CraftData.Ingredient(TechType.TitaniumIngot),
                new CraftData.Ingredient(TechType.Glass, 2));
            CraftDataHandler.SetRecipeData(TechType.VehicleHullModule1, seamothDepthModuleMK1Recipe);

            //seamoth depth module MK2 recipe
            RecipeData seamothDepthModuleMK2Recipe = new(
                new CraftData.Ingredient(TechType.VehicleHullModule1),
                new CraftData.Ingredient(TechType.PlasteelIngot),
                new CraftData.Ingredient(TechType.Magnetite, 2),
                new CraftData.Ingredient(TechType.EnameledGlass));
            CraftDataHandler.SetRecipeData(TechType.VehicleHullModule2, seamothDepthModuleMK2Recipe);

            //seamoth depth module MK3 recipe
            RecipeData seamothDepthModuleMK3Recipe = new(
                new CraftData.Ingredient(TechType.VehicleHullModule2),
                new CraftData.Ingredient(TechType.PlasteelIngot),
                new CraftData.Ingredient(TechType.AluminumOxide, 3));
            CraftDataHandler.SetRecipeData(TechType.VehicleHullModule3, seamothDepthModuleMK3Recipe);

            //seamoth perimeter defense system module recipe
            RecipeData seamothPerimeterDefenseSystemRecipe = new(
                new CraftData.Ingredient(TechType.Polyaniline),
                new CraftData.Ingredient(TechType.WiringKit));
            CraftDataHandler.SetRecipeData(TechType.SeamothElectricalDefense, seamothPerimeterDefenseSystemRecipe);

            //seamoth solar charger module recipe
            RecipeData seamothSolarChargerRecipe = new(
                new CraftData.Ingredient(TechType.AdvancedWiringKit),
                new CraftData.Ingredient(TechType.EnameledGlass));
            CraftDataHandler.SetRecipeData(TechType.SeamothSolarCharge, seamothSolarChargerRecipe);

            //seamoth sonar module recipe
            RecipeData seamothSonarRecipe = new(
                new CraftData.Ingredient(TechType.CopperWire),
                new CraftData.Ingredient(TechType.Magnetite, 2));
            CraftDataHandler.SetRecipeData(TechType.SeamothSonarModule, seamothSonarRecipe);

            //storage module recipe
            RecipeData storageModuleRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 3),
                new CraftData.Ingredient(TechType.Lithium));
            CraftDataHandler.SetRecipeData(TechType.VehicleStorageModule, storageModuleRecipe);

            //torpedo system recipe
            RecipeData torpedoSystemRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 3),
                new CraftData.Ingredient(TechType.Lithium),
                new CraftData.Ingredient(TechType.Aerogel));
            CraftDataHandler.SetRecipeData(TechType.SeamothTorpedoModule, torpedoSystemRecipe);

            Plugin.Logger.LogInfo("VehiclesUpgradesRecipes_RR loaded successfully!");
        }

        public static void BasePiecesRecipes_RR()
        {
            //foundation recipe
            RecipeData foundationRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 3),
                new CraftData.Ingredient(TechType.Lead, 2),
                new CraftData.Ingredient(TechType.Lithium));
            CraftDataHandler.SetRecipeData(TechType.BaseFoundation, foundationRecipe);

            //I corridor recipe
            RecipeData iCorridorRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 2));
            CraftDataHandler.SetRecipeData(TechType.BaseCorridorI, iCorridorRecipe);

            //I corridor glass recipe
            RecipeData iCorridorGlassRecipe = new(
                new CraftData.Ingredient(TechType.Glass, 2));
            CraftDataHandler.SetRecipeData(TechType.BaseCorridorGlassI, iCorridorGlassRecipe);

            //L corridor recipe
            RecipeData lCorridorRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 2));
            CraftDataHandler.SetRecipeData(TechType.BaseCorridorL, lCorridorRecipe);

            //L corridor glass recipe
            RecipeData lCorridorGlassRecipe = new(
                new CraftData.Ingredient(TechType.Glass, 2));
            CraftDataHandler.SetRecipeData(TechType.BaseCorridorGlassL, lCorridorGlassRecipe);

            //T corridor recipe
            RecipeData tCorridorRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 3));
            CraftDataHandler.SetRecipeData(TechType.BaseCorridorT, tCorridorRecipe);

            //X corridor recipe
            RecipeData xCorridorRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 3));
            CraftDataHandler.SetRecipeData(TechType.BaseCorridorX, xCorridorRecipe);

            //vertical connector recipe
            RecipeData verticalConnectorRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 3),
                new CraftData.Ingredient(TechType.Quartz));
            CraftDataHandler.SetRecipeData(TechType.BaseConnector, verticalConnectorRecipe);

            //multipurpose room recipe
            RecipeData multipurposeRoomRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 6));
            CraftDataHandler.SetRecipeData(TechType.BaseRoom, multipurposeRoomRecipe);

            //multipurpose glass dome recipe
            RecipeData glassDomeRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 3),
                new CraftData.Ingredient(TechType.EnameledGlass, 3),
                new CraftData.Ingredient(TechType.Lithium, 2));
            CraftDataHandler.SetRecipeData(TechType.BaseGlassDome, glassDomeRecipe);

            //large room recipe
            RecipeData largeRoomRecipe = new(
                new CraftData.Ingredient(TechType.PlasteelIngot, 2),
                new CraftData.Ingredient(TechType.Titanium, 4),
                new CraftData.Ingredient(TechType.CopperWire, 2));
            CraftDataHandler.SetRecipeData(TechType.BaseLargeRoom, largeRoomRecipe);

            //large glass dome recipe
            RecipeData largeGlassDomeRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 6),
                new CraftData.Ingredient(TechType.EnameledGlass, 6),
                new CraftData.Ingredient(TechType.Lithium, 4));
            CraftDataHandler.SetRecipeData(TechType.BaseLargeGlassDome, largeGlassDomeRecipe);

            //scanner room recipe
            RecipeData scannerRoomRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 5),
                new CraftData.Ingredient(TechType.Copper, 2),
                new CraftData.Ingredient(TechType.Gold),
                new CraftData.Ingredient(TechType.JeweledDiskPiece));
            CraftDataHandler.SetRecipeData(TechType.BaseMapRoom, scannerRoomRecipe);

            //moon pool recipe
            RecipeData moonPoolRecipe = new(
                new CraftData.Ingredient(TechType.TitaniumIngot, 2),
                new CraftData.Ingredient(TechType.Lubricant),
                new CraftData.Ingredient(TechType.Lead, 2),
                new CraftData.Ingredient(TechType.CopperWire));
            CraftDataHandler.SetRecipeData(TechType.BaseMoonpool, moonPoolRecipe);

            //observatory recipe
            RecipeData observatoryRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 3),
                new CraftData.Ingredient(TechType.EnameledGlass, 4));
            CraftDataHandler.SetRecipeData(TechType.BaseObservatory, observatoryRecipe);

            //hatch recipe
            RecipeData hatchRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 2),
                new CraftData.Ingredient(TechType.Glass));
            CraftDataHandler.SetRecipeData(TechType.BaseHatch, hatchRecipe);

            //window recipe
            RecipeData windowRecipe = new(
                new CraftData.Ingredient(TechType.Glass, 2));
            CraftDataHandler.SetRecipeData(TechType.BaseWindow, windowRecipe);

            Plugin.Logger.LogInfo("BasePiecesRecipes_RR loaded successfully!");

            //base reinforcement recipe
            RecipeData BaseReinforcementRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 3),
                new CraftData.Ingredient(TechType.Lithium, 2));
            CraftDataHandler.SetRecipeData(TechType.BaseReinforcement, BaseReinforcementRecipe);
        }

        public static void BaseExteriorModulesRecipes_RR()
        {
            //solar panel recipe
            RecipeData solarPanelRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 2),
                new CraftData.Ingredient(TechType.Quartz, 2),
                new CraftData.Ingredient(TechType.CopperWire));
            CraftDataHandler.SetRecipeData(TechType.SolarPanel, solarPanelRecipe);

            //thermal plant recipe
            RecipeData thermalPlantRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 5),
                new CraftData.Ingredient(TechType.Magnetite, 2),
                new CraftData.Ingredient(TechType.Aerogel),
                new CraftData.Ingredient(TechType.WiringKit));
            CraftDataHandler.SetRecipeData(TechType.ThermalPlant, thermalPlantRecipe);

            //power transmitter recipe
            RecipeData powerTransmitterRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 2),
                new CraftData.Ingredient(TechType.Gold),
                new CraftData.Ingredient(TechType.WiringKit));
            CraftDataHandler.SetRecipeData(TechType.PowerTransmitter, powerTransmitterRecipe);

            //floodlight recipe
            RecipeData floodlightRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 2),
                new CraftData.Ingredient(TechType.Glass, 2),
                new CraftData.Ingredient(TechType.CopperWire));
            CraftDataHandler.SetRecipeData(TechType.Techlight, floodlightRecipe);

            //spotlight recipe
            RecipeData spotlightRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 2),
                new CraftData.Ingredient(TechType.Glass),
                new CraftData.Ingredient(TechType.CopperWire));
            CraftDataHandler.SetRecipeData(TechType.Spotlight, spotlightRecipe);

            //exterior growbed recipe
            RecipeData exteriorGrowbedRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 3),
                new CraftData.Ingredient(TechType.CreepvinePiece, 2));
            CraftDataHandler.SetRecipeData(TechType.FarmingTray, exteriorGrowbedRecipe);

            //base pipe connector recipe
            RecipeData basePipeConnectorRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 2),
                new CraftData.Ingredient(TechType.Copper));
            CraftDataHandler.SetRecipeData(TechType.BasePipeConnector, basePipeConnectorRecipe);

            Plugin.Logger.LogInfo("BaseExteriorModulesRecipes_RR loaded successfully!");
        }

        public static void BaseInteriorPiecesRecipes_RR()
        {
            //ladder recipe
            RecipeData ladderRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 3));
            CraftDataHandler.SetRecipeData(TechType.BaseLadder, ladderRecipe);

            //water filtration machine recipe
            RecipeData waterFiltrationMachineRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 4),
                new CraftData.Ingredient(TechType.CopperWire),
                new CraftData.Ingredient(TechType.Aerogel, 2),
                new CraftData.Ingredient(TechType.Quartz, 2));
            CraftDataHandler.SetRecipeData(TechType.BaseFiltrationMachine, waterFiltrationMachineRecipe);

            //bulkhead recipe
            RecipeData bulkheadRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 3),
                new CraftData.Ingredient(TechType.Silicone, 2),
                new CraftData.Ingredient(TechType.Lithium));
            CraftDataHandler.SetRecipeData(TechType.BaseBulkhead, bulkheadRecipe);

            //vehicle upgrade console recipe
            RecipeData vehicleUpgradeConsoleRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 3),
                new CraftData.Ingredient(TechType.ComputerChip),
                new CraftData.Ingredient(TechType.CopperWire),
                new CraftData.Ingredient(TechType.Quartz));
            CraftDataHandler.SetRecipeData(TechType.BaseUpgradeConsole, vehicleUpgradeConsoleRecipe);

            //bioreactor recipe
            RecipeData bioreactorRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 5),
                new CraftData.Ingredient(TechType.WiringKit),
                new CraftData.Ingredient(TechType.Lubricant),
                new CraftData.Ingredient(TechType.Glass, 2));
            CraftDataHandler.SetRecipeData(TechType.BaseBioReactor, bioreactorRecipe);

            //nuclear reactor recipe
            RecipeData nuclearReactorRecipe = new(
                new CraftData.Ingredient(TechType.PlasteelIngot),
                new CraftData.Ingredient(TechType.AdvancedWiringKit),
                new CraftData.Ingredient(TechType.Lead, 4),
                new CraftData.Ingredient(TechType.Glass, 2),
                new CraftData.Ingredient(TechType.TitaniumIngot));
            CraftDataHandler.SetRecipeData(TechType.BaseNuclearReactor, nuclearReactorRecipe);

            //alien containment recipe
            RecipeData aquariumRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 3),
                new CraftData.Ingredient(TechType.Glass, 6));
            CraftDataHandler.SetRecipeData(TechType.BaseWaterPark, aquariumRecipe);

            //large room partition recipe
            RecipeData largeRoomPatitionRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 3));
            CraftDataHandler.SetRecipeData(TechType.BasePartition, largeRoomPatitionRecipe);

            //large room partition door recipe
            RecipeData largeRoomPatitionDoorRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 2),
                new CraftData.Ingredient(TechType.Quartz));
            CraftDataHandler.SetRecipeData(TechType.BasePartitionDoor, largeRoomPatitionDoorRecipe);

            Plugin.Logger.LogInfo("BaseInteriorPiecesRecipes_RR loaded successfully!");
        }

        public static void BaseInteriorModulesRecipes_RR()
        {
            //fabricator recipe
            RecipeData fabricatorRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 2),
                new CraftData.Ingredient(TechType.Gold),
                new CraftData.Ingredient(TechType.JeweledDiskPiece),
                new CraftData.Ingredient(TechType.Copper));
            CraftDataHandler.SetRecipeData(TechType.Fabricator, fabricatorRecipe);

            //radio recipe
            RecipeData radioRecipe = new(
                new CraftData.Ingredient(TechType.Titanium),
                new CraftData.Ingredient(TechType.WiringKit));
            CraftDataHandler.SetRecipeData(TechType.Radio, radioRecipe);

            //medical kit fabricator recipe
            RecipeData medicalKitFabricatorRecipe = new(
                new CraftData.Ingredient(TechType.ComputerChip),
                new CraftData.Ingredient(TechType.FiberMesh),
                new CraftData.Ingredient(TechType.Silver),
                new CraftData.Ingredient(TechType.Titanium),
                new CraftData.Ingredient(TechType.CopperWire));
            CraftDataHandler.SetRecipeData(TechType.MedicalCabinet, medicalKitFabricatorRecipe);

            //wall locker recipe
            RecipeData wallLockerRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 3),
                new CraftData.Ingredient(TechType.Quartz),
                new CraftData.Ingredient(TechType.CopperWire));
            CraftDataHandler.SetRecipeData(TechType.SmallLocker, wallLockerRecipe);

            //locker recipe
            RecipeData lockerRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 3),
                new CraftData.Ingredient(TechType.Quartz, 2));
            CraftDataHandler.SetRecipeData(TechType.Locker, lockerRecipe);

            //battery charger recipe
            RecipeData batteryChargerRecipe = new(
                new CraftData.Ingredient(TechType.WiringKit),
                new CraftData.Ingredient(TechType.CopperWire),
                new CraftData.Ingredient(TechType.Titanium),
                new CraftData.Ingredient(TechType.Silver));
            CraftDataHandler.SetRecipeData(TechType.BatteryCharger, batteryChargerRecipe);

            //power cell charger recipe
            RecipeData powerCellChargerRecipe = new(
                new CraftData.Ingredient(TechType.AdvancedWiringKit),
                new CraftData.Ingredient(TechType.AluminumOxide, 2),
                new CraftData.Ingredient(TechType.Titanium, 2),
                new CraftData.Ingredient(TechType.Gold));
            CraftDataHandler.SetRecipeData(TechType.PowerCellCharger, powerCellChargerRecipe);

            //aquarium recipe
            RecipeData aquariumRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 3),
                new CraftData.Ingredient(TechType.Glass, 3));
            CraftDataHandler.SetRecipeData(TechType.Aquarium, aquariumRecipe);

            //modification station recipe
            RecipeData modificationStationRecipe = new(
                new CraftData.Ingredient(TechType.ComputerChip),
                new CraftData.Ingredient(TechType.Titanium, 2),
                new CraftData.Ingredient(TechType.Diamond),
                new CraftData.Ingredient(TechType.Lead),
                new CraftData.Ingredient(TechType.WiringKit));
            CraftDataHandler.SetRecipeData(TechType.Workbench, modificationStationRecipe);

            //basic plant pot recipe
            RecipeData basicPlantPotRecipe = new(
                new CraftData.Ingredient(TechType.Titanium),
                new CraftData.Ingredient(TechType.PurpleRattle));
            CraftDataHandler.SetRecipeData(TechType.PlanterPot, basicPlantPotRecipe);

            //composite plant pot recipe
            RecipeData compositePlantPotRecipe = new(
                new CraftData.Ingredient(TechType.Titanium),
                new CraftData.Ingredient(TechType.PurpleRattle));
            CraftDataHandler.SetRecipeData(TechType.PlanterPot2, compositePlantPotRecipe);

            //chic plant pot recipe
            RecipeData chicPlantPotRecipe = new(
                new CraftData.Ingredient(TechType.Titanium),
                new CraftData.Ingredient(TechType.PurpleRattle));
            CraftDataHandler.SetRecipeData(TechType.PlanterPot3, chicPlantPotRecipe);

            //indoor growbed recipe
            RecipeData indoorGrowbedRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 4),
                new CraftData.Ingredient(TechType.BulboTreePiece, 2));
            CraftDataHandler.SetRecipeData(TechType.PlanterBox, indoorGrowbedRecipe);

            //plant shelf recipe
            RecipeData plantShelfRecipe = new(
                new CraftData.Ingredient(TechType.Titanium),
                new CraftData.Ingredient(TechType.PurpleRattle));
            CraftDataHandler.SetRecipeData(TechType.PlanterShelf, plantShelfRecipe);

            Plugin.Logger.LogInfo("BaseInteriorModulesRecipes_RR loaded successfully!");
        }

        public static void BaseDecorationsRecipes_RR()
        {
            //bench recipe
            RecipeData benchRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 2),
                new CraftData.Ingredient(TechType.FiberMesh));
            CraftDataHandler.SetRecipeData(TechType.Bench, benchRecipe);

            //bed recipe
            RecipeData bedRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 4),
                new CraftData.Ingredient(TechType.FiberMesh, 4));
            CraftDataHandler.SetRecipeData(TechType.NarrowBed, bedRecipe);

            //double bed recipe
            RecipeData doubleBedRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 6),
                new CraftData.Ingredient(TechType.FiberMesh, 5));
            CraftDataHandler.SetRecipeData(TechType.Bed1, doubleBedRecipe);

            //fancy double bed recipe
            RecipeData doubleBed2Recipe = new(
                new CraftData.Ingredient(TechType.Titanium, 6),
                new CraftData.Ingredient(TechType.FiberMesh, 6));
            CraftDataHandler.SetRecipeData(TechType.Bed2, doubleBed2Recipe);

            //desk recipe
            RecipeData deskRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 2),
                new CraftData.Ingredient(TechType.WiringKit));
            CraftDataHandler.SetRecipeData(TechType.StarshipDesk, deskRecipe);

            //swivel chair recipe
            RecipeData swivelChairRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 2),
                new CraftData.Ingredient(TechType.FiberMesh));
            CraftDataHandler.SetRecipeData(TechType.StarshipChair, swivelChairRecipe);

            //office chair recipe
            RecipeData officeChairRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 3));
            CraftDataHandler.SetRecipeData(TechType.StarshipChair2, officeChairRecipe);

            //command chair recipe
            RecipeData commandChairRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 3));
            CraftDataHandler.SetRecipeData(TechType.StarshipChair3, commandChairRecipe);

            //sign recipe
            RecipeData signRecipe = new(
                new CraftData.Ingredient(TechType.CopperWire),
                new CraftData.Ingredient(TechType.Glass),
                new CraftData.Ingredient(TechType.Titanium));
            CraftDataHandler.SetRecipeData(TechType.Sign, signRecipe);

            //picture frame recipe
            RecipeData pictureFrameRecipe = new(
                new CraftData.Ingredient(TechType.CopperWire),
                new CraftData.Ingredient(TechType.Titanium, 2),
                new CraftData.Ingredient(TechType.Glass));
            CraftDataHandler.SetRecipeData(TechType.PictureFrame, pictureFrameRecipe);

            //bar table recipe
            RecipeData barTableRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 2),
                new CraftData.Ingredient(TechType.Glass, 2));
            CraftDataHandler.SetRecipeData(TechType.BarTable, barTableRecipe);

            //trash cans recipe
            RecipeData trashCansRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 2),
                new CraftData.Ingredient(TechType.FiberMesh));
            CraftDataHandler.SetRecipeData(TechType.Trashcans, trashCansRecipe);

            //nuclear waste disposal recipe
            RecipeData nuclearWasteDisposalRecipe = new(
                new CraftData.Ingredient(TechType.Titanium),
                new CraftData.Ingredient(TechType.Lead, 2));
            CraftDataHandler.SetRecipeData(TechType.LabTrashcan, nuclearWasteDisposalRecipe);

            //vending machine recipe
            RecipeData vendingMachineRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 4),
                new CraftData.Ingredient(TechType.Glass, 2),
                new CraftData.Ingredient(TechType.CopperWire));
            CraftDataHandler.SetRecipeData(TechType.VendingMachine, vendingMachineRecipe);

            //coffee vending machine recipe
            RecipeData coffeeVendingMachineRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 2),
                new CraftData.Ingredient(TechType.CopperWire));
            CraftDataHandler.SetRecipeData(TechType.CoffeeVendingMachine, coffeeVendingMachineRecipe);

            //lab counter recipe
            RecipeData labCounterRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 3));
            CraftDataHandler.SetRecipeData(TechType.LabCounter, labCounterRecipe);

            //wall planter recipe
            RecipeData wallPlanterRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 3),
                new CraftData.Ingredient(TechType.CreepvinePiece, 2));
            CraftDataHandler.SetRecipeData(TechType.BasePlanter, wallPlanterRecipe);

            //shelf recipe
            RecipeData shelfRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 2));
            CraftDataHandler.SetRecipeData(TechType.SingleWallShelf, shelfRecipe);

            //wall shelves recipe
            RecipeData wallShelvesRecipe = new(
                new CraftData.Ingredient(TechType.Titanium, 4));
            CraftDataHandler.SetRecipeData(TechType.WallShelves, wallShelvesRecipe);

            Plugin.Logger.LogInfo("BaseDecorationsRecipes_RR loaded successfully!");
        }
    }
}