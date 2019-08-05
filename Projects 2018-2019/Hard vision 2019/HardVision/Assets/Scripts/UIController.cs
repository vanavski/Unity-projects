using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    #region Singleton
    public static UIController instance;

    void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }
    #endregion

    public GameObject OverlayUI;

    public bool isReloading;
    public Text ReloadText;

    public GameObject WeaponUI;

    private int currentBullets;
    private int maxBullets;

    void Start()
    {
        if (EquipmentController.instance.currentEquipment.Length != 0 && EquipmentController.instance.currentEquipment[5] != null ||
            EquipmentController.instance.currentEquipment.Length == 0)
            SetDefaultState();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.C))
            if (WeaponUI.activeSelf)
                WeaponUI.SetActive(false);
    }

    public void UpdateUI()
    {
        if (isReloading)
            ReloadText.text = "Reloading";
        else
            ReloadText.text = $"{currentBullets}/{maxBullets}";
    }

    public void Refresh()
    {
        var rangedWeapon = EquipmentController.instance.currentEquipment[5];
        if (rangedWeapon != null)
            maxBullets = rangedWeapon.Magazine;
        currentBullets = maxBullets - EquipmentController.instance.bullets;
        UpdateUI();
    }

    public void SetDefaultState()
    {
        maxBullets = 0;
        currentBullets = maxBullets;

        UpdateUI();
    }

    public void SwitchReload()
    {
        isReloading = !isReloading;

        UpdateUI();
    }
}