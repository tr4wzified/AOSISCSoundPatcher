using Mutagen.Bethesda;
using Mutagen.Bethesda.FormKeys.SkyrimSE;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Skyrim;
using System.Collections.Generic;

namespace AOSISCSoundPatcher
{
    public static class ImmersiveSoundsCompendium
    {
        public static readonly ModKey ModKey = ModKey.FromNameAndExtension("Immersive Sounds - Compendium.esp");

        // Jewelry Sounds
        public static readonly FormLink<ISoundDescriptorGetter> ITMRingUp = new FormLink<ISoundDescriptorGetter>(ModKey.MakeFormKey(0x08AB14));
        public static readonly FormLink<ISoundDescriptorGetter> ITMNeckUp = new FormLink<ISoundDescriptorGetter>(ModKey.MakeFormKey(0x08AB15));
        public static readonly FormLink<ISoundDescriptorGetter> ITMNeckDown = new FormLink<ISoundDescriptorGetter>(ModKey.MakeFormKey(0x08AB16));
        public static readonly FormLink<ISoundDescriptorGetter> ITMGemUp = new FormLink<ISoundDescriptorGetter>(ModKey.MakeFormKey(0x08AB13));
        public static readonly FormLink<ISoundDescriptorGetter> ITMGemDown = new FormLink<ISoundDescriptorGetter>(ModKey.MakeFormKey(0x08AB18));

        // Weapon Sounds
        public static readonly FormLink<ISoundDescriptorGetter> WPNSwingAxe2Hand = new FormLink<ISoundDescriptorGetter>(ModKey.MakeFormKey(0x1E6B31));
        public static readonly FormLink<ISoundDescriptorGetter> WPNSwing2HandBound = new FormLink<ISoundDescriptorGetter>(ModKey.MakeFormKey(0x04C731));
        public static readonly FormLink<ISoundDescriptorGetter> WPNSwingBlunt2Hand = new FormLink<ISoundDescriptorGetter>(ModKey.MakeFormKey(0x1F5E3B));
        public static readonly FormLink<ISoundDescriptorGetter> WPNSwingBladeMediumBoundSD = new FormLink<ISoundDescriptorGetter>(ModKey.MakeFormKey(0x04762F));

        // Armor Addon Sound Sets
        public static readonly IFormLink<IFootstepSetGetter> FSTArmor_LightLeather =    new FormLink<IFootstepSetGetter>(ModKey.MakeFormKey(0x46EE30));
        public static readonly IFormLink<IFootstepSetGetter> FSTArmor_Leather =         new FormLink<IFootstepSetGetter>(ModKey.MakeFormKey(0x3951FB));
        public static readonly IFormLink<IFootstepSetGetter> FSTArmor_Chitin =          new FormLink<IFootstepSetGetter>(ModKey.MakeFormKey(0x43C3E7));
        public static readonly IFormLink<IFootstepSetGetter> FSTArmor_LightChain =      new FormLink<IFootstepSetGetter>(ModKey.MakeFormKey(0x39A326));
        public static readonly IFormLink<IFootstepSetGetter> FSTArmor_RingMail =        new FormLink<IFootstepSetGetter>(ModKey.MakeFormKey(0x38AFA5));
        public static readonly IFormLink<IFootstepSetGetter> FSTArmor_FullChain =       new FormLink<IFootstepSetGetter>(ModKey.MakeFormKey(0x473F5B));
        public static readonly IFormLink<IFootstepSetGetter> FSTArmor_ChainPlate =      new FormLink<IFootstepSetGetter>(ModKey.MakeFormKey(0x4372BC));
        public static readonly IFormLink<IFootstepSetGetter> FSTArmor_Plate =           new FormLink<IFootstepSetGetter>(ModKey.MakeFormKey(0x3900D0));
        public static readonly IFormLink<IFootstepSetGetter> FSTArmor_HeavyPlate =      new FormLink<IFootstepSetGetter>(ModKey.MakeFormKey(0x33F049));
        public static readonly IFormLink<IFootstepSetGetter> FSTArmor_DragonPlate =     new FormLink<IFootstepSetGetter>(ModKey.MakeFormKey(0x3FF791));

        // Armor Type Footsep Sounds
        public static readonly Dictionary<IFormLinkGetter<IKeywordGetter>, IFormLink<IFootstepSetGetter>> FootstepSets = new Dictionary<IFormLinkGetter<IKeywordGetter>, IFormLink<IFootstepSetGetter>>()
        {
            { Skyrim.Keyword.ArmorMaterialDragonplate,      ImmersiveSoundsCompendium.FSTArmor_DragonPlate },
            { Skyrim.Keyword.ArmorMaterialDragonscale,      ImmersiveSoundsCompendium.FSTArmor_DragonPlate },
            { Skyrim.Keyword.ArmorMaterialDaedric,          ImmersiveSoundsCompendium.FSTArmor_HeavyPlate },
            { Skyrim.Keyword.ArmorMaterialDwarven,          ImmersiveSoundsCompendium.FSTArmor_HeavyPlate },
            { Skyrim.Keyword.ArmorMaterialEbony,            ImmersiveSoundsCompendium.FSTArmor_HeavyPlate },
            { Skyrim.Keyword.ArmorMaterialImperialHeavy,    ImmersiveSoundsCompendium.FSTArmor_HeavyPlate },
            { Skyrim.Keyword.ArmorMaterialIron,             ImmersiveSoundsCompendium.FSTArmor_HeavyPlate },
            { Skyrim.Keyword.ArmorMaterialIronBanded,       ImmersiveSoundsCompendium.FSTArmor_HeavyPlate },
            { Skyrim.Keyword.ArmorMaterialSteel,            ImmersiveSoundsCompendium.FSTArmor_HeavyPlate },
            { Skyrim.Keyword.ArmorMaterialSteelPlate,       ImmersiveSoundsCompendium.FSTArmor_HeavyPlate },
            { Skyrim.Keyword.ArmorMaterialOrcish,           ImmersiveSoundsCompendium.FSTArmor_HeavyPlate },
            { Skyrim.Keyword.ArmorMaterialElven,            ImmersiveSoundsCompendium.FSTArmor_Plate },
            { Skyrim.Keyword.ArmorMaterialElvenGilded,      ImmersiveSoundsCompendium.FSTArmor_ChainPlate },
            { Skyrim.Keyword.ArmorMaterialGlass,            ImmersiveSoundsCompendium.FSTArmor_ChainPlate },
            { Skyrim.Keyword.ArmorMaterialScaled,           ImmersiveSoundsCompendium.FSTArmor_FullChain },
            { Skyrim.Keyword.ArmorMaterialImperialStudded,  ImmersiveSoundsCompendium.FSTArmor_LightChain },
            { Skyrim.Keyword.ArmorMaterialStormcloak,       ImmersiveSoundsCompendium.FSTArmor_LightChain },
            { Skyrim.Keyword.ArmorMaterialHide,             ImmersiveSoundsCompendium.FSTArmor_Leather },
            { Skyrim.Keyword.ArmorMaterialImperialLight,    ImmersiveSoundsCompendium.FSTArmor_Leather },
            { Skyrim.Keyword.ArmorMaterialLeather,          ImmersiveSoundsCompendium.FSTArmor_Leather },
            { Skyrim.Keyword.ArmorMaterialStudded,          ImmersiveSoundsCompendium.FSTArmor_Leather }
        };

    }
}
