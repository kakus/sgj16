﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Main : MonoBehaviour {


    public GameObject obstacleGO;
    public GameObject medalGO;
    public GameObject explosionGO;
    public GameObject tunnel1GO;
    public GameObject tunnel2GO;

    public GameObject obstacleStartPos;
    public Transform startPos;
    public static Vector3 refStartPos;
    public Transform currentPosT;
    public static Vector3 currentPosV;
    public static Vector3 speed;
    public static int tunnelNum;
    public static int score = 0;
    public static float lastObPosZ=0;
    public static float lastMedalPosZ=0;
    public static float lastMedalPosX=0;
    public static float lastMedalSerieNum=5;
    public static float lastObPosX=0;
    public static float lastTimeCreated;
    public static float tunnelSpeed=40f;
    public GameObject[] predefTunnelParts;

    public static List<GameObject> createdObstacles;
    public static List<GameObject> tunnelParts;
    public static List<GameObject> explosionParts;
    public static List<GameObject> createdMedals;


    // Use this for initialization
    void Start () {
        tunnelNum = 0;
        createdObstacles = new List<GameObject>();
        createdMedals = new List<GameObject>();
        explosionParts = new List<GameObject>();
        tunnelParts = new List<GameObject>();
        refStartPos = new Vector3(startPos.position.x, startPos.position.y, startPos.position.z);
        speed = new Vector3(0,0,-Main.tunnelSpeed);
        tunnelParts.Add(predefTunnelParts[0]);
        tunnelParts.Add(predefTunnelParts[1]);
        tunnelParts.Add(predefTunnelParts[2]);
        tunnelParts.Add(predefTunnelParts[3]);
        lastTimeCreated = Time.time;


        /*currentPos.x = refStartPos.x;
        currentPos.y = refStartPos.y;
        currentPos.z = refStartPos.z;*/
        currentPosV.x= currentPosT.position.x;
        currentPosV.y= currentPosT.position.y;
        currentPosV.z= currentPosT.position.z;

        refStartPos.x = currentPosT.position.x;
        refStartPos.y = currentPosT.position.y;
        refStartPos.z = currentPosT.position.z;

    }

    // Update is called once per frame
    void Update() {
        if ((15.3f * 3f + refStartPos.z + Mathf.Round((currentPosV.z - refStartPos.z) / 1.66666f) * 1.66666f-lastObPosZ>1.66666*2) && 
            (Random.Range(0,100) < 15/Mathf.Max(1, Main.createdObstacles.Count) ||Main.createdObstacles.Count<2)) {
            //GameObject lgo = Instantiate(obstacleGO, obstacleStartPos.transform.position, Quaternion.identity) as GameObject;

            //int posID;
            //posID = (int)Mathf.Round(Random.Range(0, 4));
            lastObPosZ = 15.3f * 3f + refStartPos.z + Mathf.Round((currentPosV.z - refStartPos.z) / 1.66666f) * 1.66666f;
            Vector3 pos = new Vector3(Mathf.Round(Random.Range(0, 3)), 0.853333f, lastObPosZ);
            if (pos.x == lastObPosX)
                pos.x = Mathf.Round(Random.Range(0, 3));
            lastObPosX = pos.x;
            /*if (posID == 0)
            {
                pos.x = 1;
            }
            if (posID == 1)
            {
                pos.x = 5;
            }
            if (posID == 2)
            {
                pos.y = 1;
            }
            if (posID == 3)
            {
                pos.y = 5;
            }*/
            pos.y = 0.953333f;
            pos.x = 0.613333f+Mathf.Round(pos.x)*1.66666f;
            GameObject lgo = Instantiate(obstacleGO, pos, Quaternion.identity) as GameObject;
            createdObstacles.Add(lgo);
            //lgo.GetComponent<Rigidbody>().velocity = new Vector3(-Main.speed.x, -Main.speed.y, -Main.speed.z);
        }
        else if((15.3f * 3f + refStartPos.z + Mathf.Round((currentPosV.z - refStartPos.z) / 1.66666f) * 1.66666f - lastMedalPosZ > 1.66666)&&
            (15.3f * 3f + refStartPos.z + Mathf.Round((currentPosV.z - refStartPos.z) / 1.66666f) * 1.66666f - lastObPosZ > 1.66666) && (Main.createdMedals.Count<15))
        {
            lastMedalPosZ = 15.3f * 3f + refStartPos.z + Mathf.Round((currentPosV.z - refStartPos.z) / 1.66666f) * 1.66666f;
            Vector3 pos = new Vector3(Mathf.Round(Random.Range(0, 3)), 0.853333f, lastMedalPosZ);
            if (lastMedalSerieNum > 0)
            {
                pos.x = lastMedalPosX;
                lastMedalSerieNum -= 1;
            }
            else
            {
                lastMedalPosX=pos.x;
                lastMedalSerieNum = Mathf.Round(Random.Range(3, 6));
            }

            pos.y = 0.953333f;
            pos.x = 0.613333f + Mathf.Round(pos.x) * 1.66666f;
            GameObject lgo = Instantiate(medalGO, pos, Quaternion.identity) as GameObject;
            createdMedals.Add(lgo);
        }

        /*currentPos.x += speed.x * Time.deltaTime;
        currentPos.y += speed.y * Time.deltaTime;
        currentPos.z += speed.z * Time.deltaTime;*/


        currentPosV.x = currentPosT.position.x;
        currentPosV.y = currentPosT.position.y;
        currentPosV.z = currentPosT.position.z;
        Vector3 pos2 = new Vector3(tunnelParts[3].transform.position.x, tunnelParts[3].transform.position.y, tunnelParts[3].transform.position.z + 15.3f);
        if (Mathf.Abs(currentPosV.z-refStartPos.z) > 15.3f)
        {
            GameObject lgo;
            if (tunnelNum % 2 == 0)
            {
                //lgo = Instantiate(tunnel1GO, pos2, tunnelParts[0].transform.localRotation) as GameObject;
                lgo = Instantiate(tunnel1GO, pos2, tunnelParts[2].transform.localRotation) as GameObject;  
                             
            }
            else
            {
                lgo = Instantiate(tunnel2GO, pos2, tunnelParts[2].transform.localRotation) as GameObject;
            }
            tunnelParts.Add(lgo);
            tunnelNum += 1;

            refStartPos.x = currentPosV.x;
            refStartPos.y = currentPosV.y;
            refStartPos.z = refStartPos.z + 15.3f;

            GameObject lastGO = tunnelParts[0];
            if (Main.tunnelParts.IndexOf(lastGO) > -1)
            {
                Main.tunnelParts.Remove(lastGO);
                Destroy(lastGO);
            }

        }

    }
}
