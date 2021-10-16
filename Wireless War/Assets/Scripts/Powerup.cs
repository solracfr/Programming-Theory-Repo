using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public int SpeedMultiplier;
    public float powerupDuration; // change to private
    public bool GivePlayerShield;
    public float PowerupDuration
    {
        get {return powerupDuration;}
        set
        {
            if (value < 0) Debug.LogError("Can't have a negative powerup duration!");
            else powerupDuration = value;
        }
    }
    public virtual IEnumerator AffectPlayerStatus(int speedMultiplier, float powerupDuration, Player player)
    {
        player.isInvincible = GivePlayerShield;
        //int originalMovingSpeed = MainManager.Instance.MovingSpeed;

        MainManager.Instance.MovingSpeed *= SpeedMultiplier;
        yield return new WaitForSeconds(PowerupDuration);
        MainManager.Instance.MovingSpeed /= SpeedMultiplier;
    }
    public virtual IEnumerator AffectPlayerStatus(int speedMultiplier, float powerupDuration)
    {
        //int originalMovingSpeed = MainManager.Instance.MovingSpeed;

        MainManager.Instance.MovingSpeed *= SpeedMultiplier;
        yield return new WaitForSeconds(PowerupDuration);
        MainManager.Instance.MovingSpeed /= SpeedMultiplier;
    }
}
