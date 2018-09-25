using UnityEngine;
using System.Collections;

public class Sun : MonoBehaviour {

    private float degreesInSeconds;

    void OnEnable()
    {
        GameTimeManager timeManager = GameObject.Find("GameTimeManager").GetComponent<GameTimeManager>();
        degreesInSeconds = 360f / (timeManager.gameDayLengthMins * 60f);

        //EventManager.SunRotationMethods += RotateSun;

        StartCoroutine(RotateSun());
    }
	
	// Update is called once per frame
	void Update () {

        //this.transform.Rotate(new Vector3(.001f,0,0));   //x,y,z

	}

    /*private void RotateSun()
    {
        this.transform.Rotate(new Vector3(degreesInSeconds, 0, 0));    //x,y,z
    }*/

    private IEnumerator RotateSun()
    {
        while(true)
        {
            this.transform.Rotate(new Vector3(degreesInSeconds * Time.deltaTime, 0, 0));
            yield return null;
        }
    }
}
