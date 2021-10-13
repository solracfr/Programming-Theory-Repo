using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeatWidth = 10f;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position; // establish start position
        //repeatWidth = GetComponent<BoxCollider>().size.x / 4; // get the repeat point
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPosition.x - repeatWidth)
        {
            transform.position = startPosition;
        }
    }
}
