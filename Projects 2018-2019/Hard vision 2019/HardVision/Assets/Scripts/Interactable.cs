using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 7f;
    public Transform interactionTransform;

    private bool isFocus = false;
    private bool hasInteracted = false;

    private Transform player;

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }

    void Update()
    {
        if (isFocus && !hasInteracted)
        {
            var distanceToPlayer = Vector3.Distance(player.position, interactionTransform.position);
            if (distanceToPlayer <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}