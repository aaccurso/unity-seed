using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
	public List<Singleton> singletonPrefabs;
	
	void Awake ()
	{
		InstantiateSingletons ();
	}

	void InstantiateSingletons ()
	{
		singletonPrefabs.ForEach ((singletonPrefab) => {
			// Instantiate only if singleton not found
			if (!GameObject.Find (singletonPrefab.name)) {
				Object singletonInstance = Instantiate (singletonPrefab);
				singletonInstance.name = singletonPrefab.name;
			}
		});
	}

	public void GoToLevel (string level)
	{
		Application.LoadLevel (level);
	}
}
