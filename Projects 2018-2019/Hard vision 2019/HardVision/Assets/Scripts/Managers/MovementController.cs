using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour
{
    public NavMeshAgent PlayerAgent;

    private Transform target;

    public Vector3 AgentMoveByClick(Transform moveObj, Vector3 targetPos)
    {
        RaycastHit hit;
        Ray ray = Camera.allCameras[0].ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            targetPos.x = hit.point.x;
            targetPos.y = moveObj.position.y;
            targetPos.z = hit.point.z;
        }
        return targetPos;
    }

    void Update()
    {
        if (target != null)
        {
            PlayerAgent.SetDestination(target.position);
        }
    }

    public void FollowTarget(Interactable newTarget)
    {
        PlayerAgent.stoppingDistance = newTarget.radius * 0.5f;
        target = newTarget.interactionTransform;
    }

    public void StopFollowingTarget()
    {
        PlayerAgent.stoppingDistance = 0f;
        target = null;
    }
}