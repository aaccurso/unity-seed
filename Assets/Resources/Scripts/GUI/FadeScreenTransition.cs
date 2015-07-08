using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class FadeScreenTransition : MonoBehaviour
{
	const float DEFAULT_FADE_DURATION = 0.4f;
	
	Image image;

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

	public Tweener PreTransition (string level, float fadeDuration = DEFAULT_FADE_DURATION)
	{
		image.enabled = true;
		// Fade in
		return image.DOFade (1f, fadeDuration).OnComplete (() => {
			Application.LoadLevel (level);
			PostTransition (fadeDuration);
		});
	}

	public Tweener PostTransition (float fadeDuration = DEFAULT_FADE_DURATION)
	{
		// Fade out
		return image.DOFade (0, fadeDuration).OnComplete (() => {
			image.enabled = false;
		});
	}
}
