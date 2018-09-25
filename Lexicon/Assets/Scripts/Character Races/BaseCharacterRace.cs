using UnityEngine;
using System.Collections;

public class BaseCharacterRace {

	private string raceName = "Needs a Name";
	private string raceDescription = "Needs a Description";
	private bool hasVitalityBonus = false;
	private bool hasStrengthBonus = false;
	private bool hasAgilityBonus = false;
	private bool hasIntellectBonus = false;
	private bool hasWisdomBonus = false;
	private bool hasLuckBonus = false;
	
	public string RaceName
	{
		get{return raceName;}
		set{raceName = value;}
	}
	public string RaceDescription
	{
		get{ return raceDescription;}
		set{ raceDescription = value;}
	}
	
	public bool HasVitalityBonus { get; set; }
	public bool HasStrengthBonus { get; set; }
	public bool HasAgilityBonus { get; set; }
	public bool HasIntellectBonus { get; set; }
	public bool HasWisdomBonus { get; set; }
	public bool HasLuckBonus { get; set; }
}