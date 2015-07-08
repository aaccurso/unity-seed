using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class FadeScreenTransition : MonoBehaviour
{
	Image image;

	const float FADE_DURATION = 0.4f;

	void Awake ()
	{
		if (GameObject.FindGameObjectsWithTag (Tags.SCREEN_FX).Length == 1) {
			DontDestroyOnLoad (this.gameObject.transform.parent);
		}
	}

	void Start ()
	{
		image = this.GetComponent<Image> ();
		image.color = Color.clear;
		image.enabled = false;
	}

	public Tweener PreTransition (string level)
	{
		image.enabled = true;
		// Fade in
		return image.DOFade (1f, FADE_DURATION).OnComplete (() => {
			Application.LoadLevel (level);
			PostTransition ();
		});
	}

	public Tweener PostTransition ()
	{
		// Fade out
		return image.DOFade (0, FADE_DURATION).OnComplete (() => {
			image.enabled = false;
		});
	}
}
