using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using Input = UnityEngine.Input;
using UnityEngine.EventSystems;

public class PlayerHubController : MonoBehaviour
{
    public UnityEvent onHitTaken;

    public Animator anim;
    public NavMeshAgent agent;

    public Camera camera;

    public GameObject bullet;
    public Transform bulletPos;

    private Vector3 targetPos;
    private Interactable focus;

    public AttackController attackController;
    public MovementController moveController;

    public float WaitingTime = 4f;
    private bool canShoot;
    //private bool canAttack;

    void Start()
    {
        attackController = AttackController.instance;
        canShoot = true;
        //canAttack = true;
    }

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetMouseButtonDown(0))
        {
            MovePlayer();
            RemoveFocus();
        }

        if (Input.GetKeyDown(KeyCode.F) && EquipmentController.instance.currentEquipment[5] != null && canShoot)
        {
            attackController.Shot(bullet, bulletPos, PlayerStats.instance);
            EquipmentController.instance.bullets++;
            UIController.instance.Refresh();
            if (EquipmentController.instance.bullets == EquipmentController.instance.currentEquipment[5].Magazine)
            {
                canShoot = false;
                UIController.instance.SwitchReload();
                StartCoroutine(Reload());
            }
        }

        //if (Input.GetKey(KeyCode.G) || Input.GetKey(KeyCode.T))
        //{
        //    attackController.Attack();
        //}

        //if (Input.GetKey(KeyCode.V))
        //{
        //    if (canAttack)
        //    {
        //        attackManager.Attack(); //добавить функционал
        //        canAttack = false;
        //    }
        //}

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                var interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                    SetFocus(interactable);
            }
        }
    }

    void MovePlayer()
    {
        targetPos = moveController.AgentMoveByClick(transform, targetPos);
        agent.SetDestination(targetPos);
    }

    public IEnumerator Reload()
    {
        yield return new WaitForSeconds(WaitingTime);
        canShoot = true;
        UIController.instance.SwitchReload();
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();

            focus = newFocus;
            moveController.FollowTarget(newFocus);
        }
        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;
        moveController.StopFollowingTarget();
    }

    //public void StopAttacking()
    //{
    //    anim.SetBool("MeleeAttack", false);
    //    canAttack = true;
    //}
}