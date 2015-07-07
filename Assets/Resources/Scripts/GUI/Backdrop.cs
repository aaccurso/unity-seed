using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class Backdrop : MonoBehaviour
{
	Image image;
	const float FADE_DURATION = 0.5f;

	void Awake ()
	{
		image = this.GetComponent<Image> ();
		image.color = Color.clear;
	}

	public void Show ()
	{
		image.DOFade (1f, FADE_DURATION);
	}

	public void Hide ()
	{
		image.DOFade (0f, FADE_DURATION);
	}
}
