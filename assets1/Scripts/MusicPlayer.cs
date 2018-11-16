using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;
	
	public AudioClip startclip;
	public AudioClip gameclip;
	public AudioClip endclip;
	
	private AudioSource music;
	
	
	void Start () {
		if (instance != null && instance != this) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			music = GetComponent<AudioSource>();
			music.clip = startclip;
			music.loop = true;
			music.Play();
			
		}
		
	}
	
	void OnLevelWasLoaded(int level) {
	
	music.Stop();
	if(level == 0) {
	
	music.clip = startclip;
	}
	if(level == 1) {
			
			music.clip = gameclip;
		}
		
	if(level == 2) {
			
			music.clip = endclip;
		}
	music.loop = true;	
	music.Play();
	}
}
