using UnityEngine;
using System.Collections;

public class TestGUI : MonoBehaviour {

	/*private BaseCharacterClass class1 = new BaseKnightClass();
	private BaseCharacterClass class2 = new BasePriestClass();
	private BaseCharacterClass class3 = new BaseWarriorClass();*/

	private BaseCharacterRace class1;
	private BaseCharacterClass class2;

	// Use this for initialization
	void Start () {
		class2 = new BaseArcherClass ();
		Debug.Log (class2.CharacterClassName);
		Debug.Log (class2.CharacterClassDescription);
		Debug.Log (class2.MainStat);
		Debug.Log (class2.SecondMainStat);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*void OnGui(){
		GUILayout.Label (class1.CharacterClassName);
		GUILayout.Label (class1.CharacterClassDescription);
		GUILayout.Label (class2.CharacterClassName);
		GUILayout.Label (class2.CharacterClassDescription);
		GUILayout.Label (class3.CharacterClassName);
		GUILayout.Label (class3.CharacterClassDescription);
	}*/
}
