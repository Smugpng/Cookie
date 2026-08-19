using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioPlayer;
    public AudioClip gulp;
    public static SFXManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        if(audioPlayer == null)
        {
            audioPlayer = GetComponent<AudioSource>();
        }
    }

    public void PlaySound()
    {
        audioPlayer.PlayOneShot(gulp);
    }
}
