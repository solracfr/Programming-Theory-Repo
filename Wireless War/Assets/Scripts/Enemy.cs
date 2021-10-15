using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    // should  not be a negative number
    public float TravelAmplitude;
    public int AlteredMovingSpeed;
    public int EffectDuration;
    protected Vector3 MovementDir;
    protected Vector3 StartPos;

    [Range(0,1)] 
    public float MovementFactor;
    private float m_Period = 2f;
    public float Period
    {
        get {return m_Period;}
        set
        {
            if (value < 0.0f) Debug.LogError("Cannot have a negative period!");
            else m_Period = value;
        }
    }
    protected int m_DamageDealt;
    public int DamageDealt
    {
        get {return m_DamageDealt;}
        set
        {
            if (value < 0) Debug.LogError("Cannot deal negative damage!");
            else m_DamageDealt = value;
        }
    }

    public virtual void MoveEnemy(Vector3 direction)
    {
        float sinWave = Mathf.Sin(Time.time * Mathf.PI * 2 / m_Period);
        MovementFactor = (sinWave + 1f) / 2f;
        Vector3 offset = direction * MovementFactor * TravelAmplitude;

        transform.localPosition = StartPos + offset;
    }

    public virtual void DealDamage(Player player, int damageDealt)
    {
        player.ChangeHP(damageDealt);
    }
}
