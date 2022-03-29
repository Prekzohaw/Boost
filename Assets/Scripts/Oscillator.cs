using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float frequency = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time * frequency; //grows over time

        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(tau*cycles);

        movementFactor = Mathf.Abs(rawSinWave);
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
