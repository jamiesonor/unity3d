using UnityEngine;
using System.Collections;

public class DisplayCreatePlayerFunctions {

	private StatAllocationModule statAllocationModule = new StatAllocationModule ();

	private int classSelection;
	private string[] classSelectionNames = new string[] {"Tank", "Healer", "Damage"};
	private string playerFirstName = "Enter First Name";	//name
	private string playerLastName = "Enter Last Name";
	private string playerBio = "Enter Player Bio";	//bio
	private bool isMale = true; 		//gender selection
	private int genderSelection;
	private string[] genderTypes = new string[2] {"Male", "Female"};

	public void DisplayClassSelections ()
	{
		//A list of toggle buttons and each button will be a different class
		//selection grid
		classSelection = GUI.SelectionGrid (new Rect (50, 50, 250, 300), classSelection, classSelectionNames, 1);
		GUI.Label (new Rect (450, 50, 300, 300), FindClassDescription (classSelection));
		GUI.Label (new Rect (450, 100, 300, 300), FindClassStatValues (classSelection));
	}

	private string FindClassDescription (int classSelection)
	{
		if (classSelection == 0)
		{
			BaseCharacterClass tempClass = new BaseKnightClass ();
			return tempClass.CharacterClassDescription;
		}
		else if (classSelection == 1)
		{
			BaseCharacterClass tempClass = new BasePriestClass ();
			return tempClass.CharacterClassDescription;
		}
		else if (classSelection == 2)
		{
			BaseCharacterClass tempClass = new BaseWarriorClass ();
			return tempClass.CharacterClassDescription;
		}
		return "NO CLASS FOUND";
	}

	private string FindClassStatValues (int classSelection)
	{
		if (classSelection == 0)
		{
			BaseCharacterClass tempClass = new BaseKnightClass ();
			string tempStats = "Vitality " + tempClass.Vitality + "\n" + "Strength " + tempClass.Strength + "\n" + "Agility " + tempClass.Agility + "\n" + "Intellect " + tempClass.Intellect + "\n" + "Wisdom " + tempClass.Wisdom + "\n" + "Luck " + tempClass.Luck;
			return tempStats;
		}
		else if (classSelection == 1)
		{
			BaseCharacterClass tempClass = new BasePriestClass ();
			string tempStats = "Vitality " + tempClass.Vitality + "\n" + "Strength " + tempClass.Strength + "\n" + "Agility " + tempClass.Agility + "\n" + "Intellect " + tempClass.Intellect + "\n" + "Wisdom " + tempClass.Wisdom + "\n" + "Luck " + tempClass.Luck;
			return tempStats;
		}
		else if (classSelection == 2)
		{
			BaseCharacterClass tempClass = new BaseWarriorClass ();
			string tempStats = "Vitality " + tempClass.Vitality + "\n" + "Strength " + tempClass.Strength + "\n" + "Agility " + tempClass.Agility + "\n" + "Intellect " + tempClass.Intellect + "\n" + "Wisdom " + tempClass.Wisdom + "\n" + "Luck " + tempClass.Luck;
			return tempStats;
		}
		return "NO STATS FOUND";
	}

	public void DisplayStatAllocation ()
	{
		//a list of stats with plus and minus buttons to add stats
		//logic to make sure player cannot add more than stats given
		statAllocationModule.DisplayStatAllocationModule ();
	}

	public void DisplayFinalSetup ()
	{
		//name
		playerFirstName = GUI.TextArea (new Rect (20, 10, 150, 25), playerFirstName, 25);
		playerLastName = GUI.TextArea (new Rect (20, 55, 150, 25), playerLastName, 25);
		//gender
		genderSelection = GUI.SelectionGrid (new Rect (200, 10, 100, 70), genderSelection, genderTypes, 1);
		//add a description to your character, a short bio
		playerBio = GUI.TextArea (new Rect (20, 90, 250, 200), playerBio, 250);
	}

	private void ChooseClass (int classSelection)
	{
		if (classSelection == 0)
		{
			GameInformation.PlayerClass = new BaseKnightClass ();
		}
		else if (classSelection == 1)
		{
			GameInformation.PlayerClass = new BasePriestClass ();
		}
		else if (classSelection == 2)
		{
			GameInformation.PlayerClass = new BaseWarriorClass ();
		}
	}

	public void DisplayMainItems ()
	{
		Transform player = GameObject.FindGameObjectWithTag ("Player").transform;

		GUI.Label(new Rect (Screen.width/2, 20, 250, 250), "Create New Player");

		if (GUI.Button (new Rect (350, 350, 50, 50), "<<<"))
		{
			//turn transform tagged as player to the left
			player.Rotate(Vector3.up * 10);
		}
		if (GUI.Button (new Rect (450, 350, 50, 50), ">>>"))
		{
			//turn transform tagged as player to the right
			player.Rotate(Vector3.down * 10);
		}
		if (CreatePlayerGUI.currentState != CreatePlayerGUI.CreatePlayerStates.FINALSETUP) //if we are not in the final setup then show a next button
		{
			if (GUI.Button (new Rect (525, 350, 50, 50), "Next"))
			{
				if (CreatePlayerGUI.currentState == CreatePlayerGUI.CreatePlayerStates.CLASSSELECTION)
				{
					ChooseClass (classSelection);
					CreatePlayerGUI.currentState = CreatePlayerGUI.CreatePlayerStates.STATALLOCATION;
				}
				else if (CreatePlayerGUI.currentState == CreatePlayerGUI.CreatePlayerStates.STATALLOCATION)
				{
					GameInformation.Vitality = statAllocationModule.pointsToAllocate[0];
					GameInformation.Strength = statAllocationModule.pointsToAllocate[1];
					GameInformation.Agility = statAllocationModule.pointsToAllocate[2];
					GameInformation.Intellect = statAllocationModule.pointsToAllocate[3];
					GameInformation.Wisdom = statAllocationModule.pointsToAllocate[4];
					GameInformation.Luck = statAllocationModule.pointsToAllocate[5];

					CreatePlayerGUI.currentState = CreatePlayerGUI.CreatePlayerStates.FINALSETUP;
				}
			}
		}
		else if (CreatePlayerGUI.currentState == CreatePlayerGUI.CreatePlayerStates.FINALSETUP)
		{
			if(GUI.Button(new Rect(525, 350, 50, 50), "Finish"))
			{
				//Final Save
				GameInformation.PlayerName = playerFirstName + " " + playerLastName;
				GameInformation.PlayerBio = playerBio;
				if (genderSelection == 0)
				{
					GameInformation.IsMale = true;
				}
				else if (genderSelection == 1)
				{
					GameInformation.IsMale = false;
				}
				SaveInformation.SaveAllInformation ();
				Debug.Log ("Make Final Save");
			}
		}
		if (CreatePlayerGUI.currentState != CreatePlayerGUI.CreatePlayerStates.CLASSSELECTION)
		{
			if (GUI.Button (new Rect (275, 350, 50, 50), "Back"))
			{
				if (CreatePlayerGUI.currentState == CreatePlayerGUI.CreatePlayerStates.STATALLOCATION)
				{
					statAllocationModule.didRunOnce = false;
					GameInformation.PlayerClass = null;
					CreatePlayerGUI.currentState = CreatePlayerGUI.CreatePlayerStates.CLASSSELECTION;
				}
				else if (CreatePlayerGUI.currentState == CreatePlayerGUI.CreatePlayerStates.FINALSETUP)
				{
					CreatePlayerGUI.currentState = CreatePlayerGUI.CreatePlayerStates.STATALLOCATION;
				}
			}
		}
	}
}