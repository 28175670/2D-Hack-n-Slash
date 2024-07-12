using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimition : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string MoveState;
    [SerializeField] private string BossSlashState;
    [SerializeField] private string IdieState;
    [SerializeField] private string die;
    [SerializeField] private GameObject healthUI;
    [SerializeField] private GameObject Attackcoi;
    [SerializeField] private float attackRange = 1.1f;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Move(Vector3 direction)
    {
        if (BossMovement.isDieing == true)
        {
            return;
        }
        if (direction.x > 0)
        {
            Attackcoi.transform.rotation = Quaternion.Euler(0, 0, 0);
            healthUI.transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            Attackcoi.transform.rotation = Quaternion.Euler(0, 180, 0);
            healthUI.transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        animator.Play(MoveState);
    }
    private void FixedUpdate()
    {
        if (BossMovement.isDieing == true)
        {
            return;
        }
        AnimatorStateInfo currentStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        var playerPosition = PlayerManager.position;
        var position = transform.position;
        var direction = playerPosition - position;
        var distance = direction.magnitude;

        if (distance <= attackRange && currentStateInfo.IsName(BossSlashState) && currentStateInfo.normalizedTime >= 1f)
        {
            animator.Play(BossSlashState, 0, 0f);
            //Debug.Log("¼½§¹");
        }
    }
    public void Boss_slash()
    {
        animator.Play(BossSlashState);
    }
    public void StopAnimation()
    {
        animator.Play(IdieState);
    }
    public void DieAnimation()
    {
        animator.Play(die);
    }
   
}
