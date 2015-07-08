using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class GameController : MonoBehaviour
{
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
		if (screenTransition) {
			screenTransition.PreTransition (level);
		} else {
			Application.LoadLevel (level);
		}
	}
}
