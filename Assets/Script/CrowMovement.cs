using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class CrowMovement : MonoBehaviour
{
    [SerializeField] public Rigidbody2D CrowRd;
    [SerializeField] private float speed;
    [SerializeField] private UnityEvent<Vector3> moveDirection;
    private bool hasAppliedKnockback;
    public static bool fly;

    private void Start()
    {
        CrowRd.velocity = Vector2.zero;
        fly = false;
    }

   
    void Update()
    {
        GameObject[] crowies = GameObject.FindGameObjectsWithTag("Crow");

        foreach (GameObject Crow in crowies)
        {
            Rigidbody2D CrowRd = Crow.GetComponent<Rigidbody2D>();

        }
    }
    private void FixedUpdate()
    {

        var playerPosition = PlayerManager.position;
        var position = transform.position;
        var direction = playerPosition - position;
        var distance = direction.magnitude;

        if (CrowRd.velocity.magnitude > 2f)
        {
            // ����t�׳̤j�Ȭ�2
            CrowRd.velocity = CrowRd.velocity.normalized * 6f;
        }

        if (fly == true)  
        {
            upfly();
        }
        else
        {
            direction.Normalize();
            var targetPosition = position + direction * speed * Time.fixedDeltaTime;
            CrowRd.MovePosition(targetPosition);
            moveDirection.Invoke(direction);
        }

    }
    public void upfly()
    {
        Vector3 knockbackDirection = (PlayerManager.position - transform.position).normalized;
        knockbackDirection = new Vector3(knockbackDirection.x, knockbackDirection.y + 0.5f, knockbackDirection.z); // �פW��V
        float knockbackForce = 2f; // �]�w���h�O��
        var playerPosition = PlayerManager.position;
        var position = transform.position;
        var direction = playerPosition - position;
        var distance = direction.magnitude;
        GetComponent<Rigidbody2D>().AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

        if (direction.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        //if (!hasAppliedKnockback)
        //{
        //    Vector3 knockbackDirection = (PlayerManager.position - transform.position).normalized;
        //    knockbackDirection = new Vector3(knockbackDirection.x, knockbackDirection.y + 0.5f, knockbackDirection.z); // �פW��V
        //    float knockbackForce = 2f; // �]�w���h�O��
        //    var playerPosition = PlayerManager.position;
        //    var position = transform.position;
        //    var direction = playerPosition - position;
        //    var distance = direction.magnitude;
        //    GetComponent<Rigidbody2D>().AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

        //    if (direction.x > 0)
        //    {
        //        transform.rotation = Quaternion.Euler(0, 0, 0);
        //    }
        //    else
        //    {
        //        transform.rotation = Quaternion.Euler(0, 180, 0);
        //    }

        //    hasAppliedKnockback = true; // �]�m�w�g�I�[�L���h�O�ת��аO
        //}
    }



}
