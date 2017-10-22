using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour {

    public Transform target;

    public Vector3 offSet;
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;

    private float currentZoom = 10f;

    public float pitch = 2f;

    void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
    }

    void LateUpdate()
    {
        transform.position = target.position - offSet * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);
    }
}
