using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public float CurrentHealth { get; private set; }
    public float maxHealth = 100;
    public StatController damage;
    public StatController armor;
    public StatController regeneration;

    void Awake()
    {
        CurrentHealth = maxHealth;
    }

    public void Regenerate()
    {
        CurrentHealth += regeneration.GetValue();
    }

    public void TakeDamage(float damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        CurrentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage");
    }
}
