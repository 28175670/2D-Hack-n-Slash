using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class ChildFollower : MonoBehaviour
{
    public Transform target; // 目標物件
    public Transform Ptarget;


    private Vector3 velocity = Vector3.zero;
    private void Start()
    {
        Ptarget.SetParent(null);
        // 計算子物件相對於目標物件的初始偏移量     
    }

    private void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = targetPosition;
    }
}
