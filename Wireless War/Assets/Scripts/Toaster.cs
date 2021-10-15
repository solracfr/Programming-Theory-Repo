using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITENCE AND POLYMORPHISM FOR ENEMIES
public class Toaster : Enemy
{
    // the speed at which the track will move once we hit this enemy
    private int alteredMovingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        MovementDir = Vector3.up;
        StartPos = transform.localPosition; // gets transform's position on the tile
        DamageDealt = 1;
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
        if (other.CompareTag("Player"))
        {
            DealDamage(other.gameObject.GetComponent<Player>(), DamageDealt);
        } 
    }

    public override void DealDamage(Player player, int damageDealt)
    {
        base.DealDamage(player, damageDealt);
    }
}
