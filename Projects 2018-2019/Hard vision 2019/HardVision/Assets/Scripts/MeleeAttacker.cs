using UnityEngine;

public class MeleeAttacker : MonoBehaviour
{
    [SerializeField]
    private PlayerStats playerStats;
    [SerializeField]
    Animator anim;
    //private AttackController AttackController;

    private bool isAttack = true;
    private bool isLegAttack;

    void Start()
    {
        playerStats = GetComponentInParent<PlayerStats>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            isAttack = true;
            anim.SetBool("LegAttack", true);
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            isAttack = false;
            anim.SetBool("LegAttack", false);
        }
        if (Input.GetKey(KeyCode.T))
        {
            isAttack = true;
            anim.SetBool("MeleeAttack", true);
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            isAttack = false;
            anim.SetBool("MeleeAttack", false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isAttack)
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<HealthController>().TakeDamage(playerStats.MeleeDamage.GetValue());
                collision.gameObject.GetComponent<EnemyController>().onHitTaken.Invoke();
                gameObject.SetActive(false);
            }
    }
}
