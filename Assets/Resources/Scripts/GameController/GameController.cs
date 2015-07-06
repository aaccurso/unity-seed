using UnityEngine;
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
		// Scene Fade-out
		Application.LoadLevel (level);
		// Scene Fade-in
	}
}
