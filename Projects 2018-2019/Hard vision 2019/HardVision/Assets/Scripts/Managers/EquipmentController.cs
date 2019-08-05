using System;
using UnityEngine;

public class EquipmentController : MonoBehaviour
{
    #region Singleton

    public static EquipmentController instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public Animator anim;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    public Transform Head;
    public Transform Body;
    public Transform Legs;
    public Transform Feet;
    public Transform Weapon;

    public Equipment[] currentEquipment;
    private GameObject[] currentPrefabs;

    public int bullets;

    private InventoryController inventory;

    void Start()
    {
        inventory = InventoryController.instance;

        var slotsCount = Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[slotsCount];
        currentPrefabs = new GameObject[slotsCount];
    }

    public void Equip(Equipment newItem)
    {
        var slotIndex = (int)newItem.EquipSlot;
        Equipment oldItem = null;

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }

        onEquipmentChanged?.Invoke(newItem, oldItem);

        currentEquipment[slotIndex] = newItem;

        var newPrefab = Instantiate(newItem.Prefab);
        var parent = CheckParentSlot(newItem);
        newPrefab.transform.parent = parent;
        newPrefab.transform.localPosition = newItem.SpawnPointPos;
        newPrefab.transform.localRotation = Quaternion.Euler(newItem.SpawnPointRot);
        currentPrefabs[slotIndex] = newPrefab;

        CheckRangedWeapon(newItem);
    }

    public void UnEquip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            if (currentPrefabs[slotIndex] != null)
                Destroy(currentPrefabs[slotIndex].gameObject);
            var oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            onEquipmentChanged?.Invoke(null, oldItem);
            CheckRangedWeapon(null);
        }
    }

    public void UnEquipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            UnEquip(i);
        }
    }

    void CheckRangedWeapon(Equipment item)
    {
        if (item.EquipSlot == EquipmentSlot.RangedWeapon)
        {
            anim.SetBool("WeaponEquipped", true);
        }

        else if (anim.GetBool("WeaponEquipped"))
        {
            foreach (var eqItem in currentEquipment)
            {
                if (eqItem != null && eqItem.EquipSlot == EquipmentSlot.RangedWeapon)
                    return;
                anim.SetBool("WeaponEquipped", false);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
            UnEquipAll();

        if (bullets == currentEquipment[5].Magazine)
            bullets = 0;
    }

    Transform CheckParentSlot(Equipment newItem)
    {
        switch (newItem.EquipSlot)
        {
            case EquipmentSlot.Head:
                return Head;
            case EquipmentSlot.Chest:
                return Body;
            case EquipmentSlot.Legs:
                return Legs;
            case EquipmentSlot.Feet:
                return Feet;
            case EquipmentSlot.RangedWeapon:
                return Weapon;
            default: return Weapon;
        }
    }
}
