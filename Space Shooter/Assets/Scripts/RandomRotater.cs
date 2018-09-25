using UnityEngine;
using System.Collections;

public class RandomRotater : MonoBehaviour {

	public float tumble;

	void Start ()
	{
		GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
	}

}
