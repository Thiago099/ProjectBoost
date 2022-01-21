using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField]
    Vector3 movingVector;
    [SerializeField, Range(0, 1)]
    float movingFactor;
    [SerializeField]
    float period = 2f;
    void Start()
    {
        startingPosition = transform.position;
    }
    void Update()
    {
        if(period < Mathf.Epsilon) return;

        const float tau = Mathf.PI * 2;
        float cycles = Time.time / period;
        float rawSinWave = Mathf.Sin(cycles * tau);
        movingFactor = (rawSinWave + 1f) / 2f;
        Vector3 offset = movingVector * movingFactor;
        transform.position = startingPosition + offset;
    }
}
