using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject canv;
    public GameObject awp;

    void Update () {
        View();
	}

    public void View()
    {
        float yRot = Input.GetAxisRaw("Mouse X");
        float xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 rotation = new Vector3(-xRot, yRot, 0) * GameControl.instance.lookSensivity;
        transform.Rotate(rotation * Time.deltaTime);
    }

    public void ScopeOn()
    {
        canv.SetActive(true);
        awp.SetActive(false);
    }
}

