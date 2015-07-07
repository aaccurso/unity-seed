using UnityEngine;
using System.Collections;

public class SimpleModal : MonoBehaviour
{
	Popup popup;
	Backdrop backdrop;

	void Awake ()
	{
		popup = this.GetComponentInChildren<Popup> ();
		backdrop = this.GetComponentInChildren<Backdrop> ();
	}

	public void Show ()
	{
		popup.Show ();
		backdrop.Show ();
	}

	public void Hide ()
	{
		popup.Hide ();
		backdrop.Hide ();
	}
}
