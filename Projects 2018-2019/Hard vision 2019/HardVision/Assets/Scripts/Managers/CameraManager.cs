using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    public float minZoom;
    public float currentZoom;
    public float maxZoom;
    public float zoomSpeed;
    public float rotationSpeed = 4f;

    void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        transform.LookAt(target.position);
        offset = Quaternion.AngleAxis(Input.GetAxis("RotateCamera") * rotationSpeed * Time.deltaTime, Vector3.up) * offset;
        transform.position = target.position + offset * currentZoom;
    }
}