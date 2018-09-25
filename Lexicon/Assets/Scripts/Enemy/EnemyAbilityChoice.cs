using UnityEngine;
using System.Collections;

public class EnemyAbilityChoice {

	private int totalPlayerHealth;
	private int playerHealthPercentage;
	private BaseAbility chosenAbility;

	public BaseAbility ChooseEnemyAbility ()
	{
		totalPlayerHealth = GameInformation.PlayerHealth;
		playerHealthPercentage = (int)(totalPlayerHealth / 100) * 100;

		if (playerHealthPercentage >= 75) {
			return chosenAbility = ChooseAbilityAtSeventyFivePercent ();
		} else if (playerHealthPercentage < 75 && playerHealthPercentage >= 50) {
			return chosenAbility = new SwordSlash ();
		} else if (playerHealthPercentage < 50) {
			return chosenAbility = new SwordSlash ();
		}
		return chosenAbility = new AttackAbility ();
	}

	private BaseAbility ChooseAbilityAtSeventyFivePercent ()
	{
		return chosenAbility = new SwordSlash ();
	}
}
