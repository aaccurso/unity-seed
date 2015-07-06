using UnityEngine;
using System.Collections;

public class PlayerSettings : Singleton
{
	public static int TRUE = 1;
	public static int FALSE = 0;
	public static string FIRST_START = "FirstStart";
	public static string LANGUAGE = "Language";
	public static string MUSIC_ENABLED = "MusicEnabled";
	public static string FX_ENABLED = "FxEnabled";

	void Awake ()
	{
		if (PlayerPrefs.GetInt (FIRST_START) == TRUE) {
			PlayerPrefs.SetInt (FIRST_START, FALSE);
			PlayerPrefs.SetString (LANGUAGE, "ES");
			PlayerPrefs.SetInt (MUSIC_ENABLED, TRUE);
			PlayerPrefs.SetInt (FX_ENABLED, TRUE);
			PlayerPrefs.Save ();
		}
	}

	public static bool FxEnabled ()
	{
		return PlayerPrefs.GetInt (FX_ENABLED) == TRUE;
	}

	public static void EnableFx (bool enabled)
	{
		PlayerPrefs.SetInt (FX_ENABLED, enabled ? TRUE : FALSE);
	}

	public static bool MusicEnabled ()
	{
		return PlayerPrefs.GetInt (MUSIC_ENABLED) == TRUE;
	}

	public static void EnableMusic (bool enabled)
	{
		PlayerPrefs.SetInt (MUSIC_ENABLED, enabled ? TRUE : FALSE);
	}

	public static string Language ()
	{
		return PlayerPrefs.GetString (LANGUAGE);
	}
}
