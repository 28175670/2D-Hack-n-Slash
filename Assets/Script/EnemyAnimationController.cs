using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string MoveState;
    [SerializeField] private string SlashState;
    [SerializeField] private string IdieState;
    [SerializeField] private string HitState;
    [SerializeField] private string die;
    [SerializeField] private GameObject healthUI;
    [SerializeField] private float attackRange = 1.1f;


   
    public void Move(Vector3 direction)
    {
        if (EnemyMovement.isDieing == true)
        {
            return;
        }
        if (direction.x >0)
        {
            healthUI.transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            healthUI.transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        animator.Play(MoveState);
    }
    private void FixedUpdate()
    {
        AnimatorStateInfo currentStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        var playerPosition = PlayerManager.position;
        var position = transform.position;
        var direction = playerPosition - position;
        var distance = direction.magnitude;

        if (distance <= attackRange && currentStateInfo.IsName(SlashState) && currentStateInfo.normalizedTime >= 1f) 
        {
            animator.Play(SlashState, 0, 0f);
            //Debug.Log("¼½§¹");
        }
    }
    public void Enemy_slash()
    {
        animator.Play(SlashState);
    }
    public void StopAnimation()
    {
        animator.Play(IdieState);
    }
    public void DieAnimation()
    {
        animator.Play(die);
    }
    public void HitAnimation()
    {
        animator.Play(HitState);
    }
}
