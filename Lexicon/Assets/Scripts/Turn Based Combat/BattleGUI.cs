using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BattleGUI : MonoBehaviour {

	private Text playerName;
	private Text playerHealth;
	private Image playerHealthImage;

	private Text abilityOneName;

	//private string playerName;
	private int playerLevel;
	//private int playerHealth;
	private int playerEnergy;

	// Use this for initialization
	void Start ()
	{
		playerName = transform.FindChild ("PlayerInfoContainer").FindChild ("PlayerPortrait").FindChild ("PlayerName").GetComponent<Text> ();
		playerName.text = GameInformation.PlayerName;
		playerHealth = transform.FindChild ("PlayerInfoContainer").FindChild ("PlayerHealthBar").FindChild ("PlayerHealthValue").GetComponent<Text> ();
		playerHealthImage = transform.FindChild ("PlayerInfoContainer").FindChild ("PlayerHealthBar").GetComponent<Image> ();

		//playerName = GameInformation.PlayerName;
		playerLevel = GameInformation.PlayerLevel;
		Debug.Log (GameInformation.playerMoveTwo.AbilityStatusEffect.StatusEffectName);
	}

	// Update is called once per frame
	void Update () {
		playerName.text = GameInformation.PlayerName;
		playerHealth.text = GameInformation.PlayerHealth.ToString ();
		playerHealthImage.fillAmount = GameInformation.PlayerHealth / 1;
	}

	void OnGUI ()
	{
		//buttons for player's moves
		//Use for loop to display several abilities
		//create action bar
		/*for (int i = 0; i < GameInformation.playerAbilities.Count; i++)
		{
			if (GUI.Button (new Rect (0, 0, 0, 0), GameInformation.playerAbilities [i].AbilityName))
			{
				
			}
		}*/

		if (TurnBasedCombatStateMachine.currentState == TurnBasedCombatStateMachine.BattleStates.PLAYERCHOICE)
		{
			DisplayPlayerChoice ();
		}

		//show enemy health and other information
		//show player information
	}

	public void AbilityOne ()
	{
		TurnBasedCombatStateMachine.playerUsedAbility = GameInformation.playerMoveTwo;
		TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ADDSTATUSEFFECTS;
	}

	private void DisplayPlayerChoice ()
	{
		if (GUI.Button (new Rect (Screen.width - 250, Screen.height - 50, 100, 30), GameInformation.playerMoveOne.AbilityName))
		{
			//calculate player damage to enemy
			TurnBasedCombatStateMachine.playerUsedAbility = GameInformation.playerMoveOne;
			TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ADDSTATUSEFFECTS;
		}
		if (GUI.Button (new Rect (Screen.width - 150, Screen.height - 50, 100, 30), GameInformation.playerMoveTwo.AbilityName))
		{
			//calculate player damage to enemy
			TurnBasedCombatStateMachine.playerUsedAbility = GameInformation.playerMoveTwo;
			TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ADDSTATUSEFFECTS;
		}
	}

	public void FindAbilityOneInfo ()
	{
		abilityOneName = transform.FindChild ("MeleeAbilitiesContainer").FindChild ("AbilityOne").FindChild("Text").GetComponent<Text> ();
		abilityOneName.text = GameInformation.playerMoveTwo.AbilityName;
	}
}
