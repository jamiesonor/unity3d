using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameInformation : MonoBehaviour {

	void Awake ()
	{
		DontDestroyOnLoad (transform.gameObject);
	}

	public static List<BaseAbility> playerAbilities;

	public static bool IsMale { get; set; }
	public static string PlayerBio { get; set; }
	public static BaseArmor ArmorOne { get; set; }
	public static string PlayerName { get; set; }
	public static int PlayerLevel { get; set; }
	public static BaseCharacterClass PlayerClass { get; set; }
	public static int Vitality { get; set; }
	public static int Strength { get; set; }
	public static int Agility { get; set; }
	public static int Intellect { get; set; }
	public static int Wisdom { get; set; }
	public static int Luck { get; set; }
	public static int Gold { get; set; }
	public static int CurrentXP { get; set; }
	public static int RequiredXP { get; set; }

	public static BaseAbility playerMoveOne = new AttackAbility ();
	public static BaseAbility playerMoveTwo = new SwordSlash ();

	public static int PlayerHealth { get; set; }
	public static int PlayerEnergy { get; set; }
}
