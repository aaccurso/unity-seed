﻿using UnityEngine;
using System.Collections;

public class Singleton : MonoBehaviour
{
	void Awake ()
	{
		DontDestroyOnLoad (transform.gameObject);
	}
}
