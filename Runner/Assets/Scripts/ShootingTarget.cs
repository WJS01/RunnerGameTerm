using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTarget : MonoBehaviour {
    public int TargetState;
    public Animator anim;
    public ParticleSystem particle;
    private bool canShoot;
    private bool targetDown;

    private void Start()
    {
        canShoot = false;
        targetDown = false;
    }


    private void Update()
    {
        if (!canShoot)
        {
            return;
        }
        if (GameControl.instance.isShooting && GameControl.instance.runnerState == TargetState)
        {
            anim.SetTrigger("TargetDown");
            targetDown = true;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("asd");
        if(other.tag != "Player")
        {
            return;
        }
        canShoot = true;

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("asd");
        if (other.tag != "Player")
        {
            return;
        }
        if(targetDown == false)
        {
            anim.SetTrigger("TargetDown");
            GameControl.instance.Die();
        }

    }

    public void TargetDestroy()
    {
        Destroy(gameObject);
    }

    public void StartParticle()
    {
        particle.Play();
    }


}
