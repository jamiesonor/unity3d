using UnityEngine;
using System.Collections;

public class BasePriestClass : BaseCharacterClass {
	
	public BasePriestClass(){
		CharacterClassName = "Priest";
		CharacterClassDescription = "A spellcaster who heals his allies.";
		MainStat = MainStatBonuses.WISDOM;
		SecondMainStat = SecondStatBonuses.INTELLECT;
		CharacterClass = CharacterClasses.PRIEST;
		/*Vitality = 12;
		Strength = 8;
		Agility = 10;
		Intellect = 14;
		Wisdom = 16;
		Luck = 10;*/
	}
}
