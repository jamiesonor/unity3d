using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ability {

    private BasicObjectInformation objectInfo;
    private List<AbilityBehaviors> behaviors;
    private bool requiresTarget;
    private bool canCastOnSelf;
    private float cooldown;   //secs
    private GameObject abilityPrefab;  //ability prefab! #new
    private float castTime; //secs
    private float cost;
    private AbilityType type;

    public enum AbilityType
    {
        Spell,
        Melee
    }

    public Ability(BasicObjectInformation aBasicInfo)
    {
        objectInfo = aBasicInfo;
        behaviors = new List<global::AbilityBehaviors>();
        cooldown = 1.5f;
        requiresTarget = false;
        canCastOnSelf = false;
    }

    public Ability(BasicObjectInformation aBasicInfo, List<AbilityBehaviors> aBehaviors)
    {
        objectInfo = aBasicInfo;
        behaviors = aBehaviors;
        cooldown = 0f;
        requiresTarget = false;
        canCastOnSelf = false;
    }

    public Ability(BasicObjectInformation aBasicInfo, List<AbilityBehaviors> aBehaviors, bool aRequireTarget, int aCooldown, GameObject abilityPb)
    {
        objectInfo = aBasicInfo;
        behaviors = new List<AbilityBehaviors>();
        behaviors = aBehaviors;
        cooldown = aCooldown;
        requiresTarget = aRequireTarget;
        canCastOnSelf = false;
        abilityPrefab = abilityPb;
    }

    public BasicObjectInformation AbilityInfo
    {
        get { return objectInfo; }
    }

    public float AbilityCooldown
    {
        get { return cooldown; }
        //set { cooldown = value; }
    }

    public List<AbilityBehaviors> AbilityBehaviors
    {
        get { return behaviors; }
    }

    public GameObject AbilityPrefab
    {
        set { abilityPrefab = value; }
    }

    //This is the method that will be called anytime we use an ability
    public virtual void UseAbility(GameObject player)
    {
        foreach (AbilityBehaviors b in AbilityBehaviors)
        {
            if (b.AbilityBehaviorStartTime == global::AbilityBehaviors.BehaviorStartTimes.Beginning)
            {
                b.PerformBehavior(player, abilityPrefab);
            }
        }
    }
}
