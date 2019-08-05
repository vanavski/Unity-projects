using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveEnemy : MonoBehaviour {
	public float minSpeed;
	public float maxSpeed;
	private GameObject DefenseObject;

	public Text text;
	
	public void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Bullet")
			Destroy(this.gameObject);
		if (col.gameObject.tag == "Defense")
		{
			DefenseObject.GetComponent<Defense>().Hp--;
			Destroy(this.gameObject);
		}
	}

	void Start()
	{
		DefenseObject = GameObject.FindGameObjectWithTag("Defense");
		text = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<Text>();
	}

	void Update () {
		var speed = Random.Range(minSpeed,maxSpeed);
		transform.position = Vector3.MoveTowards(
			transform.position,
			new Vector3(-185,Random.Range(-15,92),Random.Range(-39,40)),
			speed * Time.deltaTime);	

		DefenseObject = GameObject.FindGameObjectWithTag("Defense");

		text.text = "Your hp = " + DefenseObject.GetComponent<Defense>().Hp.ToString();
		if (DefenseObject.GetComponent<Defense>().Hp <= 0)
			text.text = "YOU LOSE!";
	}
}
