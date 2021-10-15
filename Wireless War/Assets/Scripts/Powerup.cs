using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
    public int SpeedMultiplier;
    private float powerupDuration;
    public float PowerupDuration
    {
        get {return powerupDuration;}
        set
        {
            if (value < 0) Debug.LogError("Can't have a negative powerup duration!");
            else powerupDuration = value;
        }
    }
    //public abstract IEnumerator AffectPlayerStatus();
}
