using UnityEngine;
using System.Collections;

public class AbilityBehaviors {

    private BasicObjectInformation objectInfo;
    private BehaviorStartTimes startTime;

    public AbilityBehaviors(BasicObjectInformation basicInfo, BehaviorStartTimes sTime)
    {
        objectInfo = basicInfo;
        startTime = sTime;
    }

    public enum BehaviorStartTimes
    {
        Beginning,
        Middle,
        End
    }

    //we want a gameobject, our target
    public virtual void PerformBehavior(GameObject playerObject, GameObject objectHit)
    {
        Debug.LogWarning("NEED TO ADD BEHAVIOR");
    }

    public BasicObjectInformation AbilityBehaviorInfo
    {
        get { return objectInfo; }
    }

    public BehaviorStartTimes AbilityBehaviorStartTime
    {
        get { return startTime; }
    }
}
