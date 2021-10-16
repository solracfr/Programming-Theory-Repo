using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toast : Powerup
{
    //TODO: MOVE THIS FUNCTION OVER TO THE PLAYER OBJECT INSTEAD
    //THIS FUNCTION DIES AS SOON AS THE POWERUP (OR ENEMY PROBABLY)
    //DISAPPEARS FROM THE FRONT OF THE TILE LINE
    //(1) MOVE THIS FUNCTION TO THE PLAYER AND USE THIS FUNCTION ONLY TO CALL IT
    //(2) MOVE ALL INTERACTION WITH THIS SCRIPT TO THE PLAYER INSTEAD 
    public override IEnumerator AffectPlayerStatus(int speedMultiplier, float powerupDuration)
    {
        MainManager.Instance.MovingSpeed *= SpeedMultiplier;
        yield return new WaitForSeconds(PowerupDuration);
        MainManager.Instance.MovingSpeed /= SpeedMultiplier;
    }

    void OnTriggerEnter(Collider other) 
    {
        //StartCoroutine(AffectPlayerStatus());
        Debug.Log("Toast eaten!");
    }
}
