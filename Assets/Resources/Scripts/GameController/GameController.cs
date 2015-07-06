using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
	public List<Singleton> singletons;

	const string CLONE_SUFFIX = "(Clone)";

	// Use this for initialization
	void Start ()
	{
		InstantiateSingletons ();
	}

	void InstantiateSingletons ()
	{
		singletons.ForEach ((singleton) => {
			// Instantiate only if singleton not found
			if (!GameObject.Find (singleton.name + CLONE_SUFFIX)) {
				Instantiate (singleton);
			}
		});
	}

	public void GoToLevel (string level)
	{
		Application.LoadLevel (level);
	}
}
