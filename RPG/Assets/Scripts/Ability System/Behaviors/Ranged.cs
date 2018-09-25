using UnityEngine;
using System.Collections;

public class Ranged : AbilityBehaviors {

    private const string abName = "Ranged";
    private const string abDescription = "A ranged attack!";
    private const BehaviorStartTimes startTime = BehaviorStartTimes.Beginning;
    //private const Sprite icon = Resources.Load()

    private float minDistance;
    private float maxDistance;
    private bool isRandomOn;
    private float lifeDistance;

    public Ranged()
        : base(new BasicObjectInformation(abName, abDescription), startTime)
    {
        minDistance = 50;
        maxDistance = 80;
        isRandomOn = true;
    }

    public Ranged(float minDist, float maxDist, bool isRandom)
        : base(new BasicObjectInformation(abName, abDescription), startTime)
    {
        minDistance = minDist;
        maxDistance = maxDist;
        isRandomOn = isRandom;
    }

    //Using a job manager created by Prime31 to handle coroutines
    public override void PerformBehavior(GameObject playerObject, GameObject abilityPrefab)
    {
        lifeDistance = isRandomOn ? Random.Range(minDistance, maxDistance) : maxDistance;
        Debug.Log("DISTANCE: " + lifeDistance);
        Job.Make(CheckDistance(playerObject.transform.position, abilityPrefab), true);
        //StartCoroutine(CheckDistance(playerObject.transform.position));
    }

    private IEnumerator CheckDistance(Vector3 startPosition, GameObject abilityPrefab)
    {
        float tempDistance = Vector3.Distance(startPosition, abilityPrefab.transform.position);
        while (tempDistance < lifeDistance)
        {
            tempDistance = Vector3.Distance(startPosition, abilityPrefab.transform.position);

            yield return null;
        }

        //abilityPrefab.gameObject.SetActive(false);   //object pooling code if we want or destroy
        GameObject.Destroy(abilityPrefab);

        yield return null;
    }

    public float MinDistance
    {
        get { return minDistance; }
    }

    public float MaxDistance
    {
        get { return maxDistance; }
    }
}
