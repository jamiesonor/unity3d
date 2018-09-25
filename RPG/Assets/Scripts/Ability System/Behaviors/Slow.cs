using UnityEngine;
using System.Collections;

public class Slow : AbilityBehaviors {

    private const string abName = "Slow";
    private const string abDescription = "Slows object's moving speed!";
    private const BehaviorStartTimes startTime = BehaviorStartTimes.End;    //on impact
    //private const Sprite icon = Resources.Load()

    private float effectDuration;   //how long the effect lasts
    private float slowPercent;

    public Slow(float ed, float sp)
        : base(new BasicObjectInformation(abName, abDescription), startTime)
    {
        effectDuration = ed;
        slowPercent = sp;
    }

    public override void PerformBehavior(GameObject playerObject, GameObject objectHit)
    {
        //StartCoroutine(SlowMovement(objectHit));
    }

    private IEnumerator SlowMovement(GameObject objectHit)
    {
        //if(objectHit.GetComponent<"Movement">() != null)
        //get movement var
        //apply percentage slow to movement var

        yield return new WaitForSeconds(effectDuration);

        //reset object's movement speed

        yield return null;
    }
}
