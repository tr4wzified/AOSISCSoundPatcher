using System;
using System.Collections.Generic;
using System.Linq;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.Skyrim;
using System.Threading.Tasks;
using Mutagen.Bethesda.FormKeys.SkyrimSE;

namespace AOSISCSoundPatcher
{
    public class Program
    {
        [Obsolete]
        public static async Task<int> Main(string[] args)
        {
            return await SynthesisPipeline.Instance
                .AddPatch<ISkyrimMod, ISkyrimModGetter>(RunPatch)
                .SetTypicalOpen(GameRelease.SkyrimSE, "AOSISCSoundPatcher.esp")
                .Run(args);
        }

        private readonly static ModKey ImmersiveSoundsCompendium = ModKey.FromNameAndExtension("Immersive Sounds - Compendium.esp");
        private readonly static ModKey AudioOverhaulSkyrim = ModKey.FromNameAndExtension("Audio Overhaul Skyrim.esp");

        public static void RunPatch(IPatcherState<ISkyrimMod, ISkyrimModGetter> state)
        {
            if (state.LoadOrder.ContainsKey(ImmersiveSoundsCompendium))
            {
                Console.WriteLine("Detected Immersive Sounds Compendium.");

                var ringLink = new FormLink<ISoundDescriptorGetter>(ImmersiveSoundsCompendium.MakeFormKey(0x08AB14));
                var neckUpLink = new FormLink<ISoundDescriptorGetter>(ImmersiveSoundsCompendium.MakeFormKey(0x08AB15));
                var neckDownLink = new FormLink<ISoundDescriptorGetter>(ImmersiveSoundsCompendium.MakeFormKey(0x08AB16));
                var swingAxeLink = new FormLink<ISoundDescriptorGetter>(ImmersiveSoundsCompendium.MakeFormKey(0x1E6B31));
                var swingBoundAxeLink = new FormLink<ISoundDescriptorGetter>(ImmersiveSoundsCompendium.MakeFormKey(0x04C731));
                var swingBluntLink = new FormLink<ISoundDescriptorGetter>(ImmersiveSoundsCompendium.MakeFormKey(0x1F5E3B));
                var swingBladeLink = new FormLink<ISoundDescriptorGetter>(ImmersiveSoundsCompendium.MakeFormKey(0x04762F));

                foreach (var armor in state.LoadOrder.PriorityOrder.Armor().WinningOverrides())
                {
                    if (armor.Keywords != null)
                    {
                        bool modified = false;
                        var armorCopy = armor.DeepCopy();

                        if (armor.Keywords.Contains(Skyrim.Keyword.ClothingRing))
                        {
                            armorCopy.PickUpSound.SetTo(ringLink);
                            modified = true;
                        }

                        else if (armor.Keywords.Contains(Skyrim.Keyword.ClothingNecklace))
                        {
                            armorCopy.PickUpSound.SetTo(neckUpLink);
                            armorCopy.PutDownSound.SetTo(neckDownLink);
                            modified = true;
                        }

                        if (modified) state.PatchMod.Armors.Set(armorCopy);
                    }
                }

                foreach (var weapon in state.LoadOrder.PriorityOrder.Weapon().WinningOverrides())
                {
                    if (weapon.Keywords != null)
                    {
                        bool modified = false;
                        var weaponCopy = weapon.DeepCopy();

                        if (weapon.Keywords.Contains(Skyrim.Keyword.WeapTypeBattleaxe))
                        {
                            if (weapon.Data != null)
                            {
                                if (weapon.Data.Flags.HasFlag(WeaponData.Flag.BoundWeapon))
                                {
                                    weaponCopy.AttackFailSound.SetTo(swingBoundAxeLink);
                                    modified = true;
                                }
                                else
                                {
                                    weaponCopy.AttackFailSound.SetTo(swingAxeLink);
                                    modified = true;
                                }
                            }
                        }
                        else if (weapon.Keywords.Contains(Skyrim.Keyword.WeapTypeWarhammer))
                        {
                            weaponCopy.AttackFailSound.SetTo(swingBluntLink);
                            modified = true;
                        }

                        else if (weapon.Keywords.Contains(Skyrim.Keyword.WeapTypeSword) && weapon.Data != null && weapon.Data.Flags.HasFlag(WeaponData.Flag.BoundWeapon))
                        {
                            weaponCopy.AttackFailSound.SetTo(swingBladeLink);
                            modified = true;
                        }

                        if (modified) state.PatchMod.Weapons.Set(weaponCopy);
                    }
                }
            }

            if (state.LoadOrder.ContainsKey(AudioOverhaulSkyrim))
            {
                Console.WriteLine("Detected Audio Overhaul Skyrim.");

                var smallImpactLink = new FormLink<IImpactDataSetGetter>(AudioOverhaulSkyrim.MakeFormKey(0x05B6EA));

                foreach (var weapon in state.LoadOrder.PriorityOrder.Weapon().WinningOverrides())
                {
                    if (weapon.Keywords != null)
                    {
                        if (weapon.Keywords.Contains(Skyrim.Keyword.WeapTypeDagger) && weapon.Data != null && !weapon.Data.Flags.HasFlag(WeaponData.Flag.BoundWeapon))
                        {
                            var weaponCopy = weapon.DeepCopy();
                            weaponCopy.ImpactDataSet.SetTo(smallImpactLink);
                            weaponCopy.EquipSound.SetTo(Skyrim.SoundDescriptor.WPNBlade1HandSmallDrawSD);
                            weaponCopy.UnequipSound.SetTo(Skyrim.SoundDescriptor.WPNBlade1HandSmallSheatheSD);
                            state.PatchMod.Weapons.Set(weaponCopy);
                        }
                    }
                }
            }
        }
    }
}
