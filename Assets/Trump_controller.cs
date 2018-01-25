using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Trump_controller : MonoBehaviour
{
    private Rigidbody rb;
    private Animation anim;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody> ();
        anim = GetComponent<Animation> ();
    }

    // Update is called once per frame
    void Update()
    {
        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        float y = CrossPlatformInputManager.GetAxis("Vertical");
        transform.position += new Vector3(0, 0, y / 10);
        transform.position += new Vector3(x / 10, 0, 0);
        Vector3 movement = new Vector3(x, 0.0f, y);
        rb.velocity = movement * 1f;
        if (x != 0 && y != 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x, y) * Mathf.Rad2Deg, transform.eulerAngles.z);
            }

        if (x != 0 || y != 0)
        {
            anim.Play("walk");
        } else
        {
            anim.Play("idle");
        }

        }
}