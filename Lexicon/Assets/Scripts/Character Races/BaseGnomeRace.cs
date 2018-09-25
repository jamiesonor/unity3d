using UnityEngine;
using System.Collections;

public class BaseGnomeRace : BaseCharacterRace {

	public BaseGnomeRace ()
	{
		new BaseCharacterRace ();
		RaceName = "Gnome";
		RaceDescription = "Is a Gnome";
		HasAgilityBonus = true;
		HasIntellectBonus = true;
		HasLuckBonus = true;
	}
}
