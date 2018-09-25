using UnityEngine;
using System.Collections;

public class CreateNewArmor : MonoBehaviour {

	private BaseArmor newArmor;
	private string[] itemNames = new string[5]{"Common", "Uncommon", "Rare", "Mythic", "Legendary"};
	private string[] itemDescription = new string[2]{"A new cool item", "A new not-so-cool item"};
	
	private void CreateArmor ()
	{
		newArmor = new BaseArmor ();
		newArmor.ItemName = itemNames [Random.Range (0, 3)] + " Item";
		newArmor.ItemID = Random.Range (1, 101);
		ChooseItemType ();
		newArmor.ItemDescription = itemDescription[Random.Range(0, itemDescription.Length)];
		newArmor.Vitality = Random.Range (1, 11);
		newArmor.Strength = Random.Range (1, 11);
		newArmor.Agility = Random.Range (1, 11);
		newArmor.Intellect = Random.Range (1, 11);
		newArmor.Wisdom = Random.Range (1, 11);
		newArmor.Luck = Random.Range (1, 11);
	}
	
	private void ChooseItemType ()
	{
		int randomTemp = Random.Range (1, 7);
		if (randomTemp == 1)
		{
			newArmor.ArmorType = BaseArmor.ArmorTypes.HEAD;
		}
		else if (randomTemp == 2)
		{
			newArmor.ArmorType = BaseArmor.ArmorTypes.SHOULDERS;
		}
		else if (randomTemp == 3)
		{
			newArmor.ArmorType = BaseArmor.ArmorTypes.CHEST;
		}
		else if (randomTemp == 4)
		{
			newArmor.ArmorType = BaseArmor.ArmorTypes.HANDS;
		}
		else if (randomTemp == 5)
		{
			newArmor.ArmorType = BaseArmor.ArmorTypes.LEGS;
		}
		else if (randomTemp == 6)
		{
			newArmor.ArmorType = BaseArmor.ArmorTypes.FEET;
		}
	}
}
