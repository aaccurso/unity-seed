using UnityEngine;
using System.Collections;

public class PlayerSettings : Singleton<PlayerSettings>
{
	public static int TRUE = 1;
	public static int FALSE = 0;
	public static string FIRST_START = "FirstStart";
	public static string LANGUAGE = "Language";
	public static string MUSIC_ENABLED = "MusicEnabled";
	public static string FX_ENABLED = "FxEnabled";

	void Awake ()
	{
		if (PlayerPrefs.GetInt (FIRST_START) == FALSE) {
			ResetDefaultSettings ();
		}
	}

	public void ResetDefaultSettings ()
	{
		PlayerPrefs.SetInt (FIRST_START, FALSE);
		PlayerPrefs.SetString (LANGUAGE, "ES");
		PlayerPrefs.SetInt (MUSIC_ENABLED, TRUE);
		PlayerPrefs.SetInt (FX_ENABLED, TRUE);
		PlayerPrefs.Save ();
	}

	public bool FXEnabled ()
	{
		return PlayerPrefs.GetInt (FX_ENABLED) == TRUE;
	}

	public void ToggleFX (bool enabled)
	{
		PlayerPrefs.SetInt (FX_ENABLED, enabled ? TRUE : FALSE);
		SoundManager.Instance.ToggleFX (enabled);
	}

	public bool MusicEnabled ()
	{
		return PlayerPrefs.GetInt (MUSIC_ENABLED) == TRUE;
	}

	public void ToggleMusic (bool enabled)
	{
		PlayerPrefs.SetInt (MUSIC_ENABLED, enabled ? TRUE : FALSE);
		SoundManager.Instance.ToggleMusic (enabled);
	}

	public string Language ()
	{
		return PlayerPrefs.GetString (LANGUAGE);
	}
}
