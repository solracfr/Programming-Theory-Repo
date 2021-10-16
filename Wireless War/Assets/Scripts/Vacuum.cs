using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum : Enemy
{
    // the speed at which the track will move once we hit this enemy
    private int alteredMovingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        MovementDir = Vector3.right;
        StartPos = transform.localPosition; // gets transform's position on the tile
        DamageDealt = 2;
        AlteredMovingSpeed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy(MovementDir);
    }

    public override void MoveEnemy(Vector3 direction)
    {
        base.MoveEnemy(direction);
    }

    void OnTriggerEnter(Collider other) 
    {
        // Set object as not active
        // Instantiate FX
    }
}
