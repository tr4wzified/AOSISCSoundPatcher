using Mutagen.Bethesda;
using Mutagen.Bethesda.FormKeys.SkyrimSE;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Skyrim;
using System.Collections.Generic;

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

        // Projectile Replacements
        public static readonly Dictionary<FormKey, IFormLink<IProjectileGetter>> Projectiles = new Dictionary<FormKey, IFormLink<IProjectileGetter>>()
        {
            { Skyrim.Projectile.DA15WabbajackProjectile.FormKey,            AudioOverhaulSkyrim.DA15WabbajackProjectile_AOS },
            { Dragonborn.Projectile.DLC2FireStormProjectile01.FormKey,      AudioOverhaulSkyrim.DLC2FireStormProjectile01_AOS },
            { Skyrim.Projectile.DragonFrostProjectile01.FormKey,            AudioOverhaulSkyrim.DragonFrostProjectile01_AOS },
            { Skyrim.Projectile.DragonIceSpikeVolleyProjectile.FormKey,     AudioOverhaulSkyrim.DragonIceSpikeVolleyProjectile_AOS },
            { Skyrim.Projectile.FireboltDragonProjectile01.FormKey,         AudioOverhaulSkyrim.FireboltDragonProjectile01_AOS },
            { Skyrim.Projectile.FireboltExpertProjectile01.FormKey,         AudioOverhaulSkyrim.FireboltExpertProjectile01_AOS },
            { Skyrim.Projectile.FireboltProjectile01.FormKey,               AudioOverhaulSkyrim.FireboltProjectile01_AOS },
            { Skyrim.Projectile.FireboltStormProjectileAlduinDeath.FormKey, AudioOverhaulSkyrim.FireboltStormProjectileAlduinDeath_AOS },
            { Skyrim.Projectile.FireboltStormProjectileSlow01.FormKey,      AudioOverhaulSkyrim.FireboltStormProjectileSlow01_AOS },
            { Skyrim.Projectile.FlamesProjectile.FormKey,                   AudioOverhaulSkyrim.FlamesProjectile_AOS },
            { Skyrim.Projectile.FrostIcicleProjectile01.FormKey,            AudioOverhaulSkyrim.FrostIcicleProjectile01_AOS },
            { Skyrim.Projectile.FrostIcicleProjectile02.FormKey,            AudioOverhaulSkyrim.FrostIcicleProjectile02_AOS },
            { Skyrim.Projectile.FrostSprayProjectile01.FormKey,             AudioOverhaulSkyrim.FrostSprayProjectile01_AOS },
            { Skyrim.Projectile.FrostStormDualProjectile.FormKey,           AudioOverhaulSkyrim.FrostStormDualProjectile_AOS },
            { Skyrim.Projectile.FrostStormProjectile.FormKey,               AudioOverhaulSkyrim.FrostStormProjectile_AOS },
            { Skyrim.Projectile.RuneFireProjectile.FormKey,                 AudioOverhaulSkyrim.RuneFireProjectile_AOS },
            { Skyrim.Projectile.RuneFrostProjectile.FormKey,                AudioOverhaulSkyrim.RuneFrostProjectile_AOS },
            { Skyrim.Projectile.RuneLightningProjectile.FormKey,            AudioOverhaulSkyrim.RuneLightningProjectile_AOS },
            { Skyrim.Projectile.ShockBoltConAim.FormKey,                    AudioOverhaulSkyrim.ShockBoltConAimDual_AOS }
        };

        // Explosion Replacements
        public static readonly Dictionary<FormKey, IFormLink<IExplosionGetter>> Explosions = new Dictionary<FormKey, IFormLink<IExplosionGetter>>()
        {
            { Skyrim.Explosion.AlduinFirestormImpactExplosion.FormKey,      AudioOverhaulSkyrim.AlduinFirestormImpactExplosion },
            { Skyrim.Explosion.DragonFireballAreaExplosion.FormKey,         AudioOverhaulSkyrim.DragonFireballAreaExplosion_AOS },
            { Skyrim.Explosion.ExplosionDwarvenSpider.FormKey,              AudioOverhaulSkyrim.ExplosionDwarvenSpider_AOS },
            { Skyrim.Explosion.ExplosionShockMass01.FormKey,                AudioOverhaulSkyrim.ExplosionShockMass01_AOS },
            { Skyrim.Explosion.ExplosionStormAtronachPowerAttack.FormKey,   AudioOverhaulSkyrim.ExplosionStormAtronachPowerAttack_AOS },
            { Skyrim.Explosion.FXAtronachFireDeathExplosion.FormKey,        AudioOverhaulSkyrim.FXAtronachFireDeathExplosion_AOS},
            { Skyrim.Explosion.FireballStormAlduinDeathExplosion.FormKey,   AudioOverhaulSkyrim.FireballStormAlduinDeathExplosion_AOS },
            { Skyrim.Explosion.FireballStormImpactExplosion.FormKey,        AudioOverhaulSkyrim.FireballStormImpactExplosion_AOS },
            { Skyrim.Explosion.MAGIceSpikeVolleyExplosion.FormKey,          AudioOverhaulSkyrim.MAGIceSpikeVolleyExplosion_AOS },
            { Skyrim.Explosion.crGiantSlamExplosion.FormKey,                AudioOverhaulSkyrim.crGiantSlamExplosionBIG }
        };

    }
}
