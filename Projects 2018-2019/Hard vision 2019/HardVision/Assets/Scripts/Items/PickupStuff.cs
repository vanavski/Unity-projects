using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupStuff : Interactable
{
    public Equipment item;
    public GameObject WeaponUI;
    [SerializeField]
    private GameEvent OnWeaponSelected;

    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    private void OnMouseDown()
    {
        OnWeaponSelected.Raise();
        WeaponUI.SetActive(true);
    }

    private void PickUp()
    {
        var wasPickedUp = InventoryController.instance.Add(item);
        if (wasPickedUp)
            Destroy(gameObject);
    }
}