using UnityEngine;
using System.Collections;

public class BaseArcherClass : BaseCharacterClass {

	public BaseArcherClass ()
	{
		CharacterClassName = "Archer";
		CharacterClassDescription = "A skillful ranged attacker.";
		MainStat = MainStatBonuses.AGILITY;
		SecondMainStat = SecondStatBonuses.INTELLECT;
		CharacterClass = CharacterClasses.ARCHER;
	}

}
