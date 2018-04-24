using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PlayerManager : MonoBehaviour
{

    public float BoostPower = 1.0f;
    public float RotationSpeed = 1.0f;
    public float GravityPower = 1.0f;
    public float maxGravDist = 4.0f;
    public float maxGravity = 35.0f;
    public Rigidbody2D rb;

    GameObject[] planets;

    void Start()
    {
        planets = GameObject.FindGameObjectsWithTag("Planet");
    }

    void FixedUpdate()
    {
        foreach (GameObject planet in planets)
        {
            float dist = Vector3.Distance(planet.transform.position, transform.position);
            if (dist <= maxGravDist)
            {
                Vector3 v = planet.transform.position - transform.position;
                rb.AddForce(v.normalized * (GravityPower - dist / maxGravDist) * maxGravity);
            }
        }

        if (Input.GetButton("Jump"))
        {
            rb.AddForce(transform.right * BoostPower * Time.deltaTime);
        }

        if (Input.GetButton("Horizontal"))
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                rb.MoveRotation(rb.rotation + RotationSpeed * Time.deltaTime);
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                rb.MoveRotation(rb.rotation + -RotationSpeed * Time.deltaTime);
            }
        }
    }
}