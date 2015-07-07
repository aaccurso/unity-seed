using UnityEngine;
using System.Collections;

public class CloseModalButton : MonoBehaviour
{
	public void OnClick ()
	{
		this.GetComponentInParent<SimpleModal> ().Hide ();
	}
}
