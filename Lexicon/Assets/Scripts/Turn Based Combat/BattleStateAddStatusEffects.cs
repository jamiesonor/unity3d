using UnityEngine;
using System.Collections;

public class BattleStateAddStatusEffects {

	public void CheckAbilityForStatusEffects(BaseAbility usedAbility)
	{
		switch (usedAbility.AbilityStatusEffect.StatusEffectName)
		{
		case("Burn"):
			if (TryToApplyStatusEffect (usedAbility)) {
				Debug.Log ("RETURNED TRUE, APPLIED EFFECT");
				TurnBasedCombatStateMachine.statusEffectBaseDamage = usedAbility.AbilityStatusEffect.StatusEffectPower;
				Debug.Log (TurnBasedCombatStateMachine.statusEffectBaseDamage);
			}
			else
			{
				TurnBasedCombatStateMachine.statusEffectBaseDamage = 0;
			}
			//Debug.Log ("TRY TO APPLY EFFECT. ABILITY HAS " + usedAbility.AbilityStatusEffect.StatusEffectApplyPercentage + "% CHANCE");
			TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.CALCDAMAGE;
			break;
		default:
			Debug.LogError ("ERROR IN STATUS EFFECT");
			break;
		}
	}

	private bool TryToApplyStatusEffect (BaseAbility usedAbility)
	{
		//look at % chance of status effect applying
		//using % chance apply affect
		int randomTemp = Random.Range (1, 101);	//random number between 1 - 100
		Debug.Log (randomTemp);
		if (randomTemp <= usedAbility.AbilityStatusEffect.StatusEffectApplyPercentage)	//apply the status effect
		{
			return true;
		}
		return false;
	}
}
