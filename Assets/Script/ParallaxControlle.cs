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
        // 計算相機位置的變化
        Vector3 deltaMovement = cameraTransform.position - previousCameraPosition;

        // 根據視差比例,計算背景移動的距離
        transform.position += deltaMovement * parallaxScale;

        // 更新上一幀相機的位置
        previousCameraPosition = cameraTransform.position;
    }
}
