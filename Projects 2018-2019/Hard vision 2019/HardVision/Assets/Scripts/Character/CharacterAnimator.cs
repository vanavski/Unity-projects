using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    private const float animationSmoothTime = .1f;

    public Animator anim;
    public NavMeshAgent agent;

    void Update()
    {
        var speedPercent = agent.velocity.magnitude / agent.speed;
        anim.SetFloat("AnimationSpeed", speedPercent, animationSmoothTime, Time.deltaTime);
        if (speedPercent == 0)
            anim.SetBool("Moving", false);
        else anim.SetBool("Moving", true);
        if (Input.GetKey(KeyCode.Y))
            anim.SetBool("WeaponEquipped", false);
    }
}