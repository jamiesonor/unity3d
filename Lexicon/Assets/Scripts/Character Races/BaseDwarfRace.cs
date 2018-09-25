using UnityEngine;
using System.Collections;

public class BaseDwarfRace : BaseCharacterRace {

	public BaseDwarfRace ()
	{
		new BaseCharacterRace ();
		RaceName = "Dwarf";
		RaceDescription = "Is a Dwarf";
		HasVitalityBonus = true;
		HasStrengthBonus = true;
		HasLuckBonus = true;
	}
}
