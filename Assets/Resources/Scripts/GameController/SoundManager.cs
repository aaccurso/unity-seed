using UnityEngine;
using System.Collections;

public class SoundManager : Singleton
{
	bool FxEnabled;
	bool MusicEnabled;
	AudioSource backgroundMusicSource;
	GameObject backgroundMusic;

	void Start ()
	{
		backgroundMusic = new GameObject ();
		FxEnabled = PlayerSettings.FxEnabled ();
		MusicEnabled = PlayerSettings.MusicEnabled ();
	}

	public void PlayFX (AudioClip clip, bool loop = false, float volume = 1f, float pitch = 1f)
	{
		if (!FxEnabled)
			return;
		// Create an empty game object
		GameObject go = new GameObject ("Audio: " + clip.name);
		
		// Create the source
		AudioSource source = go.AddComponent<AudioSource> ();
		source.clip = clip;
		source.loop = loop;
		source.volume = volume;
		source.pitch = pitch;
		source.Play ();
		if (!loop) {
			Destroy (go, clip.length);
		}
	}

	public void PlayMusic (AudioClip clip, float volume = 1f, float pitch = 1f)
	{
		if (!MusicEnabled)
			return;
		// Ensures only one music source is being played
		if (backgroundMusicSource.isActiveAndEnabled && backgroundMusicSource.isPlaying) {
			backgroundMusicSource.Stop ();
			Destroy (backgroundMusicSource);
		}
		backgroundMusicSource = backgroundMusic.AddComponent<AudioSource> ();
		backgroundMusic.name = "Music: " + clip.name;
		backgroundMusicSource.clip = clip;
		backgroundMusicSource.loop = true;
		backgroundMusicSource.volume = volume;
		backgroundMusicSource.pitch = pitch;
		backgroundMusicSource.Play ();
	}

	public void StopAll ()
	{
		backgroundMusicSource.Stop ();
	}
}
