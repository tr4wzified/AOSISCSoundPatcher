using Mutagen.Bethesda;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Skyrim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOSISCSoundPatcher
{
    public static class ImmersiveSoundsCompendium
    {
        public static readonly ModKey ModKey = ModKey.FromNameAndExtension("Immersive Sounds - Compendium.esp");

        public static readonly FormLink<ISoundDescriptorGetter> ITMRingUp = new FormLink<ISoundDescriptorGetter>(ModKey.MakeFormKey(0x08AB14));
        public static readonly FormLink<ISoundDescriptorGetter> ITMNeckUp = new FormLink<ISoundDescriptorGetter>(ModKey.MakeFormKey(0x08AB15));
        public static readonly FormLink<ISoundDescriptorGetter> ITMNeckDown = new FormLink<ISoundDescriptorGetter>(ModKey.MakeFormKey(0x08AB16));
        public static readonly FormLink<ISoundDescriptorGetter> ITMGemUp = new FormLink<ISoundDescriptorGetter>(ModKey.MakeFormKey(0x08AB13));
        public static readonly FormLink<ISoundDescriptorGetter> ITMGemDown = new FormLink<ISoundDescriptorGetter>(ModKey.MakeFormKey(0x08AB18));
        public static readonly FormLink<ISoundDescriptorGetter> WPNSwingAxe2Hand = new FormLink<ISoundDescriptorGetter>(ModKey.MakeFormKey(0x1E6B31));
        public static readonly FormLink<ISoundDescriptorGetter> WPNSwing2HandBound = new FormLink<ISoundDescriptorGetter>(ModKey.MakeFormKey(0x04C731));
        public static readonly FormLink<ISoundDescriptorGetter> WPNSwingBlunt2Hand = new FormLink<ISoundDescriptorGetter>(ModKey.MakeFormKey(0x1F5E3B));
        public static readonly FormLink<ISoundDescriptorGetter> WPNSwingBladeMediumBoundSD = new FormLink<ISoundDescriptorGetter>(ModKey.MakeFormKey(0x04762F));
    }
}
