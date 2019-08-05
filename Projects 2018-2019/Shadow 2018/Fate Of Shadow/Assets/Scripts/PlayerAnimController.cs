using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    private Animator animator;

	public float speed = 40f;
	public float horizontalMove = 0f;
	bool jump = false;
	bool hit = false;
	bool shift = false;
	bool sit = false;
	bool hurt = false;

	
    void Start()
    {
        animator = GetComponent<Animator>();
    }

	public void GetMotion()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    void Update()
    {
		GetMotion();
		//вытащить спрайт и его анимацию на пустышку,чтобы не вертело весь объект
		// search 2d controller script
		//14:00
		horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if(Input.GetKeyDown(KeyCode.LeftShift))
		{
			shift = true;
		}
		else if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			shift = false;
		}

		if(Input.GetKeyDown(KeyCode.Space))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}
		else if (Input.GetKeyUp(KeyCode.Space))
		{
			jump=false;
			animator.SetBool("IsJumping", false);
		}
		// else if(Input.GetKeyUp(KeyCode.Space))
		// {
		// 	jump = false;
		// 	animator.SetBool("IsJumping", false);
		// }

		if (Input.GetKeyDown(KeyCode.P))
		{
			hit = true;
		}
		else if (Input.GetKeyUp(KeyCode.P))
		{
			hit = false;
		}
		// if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
		// {
		// 	animator.SetTrigger("ShadowIdle");
		// }
    }
}
