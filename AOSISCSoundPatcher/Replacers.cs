using Mutagen.Bethesda.FormKeys.SkyrimSE;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Skyrim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOSISCSoundPatcher
{
    public static class Replacers
    {
        public static readonly Dictionary<FormKey, IFormLink<IProjectileGetter>> Projectiles = new Dictionary<FormKey, IFormLink<IProjectileGetter>>()
        {
            { Skyrim.Projectile.DA15WabbajackProjectile.FormKey, AudioOverhaulSkyrim.DA15WabbajackProjectile_AOS },
            { Dragonborn.Projectile.DLC2FireStormProjectile01.FormKey, AudioOverhaulSkyrim.DLC2FireStormProjectile01_AOS },
            { Skyrim.Projectile.DragonFrostProjectile01.FormKey, AudioOverhaulSkyrim.DragonFrostProjectile01_AOS },
            { Skyrim.Projectile.DragonIceSpikeVolleyProjectile.FormKey, AudioOverhaulSkyrim.DragonIceSpikeVolleyProjectile_AOS },
            { Skyrim.Projectile.FireboltDragonProjectile01.FormKey, AudioOverhaulSkyrim.FireboltDragonProjectile01_AOS },
            { Skyrim.Projectile.FireboltExpertProjectile01.FormKey, AudioOverhaulSkyrim.FireboltExpertProjectile01_AOS },
            { Skyrim.Projectile.FireboltProjectile01.FormKey, AudioOverhaulSkyrim.FireboltProjectile01_AOS },
            { Skyrim.Projectile.FireboltStormProjectileAlduinDeath.FormKey, AudioOverhaulSkyrim.FireboltStormProjectileAlduinDeath_AOS },
            { Skyrim.Projectile.FireboltStormProjectileSlow01.FormKey, AudioOverhaulSkyrim.FireboltStormProjectileSlow01_AOS },
            { Skyrim.Projectile.FlamesProjectile.FormKey, AudioOverhaulSkyrim.FlamesProjectile_AOS },
            { Skyrim.Projectile.FrostIcicleProjectile01.FormKey, AudioOverhaulSkyrim.FrostIcicleProjectile01_AOS },
            { Skyrim.Projectile.FrostIcicleProjectile02.FormKey, AudioOverhaulSkyrim.FrostIcicleProjectile02_AOS },
            { Skyrim.Projectile.FrostSprayProjectile01.FormKey, AudioOverhaulSkyrim.FrostSprayProjectile01_AOS },
            { Skyrim.Projectile.FrostStormDualProjectile.FormKey, AudioOverhaulSkyrim.FrostStormDualProjectile_AOS },
            { Skyrim.Projectile.FrostStormProjectile.FormKey, AudioOverhaulSkyrim.FrostStormProjectile_AOS },
            { Skyrim.Projectile.RuneFireProjectile.FormKey, AudioOverhaulSkyrim.RuneFireProjectile_AOS },
            { Skyrim.Projectile.RuneFrostProjectile.FormKey, AudioOverhaulSkyrim.RuneFrostProjectile_AOS },
            { Skyrim.Projectile.RuneLightningProjectile.FormKey, AudioOverhaulSkyrim.RuneLightningProjectile_AOS },
            { Skyrim.Projectile.ShockBoltConAim.FormKey, AudioOverhaulSkyrim.ShockBoltConAimDual_AOS }
        };

        public static readonly Dictionary<FormKey, IFormLink<IExplosionGetter>> Explosions = new Dictionary<FormKey, IFormLink<IExplosionGetter>>()
        {
            { Skyrim.Explosion.AlduinFirestormImpactExplosion.FormKey, AudioOverhaulSkyrim.AlduinFirestormImpactExplosion },
            { Skyrim.Explosion.DragonFireballAreaExplosion.FormKey, AudioOverhaulSkyrim.DragonFireballAreaExplosion_AOS },
            { Skyrim.Explosion.ExplosionDwarvenSpider.FormKey, AudioOverhaulSkyrim.ExplosionDwarvenSpider_AOS },
            { Skyrim.Explosion.ExplosionShockMass01.FormKey, AudioOverhaulSkyrim.ExplosionShockMass01_AOS },
            { Skyrim.Explosion.ExplosionStormAtronachPowerAttack.FormKey, AudioOverhaulSkyrim.ExplosionStormAtronachPowerAttack_AOS },
            { Skyrim.Explosion.FXAtronachFireDeathExplosion.FormKey, AudioOverhaulSkyrim.FXAtronachFireDeathExplosion_AOS},
            { Skyrim.Explosion.FireballStormAlduinDeathExplosion.FormKey, AudioOverhaulSkyrim.FireballStormAlduinDeathExplosion_AOS },
            { Skyrim.Explosion.FireballStormImpactExplosion.FormKey, AudioOverhaulSkyrim.FireballStormImpactExplosion_AOS },
            { Skyrim.Explosion.MAGIceSpikeVolleyExplosion.FormKey, AudioOverhaulSkyrim.MAGIceSpikeVolleyExplosion_AOS },
            { Skyrim.Explosion.crGiantSlamExplosion.FormKey, AudioOverhaulSkyrim.crGiantSlamExplosionBIG },
        };
    }
}
