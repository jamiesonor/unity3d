using UnityEngine;
using System.Collections;

public class BaseHumanRace : BaseCharacterRace {

	public BaseHumanRace ()
	{
		new BaseCharacterRace ();
		RaceName = "Human";
		RaceDescription = "Is a Human";
		HasVitalityBonus = true;
		HasStrengthBonus = true;
		HasWisdomBonus = true;
	}
}
