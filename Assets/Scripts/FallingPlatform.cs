using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float yellowFallDelay = 1f;
    public float orangeFallDelay = 1f;
    public float redFallDelay = 1f;
    public GameObject player;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == player)
        {
            StartCoroutine(Fall());
        }
    }

    // The platform is initially green, then turns more red (emissve color) as it gets closer to falling
    IEnumerator Fall()
    {
        /* yield return new WaitForSeconds(yellowFallDelay);
        GetComponent<Renderer>().material.color = Color.yellow;
        yield return new WaitForSeconds(orangeFallDelay);
        GetComponent<Renderer>().material.color = new Color(1.0f, 0.64f, 0.0f);
        yield return new WaitForSeconds(redFallDelay);
        GetComponent<Renderer>().material.color = Color.red;
        rb.isKinematic = false;
        yield return 0; */

        yield return new WaitForSeconds(yellowFallDelay);
        GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.yellow);
        yield return new WaitForSeconds(orangeFallDelay);
        GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(1.0f, 0.64f, 0.0f));
        yield return new WaitForSeconds(redFallDelay);
        GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
        rb.isKinematic = false;
        yield return 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // If the platform falls below the map, destroy it
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
