using UnityEngine;
using System.Collections;

public class TurnBasedCombatStateMachine : MonoBehaviour {

	private bool hasAddedXP = false;
	private BattleStateStart battleStateStartScript = new BattleStateStart ();
	private BattleCalculations battleCalcScript = new BattleCalculations ();
	private BattleStateAddStatusEffects battleStateAddStatusEffectsScript = new BattleStateAddStatusEffects ();
	private BattleStateEnemyChoice battleStateEnemyChoiceScript = new BattleStateEnemyChoice ();
	public static BaseAbility playerUsedAbility;
	public static BaseAbility enemyUsedAbility;
	public static int statusEffectBaseDamage;
	public static int totalTurnCount;
	public static bool playerDidCompleteTurn;
	public static bool enemyDidCompleteTurn;
	public static BattleStates currentUser;	//enemy or player choice

	public enum BattleStates
	{
		START,
		PLAYERCHOICE,
		CALCDAMAGE,
		ADDSTATUSEFFECTS,
		ENEMYCHOICE,
		ENDTURN,
		LOSE,
		WIN
	}

	public static BattleStates currentState;

	// Use this for initialization
	void Start ()
	{
		hasAddedXP = false;
		totalTurnCount = 1;
		currentState = BattleStates.START;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (currentState);
		switch (currentState)
		{
		case (BattleStates.START):
			//SETUP BATTLE FUNCTION
			//create enemy
			battleStateStartScript.PrepareBattle();
			//choose who goes first based on luck
			break;
		case (BattleStates.PLAYERCHOICE):	//player chooses the ability they want to use
			currentUser = BattleStates.PLAYERCHOICE;
			break;
		case (BattleStates.ENEMYCHOICE):
			//coded AI goes here
			currentUser = BattleStates.ENEMYCHOICE;
			battleStateEnemyChoiceScript.EnemyCompleteTurn();
			//enemyDidCompleteTurn = true;
			//CheckWhoGoesNext ();
			break;
		case (BattleStates.CALCDAMAGE):	//we calculate damage done by player, look for existing status effects and add that damage
			if (currentUser == BattleStates.PLAYERCHOICE) {
				battleCalcScript.CalculateTotalPlayerDamage(playerUsedAbility);
			}
			if (currentUser == BattleStates.ENEMYCHOICE) {
				battleCalcScript.CalculateTotalEnemyDamage(enemyUsedAbility);
			}
			//Debug.Log ("CALCULATING DAMAGE");
			CheckWhoGoesNext ();
			break;
		case(BattleStates.ADDSTATUSEFFECTS):	//we try to add a status effect, if it exists
			battleStateAddStatusEffectsScript.CheckAbilityForStatusEffects(playerUsedAbility);
			break;
		case (BattleStates.ENDTURN):
			totalTurnCount += 1;
			playerDidCompleteTurn = false;
			enemyDidCompleteTurn = false;
			Debug.Log (totalTurnCount);
			break;
		case (BattleStates.LOSE):
			break;
		case (BattleStates.WIN):
			if(!hasAddedXP)
			{
				IncreaseExperience.AddExperience();
				hasAddedXP = true;
			}
			break;
		}
	}

	void OnGUI ()
	{
		if (GUILayout.Button ("NEXT STATE"))
		{
			if (currentState == BattleStates.START) {
				currentState = BattleStates.PLAYERCHOICE;
			} else if (currentState == BattleStates.PLAYERCHOICE) {
				currentState = BattleStates.ENEMYCHOICE;
			} else if (currentState == BattleStates.ENEMYCHOICE) {
				currentState = BattleStates.LOSE;
			} else if (currentState == BattleStates.LOSE) {
				currentState = BattleStates.WIN;
			} else if (currentState == BattleStates.WIN) {
				currentState = BattleStates.START;
			}
		}
	}

	private void CheckWhoGoesNext ()
	{
		if (playerDidCompleteTurn && !enemyDidCompleteTurn) {
			//enemy turn
			currentState = BattleStates.ENEMYCHOICE;
		}
		if (!playerDidCompleteTurn && enemyDidCompleteTurn ) {
			//player turn
			currentState = BattleStates.PLAYERCHOICE;
		}
		if (playerDidCompleteTurn && enemyDidCompleteTurn) {
			//end turn state
			currentState = BattleStates.ENDTURN;
		}
	}
}
