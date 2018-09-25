using UnityEngine;
using System.Collections;

public class StatAllocationModule {

	private string[] statNames = new string[6] {"Vitality", "Strength", "Agility", "Intellect", "Wisdom", "Luck"};
	private string[] statDescriptions = new string[6] {"Health Modifier", "Heavy Damage Modifier", "Light Damage Modifier", "Magic Damage Modifier", "Spell Regen Modifier", "Chance Modifier"};
	private bool[] statSelections = new bool[6];

	public int[] pointsToAllocate = new int[6];

	private int[] baseStatPoints = new int[6];		//starting stat values for the chosen class

	private int availablePoints = 5;

	public bool didRunOnce = false;

	public void DisplayStatAllocationModule ()
	{
		if (!didRunOnce)
		{
			RetrieveBaseStatPoints ();
			didRunOnce = true;
		}
		DisplayStatToggleSwitches ();
		DisplayStatIncreaseDecreaseButtons ();
	}

	public void DisplayStatToggleSwitches ()
	{
		for (int i = 0; i < statNames.Length; i++)
		{
			statSelections[i] = GUI.Toggle(new Rect(10, 60*i + 10, 100, 50), statSelections[i], statNames[i]);
			GUI.Label(new Rect(100 ,60*i + 10, 50, 50), pointsToAllocate[i].ToString ());
			if(statSelections[i])
			{
				GUI.Label(new Rect(20, 60*i + 30, 150, 100), statDescriptions[i]);
			}
		}
	}

	private void DisplayStatIncreaseDecreaseButtons ()
	{
		for (int i = 0; i < pointsToAllocate.Length; i++) {
			if(pointsToAllocate[i]  >= baseStatPoints[i] && availablePoints > 0)
			{
				if(GUI.Button(new Rect(200, 60*i + 10, 50, 50), "+"))
				{
					pointsToAllocate[i] += 1;
					--availablePoints;
				}
			}
			if(pointsToAllocate[i] > baseStatPoints[i])
			{
				if(GUI.Button(new Rect(260, 60*i + 10, 50, 50), "-"))
				{
					pointsToAllocate[i] -= 1;
					++availablePoints;
				}
			}
		}
	}

	private void RetrieveBaseStatPoints ()
	{
		BaseCharacterClass cClass = GameInformation.PlayerClass;

		pointsToAllocate [0] = cClass.Vitality;
		baseStatPoints [0] = cClass.Vitality;

		pointsToAllocate [1] = cClass.Strength;
		baseStatPoints [1] = cClass.Strength;

		pointsToAllocate [2] = cClass.Agility;
		baseStatPoints [2] = cClass.Agility;

		pointsToAllocate [3] = cClass.Intellect;
		baseStatPoints [3] = cClass.Intellect;

		pointsToAllocate [4] = cClass.Wisdom;
		baseStatPoints [4] = cClass.Wisdom;

		pointsToAllocate [5] = cClass.Luck;
		baseStatPoints [5] = cClass.Luck;
	}
}
