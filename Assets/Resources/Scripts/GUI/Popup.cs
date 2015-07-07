using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Popup : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		this.transform.DOMoveY (2f, 1f);
	}
}
