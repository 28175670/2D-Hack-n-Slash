using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private UnityEvent<int> healthChanged;
    
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    public int Value
    {
        get { return health; }
       
    }

    public void DecreaseHealth(int amount)
    {
        
        health -= amount;
        healthChanged.Invoke(health);
    }   
}
