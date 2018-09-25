using UnityEngine;
using System.Collections;

public class BaseWeapon : BaseItem {	//BaseWeapon <- BaseItem

	public enum WeaponTypes{
		SWORD,
		STAFF,
		DAGGER,
		BOW,
		SHIELD,
		MACE
	}

	private WeaponTypes weaponType;
	private int spellEffectID;

	public WeaponTypes WeaponType
	{
		get{ return weaponType;}
		set{ weaponType = value;}
	}

	public int SpellEffectID
	{
		get{ return spellEffectID;}
		set{ spellEffectID = value;}
	}
}
