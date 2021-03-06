﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControl2 : MonoBehaviour {


    public Vector3 speed;
    public Vector3 destVec;
    public bool destMode=true;
    public int trackPos=0;
    public bool wasPressed = false;
    public static float lastHitTime = -5;
    private Animator anim;


    // Use this for initialization
    void Start () {
        lastHitTime = -5;
        speed = new Vector3(0, 0, 10000f);
        anim = GetComponentInChildren<Animator>();

        anim.SetFloat("animSpeed", 0);
        //gameObject.transform.position =new Vector3( Main.tunnelParts[0].transform.position.x + 2.5f, gameObject.transform.position.y, gameObject.transform.position.z);
	}

    // Update is called once per frame
    void Update() {
        speed.x = 0;
        speed.y = 0;

        if (GetComponent<Rigidbody>().velocity.magnitude < 20)
            speed.z = 50f;
        else
            speed.z = 0;

        if (Main.outroStartTime > 0)
            speed.z=0;

        //if ((Input.GetKeyDown(KeyCode.LeftArrow)|| HugoInput.GetInputForPlayer(0).IsButtonPressed(EHugoButton.Key_4) && trackPos>=0) {
            if (HugoInput.GetInputForPlayer(0).ButttonJustPressed(EHugoButton.Key_4) && trackPos>=0) {
            speed.x = -1.666666f * 100f;
            destMode = true;
            trackPos -= 1;
            destVec.x = Main.tunnelParts[0].transform.position.x + 2.8f +trackPos* 1.6666666f;

            anim.SetFloat("animSpeed", 1);

        }

        //if (Input.GetKeyDown(KeyCode.RightArrow) && trackPos <= 0) {
          if (HugoInput.GetInputForPlayer(0).ButttonJustPressed(EHugoButton.Key_6) && trackPos <= 0) { 
            destMode = true;
            trackPos += 1;
            destVec.x = Main.tunnelParts[0].transform.position.x + 2.8f  + trackPos * 1.6666666f;

            anim.SetFloat("animSpeed", 1);

        }
        if (destMode && (destVec.x<gameObject.transform.position.x))
        {
            //speed.x = -1.666666f * 300f;

            speed.x = Mathf.Lerp(0, -1.666666f * 300f, Mathf.Abs( Mathf.Abs(destVec.x - gameObject.transform.position.x)));
        }


        if (destMode && destVec.x > gameObject.transform.position.x)
        {
            speed.x = Mathf.Lerp(0,1.666666f * 300f,Mathf.Abs( Mathf.Abs(destVec.x - gameObject.transform.position.x)));
        }

        if (destMode && Mathf.Abs(destVec.x - gameObject.transform.position.x)<0.6)
        {
            speed.x = destVec.x - gameObject.transform.position.x;
            speed.y = 0;
            float prevz = speed.z;
            speed.z = 0;
            gameObject.transform.Translate(speed, Space.World);
            speed.x = 0;
            speed.z = prevz;
            destMode = false;
            GetComponent<Rigidbody>().velocity = new Vector3(0, GetComponent<Rigidbody>().velocity.y, Mathf.Min(20,GetComponent<Rigidbody>().velocity.z));
        }

        //destVec.x = Main.tunnelParts[0].transform.position.x + 2.8f  + trackPos * 1.6666666f;
        if (Mathf.Abs(destVec.x - gameObject.transform.position.x) > 0.1)
        {
            destMode = true;
        }

        if (Time.time - lastHitTime < 2)
        {

            Renderer rndr = gameObject.GetComponentsInChildren<Renderer>()[1];

            Color c = Color.white;
            //c.a = 0.2f+Mathf.Round(0.5f * (1+Mathf.Sin((Time.time - lastHitTime)*20)))*0.8f;
            c.a = (Mathf.Round((Time.time - lastHitTime)*10))%2.0f;
            rndr.material.color = c;

        }
        else
        {
            Renderer rndr = gameObject.GetComponentsInChildren<Renderer>()[1];

            Color c = Color.white;
            c.a = 1;
            rndr.material.color = c;
        }

        if (Main.score >= 50)
        {
            //levelWinAS.Play();

            anim.SetInteger("IsWin", 1);
        }

        else if (Main.health <= 0)
        {
            anim.SetInteger("IsLost", 1);
        }
        if (Main.outroStartTime > 0 && Time.time > Main.outroStartTime)
        {
            if (Main.health <= 0) { 
                int scene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(scene, LoadSceneMode.Single);
            }
            else
                Application.LoadLevel("FinalScene");
        }
        //GetComponent<Rigidbody>().velocity = speed;
        GetComponent<Rigidbody>().AddForce(speed);
        /*if (Input.GetKeyDown(KeyCode.LeftArrow))
            speed.x = -100;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            speed.x = -100;*/
        //gameObject.transform.Translate(speed * Time.deltaTime, Space.World);
        //gameObject.transform.Translate(speed, Space.World);
    }
}
