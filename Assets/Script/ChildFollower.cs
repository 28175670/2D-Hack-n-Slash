using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class ChildFollower : MonoBehaviour
{
    public Transform target; // �ؼЪ���
    public Transform Ptarget;


    private Vector3 velocity = Vector3.zero;
    private void Start()
    {
        Ptarget.SetParent(null);
        // �p��l����۹��ؼЪ��󪺪�l�����q     
    }

    private void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = targetPosition;
    }
}
