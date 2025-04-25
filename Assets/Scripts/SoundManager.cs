using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioClip _audioClip_FinishLevel;
    [SerializeField] private AudioClip _audioClip_GameOver;

    private AudioSource _audioSource;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            transform.parent = null;
            _audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayFinishLevel()
    {
        _audioSource.PlayOneShot(_audioClip_FinishLevel);
    }

    public void PlayGameOver()
    {
        _audioSource.PlayOneShot(_audioClip_GameOver);
    }
}
