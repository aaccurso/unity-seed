using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SoundManager : Singleton<SoundManager>
{
	const float DEFAULT_FADE_DURATION = 0.3f;
	const float DEFAULT_VOLUME = 1f;
	const float UNITY_EDITOR_VOLUME = 0.1f;

	bool FXEnabled;
	bool MusicEnabled;
	AudioSource musicSource;
	GameObject music;
	float defaultVolume = DEFAULT_VOLUME;

	void Awake ()
	{
		music = new GameObject ("Music");
		music.transform.SetParent (this.gameObject.transform);
		DontDestroyOnLoad (music);
		FXEnabled = PlayerSettings.Instance.FXEnabled ();
		MusicEnabled = PlayerSettings.Instance.MusicEnabled ();
		#if UNITY_EDITOR
		this.defaultVolume = UNITY_EDITOR_VOLUME;
		#endif
	}

	#if UNITY_EDITOR
	void Update ()
	{
		// Key M: mutes music and sound
		if (Input.GetKeyDown (KeyCode.M)) {
			ToggleFX (!FXEnabled);
			ToggleMusic (!MusicEnabled);
			Debug.Log ("MusicEnabled: " + MusicEnabled.ToString ());
			Debug.Log ("FXEnabled: " + FXEnabled.ToString ());
		}
		// Key V: sets volume to max value
		if (Input.GetKeyDown (KeyCode.V)) {
			this.defaultVolume = DEFAULT_VOLUME;
		}
	}
	#endif

	public void PlayFX (AudioClip clip, bool loop = false, float volume = DEFAULT_VOLUME, float pitch = DEFAULT_VOLUME)
	{
		if (!(FXEnabled && clip))
			return;
		// Create an empty game object
		GameObject audio = new GameObject ("Audio: " + clip.name);
		audio.transform.SetParent (this.gameObject.transform);
		AudioSource source = audio.AddComponent<AudioSource> ();
		source.clip = clip;
		source.loop = loop;
		source.volume = this.defaultVolume < DEFAULT_VOLUME ? this.defaultVolume : volume;
		source.pitch = pitch;
		source.Play ();
		if (!loop) {
			// Destroy when clip finishes playing
			Destroy (audio, clip.length);
		}
	}

	public void PlayMusic (AudioClip clip, float volume = DEFAULT_VOLUME, float pitch = DEFAULT_VOLUME)
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
		musicSource.volume = this.defaultVolume < DEFAULT_VOLUME ? this.defaultVolume : volume;
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
			musicSource.DOFade (this.defaultVolume, DEFAULT_FADE_DURATION);
		} else {
			StopMusic ();
		}
	}

	public void ToggleFX (bool enabled)
	{
		FXEnabled = enabled;
	}

	public void StopMusic (float fadeDuration = DEFAULT_FADE_DURATION)
	{
		if (!musicSource)
			return;
		musicSource.DOFade (0, fadeDuration).OnComplete (() => {
			musicSource.Stop ();
		});
	}
}
