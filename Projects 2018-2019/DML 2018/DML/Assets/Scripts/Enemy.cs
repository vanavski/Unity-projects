using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour 
{
	public GameObject enemy;
	
	[SerializeField]
	private float spawnTime;
	[SerializeField]
	private float spawnDelay;

	private int HP;
	void Start () 
	{
		InvokeRepeating("CreateEnemy",spawnTime,spawnDelay);	
	}

	public void CreateEnemy()
	{
		var newEnemy = Instantiate(enemy,new Vector3(180,Random.Range(40,160),Random.Range(-42,41)),Quaternion.identity);	
		Destroy(newEnemy,150);		
	}

	void Update()
	{
		spawnTime = Random.Range(3,10);
		spawnDelay = Random.Range(3,10);		
	}
}
