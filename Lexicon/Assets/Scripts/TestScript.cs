using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		LoadInformation.LoadAllInformation ();
		Debug.Log ("Player Name: " + GameInformation.PlayerName);
		//Debug.Log ("Player Class: " + GameInformation.PlayerClass.CharacterClassName);
		Debug.Log ("Player Level: " + GameInformation.PlayerLevel);
		Debug.Log ("Player Vitality: " + GameInformation.Vitality);
		Debug.Log ("Player Strength: " + GameInformation.Strength);
		Debug.Log ("Player Agility: " + GameInformation.Agility);
		Debug.Log ("Player Intellect: " + GameInformation.Intellect);
		Debug.Log ("Player Wisdom: " + GameInformation.Wisdom);
		Debug.Log ("Player Luck: " + GameInformation.Luck);
		Debug.Log ("Player Gold: " + GameInformation.Gold);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
