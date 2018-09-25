using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class CreateNewCharacter : MonoBehaviour {

	private BasePlayer newPlayer;
	private bool isKnightClass;
	private bool isWarriorClass;
	private bool isPriestClass;
	private string playerName = "Enter Name";

	// Use this for initialization
	void Start () {
		newPlayer = new BasePlayer ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI ()
	{
		playerName = GUILayout.TextField (playerName, 15);
		playerName = Regex.Replace (playerName, @"[^a-zA-Z0-9 ]", "" );

		if (GUILayout.Toggle (isKnightClass, "Knight Class"))
		{
			isKnightClass = true;
			isWarriorClass = false;
			isPriestClass = false;
		}

		if (GUILayout.Toggle (isWarriorClass, "Warrior Class"))
		{
			isWarriorClass = true;
			isKnightClass = false;
			isPriestClass = false;
		}

		if (GUILayout.Toggle (isPriestClass, "Priest Class"))
		{
			isPriestClass = true;
			isKnightClass = false;
			isWarriorClass = false;
		}

		if (GUILayout.Button ("Create"))
		{
			if (isKnightClass)
			{
				newPlayer.PlayerClass = new BaseKnightClass ();
			}
			else if (isWarriorClass)
			{
				newPlayer.PlayerClass = new BaseWarriorClass ();
			}
			else if (isPriestClass)
			{
				newPlayer.PlayerClass = new BasePriestClass ();
			}

			CreateNewPlayer ();

			StoreNewPlayerInfo ();
			SaveInformation.SaveAllInformation ();
		}

		if (GUILayout.Button ("Load"))
		{
			Application.LoadLevel("Test");
		}
	}

	private void StoreNewPlayerInfo ()
	{
		GameInformation.PlayerName = newPlayer.PlayerName;
		GameInformation.PlayerLevel = newPlayer.PlayerLevel;
		GameInformation.Vitality = newPlayer.Vitality;
		GameInformation.Strength = newPlayer.Strength;
		GameInformation.Agility = newPlayer.Agility;
		GameInformation.Intellect = newPlayer.Intellect;
		GameInformation.Wisdom = newPlayer.Wisdom;
		GameInformation.Luck = newPlayer.Luck;
		GameInformation.Gold = newPlayer.Gold;
	}

	private void CreateNewPlayer ()
	{
		newPlayer.PlayerLevel = 1;
		newPlayer.Vitality = newPlayer.PlayerClass.Vitality;
		newPlayer.Strength = newPlayer.PlayerClass.Strength;
		newPlayer.Agility = newPlayer.PlayerClass.Agility;
		newPlayer.Intellect = newPlayer.PlayerClass.Intellect;
		newPlayer.Wisdom = newPlayer.PlayerClass.Wisdom;
		newPlayer.Luck = newPlayer.PlayerClass.Luck;
		newPlayer.Gold = 10;
		newPlayer.PlayerName = playerName;

		Debug.Log ("Player Name: " + newPlayer.PlayerName);
		Debug.Log ("Player Class: " + newPlayer.PlayerClass.CharacterClassName);
		Debug.Log ("Player Level: " + newPlayer.PlayerLevel);
		Debug.Log ("Player Vitality: " + newPlayer.Vitality);
		Debug.Log ("Player Strength: " + newPlayer.Strength);
		Debug.Log ("Player Agility: " + newPlayer.Agility);
		Debug.Log ("Player Intellect: " + newPlayer.Intellect);
		Debug.Log ("Player Wisdom: " + newPlayer.Wisdom);
		Debug.Log ("Player Luck: " + newPlayer.Luck);
		Debug.Log ("Player Gold: " + newPlayer.Gold);
	}
}