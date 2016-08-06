using UnityEngine;
using System.Collections;

public class PlayerControl2 : MonoBehaviour {


    public Vector3 speed;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        speed.x = 0;
        speed.y = 0;
        speed.z = 0;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            speed.x = -1.666666f;

        if (Input.GetKeyDown(KeyCode.RightArrow))
            speed.x =1.666666f;


        /*if (Input.GetKeyDown(KeyCode.LeftArrow))
            speed.x = -100;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            speed.x = -100;*/
        //gameObject.transform.Translate(speed * Time.deltaTime, Space.World);
        gameObject.transform.Translate(speed, Space.World);
    }
}
