using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITENCE AND POLYMORPHISM FOR ENEMIES
public class Toaster : Enemy
{

    // Start is called before the first frame update
    void Start()
    {
        MovementDir = Vector3.up;
        StartPos = transform.localPosition; // gets transform's position on the tile
        DamageDealt = 1;
        AlteredMovingSpeed = 0;
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

    private void OnTriggerEnter(Collider other) 
    {
        // set object as not active
        // make death FX
    }

    public override void DealDamage(Player player, int damageDealt)
    {
        base.DealDamage(player, damageDealt);
    }
}
