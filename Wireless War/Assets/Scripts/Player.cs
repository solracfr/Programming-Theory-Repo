using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int HP {get; private set;}
    public bool isHit {get; private set;}
    public bool isInvincible {get; set;}
    private float m_Speed = 2f;
    public float Speed // can be accessed elsewhere, like in the enemy script for example
    {
        get {return m_Speed;}
        set 
        {
            if (value < 0.0f)
            {
                Debug.LogError("Cannot set value to a negative number!");
            }
            else
            {
                m_Speed = value;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        HP = 3;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
    }

    void ProcessMovement()
    {
        Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.Translate(moveDir * m_Speed * Time.deltaTime, Space.World);
    }

    // amtToChange should accept only positive numbers
    public void ChangeHP(int amtToChange)
    {
        HP -= amtToChange;
    }

    public void ResetHP()
    {
        HP = 0;
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Enemy"))
        {
            if (isInvincible)
            {
                isInvincible = false;
            }
            else
            {   // get the enemy reference
                Enemy enemy = other.gameObject.GetComponent<Enemy>();

                // call functions for enemy effects;
                enemy.DealDamage(this, enemy.DamageDealt);
                StartCoroutine(enemy.AffectStageSpeed());
            }
            
            
        }

        if (other.CompareTag("Powerup"))
        {
            // get the powerup reference
            Powerup powerup = other.gameObject.GetComponent<Powerup>();
            //powerup reference may get deactivated before the duration is over...
            int speedMultiplier = powerup.SpeedMultiplier;
            float duration = powerup.PowerupDuration;
            bool givePlayerShield = powerup.GivePlayerShield;

            if (givePlayerShield)
            {
                StartCoroutine(powerup.AffectPlayerStatus(speedMultiplier, duration, this));
            }
            else 
            {
                StartCoroutine(powerup.AffectPlayerStatus(speedMultiplier, duration));
            }  
        }
    }

    public IEnumerator AffectPlayerStatus(Enemy enemy)
    {
        //enemy reference may get deactivated before the duration is over...
        int originalMovingSpeed = MainManager.Instance.MovingSpeed;
        float duration = enemy.EffectDuration;

        MainManager.Instance.MovingSpeed = enemy.AlteredMovingSpeed;
        yield return new WaitForSeconds(duration);
        MainManager.Instance.MovingSpeed = originalMovingSpeed;
    }
}
