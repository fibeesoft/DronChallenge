using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DronPlayer", menuName = "Create new dronePlayer")]
public class DronPlayer : ScriptableObject
{
    //speed 1 - 2
    // flexibility 1 - 2
    // hp 4 - 10
    // size 0.4 - 1.2
    // batterymax 0.6 - 2
    // boost 0.5 - 3
    public static float speedMax = 2f;
    public static float flexibilityMax = 2f;
    public static int hpMax = 10;
    public static float sizeMax = 1.2f;
    public static float batteryMax = 2f;
    public static float boostMax = 3f;

    public string droneName = "new drone";
    [Range(0.1f, 2f)] public float speed = 1f;
    [Range(0.1f, 2f)] public float flexibility = 1f;
    [Range(1, 10)] public int hp = 2;
    [Range(0.1f, 1.2f)] public float size = 1f;
    [Range(0.1f, 2f)] public float battery = 1f;
    [Range(0.1f, 3f)] public float boost = 1f;
}
