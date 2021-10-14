using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int PlayerHP {get; private set;}
    public bool isHit {get; private set;}
    public bool isInvincible {get; private set;}
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

    void OnTriggerEnter(Collider other) 
    {
        // if powerup -> make cool shit happen
        // if enemy -> reduce HP; set hit and Invincibility frames
    }
}
