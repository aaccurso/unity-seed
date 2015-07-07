using UnityEngine;
using System.Collections;

public class SimpleModalButton : MonoBehaviour
{
	public string level;

	public void OnClick ()
	{
		GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ().GoToLevel (level);
	}
}
