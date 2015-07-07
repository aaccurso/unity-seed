using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class GameController : MonoBehaviour
{
	public AudioClip music;
	public GameObject ScreenFX;
	FadeScreenTransition screenTransition;

	void Awake ()
	{
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
