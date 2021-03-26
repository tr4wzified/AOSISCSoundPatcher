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
            if (!state.LoadOrder.ContainsKey(ImmersiveSoundsCompendium) && !state.LoadOrder.ContainsKey(AudioOverhaulSkyrim))
                throw new Exception("This patcher won't function without either Immersive Sounds Compendium or Audio Overhaul Skyrim! Either don't use this patcher or use one of the above mods to let it function.");

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
                    if (armor.Keywords == null) continue;

                    if (armor.Keywords.Contains(Skyrim.Keyword.ClothingRing) && armor.PickUpSound != ringLink.AsNullable())
                    {
                        var armorCopy = armor.DeepCopy();
                        armorCopy.PickUpSound.SetTo(ringLink);
                        state.PatchMod.Armors.Set(armorCopy);
                    }
                    else if (armor.Keywords.Contains(Skyrim.Keyword.ClothingNecklace) && (armor.PickUpSound.FormKey != neckUpLink.FormKey || armor.PutDownSound.FormKey != neckDownLink.FormKey))
                    {
                        var armorCopy = armor.DeepCopy();
                        armorCopy.PickUpSound.SetTo(neckUpLink);
                        armorCopy.PutDownSound.SetTo(neckDownLink);
                        state.PatchMod.Armors.Set(armorCopy);
                    }
                }

                foreach (var weapon in state.LoadOrder.PriorityOrder.Weapon().WinningOverrides())
                {
                    if (weapon.Keywords == null) continue;

                    if (weapon.Keywords.Contains(Skyrim.Keyword.WeapTypeBattleaxe))
                    {
                        if (weapon.Data != null && weapon.Data.Flags.HasFlag(WeaponData.Flag.BoundWeapon) && weapon.AttackFailSound.FormKey != swingBoundAxeLink.FormKey)
                        {
                            var weaponCopy = weapon.DeepCopy();
                            weaponCopy.AttackFailSound.SetTo(swingBoundAxeLink);
                            state.PatchMod.Weapons.Set(weaponCopy);
                        }
                        else if (weapon.AttackFailSound.FormKey != swingAxeLink.FormKey)
                        {
                            var weaponCopy = weapon.DeepCopy();
                            weaponCopy.AttackFailSound.SetTo(swingAxeLink);
                            state.PatchMod.Weapons.Set(weaponCopy);
                        }
                    }

                    else if (weapon.Keywords.Contains(Skyrim.Keyword.WeapTypeWarhammer) && weapon.AttackFailSound.FormKey != swingBluntLink.FormKey)
                    {
                        var weaponCopy = weapon.DeepCopy();
                        weaponCopy.AttackFailSound.SetTo(swingBluntLink);
                        state.PatchMod.Weapons.Set(weaponCopy);
                    }

                    else if (weapon.Keywords.Contains(Skyrim.Keyword.WeapTypeSword) && weapon.Data != null && weapon.Data.Flags.HasFlag(WeaponData.Flag.BoundWeapon) && weapon.AttackFailSound.FormKey != swingBladeLink.FormKey)
                    {
                        var weaponCopy = weapon.DeepCopy();
                        weaponCopy.AttackFailSound.SetTo(swingBladeLink);
                        state.PatchMod.Weapons.Set(weaponCopy);
                    }
                }
            }

            if (state.LoadOrder.ContainsKey(AudioOverhaulSkyrim))
            {
                Console.WriteLine("Detected Audio Overhaul Skyrim.");

                var smallImpactLink = new FormLink<IImpactDataSetGetter>(AudioOverhaulSkyrim.MakeFormKey(0x05B6EA));

                foreach (var weapon in state.LoadOrder.PriorityOrder.Weapon().WinningOverrides())
                {
                    if (weapon.Keywords == null) continue;

                    if (weapon.Keywords.Contains(Skyrim.Keyword.WeapTypeDagger) && weapon.Data != null && !weapon.Data.Flags.HasFlag(WeaponData.Flag.BoundWeapon) && (weapon.ImpactDataSet.FormKey != smallImpactLink.FormKey || weapon.EquipSound.FormKey != Skyrim.SoundDescriptor.WPNBlade1HandSmallDrawSD.FormKey || weapon.UnequipSound.FormKey != Skyrim.SoundDescriptor.WPNBlade1HandSmallSheatheSD.FormKey))
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
