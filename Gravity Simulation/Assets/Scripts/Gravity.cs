using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Gravity : MonoBehaviour
{
    // Spacetime list
    private List<ObjInSpace> objPropList = new List<ObjInSpace>();

    //GameObject lists
    public List<GameObject> starList = new List<GameObject>();
    public List<GameObject> largePlanetList = new List<GameObject>();
    public List<GameObject> smallPlanetList = new List<GameObject>();
    public List<GameObject> moonList = new List<GameObject>();

    // Prefabs
    public GameObject starPrefab1;
    public GameObject starPrefab2;
    public GameObject largePlanetPrefab1;
    public GameObject largePlanetPrefab2;
    public GameObject largePlanetPrefab3;
    public GameObject largePlanetPrefab4;
    public GameObject largePlanetPrefab5;
    public GameObject largePlanetPrefab6;
    public GameObject smallPlanetPrefab1;
    public GameObject smallPlanetPrefab2;
    public GameObject smallPlanetPrefab3;
    public GameObject smallPlanetPrefab4;
    public GameObject smallPlanetPrefab5;
    public GameObject smallPlanetPrefab6;
    public GameObject moonPrefab1;

    // Toggle buttons
    public Toggle starToggle;
    public Toggle largePlanetToggle;
    public Toggle smallPlanetToggle;
    public Toggle moonToggle;

    // Distance between two objects
    private float distance;

    // Simulation settings
    public float massMultiplier = 10;
    public float G = 6.67408f;

    // Mouse positions used to calculate initial velocity
    public Vector3 mouseDownPosition;
    public Vector3 mouseUpPosition;
    public Vector3 initialForce;

    public ObjInSpace selectedObject;

    // Use this for initialization
    void Start()
    {
        // Add prefabs to GameObject lists
        starList.Add(starPrefab1);
        starList.Add(starPrefab2);

        largePlanetList.Add(largePlanetPrefab1);
        largePlanetList.Add(largePlanetPrefab2);
        largePlanetList.Add(largePlanetPrefab3);
        largePlanetList.Add(largePlanetPrefab4);
        largePlanetList.Add(largePlanetPrefab5);
        largePlanetList.Add(largePlanetPrefab6);

        smallPlanetList.Add(smallPlanetPrefab1);
        smallPlanetList.Add(smallPlanetPrefab2);
        smallPlanetList.Add(smallPlanetPrefab3);
        smallPlanetList.Add(smallPlanetPrefab4);
        smallPlanetList.Add(smallPlanetPrefab5);
        smallPlanetList.Add(smallPlanetPrefab6);

        moonList.Add(moonPrefab1);
    }

    // Update is called once per frame
    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            // Create object at mouse position on click
            if (Input.GetButtonDown("Fire2"))
            {
                mouseDownPosition = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
                instantiateObjectType();
            }

            // Apply force to created object after releasing mouse drag
            if (Input.GetButtonUp("Fire2"))
            {
                mouseUpPosition = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
                initialForce = calculateInitialForce(mouseDownPosition, mouseUpPosition);
                setVelocity(selectedObject, initialForce);
            }
        }
    }

    // Calculates physics at every fixed timestep (default = 0.02 s) - Longer timestep is a performance increase but gives less accurate results
    void FixedUpdate()
    {
        List<ObjInSpace> objsToDelete = new List<ObjInSpace>();

        if (objPropList.Count > 1)
        {
            foreach (ObjInSpace objInSpace in objPropList)
            {
                // Loops through all objects and calculates the gravitational forces
                for (int a = objPropList.Count - 1; a >= 0; a--)
                {
                    GameObject objectA = objPropList[a].gameObject;

                    // Calculate forces applied to objects
                    int b;
                    for (b = objPropList.Count - 1; b >= 0; b--)
                    {
                        if (b != a)
                        {
                            GameObject objectB = objPropList[b].gameObject;

                            float xPosA = objectA.transform.position.x;
                            float xPosB = objectB.transform.position.x;
                            float yPosA = objectA.transform.position.y;
                            float yPosB = objectB.transform.position.y;
                            float zPosA = objectA.transform.position.z;
                            float zPosB = objectB.transform.position.z;

                            // getObjectDistance
                            distance = getObjectDistance(xPosA, xPosB, yPosA, yPosB, zPosA, zPosB);

                            if (distance > 0)
                            {
                                float massA = objectA.gameObject.GetComponent<Rigidbody>().mass;
                                float massB = objectB.gameObject.GetComponent<Rigidbody>().mass;

                                // Newton's constant G - 6.67408 × 10-11 m3 kg-1 s-2    -  can be changed to increase the forces and speed objects up
                                // force in each direction
                                float Fgx = ((G * massA * massB) / Mathf.Pow(distance, 3)) * Mathf.Sqrt(Mathf.Pow(xPosA - xPosB, 2));
                                float Fgy = ((G * massA * massB) / Mathf.Pow(distance, 3)) * Mathf.Sqrt(Mathf.Pow(yPosA - yPosB, 2));
                                float Fgz = ((G * massA * massB) / Mathf.Pow(distance, 3)) * Mathf.Sqrt(Mathf.Pow(zPosA - zPosB, 2));

                                // Newton's Third Law
                                // check if we need to move in the neg or pos directon
                                if (xPosB < xPosA)
                                {
                                    Fgx = Fgx * -1;
                                }
                                if (yPosB < yPosA)
                                {
                                    Fgy = Fgy * -1;
                                }
                                if (zPosB < zPosA)
                                {
                                    Fgz = Fgz * -1;
                                }

                                // Applies force to each object
                                objectA.GetComponent<Rigidbody>().AddForce(Fgx, Fgy, Fgz);


                            }
                            if (distance < objectA.gameObject.GetComponent<SphereCollider>().radius + objectB.gameObject.GetComponent<SphereCollider>().radius)
                            {
                                // Lambda expression to check if objectA or objectB have been destroyed
                                if (!objsToDelete.Exists(x => x == objPropList[a]) && !objsToDelete.Exists(x => x == objPropList[b]))
                                {
                                    objsToDelete = JoinCollidingBodies(objPropList[a], objPropList[b]);
                                }
                            }
                        }
                    }
                }
            }
        }


        // delete 
        foreach (ObjInSpace objInSpace in objsToDelete)
        {
            objPropList.Remove(objInSpace);
            Destroy(objInSpace.gameObject);
        }
    }

    // Returns distance between two objects
    private float getObjectDistance(float xPosA, float xPosB, float yPosA, float yPosB, float zPosA, float zPosB)
    {
        distance = Mathf.Sqrt(
            Mathf.Pow(xPosA - xPosB, 2) +
            Mathf.Pow(yPosA - yPosB, 2) +
            Mathf.Pow(zPosA - zPosB, 2)
            );

        return distance;
    }

    // Instantiates different type of object based on toggles
    public void instantiateObjectType()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100.0f;
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);

        GameObject objectCreated = null;

        if (starToggle.isOn)
        {
            int starIndex = Random.Range(0, starList.Count);
            objectCreated = Instantiate(starList[starIndex], objectPos, Quaternion.identity);
        }
        else if (largePlanetToggle.isOn)
        {
            int largePlanetIndex = Random.Range(0, largePlanetList.Count);
            objectCreated = Instantiate(largePlanetList[largePlanetIndex], objectPos, Quaternion.identity);
        }
        else if (smallPlanetToggle.isOn)
        {
            int smallPlanetIndex = Random.Range(0, largePlanetList.Count);
            objectCreated = Instantiate(smallPlanetList[smallPlanetIndex], objectPos, Quaternion.identity);
        }
        else if (moonToggle.isOn)
        {
            int moonIndex = Random.Range(0, moonList.Count);
            objectCreated = Instantiate(moonList[moonIndex], objectPos, Quaternion.identity);
        }
        if (objectCreated != null)
        {
            ObjInSpace objInSpace = new ObjInSpace();
            objInSpace.gameObject = objectCreated;
            objPropList.Add(objInSpace);
            selectedObject = objInSpace;
        }
    }

    // Calculates initial force applied from length of mouse drag
    private Vector3 calculateInitialForce(Vector3 mousePreviousPosition, Vector3 mouseCurrentPosition)
    {
        Vector3 calculatedForce = (mousePreviousPosition - mouseCurrentPosition) / 10;

        return calculatedForce;
    }

    // Sets velocity of gameObject
    private void setVelocity(ObjInSpace objInSpace, Vector3 newVelocity)
    {

        objInSpace.gameObject.GetComponent<Rigidbody>().velocity = newVelocity;

    }

    // Takes two objects, joins them if they're within each other's radius
    public List<ObjInSpace> JoinCollidingBodies(ObjInSpace objectAInSpace, ObjInSpace objectBInSpace)
    {
        GameObject objectA = objectAInSpace.gameObject;
        GameObject objectB = objectBInSpace.gameObject;

        List<ObjInSpace> objsToDelete = new List<ObjInSpace>();

        float objectAMass = objectA.gameObject.GetComponent<Rigidbody>().mass;
        float objectBMass = objectB.GetComponent<Rigidbody>().mass;

        Vector3 objectAVelocity = objectA.GetComponent<Rigidbody>().velocity;
        Vector3 objectBVelocity = objectB.GetComponent<Rigidbody>().velocity;

        // New object mass
        float newMass = (objectAMass + objectBMass);

        // New object velocity
        Vector3 newVelocity = ((objectAVelocity * objectAMass) / newMass) + ((objectBVelocity * objectBMass) / newMass);

        // Check to see which object has greater mass and scales object based on its new mass
        if (objectAMass >= objectBMass)
        {
            objsToDelete.Add(objectBInSpace);
            objectA.GetComponent<Rigidbody>().mass = newMass;
            objectA.GetComponent<Rigidbody>().velocity = newVelocity;
            objectA.transform.localScale += new Vector3((newMass / objectAMass) - 1, (newMass / objectAMass) - 1, (newMass / objectAMass) - 1);
        }
        else
        {
            objsToDelete.Add(objectAInSpace);
            objectB.GetComponent<Rigidbody>().mass = newMass;
            objectB.GetComponent<Rigidbody>().velocity = newVelocity;
            objectB.transform.localScale += new Vector3((newMass / objectBMass) - 1, (newMass / objectBMass) - 1, (newMass / objectBMass) - 1);
        }

        // Returns list of objects marked for deletion
        return objsToDelete;
    }
}


public class ObjInSpace
{
    public GameObject gameObject { get; set; }
}
