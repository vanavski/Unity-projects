using UnityEngine;

public class BulletController : MonoBehaviour
{
    public CharacterStats myStats;

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Character")
        {
            col.gameObject.GetComponent<HealthController>().TakeDamage(myStats.damage.GetValue());
            col.gameObject.GetComponentInChildren<PlayerHubController>().onHitTaken.Invoke();
            gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<HealthController>().TakeDamage(myStats.damage.GetValue());
            col.gameObject.GetComponent<EnemyController>().onHitTaken.Invoke();
            gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }
}