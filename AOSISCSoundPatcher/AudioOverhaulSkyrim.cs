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

        // Impact Data
        public static readonly FormLink<IImpactDataSetGetter> WPNzBlade1HandSmallImpactSet = new FormLink<IImpactDataSetGetter>(ModKey.MakeFormKey(0x05B6EA));

        // Projectiles
        public readonly static FormLink<IProjectileGetter> DA15WabbajackProjectile_AOS = new FormLink<IProjectileGetter>(ModKey.MakeFormKey(0x000847));
        public readonly static FormLink<IProjectileGetter> DLC2FireStormProjectile01_AOS = new FormLink<IProjectileGetter>(ModKey.MakeFormKey(0x000848));
        public readonly static FormLink<IProjectileGetter> DragonFrostProjectile01_AOS = new FormLink<IProjectileGetter>(ModKey.MakeFormKey(0x00085A));
        public readonly static FormLink<IProjectileGetter> DragonIceSpikeVolleyProjectile_AOS = new FormLink<IProjectileGetter>(ModKey.MakeFormKey(0x00084A));
        public readonly static FormLink<IProjectileGetter> FireboltDragonProjectile01_AOS = new FormLink<IProjectileGetter>(ModKey.MakeFormKey(0x00084C));
        public readonly static FormLink<IProjectileGetter> FireboltExpertProjectile01_AOS = new FormLink<IProjectileGetter>(ModKey.MakeFormKey(0x00084D));
        public readonly static FormLink<IProjectileGetter> FireboltProjectile01_AOS = new FormLink<IProjectileGetter>(ModKey.MakeFormKey(0x00084E));
        public readonly static FormLink<IProjectileGetter> FireboltStormProjectileAlduinDeath_AOS = new FormLink<IProjectileGetter>(ModKey.MakeFormKey(0x00084F));
        public readonly static FormLink<IProjectileGetter> FireboltStormProjectileSlow01_AOS = new FormLink<IProjectileGetter>(ModKey.MakeFormKey(0x000850));
        public readonly static FormLink<IProjectileGetter> FlamesProjectile_AOS = new FormLink<IProjectileGetter>(ModKey.MakeFormKey(0x000851));
        public readonly static FormLink<IProjectileGetter> FrostIcicleProjectile01_AOS = new FormLink<IProjectileGetter>(ModKey.MakeFormKey(0x000852));
        public readonly static FormLink<IProjectileGetter> FrostIcicleProjectile02_AOS = new FormLink<IProjectileGetter>(ModKey.MakeFormKey(0x000853));
        public readonly static FormLink<IProjectileGetter> FrostSprayProjectile01_AOS = new FormLink<IProjectileGetter>(ModKey.MakeFormKey(0x000854));
        public readonly static FormLink<IProjectileGetter> FrostStormDualProjectile_AOS = new FormLink<IProjectileGetter>(ModKey.MakeFormKey(0x000855));
        public readonly static FormLink<IProjectileGetter> FrostStormProjectile_AOS = new FormLink<IProjectileGetter>(ModKey.MakeFormKey(0x000856));
        public readonly static FormLink<IProjectileGetter> RuneFireProjectile_AOS = new FormLink<IProjectileGetter>(ModKey.MakeFormKey(0x000857));
        public readonly static FormLink<IProjectileGetter> RuneFrostProjectile_AOS = new FormLink<IProjectileGetter>(ModKey.MakeFormKey(0x000858));
        public readonly static FormLink<IProjectileGetter> RuneLightningProjectile_AOS = new FormLink<IProjectileGetter>(ModKey.MakeFormKey(0x000859));
        public readonly static FormLink<IProjectileGetter> ShockBoltConAimDual_AOS = new FormLink<IProjectileGetter>(ModKey.MakeFormKey(0x0155C9));


        // Explosions

        public readonly static FormLink<IExplosionGetter> AlduinFirestormImpactExplosion = new FormLink<IExplosionGetter>(ModKey.MakeFormKey(0x000844));
        public readonly static FormLink<IExplosionGetter> ExplosionDwarvenSpider_AOS = new FormLink<IExplosionGetter>(ModKey.MakeFormKey(0x000840));
        public readonly static FormLink<IExplosionGetter> ExplosionShockMass01_AOS = new FormLink<IExplosionGetter>(ModKey.MakeFormKey(0x00083B));
        public readonly static FormLink<IExplosionGetter> FireballStormAlduinDeathExplosion_AOS = new FormLink<IExplosionGetter>(ModKey.MakeFormKey(0x00083F));
        public readonly static FormLink<IExplosionGetter> MAGIceSpikeVolleyExplosion_AOS = new FormLink<IExplosionGetter>(ModKey.MakeFormKey(0x00083C));
        public readonly static FormLink<IExplosionGetter> crGiantSlamExplosionBIG = new FormLink<IExplosionGetter>(ModKey.MakeFormKey(0x000841));
        public readonly static IFormLink<IExplosionGetter> DragonFireballAreaExplosion_AOS = new FormLink<IExplosionGetter>(ModKey.MakeFormKey(0x00083E));
        public readonly static IFormLink<IExplosionGetter> ExplosionStormAtronachPowerAttack_AOS = new FormLink<IExplosionGetter>(ModKey.MakeFormKey(0x000842));
        public readonly static IFormLink<IExplosionGetter> FXAtronachFireDeathExplosion_AOS = new FormLink<IExplosionGetter>(ModKey.MakeFormKey(0x000837));
        public readonly static IFormLink<IExplosionGetter> FireballStormImpactExplosion_AOS = new FormLink<IExplosionGetter>(ModKey.MakeFormKey(0x00083D));
    }
}
