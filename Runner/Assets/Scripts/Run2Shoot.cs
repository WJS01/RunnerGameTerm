using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run2Shoot : MonoBehaviour {

    public Camera mainCamera;
    public Camera gunCamera;
    public GameObject canv;
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Player")
        {
            return;
        }
        other.gameObject.SetActive(false);
        RunToShoot();
    }

    public void RunToShoot()
    {
        mainCamera.enabled = false;
        gunCamera.enabled = true;
        anim.SetTrigger("Zoom");
    }

    
}
