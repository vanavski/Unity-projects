using UnityEngine;

public class HealthController : MonoBehaviour
{
    private float healthWidth;
    public RectTransform healthBar;
    public CharacterStats stats;

    void Awake()
    {
        healthWidth = healthBar.sizeDelta.x / stats.maxHealth;
    }

    void Update()
    {
        if (stats.CurrentHealth < stats.maxHealth)
            Regenerate();
    }

    public void TakeDamage(float damageAmount)
    {
        stats.TakeDamage(damageAmount);
        healthBar.sizeDelta = new Vector2(healthBar.sizeDelta.x - healthWidth * damageAmount, healthBar.sizeDelta.y);
        if (healthBar.sizeDelta.x <= 0)
            gameObject.SetActive(false);

    }

    public void Regenerate()
    {
        stats.Regenerate();
        healthBar.sizeDelta = new Vector2(healthBar.sizeDelta.x + stats.regeneration.GetValue(), healthBar.sizeDelta.y);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
