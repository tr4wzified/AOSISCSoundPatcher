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

        public static void RunPatch(IPatcherState<ISkyrimMod, ISkyrimModGetter> state)
        {
            bool iscActive = state.LoadOrder.ContainsKey(ImmersiveSoundsCompendium.ModKey);
            bool aosActive = state.LoadOrder.ContainsKey(AudioOverhaulSkyrim.ModKey);

            if (!iscActive && !aosActive)
                throw new Exception("This patcher won't function without either Immersive Sounds Compendium or Audio Overhaul Skyrim! Either don't use this patcher or use one of the above mods to let it function.");


            if (iscActive)
            {
                Console.WriteLine("Detected Immersive Sounds Compendium.");


                // Patch Rings (pick up sound) & Necklaces equip and unequip sound
                foreach (var armor in state.LoadOrder.PriorityOrder.Armor().WinningOverrides())
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

                    if (armorCopy.PickUpSound.FormKey != armor.PickUpSound.FormKey || armorCopy.PutDownSound.FormKey != armorCopy.PutDownSound.FormKey)
                        state.PatchMod.Armors.Set(armorCopy);
                }

                foreach (var weapon in state.LoadOrder.PriorityOrder.Weapon().WinningOverrides())
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

                foreach (var soulGem in state.LoadOrder.PriorityOrder.SoulGem().WinningOverrides())
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
            }
        }
    }
}
