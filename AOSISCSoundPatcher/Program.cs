using System;
using System.Linq;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.Skyrim;
using System.Threading.Tasks;
using Mutagen.Bethesda.FormKeys.SkyrimSE;
using Mutagen.Bethesda.Plugins.Exceptions;

namespace AOSISCSoundPatcher
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            return await SynthesisPipeline.Instance
                .AddPatch<ISkyrimMod, ISkyrimModGetter>(RunPatch)
                .SetTypicalOpen(GameRelease.SkyrimSE, "AOSISCSoundPatcher.esp")
                .Run(args);
        }

        public static void RunPatch(IPatcherState<ISkyrimMod, ISkyrimModGetter> state)
        {
            bool iscActive = state.LoadOrder.ContainsKey(ImmersiveSoundsCompendium.ModKey);
            bool aosActive = state.LoadOrder.ContainsKey(AudioOverhaulSkyrim.ModKey);

            if (!iscActive && !aosActive)
                throw new Exception("This patcher won't function without either Immersive Sounds Compendium or Audio Overhaul Skyrim! Either don't use this patcher or use one of the above mods to let it function.");
            if (iscActive)
                Console.WriteLine("Detected Immersive Sounds Compendium.");
            if (aosActive)
                Console.WriteLine("Detected Audio Overhaul for Skyrim.");

            if (iscActive)
            {
                // Patch Armor sounds, Rings (pick up sound) & Necklaces equip and unequip sounds.
                foreach (var armor in state.LoadOrder.PriorityOrder.Armor().WinningOverrides())
                {
                    try
                    {
                        if (armor.Keywords == null) continue;

                        var armorCopy = armor.DeepCopy();

                        if (armor.Keywords.Contains(Skyrim.Keyword.ClothingRing))
                        {
                            armorCopy.PickUpSound.SetTo(ImmersiveSoundsCompendium.ITMRingUp);
                        }
                        else if (armor.Keywords.Contains(Skyrim.Keyword.ClothingNecklace))
                        {
                            armorCopy.PickUpSound.SetTo(ImmersiveSoundsCompendium.ITMNeckUp);
                            armorCopy.PutDownSound.SetTo(ImmersiveSoundsCompendium.ITMNeckDown);
                        }
                        else if (armor.Keywords.Contains(Skyrim.Keyword.ArmorCuirass))
                        {
                            foreach (var keyword in armor.Keywords)
                            {
                                if (ImmersiveSoundsCompendium.FootstepSets.TryGetValue(keyword, out var armorSound))
                                {
                                    foreach (var armorAddon in armor.Armature)
                                    {
                                        var resolvedAddon = armorAddon.TryResolve(state.LinkCache);
                                        if (resolvedAddon is not null && resolvedAddon.FootstepSound.IsNull)
                                        {
                                            var addonCopy = resolvedAddon.DeepCopy();
                                            addonCopy.FootstepSound.SetTo(armorSound);
                                            state.PatchMod.ArmorAddons.Set(addonCopy);
                                        }
                                    }
                                }
                            }
                        }

                        if (armor.PickUpSound.FormKey != armorCopy.PickUpSound.FormKey || armor.PutDownSound.FormKey != armorCopy.PutDownSound.FormKey)
                            state.PatchMod.Armors.Set(armorCopy);
                    }
                    catch (Exception e)
                    {
                        throw RecordException.Enrich(e, armor);
                    }
                }

                // Patch weapon swing and impact sounds.
                foreach (var weapon in state.LoadOrder.PriorityOrder.Weapon().WinningOverrides())
                {
                    try
                    {
                        if (weapon.Template.IsNull)
                        {
                        if (weapon.Keywords == null) continue;

                        var weaponCopy = weapon.DeepCopy();

                        if (aosActive)
                        {
                            if (weapon.Keywords.Contains(Skyrim.Keyword.WeapTypeDagger) && weapon.Data != null && !weapon.Data.Flags.HasFlag(WeaponData.Flag.BoundWeapon))
                            {
                                weaponCopy.ImpactDataSet.SetTo(AudioOverhaulSkyrim.WPNzBlade1HandSmallImpactSet);
                                weaponCopy.EquipSound.SetTo(Skyrim.SoundDescriptor.WPNBlade1HandSmallDrawSD);
                                weaponCopy.UnequipSound.SetTo(Skyrim.SoundDescriptor.WPNBlade1HandSmallSheatheSD);
                            }

                            var changed = weapon.ImpactDataSet.FormKey != weaponCopy.ImpactDataSet.FormKey || weapon.EquipSound.FormKey != weaponCopy.EquipSound.FormKey || weapon.UnequipSound.FormKey != weaponCopy.UnequipSound.FormKey;

                            if (changed)
                                state.PatchMod.Weapons.Set(weaponCopy);
                        }

                        if (weapon.Keywords.Contains(Skyrim.Keyword.WeapTypeBattleaxe))
                        {
                            if (weapon.Data?.Flags.HasFlag(WeaponData.Flag.BoundWeapon) ?? false)
                            {
                                weaponCopy.AttackFailSound.SetTo(ImmersiveSoundsCompendium.WPNSwing2HandBound);
                            }
                            else
                            {
                                weaponCopy.AttackFailSound.SetTo(ImmersiveSoundsCompendium.WPNSwingAxe2Hand);
                            }

                        }

                        else if (weapon.Keywords.Contains(Skyrim.Keyword.WeapTypeWarhammer))
                        {
                            weaponCopy.AttackFailSound.SetTo(ImmersiveSoundsCompendium.WPNSwingBlunt2Hand);
                        }

                        else if (weapon.Keywords.Contains(Skyrim.Keyword.WeapTypeSword) && weapon.Data != null && weapon.Data.Flags.HasFlag(WeaponData.Flag.BoundWeapon))
                        {
                            weaponCopy.AttackFailSound.SetTo(ImmersiveSoundsCompendium.WPNSwingBladeMediumBoundSD);
                        }

                        if (weapon.AttackFailSound.FormKey != weaponCopy.AttackFailSound.FormKey ||
                            weapon.ImpactDataSet.FormKey != weaponCopy.ImpactDataSet.FormKey ||
                            weapon.EquipSound.FormKey != weaponCopy.EquipSound.FormKey ||
                            weapon.UnequipSound.FormKey != weaponCopy.UnequipSound.FormKey)
                        {
                            state.PatchMod.Weapons.Set(weaponCopy);
                        }
                        }
                    }
                    catch (Exception e)
                    {
                        throw RecordException.Enrich(e, weapon);
                    }
                }

                // Path soul gem sounds.
                foreach (var soulGem in state.LoadOrder.PriorityOrder.SoulGem().WinningOverrides())
                {
                    try
                    {
                        if (soulGem.Keywords?.Contains(Skyrim.Keyword.VendorItemSoulGem) ?? false)
                        {
                            var soulGemCopy = soulGem.DeepCopy();
                            soulGemCopy.PickUpSound.SetTo(ImmersiveSoundsCompendium.ITMGemUp);
                            soulGemCopy.PutDownSound.SetTo(ImmersiveSoundsCompendium.ITMGemDown);

                            if (soulGem.PickUpSound.FormKey != soulGemCopy.PickUpSound.FormKey || soulGem.PutDownSound.FormKey != soulGemCopy.PutDownSound.FormKey)
                                state.PatchMod.SoulGems.Set(soulGemCopy);
                        }
                    }
                    catch (Exception e)
                    {
                        throw RecordException.Enrich(e, soulGem);
                    }
                }

                // Patch magic projectile and explosion sounds.
                foreach (var magicEffect in state.LoadOrder.PriorityOrder.MagicEffect().WinningOverrides())
                {
                    try
                    {
                        if (magicEffect.Projectile == null) continue;

                        var magicEffectCopy = magicEffect.DeepCopy();

                        if (aosActive)
                        {
                            if (AudioOverhaulSkyrim.Projectiles.TryGetValue(magicEffect.Projectile.FormKey, out var replacerProjectile) && replacerProjectile != null)
                                magicEffectCopy.Projectile.SetTo(replacerProjectile);

                            if (AudioOverhaulSkyrim.Explosions.TryGetValue(magicEffect.Explosion.FormKey, out var replacerExplosion) && replacerExplosion != null)
                                magicEffectCopy.Explosion.SetTo(replacerExplosion);
                            /*
                            WIP - Replace explosion properties in scripts (dwarven spider summons) (reference formkey: 0004EFC6)
                            foreach (var script in magicEffectCopy.VirtualMachineAdapter.Scripts)
                            {
                                foreach (var property in script.Properties)
                                {
                                    property.
                                    foreach (var containedFormLink in property.ContainedFormLinks)
                                    {
                                        if (Replacers.Explosions.TryGetValue(containedFormLink.FormKey, out var replacerExplosion)
                                            containedFormLink.
                                    }
                                }
                            }
                            */
                        }

                        if (magicEffect.Projectile.FormKey != magicEffectCopy.Projectile.FormKey || magicEffect.Explosion.FormKey != magicEffectCopy.Explosion.FormKey)
                            state.PatchMod.MagicEffects.Set(magicEffectCopy);
                    }
                    catch (Exception e)
                    {
                        throw RecordException.Enrich(e, magicEffect);
                    }
                }
            }
        }
    }
}
