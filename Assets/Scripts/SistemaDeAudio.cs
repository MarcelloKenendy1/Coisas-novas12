using UnityEngine;
using UnityEngine.UIElements;

public class SistemaDeAudio : MonoBehaviour
{
    [Header("Fontes de Audio")]
    [SerializeField] private AudioSource bgaudio;
    [SerializeField] private AudioSource sfxaudio;
    [Header("Volumes de Audio")]
    [Range(0f, 1f)][SerializeField] private float bgvolume = 0.5f;
    [Range(0f, 1f)][SerializeField] private float sfxvolume = 0.5f;
    private static SistemaDeAudio instance;


    private void Awake()
    {
      if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
           
        }
    
          instance = this;
          DontDestroyOnLoad(gameObject);
    
        bgaudio = GameObject.Find("BgAudio").GetComponent<AudioSource>();
        sfxaudio = GameObject.Find("sfxAudio").GetComponent<AudioSource>();
        
    
    } 

    void Start()
    {
        bgaudio = GetComponent<AudioSource>();
        sfxaudio = GetComponent<AudioSource>();
    }

   
  public void PlayBackGroundMusic(AudioClip clip)
    {
        bgaudio.clip = clip;
        bgaudio.volume = bgvolume;
        bgaudio.loop = true;
        bgaudio.Play();
    }


    public void PlaySoundEffects( AudioClip clip)
    {
        sfxaudio.clip = clip;
        sfxaudio.PlayOneShot(clip);
    }
   
}
