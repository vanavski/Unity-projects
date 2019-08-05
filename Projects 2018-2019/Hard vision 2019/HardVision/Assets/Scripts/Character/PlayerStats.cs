public class PlayerStats : CharacterStats
{
    #region Singleton
    public static PlayerStats instance;

    public void Awake()
    {
        instance = this;
    }
    #endregion

    public StatController MeleeDamage;

    void Start()
    {
        EquipmentController.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    public void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            armor.AddModifier(newItem.ArmorModifier);
            damage.AddModifier(newItem.DamageModifier);
        }

        if (oldItem != null)
        {
            armor.RemoveModifier(oldItem.ArmorModifier);
            damage.RemoveModifier(oldItem.DamageModifier);
        }
    }
}