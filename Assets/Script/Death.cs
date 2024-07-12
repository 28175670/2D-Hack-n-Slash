using UnityEngine;
using UnityEngine.Events;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject healthbar;
    [SerializeField] private UnityEvent DiedEvent;
    
    public void CheckDeath(int health)
    {
        if(health <= 0 )
        {
            DiedEvent.Invoke();        
        }
    }
    
    public void DieDestory()
    {
        //gameObject.SetActive(false);
        Destroy(this.gameObject, 2.5f);
        
    }
    public void BossDieDestory()
    {
        //gameObject.SetActive(false);
        Destroy(this.gameObject, 5f);

    }
    public void DieActive()
    {
        gameObject.SetActive(false);

    }
    public void HealthBarActive()
    {
        healthbar.SetActive(false);

    }
    public void CrowdieActive()
    {
        healthbar.SetActive(true);   
    }
    public void ScoreUp()
    {
        Scoreupdate.instance.UpdateScore();
        Levelupdate.instance.LevelUpdate();
    }
}
