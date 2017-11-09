using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{

    public Rigidbody rb;
    public Animator anim;
    public ParticleSystem muzzle;
    public float runSpeed;
    public float crouchSpeed;
    public Collider standCol;
    public Collider crouchCol;
    public Collider proneCol;
    public bool isDead;

    private float moveSpeed;
    private bool isCrouch;
    public bool isProne;
    public int currentState;
    public Collider[] colState = new Collider[3];

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        moveSpeed = runSpeed;
        colState[0] = proneCol;
        colState[1] = crouchCol;
        colState[2] = standCol;
        currentState = 2;
        isDead = false;
    }

    void Update()
    {
        if (isDead)
        {
            return;
        }
        Shoot();
        Crouch();
        Prone();
        Forward();
        ColliderState();
    }



    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Shoot");
        }

    }

    void ShootStart()
    {
        moveSpeed = 0;
        muzzle.Play();
        GameControl.instance.isShooting = true;
    }

    void ShootStop()
    {
        muzzle.Stop();
        GameControl.instance.isShooting = false;
    }

    void StopRun()
    {
        GameControl.instance.isShooting = true;
    }

    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetBool("isCrouch", true);
            isCrouch = true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            anim.SetBool("isCrouch", false);
            isCrouch = false;
        }
    }

    void Prone()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetBool("isProne", true);
            isProne = true;
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            anim.SetBool("isProne", false);
            
        }
    }

    void AnimFalseProne()
    {
        isProne = false;
    }

    void Forward()
    {
        if (GameControl.instance.isShooting)
        {
            return;
        }

        if (isProne)
        {
            moveSpeed = 0;
            GameControl.instance.runnerState = 0;
        }

        else if (isCrouch)
        {
            moveSpeed = crouchSpeed;
            GameControl.instance.runnerState = 1;
        }

        else {
            moveSpeed = runSpeed;
            GameControl.instance.runnerState = 2;
        }

        rb.velocity = transform.forward * moveSpeed;
    }

    public void ColliderState()
    {
        if(currentState == GameControl.instance.runnerState)
        {
            return;
        }

        if (isProne)
        {
            colState[currentState].enabled = false;
            colState[0].enabled = true;
            currentState = 0;
        }
        else if (isCrouch)
        {
            colState[currentState].enabled = false;
            colState[1].enabled = true;
            currentState = 1;
        }
       
        else
        {
            colState[currentState].enabled = false;
            colState[2].enabled = true;
            currentState = 2;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Obstacle")
        {
            return;
        }
        GameControl.instance.Die();
    }

}
