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

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Enemy"))
        {
            StartCoroutine(AffectPlayerStatus(other.gameObject.GetComponent<Enemy>()));
        }

        if (other.CompareTag("Powerup"))
        {
            StartCoroutine(AffectPlayerStatus(other.gameObject.GetComponent<Powerup>()));
        }
    }

    public IEnumerator AffectPlayerStatus(Powerup powerup)
    {
        MainManager.Instance.MovingSpeed *= powerup.SpeedMultiplier;
        yield return new WaitForSeconds(powerup.PowerupDuration);
        MainManager.Instance.MovingSpeed /= powerup.SpeedMultiplier;
    }

    public IEnumerator AffectPlayerStatus(Enemy enemy)
    {
        int originalMovingSpeed = MainManager.Instance.MovingSpeed;
        MainManager.Instance.MovingSpeed = enemy.AlteredMovingSpeed;
        yield return new WaitForSeconds(enemy.EffectDuration);
        MainManager.Instance.MovingSpeed = originalMovingSpeed;
    }
}
