using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
	const float FADE_DURATION = 0.3f;

	public AudioClip music;
	FadeScreenTransition screenTransition;

	void Awake ()
	{
		GameObject ScreenFX = GameObject.FindGameObjectWithTag (Tags.SCREEN_FX);
		if (ScreenFX) {
			screenTransition = ScreenFX.GetComponentInChildren<FadeScreenTransition> ();
		}
	}

	void Start ()
	{
		SoundManager.Instance.PlayMusic (music);
	}

	public void GoToLevel (string level)
	{
		SoundManager.Instance.StopMusic (FADE_DURATION);
		if (screenTransition) {
			screenTransition.PreTransition (level, FADE_DURATION);
		} else {
			Application.LoadLevel (level);
		}
	}
}
