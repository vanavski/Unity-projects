using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment", order = 51)]
public class Equipment : Item
{
    public EquipmentSlot EquipSlot;
    public GameObject Prefab;
    public Vector3 SpawnPointPos;
    public Vector3 SpawnPointRot;
    
    public string Description;
    public int ArmorModifier;
    public int DamageModifier;
    public int Magazine;

    public override void Use()
    {
        base.Use();
        EquipmentController.instance.Equip(this);
        RemoveFromInventory();
    }
}

public enum EquipmentSlot
{
    Head, Chest, Legs, Feet, MeleeWeapon, RangedWeapon
}
