using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

    public delegate void EndOfDay();
    public static event EndOfDay EndOfDayMethods;

    public delegate void Sun();
    public static event Sun SunRotationMethods;

    public static void ResetDay()
    {
        EndOfDayMethods();
    }

    public static void RotateSun()
    {
        SunRotationMethods();
    }
}
