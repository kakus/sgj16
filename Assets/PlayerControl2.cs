using UnityEngine;
using System.Collections;

public class PlayerControl2 : MonoBehaviour {


    public Vector3 speed;
    public Vector3 destVec;
    public bool destMode=true;
    public int trackPos=0;
    public bool wasPressed = false;

    // Use this for initialization
    void Start () {
        speed = new Vector3(0, 0, 10000f);
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

        //if ((Input.GetKeyDown(KeyCode.LeftArrow)|| HugoInput.GetInputForPlayer(0).IsButtonPressed(EHugoButton.Key_4) && trackPos>=0) {
        if (HugoInput.GetInputForPlayer(0).ButttonJustPressed(EHugoButton.Key_4) && trackPos>=0) {
            speed.x = -1.666666f * 100f;
            destMode = true;
            trackPos -= 1;
            destVec.x = Main.tunnelParts[0].transform.position.x + 2.8f +trackPos* 1.6666666f;
            
        }

        //if (Input.GetKeyDown(KeyCode.RightArrow) && trackPos <= 0) {
          if (HugoInput.GetInputForPlayer(0).ButttonJustPressed(EHugoButton.Key_6) && trackPos <= 0) { 
            destMode = true;
            trackPos += 1;
            destVec.x = Main.tunnelParts[0].transform.position.x + 2.8f  + trackPos * 1.6666666f;
           
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
            GetComponent<Rigidbody>().velocity = new Vector3(0, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
        }

        //destVec.x = Main.tunnelParts[0].transform.position.x + 2.8f  + trackPos * 1.6666666f;
        if (Mathf.Abs(destVec.x - gameObject.transform.position.x) > 0.1)
        {
            destMode = true;
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
