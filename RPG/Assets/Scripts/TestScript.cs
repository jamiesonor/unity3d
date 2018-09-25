using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        EventManager.EndOfDayMethods += TestMethod;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void TestMethod()
    {
        Debug.LogWarning("Event Fired in the Test Script!");
    }
}
