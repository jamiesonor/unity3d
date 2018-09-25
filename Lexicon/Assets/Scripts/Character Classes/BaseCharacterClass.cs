using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseCharacterClass {

	private string characterClassName;
	private string characterClassDescription;
	//Stats
	private int vitality = 12;
	private int strength = 8;
	private int agility = 10;
	private int intellect = 8;
	private int wisdom = 10;
	private int luck = 10;

	public enum CharacterClasses
	{
		KNIGHT,
		PRIEST,
		WARRIOR,
		ARCHER,
		MAGE
	}

	public enum MainStatBonuses
	{
		VITALITY,
		STRENGTH,
		AGILITY,
		INTELLECT,
		WISDOM,
		LUCK
	}

	public enum SecondStatBonuses
	{
		VITALITY,
		STRENGTH,
		AGILITY,
		INTELLECT,
		WISDOM,
		LUCK
	}

	public string CharacterClassName {
		get{return characterClassName;}
		set{characterClassName = value;}
	}
	public string CharacterClassDescription {
		get{return characterClassDescription;}
		set{characterClassDescription = value;}
	}

	public CharacterClasses CharacterClass{ get; set; }
	public MainStatBonuses MainStat{ get; set; }
	public SecondStatBonuses SecondMainStat{ get; set; }
	public List<BaseAbility> playerAbilities = new List<BaseAbility> ();

	public int Vitality {
		get{return vitality;}
		set{vitality = value;}
	}
	public int Strength {
		get{return strength;}
		set{strength = value;}
	}
	public int Agility {
		get{return agility;}
		set{agility = value;}
	}
	public int Intellect {
		get{return intellect;}
		set{intellect = value;}
	}
	public int Wisdom {
		get{return wisdom;}
		set{wisdom = value;}
	}
	public int Luck {
		get{return luck;}
		set{luck = value;}
	}
}
