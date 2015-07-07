using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Popup : MonoBehaviour
{
	float startY;
	const float MOVE_DURATION = 1f;

	void Start ()
	{
		startY = this.GetComponent<RectTransform> ().position.y;
	}

	public void Show ()
	{
		this.transform.DOMoveY (0, MOVE_DURATION);
	}

	public void Hide ()
	{
		this.transform.DOMoveY (startY, MOVE_DURATION);
	}
}
