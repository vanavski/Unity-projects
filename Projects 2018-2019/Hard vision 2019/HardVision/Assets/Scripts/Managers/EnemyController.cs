using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    public UnityEvent onHitTaken;
    public GameObject bullet;
    public Transform bulletPos;
    public GameObject Character;

    public AttackController attackController;
    public float WaitingTime = 1f;
    public bool canShoot = true;

    void Update()
    {
        if (Vector3.Distance(transform.position, Character.transform.position) < 12f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation,
                Quaternion.LookRotation(Character.transform.position - transform.position),
                120f * Time.deltaTime);
            if (canShoot)
            {
                canShoot = false;
                attackController.Shot(bullet, bulletPos, GetComponent<CharacterStats>());
                StartCoroutine(WaitForShot());
            }
        }
    }

    private IEnumerator WaitForShot()
    {
        yield return new WaitForSeconds(WaitingTime);
        canShoot = true;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}