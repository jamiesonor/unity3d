using UnityEngine;
using System.Collections;

public class BattleStateStart {
	
	public BasePlayer newEnemy = new BasePlayer ();
	private StatCalculations statCalculationsScript = new StatCalculations ();
	private BaseCharacterClass[] classTypes = new BaseCharacterClass[] {new BaseKnightClass (), new BasePriestClass (), new BaseWarriorClass (), new BaseArcherClass (), new BaseMageClass ()};
	private string[] enemyNames = new string[]{"Deadly Enemy", "Fierce Enemy", "Subtle Enemy", "Powerful Enemy"};

	private int playerVitality;
	private int playerAgility;
	private int playerHealth;
	private int playerEnergy;

	public void PrepareBattle ()
	{
		//create enemy
		CreateNewEnemy ();
		//find player stat calculations
		DeterminePlayerVitals ();
		//choose who goes first based on luck
		ChooseWhoGoesFirst ();
		//does the scene have a StatusEffect? If so, apply effect throughout battle
	}

	private void CreateNewEnemy ()
	{
		newEnemy.PlayerName = enemyNames[Random.Range(0, enemyNames.Length)];
		newEnemy.PlayerLevel = Random.Range (GameInformation.PlayerLevel - 2, GameInformation.PlayerLevel + 2);
		newEnemy.PlayerClass = classTypes [Random.Range (0, classTypes.Length)];	//randomly chooses class out of the array above
		newEnemy.Vitality = statCalculationsScript.CalculateStat (newEnemy.Vitality, StatCalculations.StatType.VITALITY, newEnemy.PlayerLevel, true);
		newEnemy.Agility = statCalculationsScript.CalculateStat (newEnemy.Agility, StatCalculations.StatType.AGILITY, newEnemy.PlayerLevel, true);
		newEnemy.Strength = statCalculationsScript.CalculateStat (newEnemy.Strength, StatCalculations.StatType.STRENGTH, newEnemy.PlayerLevel, true);
		newEnemy.Intellect = statCalculationsScript.CalculateStat (newEnemy.Intellect, StatCalculations.StatType.INTELLECT, newEnemy.PlayerLevel, true);
		newEnemy.Wisdom = statCalculationsScript.CalculateStat (newEnemy.Wisdom, StatCalculations.StatType.WISDOM, newEnemy.PlayerLevel, true);
		newEnemy.Luck = statCalculationsScript.CalculateStat (newEnemy.Luck, StatCalculations.StatType.LUCK, newEnemy.PlayerLevel, true);
	}

	private void ChooseWhoGoesFirst ()
	{
		if (GameInformation.Luck >= newEnemy.Luck)
		{
			//player goes first
			TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.PLAYERCHOICE;
		}
		if (GameInformation.Luck < newEnemy.Luck)
		{
			//enemy goes first
			TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ENEMYCHOICE;
		}
		/*if (GameInformation.Luck == newEnemy.Luck)
		{

		}*/
	}

	private void DeterminePlayerVitals ()
	{
		GameInformation.PlayerName = "Test Name";
		GameInformation.PlayerClass = new BaseMageClass ();
		GameInformation.Intellect = GameInformation.PlayerClass.Intellect;
		GameInformation.Wisdom = GameInformation.PlayerClass.Wisdom;
		GameInformation.Vitality = GameInformation.PlayerClass.Vitality;
		playerVitality = statCalculationsScript.CalculateStat (GameInformation.Vitality, StatCalculations.StatType.VITALITY, GameInformation.PlayerLevel, false);
		Debug.Log (playerVitality);
		playerAgility = statCalculationsScript.CalculateStat (GameInformation.Agility, StatCalculations.StatType.AGILITY, GameInformation.PlayerLevel, false);
		playerHealth = statCalculationsScript.CalculateHealth (playerVitality);	//calculate health
		playerEnergy = statCalculationsScript.CalculateEnergy (playerAgility);	//calculate energy
		GameInformation.PlayerHealth = playerHealth;
		Debug.Log (GameInformation.PlayerHealth);
		GameInformation.PlayerEnergy = playerEnergy;
		GameInformation.PlayerLevel = 1;
	}
}
