using UnityEngine;
using UnityEngine.UI;

public class ItemMerchant : MonoBehaviour
{
    [SerializeField]
    private Text itemName;
    [SerializeField]
    private Text description;
    [SerializeField]
    private Image icon;
    [SerializeField]
    private Text armorModifier;
    [SerializeField]
    private Text damageModifier;
    [SerializeField]
    private Text magazine;

    public void UpdateDisplayUI(Equipment swordData)
    {
        itemName.text = swordData.name;
        description.text = swordData.Description;
        icon.sprite = swordData.icon;
        armorModifier.text = swordData.ArmorModifier.ToString();
        damageModifier.text = swordData.DamageModifier.ToString();
        magazine.text = swordData.Magazine.ToString();
    }
}