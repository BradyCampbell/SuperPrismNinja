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
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
