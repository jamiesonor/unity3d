using UnityEngine;
using System.Collections;

public class BattleCalculations {

	private StatCalculations statCalcScript = new StatCalculations ();

	private BaseAbility playerUsedAbility;

	private int abilityPower;
	private int statusEffectDamage;
	private float totalAbilityPowerDamage;
	private int totalUsedAbilityDamage;
	private float totalPlayerDamage;
	private int totalCritStrikeDamage;

	private float damageVarianceModifier = .025f;	//2.5%

	public void CalculateTotalPlayerDamage (BaseAbility usedAbility)
	{
		playerUsedAbility = usedAbility;
		totalUsedAbilityDamage = (int)(CalculateAbilityDamage (usedAbility));
		totalCritStrikeDamage = CalculateCriticalStrikeDamage ();
		statusEffectDamage = CalculateStatusEffectDamage ();
		totalPlayerDamage = totalUsedAbilityDamage + totalCritStrikeDamage + statusEffectDamage;
		totalPlayerDamage += (int)(Random.Range (-(totalPlayerDamage * damageVarianceModifier), totalPlayerDamage * damageVarianceModifier));
		Debug.Log (totalPlayerDamage);
		TurnBasedCombatStateMachine.playerDidCompleteTurn = true;
		//TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ENEMYCHOICE;
	}

	public void CalculateTotalEnemyDamage (BaseAbility usedAbility)
	{
		playerUsedAbility = usedAbility;
		totalUsedAbilityDamage = (int)(CalculateAbilityDamage (usedAbility));
		totalCritStrikeDamage = CalculateCriticalStrikeDamage ();
		statusEffectDamage = CalculateStatusEffectDamage ();
		totalPlayerDamage = totalUsedAbilityDamage + totalCritStrikeDamage + statusEffectDamage;
		totalPlayerDamage += (int)(Random.Range (-(totalPlayerDamage * damageVarianceModifier), totalPlayerDamage * damageVarianceModifier));
		Debug.Log (totalPlayerDamage);
		TurnBasedCombatStateMachine.enemyDidCompleteTurn = true;
		//TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ENEMYCHOICE;
	}

	private float CalculateAbilityDamage (BaseAbility usedAbility)
	{
		abilityPower = usedAbility.AbilityPower;	//retrieves power of move
		totalAbilityPowerDamage = abilityPower * statCalcScript.FindPlayerMainStatAndCalculateMainStatModifier ();	//find main stat and use as modifier for damage
		return totalAbilityPowerDamage;
	}

	private int CalculateStatusEffectDamage ()
	{
		return statusEffectDamage = TurnBasedCombatStateMachine.statusEffectBaseDamage * GameInformation.PlayerLevel;
	}

	private int CalculateCriticalStrikeDamage ()
	{
		if (DecideIfAbilityCriticallyHit ()) {
			totalCritStrikeDamage = 0;
			return totalCritStrikeDamage = (int)(playerUsedAbility.AbilityCritModifier * totalAbilityPowerDamage);
		} else {
			return totalCritStrikeDamage = 0;
		}
	}

	private bool DecideIfAbilityCriticallyHit ()
	{
		int randomTemp = Random.Range (1, 101);
		if (randomTemp <= playerUsedAbility.AbilityCritChance) {
			Debug.Log ("CRIT!");
			return true;	//we did critically hit
		} else {
			return false;	//we did not critically hit
		}
	}
}
