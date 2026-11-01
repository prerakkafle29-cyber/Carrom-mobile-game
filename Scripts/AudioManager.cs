using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource soundEffectSource;

    [Header("Audio Clips")]
    public AudioClip coinHitClip;
    public AudioClip pocketScoreClip;
    public AudioClip strikerShotClip;
    public AudioClip foulClip;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayCoinHit()
    {
        if (soundEffectSource && coinHitClip)
            soundEffectSource.PlayOneShot(coinHitClip);
    }

    public void PlayPocketScore()
    {
        if (soundEffectSource && pocketScoreClip)
            soundEffectSource.PlayOneShot(pocketScoreClip);
    }

    public void PlayStrikerShot()
    {
        if (soundEffectSource && strikerShotClip)
            soundEffectSource.PlayOneShot(strikerShotClip);
    }

    public void PlayFoul()
    {
        if (soundEffectSource && foulClip)
            soundEffectSource.PlayOneShot(foulClip);
    }
}
