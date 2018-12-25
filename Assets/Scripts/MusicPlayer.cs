using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instance = null;
    public static MusicPlayer Instance
    {
        get { return instance; }
    }

    AudioSource source;
    public AudioClip gameClip;

    void Start()
    {
        InitializeSource();
    }

    void InitializeSource()
    {
        if (source == null)
            source = GetComponent<AudioSource>();
    }

    public void Silence()
    {
        InitializeSource();
        source.Stop();
    }

    public void PlayGameMusic()
    {
        InitializeSource();

        var clip = gameClip;
        if (clip != null)
        {
            if (!source.isPlaying || source.clip != clip)
            {
                source.Stop();
                source.clip = clip;
                source.time = 0f;
                source.Play();
            }
        }
        else
        {
            Silence();
        }
    }

    void Update()
    {
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}