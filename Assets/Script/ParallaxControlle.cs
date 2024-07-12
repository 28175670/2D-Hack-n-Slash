using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxControlle : MonoBehaviour
{
    public Transform cameraTransform;
    public float parallaxScale = 0.5f;

    private Vector3 previousCameraPosition;

    private void Start()
    {
        previousCameraPosition = cameraTransform.position;
    }

    private void FixedUpdate()
    {
        // �p��۾���m���ܤ�
        Vector3 deltaMovement = cameraTransform.position - previousCameraPosition;

        // �ھڵ��t���,�p��I�����ʪ��Z��
        transform.position += deltaMovement * parallaxScale;

        // ��s�W�@�V�۾�����m
        previousCameraPosition = cameraTransform.position;
    }
}
