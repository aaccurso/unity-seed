using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
	public AudioClip music;

	void Start ()
	{
		SoundManager.Instance.PlayMusic (music);
	}

	public void GoToLevel (string level)
	{
		// TODO: Scene Fade-out
		Application.LoadLevel (level);
		// TODO: Scene Fade-in
	}
}
