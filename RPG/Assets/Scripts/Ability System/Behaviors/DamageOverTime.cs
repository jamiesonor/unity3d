using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class DamageOverTime : AbilityBehaviors {

    private const string abName = "Damage Over Time";
    private const string abDescription = "A dot!";
    private const BehaviorStartTimes startTime = BehaviorStartTimes.Beginning;    //on impact
    //private const Sprite icon = Resources.Load()

    private float effectDuration;   //how long the effect lasts
    private Stopwatch durationTimer = new Stopwatch();
    private float baseEffectDamage;
    private float damageTickDuration;

    public DamageOverTime(float ed, float bd, float dtd)
        : base(new BasicObjectInformation(abName, abDescription), startTime)
    {
        effectDuration = ed;
        baseEffectDamage = bd;
        damageTickDuration = dtd;
    }

    public override void PerformBehavior(GameObject playerObject, GameObject objectHit)
    {
        //StartCoroutine(DOT());
    }

    private IEnumerator DOT()
    {
        durationTimer.Start();  //turns on timer

        while(durationTimer.Elapsed.TotalSeconds <= effectDuration)
        {
            //onDamage(list<targets>, baseDamage);
            yield return new WaitForSeconds(damageTickDuration);
        }

        durationTimer.Stop();
        durationTimer.Reset();

        yield return null;
    }
}
