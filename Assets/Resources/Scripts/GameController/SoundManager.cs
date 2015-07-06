using UnityEngine;
using System.Collections;

public class SoundManager : Singleton<SoundManager>
{
	bool FxEnabled;
	bool MusicEnabled;
	AudioSource musicSource;
	GameObject music;

	void Awake ()
	{
		music = new GameObject ("Music");
		DontDestroyOnLoad (music);
		FxEnabled = PlayerSettings.Instance.FXEnabled ();
		MusicEnabled = PlayerSettings.Instance.MusicEnabled ();
	}

	public void PlayFX (AudioClip clip, bool loop = false, float volume = 1f, float pitch = 1f)
	{
		if (!FxEnabled)
			return;
		// Create an empty game object
		GameObject audio = new GameObject ("Audio: " + clip.name);
		AudioSource source = audio.AddComponent<AudioSource> ();
		source.clip = clip;
		source.loop = loop;
		source.volume = volume;
		source.pitch = pitch;
		source.Play ();
		if (!loop) {
			// Destroy when clip finishes playing
			Destroy (audio, clip.length);
		}
	}

	public void PlayMusic (AudioClip clip, float volume = 1f, float pitch = 1f)
	{
		if (!MusicEnabled)
			return;
		// Ensures only one music source is being played
		if (musicSource && musicSource.isPlaying) {
			// If music clip is the same, do nothing
			if (musicSource.clip == clip)
				return;
			musicSource.Stop ();
			Destroy (musicSource);
		}
		music.name = "Music: " + clip.name;
		musicSource = music.AddComponent<AudioSource> ();
		musicSource.clip = clip;
		musicSource.loop = true;
		musicSource.volume = volume;
		musicSource.pitch = pitch;
		musicSource.Play ();
	}

	public void ToggleMusic (bool enabled)
	{
		if (enabled) {
			musicSource.Play ();
		} else {
			musicSource.Stop ();
		}
	}

	public void ToggleFX (bool enabled)
	{
		throw new System.NotImplementedException ();
	}
}
