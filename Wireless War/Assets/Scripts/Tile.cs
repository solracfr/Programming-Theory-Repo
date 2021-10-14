using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject[] obstacles; //Objects that contains different obstacle types which will be randomly activated
    private float m_prefabLength = 20f;
    public float prefabLength 
    {
        get
        {
            return m_prefabLength;
        }
    }

    void Start()
    {
        
    }

    public void ActivateRandomObstacle()
    {
        DeactivateAllObstacles();

        int randomNumber = (int)Random.Range(0, obstacles.Length);
        obstacles[randomNumber].SetActive(true);
    }

    public void DeactivateAllObstacles()
    {
        foreach (GameObject obstacle in obstacles)
        {
            obstacle.SetActive(false);
        }
    }
}
