using UnityEngine;
using System.Collections;

public class BasePotion : BaseItem {

	public enum PotionTypes
	{
		HEALTH,
		ENERGY,
		VITALITY,
		STRENGTH,
		AGILITY,
		INTELLECT,
		WISDOM,
		LUCK
	}

	private PotionTypes potionType;
	private int spellEffectID;

	public PotionTypes PotionType
	{
		get{ return potionType;}
		set{ potionType = value;}
	}

	public int SpellEffectID
	{
		get{ return spellEffectID;}
		set{ spellEffectID = value;}
	}
}
