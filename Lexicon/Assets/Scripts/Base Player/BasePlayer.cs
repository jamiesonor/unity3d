using UnityEngine;
using System.Collections;

public class BasePlayer {

	private string playerName;
	private int playerLevel;
	private BaseCharacterClass playerClass;

	private int vitality;	//health
	private int strength;	//heavy dps stat
	private int agility;	//light dps stat
	private int intellect;	//magic damage
	private int wisdom;		//mana regen
	private int luck;		//more loot

	private int gold; 		//in game currency
	
	private int currentXP;
	private int requiredXP;
	private int statPointsToAllocate;

	/*public string PlayerName
	{
		get{ return playerName;}
		set{ playerName = value;}
	}*/

	public string PlayerName { get; set; }

	public int CurrentXP { get; set; }
	public int RequiredXP { get; set; }

	public int StatPointsToAllocate { get; set; }

	public int PlayerLevel
	{
		get{ return playerLevel;}
		set{ playerLevel = value;}
	}
	public BaseCharacterClass PlayerClass
	{
		get{ return playerClass;}
		set{ playerClass = value;}
	}
	public int Vitality
	{
		get{ return vitality;}
		set{ vitality = value;}
	}
	public int Strength
	{
		get{ return strength;}
		set{ strength = value;}
	}
	public int Agility
	{
		get{ return agility;}
		set{ agility = value;}
	}
	public int Intellect
	{
		get{ return intellect;}
		set{ intellect = value;}
	}
	public int Wisdom
	{
		get{ return wisdom;}
		set{ wisdom = value;}
	}
	public int Luck
	{
		get{ return luck;}
		set{ luck = value;}
	}
	public int Gold
	{
		get{ return gold;}
		set{ gold = value;}
	}
}
