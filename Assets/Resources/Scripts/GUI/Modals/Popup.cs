using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Popup : MonoBehaviour
{
	float startY;
	const float MOVE_DURATION = 0.5f;

	void Start ()
	{
		startY = this.GetComponent<RectTransform> ().position.y;
	}

	public Tweener Show ()
	{
		return this.transform.DOMoveY (0, MOVE_DURATION);
	}

	public Tweener Hide ()
	{
		return this.transform.DOMoveY (startY, MOVE_DURATION);
	}
}
