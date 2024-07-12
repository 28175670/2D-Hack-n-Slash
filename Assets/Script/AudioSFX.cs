using UnityEngine;

public class AudioSFX : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip gameOverClip;
    [SerializeField] private AudioClip takeDamageClip;
    [SerializeField] private AudioClip AttackOneClip;
    [SerializeField] private AudioClip LevelUp;
    private static AudioSFX instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlayGameOver()
    {
        audioSource.PlayOneShot(gameOverClip);
    }

    //public void PlayMagicMissileLanuchClip()
    //{
    //    audioSource.PlayOneShot(magicMissileLanuchClip);
    //}

    public void PlayTakeDamage()
    {
        audioSource.PlayOneShot(takeDamageClip);
    }
    public void PlayAttackOneClip()
    {
        audioSource.PlayOneShot(AttackOneClip);
    }
    public static void levelup()
    {
        instance.audioSource.PlayOneShot(instance.LevelUp);
    }

}
