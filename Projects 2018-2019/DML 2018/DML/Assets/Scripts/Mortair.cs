using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortair : MonoBehaviour
{
    [Header("Cannon Movement")]
    [SerializeField]
    private Transform cannon;
    [SerializeField]
    private float cannonSpeed = 50f;
    [SerializeField]
    private float cannonSuperSpeedMultiplier = 3f;
    [SerializeField]
    private float cannonAngleLimit = 65f;
    [Header("Cannon Shooting")]
    [SerializeField]
    private Transform shootingPivot;
    [SerializeField]
    private GameObject bulletPrefab;
	[SerializeField]
	private float bulletSpeed = 100f;

    private float _currentAngle;
    
    void Update()
    {
        _currentAngle += Input.GetAxis("Vertical") * Time.deltaTime * cannonSpeed *
                    (Input.GetKey(KeyCode.LeftShift) ? cannonSuperSpeedMultiplier : 1f);
        _currentAngle = Mathf.Clamp(_currentAngle, -cannonAngleLimit, cannonAngleLimit);

        cannon.rotation = Quaternion.Euler(0f, 0f, _currentAngle);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newBullet = Instantiate<GameObject>(bulletPrefab, shootingPivot.position, Quaternion.identity);
			Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody> ();
			bulletRigidbody.AddForce(cannon.up * bulletSpeed, ForceMode.Impulse);

			Destroy(newBullet, 20f);
        }
    }
}
