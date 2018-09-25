using UnityEngine;
using System.Collections;

public class SaveInformation : MonoBehaviour {

	public static void SaveAllInformation ()
	{
		PlayerPrefs.SetInt("Player Level", GameInformation.PlayerLevel);
		PlayerPrefs.SetString ("Player Name", GameInformation.PlayerName);
		PlayerPrefs.SetInt("Vitality", GameInformation.Vitality);
		PlayerPrefs.SetInt("Strength", GameInformation.Strength);
		PlayerPrefs.SetInt("Agility", GameInformation.Agility);
		PlayerPrefs.SetInt("Intellect", GameInformation.Intellect);
		PlayerPrefs.SetInt("Wisdom", GameInformation.Wisdom);
		PlayerPrefs.SetInt("Luck", GameInformation.Luck);
		PlayerPrefs.SetInt ("Gold", GameInformation.Gold);

		if (GameInformation.ArmorOne != null)
		{
			PPSerialization.Save ("Armor Item 1", GameInformation.ArmorOne);
		}

		Debug.Log ("Saved All Information");
	}
}
