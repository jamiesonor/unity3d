using UnityEngine;
using System.Collections;

public class BaseWarriorClass : BaseCharacterClass {
	
	public  BaseWarriorClass(){
		CharacterClassName = "Warrior";
		CharacterClassDescription = "An armsman who deals damage to his foes.";
		MainStat = MainStatBonuses.STRENGTH;
		SecondMainStat = SecondStatBonuses.VITALITY;
		CharacterClass = CharacterClasses.WARRIOR;
		playerAbilities.Add (new AttackAbility ());
		playerAbilities.Add (new SwordSlash ());
		/*Vitality = 12;
		Strength = 16;
		Agility = 14;
		Intellect = 10;
		Wisdom = 8;
		Luck = 10;*/
	}
}
