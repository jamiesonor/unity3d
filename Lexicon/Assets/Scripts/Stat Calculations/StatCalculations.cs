using UnityEngine;
using System.Collections;

public class StatCalculations {

	private float enemyVitalityModifier = 0.25f;	//25%
	private float enemyAgilityModifier = 0.25f;	//25%
	private float enemyStrengthModifier = 0.2f;	//20%
	private float enemyIntellectModifier = 0.2f;	//20%
	private float enemyWisdomModifier = 0.1f;	//10%
	private float enemyLuckModifier = 0.1f;	//10%
	private float playerVitalityModifier = 0.3f;	//30%
	private float playerAgilityModifier = 0.3f;	//30%
	private float statModifier;

	private float mainStatModifier = 0.5f;
	private float secondStatModifier = 0.2f;

	public enum StatType
	{
		VITALITY,
		AGILITY,
		STRENGTH,
		INTELLECT,
		WISDOM,
		LUCK
	}

	public int CalculateStat(int statVal, StatType statType, int level, bool isEnemy)
	{
		if (isEnemy)
		{
			SetEnemyModifier (statType);
			return (statVal + (int)((statVal * statModifier) * level));
		}
		else if (!isEnemy)
		{
			SetEnemyModifier (statType);
			return (statVal + (int)((statVal * statModifier) * level)); 
		}
		return 0;
	}
	
	private void SetEnemyModifier (StatType statType)
	{
		if (statType == StatType.VITALITY)
		{
			statModifier = enemyVitalityModifier;
			statModifier = playerVitalityModifier;
		}
		if (statType == StatType.AGILITY)
		{
			statModifier = enemyAgilityModifier;
			statModifier = playerAgilityModifier;
		}
		if (statType == StatType.STRENGTH)
		{
			statModifier = enemyStrengthModifier;
		}
		if (statType == StatType.INTELLECT)
		{
			statModifier = enemyIntellectModifier;
		}
		if (statType == StatType.WISDOM)
		{
			statModifier = enemyWisdomModifier;
		}
		if (statType == StatType.LUCK)
		{
			statModifier = enemyLuckModifier;
		}
	}

	public int CalculateHealth (int statValue)
	{
		return statValue * 100; //calculate health based on vitality times 100
	}

	public int CalculateEnergy (int statValue)
	{
		return statValue * 50;
	}

	public float FindPlayerMainStatAndCalculateMainStatModifier ()
	{
		if (GameInformation.PlayerClass.MainStat == BaseCharacterClass.MainStatBonuses.INTELLECT && GameInformation.PlayerClass.SecondMainStat == BaseCharacterClass.SecondStatBonuses.WISDOM)
		{
			//8 intellect at level 1
			Debug.Log (GameInformation.Intellect);
			//10 wisdom at level 1
			return (GameInformation.Intellect * mainStatModifier) + (GameInformation.Wisdom * secondStatModifier);
		}
		return 1.0f;
	}
}
