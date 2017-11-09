using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    public static GameControl instance;
    public int runnerState;
    public bool isShooting;
    public GameObject player;
    public float lookSensivity;
    private Runner runner;

	void Awake () {
        instance = this;
	}

    private void Start()
    {
        isShooting = false;
        runner = player.GetComponent<Runner>();
    }

    public void Die()
    {
        Debug.Log("asd");
        runner.anim.SetTrigger("Die");
        runner.colState[runner.currentState].enabled = false;
        runner.colState[0].enabled = true;
        runner.isDead = true;
        
    }
	

}
