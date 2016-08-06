using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Main : MonoBehaviour {


    public GameObject obstacleGO;
    public GameObject explosionGO;

    public GameObject obstacleStartPos;

    public static List<GameObject> createdObstacles;
    public static List<GameObject> explosionParts;

    // Use this for initialization
    void Start () {
        createdObstacles = new List<GameObject>();
        explosionParts = new List<GameObject>();
    }

    // Update is called once per frame
    void Update() {
        if (Random.Range(0,100) < 50) {
            //GameObject lgo = Instantiate(obstacleGO, obstacleStartPos.transform.position, Quaternion.identity) as GameObject;

            int posID;
            posID = (int)Mathf.Round(Random.Range(0, 4));
            Vector3 pos = new Vector3(Random.Range(1, 5), Random.Range(1, 5), 27);
            if (posID == 0)
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
            }
            GameObject lgo = Instantiate(obstacleGO, pos, Quaternion.identity) as GameObject;
            createdObstacles.Add(lgo);
        }

    }
}
