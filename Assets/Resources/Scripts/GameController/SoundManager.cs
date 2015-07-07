using UnityEngine;
using System.Collections;

public class SoundManager : Singleton<SoundManager>
{
	bool FXEnabled;
	bool MusicEnabled;
	AudioSource musicSource;
	GameObject music;

	void Awake ()
	{
		music = new GameObject ("Music");
		music.transform.SetParent (this.gameObject.transform);
		DontDestroyOnLoad (music);
		FXEnabled = PlayerSettings.Instance.FXEnabled ();
		MusicEnabled = PlayerSettings.Instance.MusicEnabled ();
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.M)) {
			ToggleFX (!FXEnabled);
			ToggleMusic (!MusicEnabled);
		}
	}

	public void PlayFX (AudioClip clip, bool loop = false, float volume = 1f, float pitch = 1f)
	{
		if (!(FXEnabled && clip))
			return;
		// Create an empty game object
		GameObject audio = new GameObject ("Audio: " + clip.name);
		audio.transform.SetParent (this.gameObject.transform);
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
		if (!(MusicEnabled && clip))
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
		MusicEnabled = enabled;
		if (!musicSource)
			return;
		if (enabled) {
			musicSource.Play ();
		} else {
			musicSource.Stop ();
		}
	}

	public void ToggleFX (bool enabled)
	{
		FXEnabled = enabled;
	}
}
