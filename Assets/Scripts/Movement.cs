using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float baseSpeed = 100.0f;
    [SerializeField] float boost = 0.2f;
    [SerializeField] float rotateSpeed = 5.0f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotate();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                ApplyThrust(baseSpeed * (boost + 1));
            }
            else
            {
                ApplyThrust(baseSpeed);
            }
        }
    }

    void ApplyThrust(float speed)
    {
        rb.AddRelativeForce(Vector3.up * speed * Time.deltaTime);
    }

    void ProcessRotate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyRotation(rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            ApplyRotation(-rotateSpeed);
        }
    }

    void ApplyRotation(float rotationSpeed)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
