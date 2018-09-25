using UnityEngine;
using System.Collections;

public class CreatePlayerGUI : MonoBehaviour {

	public enum CreatePlayerStates
	{
		CLASSSELECTION, //display all class types
		STATALLOCATION,	//allocate stats where the player wants
		FINALSETUP		//add name and misc items
	}
	
	private DisplayCreatePlayerFunctions displayFunctions = new DisplayCreatePlayerFunctions ();

	public static CreatePlayerStates currentState;
	
	// Use this for initialization
	void Start () {
		currentState = CreatePlayerStates.CLASSSELECTION;
	}
	
	// Update is called once per frame
	void Update () {
		switch (currentState) {
		case(CreatePlayerStates.CLASSSELECTION):
			break;
		case(CreatePlayerStates.STATALLOCATION):
			break;
		case(CreatePlayerStates.FINALSETUP):
			break;
		}
	}
	
	void OnGUI ()
	{
		displayFunctions.DisplayMainItems ();

		if (currentState == CreatePlayerStates.CLASSSELECTION)
		{
			//Display class selection function
			displayFunctions.DisplayClassSelections ();
		}
		if (currentState == CreatePlayerStates.STATALLOCATION)
		{
			//Display stat allocation function
			displayFunctions.DisplayStatAllocation ();
		}
		if (currentState == CreatePlayerStates.FINALSETUP)
		{
			//Display final setup function
			displayFunctions.DisplayFinalSetup ();
		}
	}
}
