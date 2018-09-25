using UnityEngine;
using System.Collections;

public class LevelUp {

	public int maxPlayerLevel = 50;

	public void LevelUpCharacter ()
	{
		//Check to see if current xp > required xp
		if (GameInformation.CurrentXP > GameInformation.RequiredXP) {
			GameInformation.CurrentXP -= GameInformation.RequiredXP;
		}
		else
		{
			GameInformation.CurrentXP = 0;
		}

		if (GameInformation.PlayerLevel < maxPlayerLevel) {
			GameInformation.PlayerLevel += 1;
		}
		else
		{
			GameInformation.PlayerLevel = maxPlayerLevel;
		}
		//give player stat points
		//randomly decide to give up items
		//give them a move/ability
		//give money
		//determine the next amount of required xp
		DetermineRequiredXP ();
	}

	private void DetermineRequiredXP ()
	{
		int temp = (GameInformation.PlayerLevel * 1000) + 250;
		GameInformation.RequiredXP = temp;
	}

/*	private void DetermineMoneyToGive ()
	{
		if (GameInformation.PlayerLevel <= 10)
		{
			//give a certain amount of money
		}
	}*/
}
