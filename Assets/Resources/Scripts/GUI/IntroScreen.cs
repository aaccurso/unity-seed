using UnityEngine;
using System.Collections;

public class IntroScreen : MonoBehaviour
{
	public string movieClip;
	public bool localize;
	public string level;

	string moviePath;

	void Start ()
	{
		moviePath = (localize ? PlayerSettings.Instance.Language () + "/" : "") + movieClip;
		StartCoroutine (PlayFullscreenVideo (moviePath));
	}
	
	private IEnumerator PlayFullscreenVideo (string moviePath)
	{
		Handheld.PlayFullScreenMovie (moviePath, Color.black, FullScreenMovieControlMode.CancelOnInput, FullScreenMovieScalingMode.AspectFit);
		yield return new WaitForSeconds (0);
		GameObject.FindGameObjectWithTag (Tags.GAME_CONTROLLER).GetComponent<GameController> ().GoToLevel (level);
	}
}
