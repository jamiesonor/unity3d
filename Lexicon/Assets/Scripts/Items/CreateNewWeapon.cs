using UnityEngine;
using System.Collections;

public class CreateNewWeapon : MonoBehaviour {

	private BaseWeapon newWeapon;

	void Start (){
		CreateWeapon ();
		Debug.Log (newWeapon.ItemName);
		Debug.Log (newWeapon.ItemDescription);
		Debug.Log (newWeapon.ItemID.ToString());
		Debug.Log (newWeapon.WeaponType.ToString());
		Debug.Log (newWeapon.Vitality.ToString());
		Debug.Log (newWeapon.Luck.ToString());
	}

	public void CreateWeapon()
	{
		newWeapon = new BaseWeapon ();

		//assign name to the weapon
		newWeapon.ItemName = "W" + Random.Range (1, 101);
		//create a weapon description
		newWeapon.ItemDescription = "This is a new Weapon.";
		//weapon id
		newWeapon.ItemID = Random.Range (1, 101);
		//stats
		newWeapon.Vitality = Random.Range (1, 11);
		newWeapon.Strength = Random.Range (1, 11);
		newWeapon.Agility = Random.Range (1, 11);
		newWeapon.Intellect = Random.Range (1, 11);
		newWeapon.Wisdom = Random.Range (1, 11);
		newWeapon.Luck = Random.Range (1, 11);
		//choose type of weapon
		ChooseWeaponType ();
		//spell effect id
		newWeapon.SpellEffectID = Random.Range (1, 101);
	}

	private void ChooseWeaponType()
	{
		System.Array weapons = System.Enum.GetValues (typeof(BaseWeapon.WeaponTypes));
		newWeapon.WeaponType = (BaseWeapon.WeaponTypes)weapons.GetValue (Random.Range (0, weapons.Length));
	}
}
