using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public void stop()
    {
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
    }
}
