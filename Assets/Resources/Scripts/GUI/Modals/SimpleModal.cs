using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SimpleModal : MonoBehaviour
{
	Backdrop backdrop;
	Popup popup;

	void Awake ()
	{
		backdrop = this.GetComponentInChildren<Backdrop> ();
		popup = this.GetComponentInChildren<Popup> ();
	}

	public void Show ()
	{
		backdrop.Show ();
		popup.Show ();
	}

	public void Hide ()
	{
		backdrop.Hide ();
		popup.Hide ().OnComplete (() => {
			Destroy (this.gameObject);
		});
	}
}
