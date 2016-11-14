using UnityEngine;
using System.Collections;

/// <summary>
/// since the sound manager is pretty simple in this game, we took the class
/// explained on the official Unity website
/// </summary>
public class SoundManager : MonoBehaviour {
    public AudioSource efxSource;
    public AudioSource musicSource;
    public static SoundManager instance = null;
    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;

    /// <summary>
    /// force a singleton
    /// </summary>
    void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// play a single clip
    /// </summary>
    /// <param name="clip"></param>
    public void PlaySingle(AudioClip clip) {
        efxSource.clip = clip;
        efxSource.Play();
    }

    /// <summary>
    /// play a random sound from a list given, making the pitch a little random
    /// </summary>
    /// <param name="clips"></param>
    public void RandomizeSfx(params AudioClip[] clips) {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);
        efxSource.pitch = randomPitch;
        efxSource.clip = clips[randomIndex];
        efxSource.Play();
    }
}