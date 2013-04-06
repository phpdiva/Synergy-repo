using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour {
	
	//public AudioClip newMusic; //Pick an audio track to play.
	//public AudioClip[] audioClip = new AudioClip[10];
	public List<AudioClip> audioClip = new List<AudioClip>();

	// Use this for initialization
	void Awake ()
	{
		this.audio.clip = audioClip[0];
		//GameObject gameObject = GameObject.Find("MusicManager"); //Finds the game object called Game Music, if it goes by a different name, change this.
          	//this.audio.clip = NewMusic; //Replaces the old audio with the new one set in the inspector.
		this.audio.Play(); //Plays the audio.
		//go.audio.Stop(); //Plays the audio.
	}
	
	void ChangeTrack()
	{
		Debug.Log("ChangeTrack");
		string stringLevelNumber = Application.loadedLevelName;
		Debug.Log(stringLevelNumber);
		int levelNumber = int.Parse( stringLevelNumber.Substring(0,2));
		Debug.Log(levelNumber);
		this.audio.clip = audioClip[levelNumber -1];//-1 to negate array 0 index
		this.audio.Play();
	}
	
	void ChangeTrack(AudioClip song)
	{
		this.audio.clip = song;//-1 to negate array 0 index
		this.audio.Play();
	}
}
