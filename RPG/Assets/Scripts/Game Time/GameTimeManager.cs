using UnityEngine;
using System.Collections;

public class GameTimeManager : MonoBehaviour {

    public int gameDayLengthMins;

    private int gameDayLengthSecs;
    private int currentGameTime;
    private bool isRunning = true;
    private bool isDayOver = false;
    private bool isPaused = false;

    void OnEnable()
    {
        gameDayLengthSecs = gameDayLengthMins * 10;

        EventManager.EndOfDayMethods += ResetGameClock;

        EnableGameClock();
    }

    void OnDisable()
    {
        KillGameClock();
        EventManager.EndOfDayMethods -= ResetGameClock;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPaused)
                UnPauseGameClock();
            else
                PauseGameClock();
        }
    }

    //basic setup of a coroutine
    private IEnumerator GameClock()
    {
        while (isRunning)
        {
            if (isPaused)
                yield return null;
            else
            {
                currentGameTime++;
                //EventManager.RotateSun();
                if (currentGameTime >= gameDayLengthSecs)
                {
                    //day is over
                    isDayOver = true;
                    EventManager.ResetDay();
                }
                Debug.Log("Current Game Time: " + currentGameTime);
                yield return new WaitForSeconds(1f);    //add modifier here to manipulate game time speed
            }
        }
    }

    private void PauseGameClock()
    {
        Debug.LogWarning("Game Clock Paused");
        isPaused = true;
    }

    private void UnPauseGameClock()
    {
        Debug.LogWarning("Game Clock UnPaused");
        isPaused = false;
    }

    private void ResetGameClock()
    {
        Debug.Log("Event Fired, Day is over!");
        currentGameTime = 0;
        isDayOver = false;
    }

    private void KillGameClock()
    {
        Debug.LogWarning("Killed Game Clock");
        isRunning = false;
    }

    private void EnableGameClock()
    {
        isPaused = false;
        isRunning = true;
        StartCoroutine(GameClock());
    }
}
