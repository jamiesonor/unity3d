using UnityEngine;
using System.Collections;

public class BaseMageClass : BaseCharacterClass {

	public BaseMageClass ()
	{
		CharacterClassName = "Mage";
		CharacterClassDescription = "A wise wizard who casts spells!";
		MainStat = MainStatBonuses.INTELLECT;
		SecondMainStat = SecondStatBonuses.WISDOM;
		CharacterClass = CharacterClasses.MAGE;
	}
}
