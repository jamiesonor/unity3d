using UnityEngine;
using System.Collections;

public class BaseKnightClass : BaseCharacterClass {

	public BaseKnightClass(){
		CharacterClassName = "Knight";
		CharacterClassDescription = "A strong hero who takes damage and protects his allies.";
		MainStat = MainStatBonuses.VITALITY;
		SecondMainStat = SecondStatBonuses.STRENGTH;
		CharacterClass = CharacterClasses.KNIGHT;
		/*Vitality = 16;
		Strength = 14;
		Agility = 12;
		Intellect = 10;
		Wisdom = 8;
		Luck = 10;*/
	}
}
