using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float MovementSpeed;
    public int DamageDealt;

    ///<summary>
    /// should affect the player character depending on the enemy attacking
    ///<summary>
    public abstract void AffectPlayerStatus();

    public virtual void MoveEnemy(Vector3 direction)
    {
        transform.Translate(direction * Mathf.Sin(MovementSpeed * Time.deltaTime));
    }

    public virtual void DealDamage(int DamageDealt)
    {
        // reduce enemy HP
    }
}
