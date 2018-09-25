using UnityEngine;
using System.Collections;

public class CreateNewPotion : MonoBehaviour {

	private BasePotion newPotion;

	// Use this for initialization
	void Start () {
		CreatePotion ();
		Debug.Log (newPotion.ItemName);
		Debug.Log (newPotion.ItemDescription);
		Debug.Log (newPotion.ItemID);
		Debug.Log (newPotion.PotionType);
	}

	private void CreatePotion ()
	{
		newPotion = new BasePotion ();
		newPotion.ItemName = "Potion";
		newPotion.ItemDescription = "This is a potion.";
		newPotion.ItemID = Random.Range (1, 101);
		ChoosePotionType ();
	}

	private void ChoosePotionType ()
	{
		System.Array potions = System.Enum.GetValues (typeof(BasePotion.PotionTypes));
		newPotion.PotionType = (BasePotion.PotionTypes)potions.GetValue (Random.Range (0, potions.Length));
	}
}
