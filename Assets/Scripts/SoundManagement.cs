using UnityEngine;
using System.Collections;

public class SoundManagement : MonoBehaviour {

	public AudioSource sfxSource;
	public AudioSource musicSource;
	public AudioSource jingleSource;
	public static SoundManagement instance = null;
	public bool effectsOn = true;

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
		jingleSource.enabled = false;
	}

	public void SoundOn()
	{
		musicSource.enabled = true;
		jingleSource.enabled = true;
	}

	public void playSFX (AudioClip SFX)
	{
		sfxSource.PlayOneShot (SFX);
	}

	public void playMusic(AudioClip music)
	{
		musicSource.clip = music;
		musicSource.Play ();
	}

	public void jingleTime()
	{
		musicSource.Pause ();
		jingleSource.Play ();
	}

	public void jingleStop()
	{
		musicSource.UnPause ();
		jingleSource.Stop ();
	}
}
