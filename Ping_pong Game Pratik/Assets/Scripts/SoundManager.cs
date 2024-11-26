using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;

    [SerializeField] private SoundLibrary sfxlibrary;
    [SerializeField] private AudioSource sfx2DSource;
    [SerializeField] private AudioSource bgmSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
           
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    public void PlaySound3D(AudioClip clip, Vector3 pos)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, pos);
        }

    }
    public void PlaySound3D(string soundName, Vector3 pos)
    {
        PlaySound3D(sfxlibrary.GetClipFromName(soundName), pos);
    }

    public void Playsound2D(string soundName)
    {
        sfx2DSource.PlayOneShot(sfxlibrary.GetClipFromName(soundName));
    }
    public void PlayBackgroundMusic(AudioClip clip)
    {
        if (clip != null && bgmSource != null)
        {
            bgmSource.clip = clip;
            bgmSource.Play();
        }
    }

    public void PlayBackgroundMusic(string musicName)
    {
        PlayBackgroundMusic(sfxlibrary.GetClipFromName(musicName));
    }
    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = Mathf.Clamp(volume, 0f, 1f); 
    }
}
