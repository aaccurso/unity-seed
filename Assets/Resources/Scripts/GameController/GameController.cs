using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
	public List<Singleton> singletons;
	
	void Awake ()
	{
		InstantiateSingletons ();
	}

	void InstantiateSingletons ()
	{
		singletons.ForEach ((singleton) => {
			// Instantiate only if singleton not found
			if (!GameObject.Find (singleton.name)) {
				Object singletonInstance = Instantiate (singleton);
				singletonInstance.name = singleton.name;
			}
		});
	}

	public void GoToLevel (string level)
	{
		Application.LoadLevel (level);
	}
}
