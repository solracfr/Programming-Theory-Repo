using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    Vector3 spawnPosition;
    float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -spawnPosition.x)
        {
            transform.position = spawnPosition;
        }
    }
}
