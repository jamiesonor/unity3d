using UnityEngine;
using System.Collections;

public class BaseElfRace : BaseCharacterRace {

	public BaseElfRace ()
	{
		new BaseCharacterRace ();
		RaceName = "Elf";
		RaceDescription = "Is an Elf";
		HasAgilityBonus = true;
		HasIntellectBonus = true;
		HasWisdomBonus = true;
	}
}
