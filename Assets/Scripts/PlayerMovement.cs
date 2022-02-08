using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 100;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void MoveLeft()
    {
        print("Moving Left");
        rb.AddRelativeForce(Vector3.left * force);
    }

    public void MoveRight()
    {
        print("Moving Right");
        rb.AddRelativeForce(Vector3.right * force);

    }

    public void MoveForward()
    {
        print("Moving Forward");
        rb.AddRelativeForce(Vector3.forward * force);

    }

    public void MoveBackward()
    {
        print("Moving Back");
        rb.AddRelativeForce(Vector3.back * force);

    }

}
