using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPDash : MonoBehaviour
{


    [Header("Dash")]
    public KeyCode dashKey = KeyCode.E;

    public float dashForce;
    public float dashUpwardForce;
    public float dashTime;

    public Transform orientation;
    public Transform playercam;

    [Header("Cooldown")]
    public float dashCd;
    private float dashCdTimer;


    [Header("Settings")]
    public bool useCameraforward = true;
    public bool allowAlldirections = true;
    public bool disablegravity = false;
    public bool resetVelocity = true;
    public PlayerCam cam;
    public float dashFOV;


    private Rigidbody rb;

    private PlayerMovement pm;
    // Start is called before the first frame update
    void Start()
    {
        pm = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(dashKey))
        {
            Dash();
        }

        if(dashCdTimer > 0)
        {
            dashCdTimer -= Time.deltaTime;
        }
    }

    private Vector3 delayedForce;
    private void Dash()
    {
        if(dashCdTimer > 0)
        {
            return;
        }
        else
        {
            dashCdTimer = dashCd;
        }
        pm.Dashing = true;
        Transform forwardD;

        if (useCameraforward)
        {
            forwardD = playercam;
        }
        else
        {
            forwardD = orientation;
        }

        Vector3 vec = GetDir(forwardD);
        Vector3 forcetoapply = vec * dashForce + orientation.up * dashUpwardForce;

        if(disablegravity)
        {
            rb.useGravity = false;
        }

        delayedForce = forcetoapply;
        Invoke(nameof(delaydash), 0.025f);

        Invoke(nameof(ResetDash), dashTime);

    }

    private void delaydash()
    {
        if(resetVelocity)
        {
            rb.velocity = Vector3.zero;
        }
        rb.AddForce(delayedForce, ForceMode.Impulse);
    }
    private void ResetDash()
    {
        pm.Dashing = false;
        if (disablegravity)
        {
            rb.useGravity = true;
        }
    }

    private Vector3 GetDir(Transform forwardD)
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3();

        if (allowAlldirections)
        {
            dir = forwardD.forward * v + forwardD.right * h;
        }
        else
        {
            dir = forwardD.forward;
        }

        if(v == 0 && h == 0)
        {
            dir = forwardD.forward;
        }

        return dir.normalized;
    }
}


