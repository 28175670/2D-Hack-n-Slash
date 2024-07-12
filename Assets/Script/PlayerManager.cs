using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private static PlayerManager _instance;

    public static Vector3 position
    {
        get { return _instance.playerTransform.position; }
    }

    private void Awake()
    {
        _instance = this;
    }
}
