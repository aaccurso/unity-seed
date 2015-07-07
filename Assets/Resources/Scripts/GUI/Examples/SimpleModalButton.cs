using UnityEngine;
using System.Collections;

public class SimpleModalButton : MonoBehaviour
{
	public string level;

	public void OnClick ()
	{
		GameObject.FindGameObjectWithTag (Tags.GAME_CONTROLLER).GetComponent<GameController> ().GoToLevel (level);
	}
}
