﻿using UnityEngine;
using System.Collections;

public class OutOfBounds : MonoBehaviour {


    public float limitY;
    public float limitDist;
    public Vector3 speed;
    public Vector3 angSpeedV;
    public float angSpeedS;
    public float gravity;

    // Use this for initialization
    void Start () {
        speed = new Vector3(0, 0, -10);
	}
	
	// Update is called once per frame
	void Update () {
        //speed.y -= gravity * Time.deltaTime;
        gameObject.transform.Translate(speed * Time.deltaTime, Space.World);
        //gameObject.transform.Rotate(angSpeedV, angSpeedS);

        /*if (gameObject.transform.position.z < -15)
            //gameObject.SetActive(false);
        Destroy(gameObject);
        if (gameObject.transform.position.magnitude > 40)
            //gameObject.SetActive(false);
        Destroy(gameObject);*/
        
    }
}