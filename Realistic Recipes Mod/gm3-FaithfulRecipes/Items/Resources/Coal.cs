using Nautilus.Assets;
using Nautilus.Assets.PrefabTemplates;

namespace RRM.FaithfulRecipes.Items.Resources
{
    public class Coal
    {
        public static PrefabInfo Info { get; private set; }

        public static void Register()
        {
            string classId = "Coal";
            string displayName = "Coal";
            string description = "Coal that makes me go yes.";
            string language = "English";
            bool unlockAtStart = false;
            //System.Reflection.Assembly techTypeOwner = null;

            Info = PrefabInfo.WithTechType(
                classId, displayName, description,
                language, unlockAtStart/*, techTypeOwner*/
                )
                .WithIcon(SpriteManager.Get(TechType.Nickel));
            var coalPrefab = new CustomPrefab(Info);

            var coalObj = new CloneTemplate(Info, TechType.Nickel);
            coalPrefab.SetGameObject(coalObj);

            coalPrefab.Register();
        }
    }
}