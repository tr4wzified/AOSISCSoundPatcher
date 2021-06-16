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
    public static class AudioOverhaulSkyrim
    {
        public static readonly ModKey ModKey = ModKey.FromNameAndExtension("Audio Overhaul Skyrim.esp");

        public static readonly FormLink<IImpactDataSetGetter> WPNzBlade1HandSmallImpactSet = new FormLink<IImpactDataSetGetter>(ModKey.MakeFormKey(0x05B6EA));
    }
}
