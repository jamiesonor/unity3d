using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform cameraTarget;

    private float x = 0.0f;
    private float y = 0.0f;

	private int mouseXSpeedMod = 5;
	private int mouseYSpeedMod = 3;

	public float maxViewDistance = 25;	//how far the camera will zoom out
	public float minViewDistance = 1;	//how close the camera will zoom in

	public int zoomRate = 30;	//how fast the camera will zoom
	public int lerpRate = 10;

	private float distance = 3;	//starting distance away from player
	private float desiredDistance;	//used for calculations
	private float correctedDistance;	//used for calculations
	private float currentDistance;

	public float cameraTargetHeight = 1.5f;

	void Start () {
        Vector3 angles = transform.eulerAngles;
        x = angles.x;
        y = angles.y;

		currentDistance = distance;
		desiredDistance = distance;
		correctedDistance = distance;
	}


	//Updates AFTER update function, since our camera controls are not as important as our movement, we want our movement to occur first
	void LateUpdate () {
        if (Input.GetMouseButton (0)) {
			// 0 - left mouse button or 1 - right mouse button
			x += Input.GetAxis ("Mouse X") * mouseXSpeedMod;
			y -= Input.GetAxis ("Mouse Y") * mouseYSpeedMod;
		}
		else if (Input.GetAxis ("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)	//if either vertical or horizontal buttons are pressed, then the code below will execute
		{
			float targetRotationAngle = cameraTarget.eulerAngles.y;
			float cameraRotationAngle = transform.eulerAngles.y;
			x = Mathf.LerpAngle(cameraRotationAngle, targetRotationAngle, lerpRate * Time.deltaTime);
		}

		y = ClampAngle (y, -50, 80);

		Quaternion rotation = Quaternion.Euler (y, x, 0);

		desiredDistance -= Input.GetAxis ("Mouse ScrollWheel") * Time.deltaTime * zoomRate * Mathf.Abs (desiredDistance);	//calculates the distance the player wants their camera
		desiredDistance = Mathf.Clamp (desiredDistance, minViewDistance, maxViewDistance);	//
		correctedDistance = desiredDistance;

		Vector3 position = cameraTarget.position - (rotation * Vector3.forward * desiredDistance); //(x,y,z) * (0,1,0) * (angle in degrees)

		RaycastHit collisionHit;
		Vector3 cameraTargetPosition = new Vector3 (cameraTarget.position.x, cameraTarget.position.y + cameraTargetHeight, cameraTarget.position.z);

		bool isCorrected = false;
		if (Physics.Linecast (cameraTargetPosition, position, out collisionHit))
		{
			position = collisionHit.point;
			correctedDistance = Vector3.Distance(cameraTargetPosition, position);
			isCorrected = true;
		}

		//?:
		//condition ? first_expression : second_expression;
		currentDistance = !isCorrected || correctedDistance > currentDistance ? Mathf.Lerp (currentDistance, correctedDistance, Time.deltaTime * zoomRate) : correctedDistance;

		position = cameraTarget.position - (rotation * Vector3.forward * currentDistance + new Vector3(0, -cameraTargetHeight, 0));

		transform.rotation = rotation;	//when you call transform within the script, the script looks for the transform the script is attached to
		transform.position = position;
	}

	private static float ClampAngle (float angle, float min, float max)
	{
		if (angle < -360)
		{
			angle += 360;
		}
		if (angle > 360)
		{
			angle -= 360;
		}
		return Mathf.Clamp(angle, min, max);
	}
}
