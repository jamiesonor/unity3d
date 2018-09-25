using UnityEngine;
using System.Collections;

public class LoadInformation : MonoBehaviour {

	public static void LoadAllInformation ()
	{
		GameInformation.PlayerName = PlayerPrefs.GetString ("Player Name");
		GameInformation.PlayerLevel = PlayerPrefs.GetInt ("Player Level");
		GameInformation.Vitality = PlayerPrefs.GetInt ("Vitality");
		GameInformation.Strength = PlayerPrefs.GetInt ("Strength");
		GameInformation.Agility = PlayerPrefs.GetInt ("Agility");
		GameInformation.Intellect = PlayerPrefs.GetInt ("Intellect");
		GameInformation.Wisdom = PlayerPrefs.GetInt ("Wisdom");
		GameInformation.Luck = PlayerPrefs.GetInt ("Luck");
		GameInformation.Gold = PlayerPrefs.GetInt ("Gold");

		if (PlayerPrefs.GetString ("Armor Item 1") != null)
		{
			GameInformation.ArmorOne = (BaseArmor)PPSerialization.Load("Armor Item 1");
		}
	}
}
