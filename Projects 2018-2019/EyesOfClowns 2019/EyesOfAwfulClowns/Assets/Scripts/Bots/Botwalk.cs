using UnityEngine;
using UnityEngine.AI;

//[RequireComponent(typeof(NavMeshAgent))]

public class BotWalk: MonoBehaviour
{
    public int activeDistance = 10;
    public Transform[] wayPoints;
    public float stoppingDistance = 5;
    public float timeWait = 3;
    public float rotationSpeed = 5;
    public Transform defLook;
    private NavMeshAgent agent;
    private Vector3 target;
    private float curTimeout;
    private int wayCount;
    private bool isTarget;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void SetRotation(Vector3 lookAt)
    {
        Vector3 lookPos = lookAt - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    void Update()
    {
        target = PlayerInfo.player.position;
        float dis = Vector3.Distance(transform.position, PlayerInfo.player.position);
        if (dis < activeDistance)
        {
            isTarget = true;
        }

        if (wayPoints.Length >= 2 && !isTarget)
        {
            agent.stoppingDistance = 0;
            agent.SetDestination(wayPoints[wayCount].position);
            if (!agent.hasPath)
            {
                SetRotation(defLook.position);
                curTimeout += Time.deltaTime;
                if (curTimeout > timeWait) { curTimeout = 0; if (wayCount < wayPoints.Length - 1) wayCount++; else wayCount = 0; }
            }
        }
        else if (wayPoints.Length == 0 || isTarget)
        {
            agent.stoppingDistance = stoppingDistance;
            agent.SetDestination(target);
            if (agent.velocity == Vector3.zero) SetRotation(target);
        }

    }
}