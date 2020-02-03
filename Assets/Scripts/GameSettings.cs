using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSettings 
{
    public static bool IsColliderOn { get { return isColliderOn; } set { isColliderOn = value; } }
    static bool isColliderOn = true;
    public static Vector3 SpawnPosition = new Vector3(0f, 0.2f, 0f);

    public static float lowestTime;
    public static float LowestTime { get { return lowestTime; } set { lowestTime = value; } }
    public static float lastTime;
    public static float LastTime { get { return lastTime; } set { lastTime = value; } }

    public static int DroneChoosen { get; set; }
    public static int LevelChoosen { get; set; }
    public static int LevelsQuantity { get { return 1; } }

    public static bool isBatteryDraining { get; set; }
    public static bool isUndestractable { get; set; }

}
