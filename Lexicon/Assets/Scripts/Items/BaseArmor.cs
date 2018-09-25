using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseArmor : BaseItem {

	public enum ArmorTypes
	{
		HEAD,
		SHOULDERS,
		CHEST,
		HANDS,
		LEGS,
		FEET
	}

	private ArmorTypes armorType;
	private int spellEffectID;

	public ArmorTypes ArmorType
	{
		get{ return armorType;}
		set{ armorType = value;}
	}

	public int SpellEffectID
	{
		get{ return spellEffectID;}
		set{ spellEffectID = value;}
	}
}
