using UnityEngine;
using System.Collections;

public class SoundManagement : MonoBehaviour {

	public AudioSource sfxSource;
	public AudioSource musicSource;
	public static SoundManagement instance = null;

	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
		}
		else if (instance != this)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SoundOff()
	{
		musicSource.enabled = false;
	}

	public void SoundOn()
	{
		musicSource.enabled = true;
	}

	public void playSFX (AudioClip SFX)
	{
		sfxSource.clip = SFX;
		sfxSource.Play ();
	}

	public void playMusic(AudioClip music)
	{
		musicSource.clip = music;
		musicSource.Play ();
	}
}
