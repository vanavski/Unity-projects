using UnityEngine;

public class AttackController : MonoBehaviour
{
    #region Singleton
    public static AttackController instance;

    public void Awake()
    {
        instance = this;
    }
    #endregion

    public const float Speed = 50f;
    public Animator anim;

    public void Shot(GameObject bullet, Transform spawnPos, CharacterStats stats, float speed = Speed)
    {
        var currentBullet = PoolController.SharedInstance.GetPooledObject("Bullet");
        if (currentBullet != null)
        {
            currentBullet.transform.position = spawnPos.transform.position;
            currentBullet.transform.rotation = spawnPos.transform.rotation;
            currentBullet.GetComponent<BulletController>().myStats = stats;
            currentBullet.SetActive(true);
            currentBullet.GetComponent<Rigidbody>().velocity = currentBullet.transform.forward * speed;
        }
    }

    public void Attack()
    {
        anim.SetBool("MeleeAttack", true);
        //добавить функционал по отнимаю хп
    }
}