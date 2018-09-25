using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Diagnostics;

public class AbilityUse : MonoBehaviour {

    public GameObject fireballPrefab;
    private FireBallAbility fba;
    private Stopwatch abilityCooldownTimer;
    private Button button;
    private Image fillImage;

    public void OnAbilityUse(GameObject btn)
    {
        //if ability is not on cooldown use it
        fillImage = btn.transform.GetChild(0).gameObject.GetComponent<Image>();
        button = btn.GetComponent<Button>();
        button.interactable = false;
        fillImage.fillAmount = 1;
        abilityCooldownTimer = new Stopwatch();
        abilityCooldownTimer.Start();

        GameObject go = Instantiate<GameObject>(fireballPrefab);
        go.transform.position = this.transform.position;
        fba = new FireBallAbility();
        fba.AbilityPrefab = go;
        fba.UseAbility(this.gameObject);

        StartCoroutine(SpinImage());
    }

    private IEnumerator SpinImage()
    {
        UnityEngine.Debug.Log(fba.AbilityCooldown);
        while(abilityCooldownTimer.IsRunning && abilityCooldownTimer.Elapsed.TotalSeconds < fba.AbilityCooldown)
        {
            UnityEngine.Debug.Log(fillImage.fillAmount);
            fillImage.fillAmount = ((float)abilityCooldownTimer.Elapsed.TotalSeconds / fba.AbilityCooldown);
            yield return null;
        }
        fillImage.fillAmount = 0;
        button.interactable = true;
        abilityCooldownTimer.Stop();
        abilityCooldownTimer.Reset();

        yield return null;
    }
}
