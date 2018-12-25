using UnityEngine;

public class AudioHelper : MonoBehaviour
{
    public AudioClip hurt1;

    public AudioClip laser1;
    public AudioClip laser2;
    public AudioClip laser3;
    public AudioClip laser4;

    public AudioClip bow;

    AudioSource source;
    System.Random random;

    void Start()
    {
        source = Camera.main.GetComponent<AudioSource>();
        random = new System.Random();
    }

    public void Bow()
    {
        source.PlayOneShot(bow);
    }

    public void Die()
    {
        source.PlayOneShot(hurt1);
    }

    public void Laser()
    {
        var val = random.Next(0, 5);
        if (val == 0)
            source.PlayOneShot(laser1, 0.1f);
        else if (val == 1)
            source.PlayOneShot(laser2, 0.1f);
        else if (val == 2)
            source.PlayOneShot(laser3, 0.1f);
        else
            source.PlayOneShot(laser4, 0.1f);
    }
}