using UnityEngine;

public class AudioHelper : MonoBehaviour
{
    public AudioClip die1;
    public AudioClip die2;
    public AudioClip die3;
    public AudioClip die4;
    public AudioClip die5;
    public AudioClip die6;
    public AudioClip die7;
    public AudioClip die8;
    public AudioClip die9;
    public AudioClip die10;
    public AudioClip die11;
    public AudioClip die12;
    public AudioClip die13;

    public AudioClip laser1;
    public AudioClip laser2;
    public AudioClip laser3;
    public AudioClip laser4;

    public AudioClip muscles;
    public AudioClip beastMaster;
    public AudioClip beastMasterIntro;
    public AudioClip butCanYouDoThis;
    public AudioClip fast;
    public AudioClip reee;
    public AudioClip smashSubscribe;

    AudioSource source;
    System.Random random;

    void Start()
    {
        source = Camera.main.GetComponent<AudioSource>();
        random = new System.Random();
    }

    public void Muscles()
    {
        source.PlayOneShot(muscles);
    }

    public void BeastMasterIntro()
    {
        source.PlayOneShot(beastMasterIntro);
    }

    public void SmashSubscribe()
    {
        source.PlayOneShot(smashSubscribe);
    }

    public void Reee()
    {
        source.PlayOneShot(reee);
    }

    public void Fast()
    {
        source.PlayOneShot(fast);
    }

    public void ButCanYouDoThis()
    {
        source.PlayOneShot(butCanYouDoThis);
    }

    public void BeastMaster()
    {
        source.PlayOneShot(beastMaster);
    }

    public void Die()
    {
        var val = random.Next(0, 12);
        if (val == 0)
            source.PlayOneShot(die3);
        else if (val == 1)
            source.PlayOneShot(die4);
        else if (val == 2)
            source.PlayOneShot(die5);
        else if (val == 3)
            source.PlayOneShot(die6);
        else if (val == 4)
            source.PlayOneShot(die7);
        else if (val == 5)
            source.PlayOneShot(die8);
        else if (val == 6)
            source.PlayOneShot(die9);
        else if (val == 7)
            source.PlayOneShot(die10);
        else if (val == 8)
            source.PlayOneShot(die11);
        else if (val == 9)
            source.PlayOneShot(die12);
        else
            source.PlayOneShot(die13);
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