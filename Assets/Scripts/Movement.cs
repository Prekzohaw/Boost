using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float upThrust = 1f;
    [SerializeField] float rotationThrust = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            UpwardThrust();
        }
        if (Input.GetKey(KeyCode.A))
        {
            RotatingThrust(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotatingThrust(-rotationThrust);
        }
    }

    void UpwardThrust()
    {
            rb.AddRelativeForce(Vector3.up * Time.deltaTime * upThrust);
    }

    void RotatingThrust(float rotationPower)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationPower);
        rb.freezeRotation = false;
    }
}
