using UnityEngine;
using System.Collections;

public class CreateModalButton : MonoBehaviour
{
	public GameObject Modal;

	public void OnClick ()
	{
		GameObject ModalGroup = GameObject.FindGameObjectWithTag ("ModalGroup");
		GameObject ModalInstance = Instantiate (Modal) as GameObject;
		ModalInstance.GetComponent<RectTransform> ().transform.SetParent (ModalGroup.GetComponent<RectTransform> (), false);
		ModalInstance.GetComponent<SimpleModal> ().Show ();
	}
}
