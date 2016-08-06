using UnityEngine;
using System.Collections;

public class OutOfBounds : MonoBehaviour {

    
    public Vector3 speed;
    public float gravity;

    // Use this for initialization
    void Start () {
        speed = new Vector3(0, 0, -Main.tunnelSpeed);
	}
	
	// Update is called once per frame
	void Update () {
        //speed.y -= gravity * Time.deltaTime;
        //gameObject.transform.Translate(speed * Time.deltaTime, Space.World);
        //gameObject.transform.Rotate(angSpeedV, angSpeedS);

       

        //if (gameObject.transform.position.z < -15 || (new Vector2(2.5f, 2.5f) - new Vector2(gameObject.transform.position.x, gameObject.transform.position.y)).magnitude>6)
       // if (gameObject.transform.position.z < -15 || (Mathf.Abs(gameObject.transform.position.x-2.5f)+Mathf.Abs(gameObject.transform.position.y-2.5f)>6f))
        if (Main.tunnelParts[0].transform.position.z- gameObject.transform.position.z > 15)// || (Mathf.Abs(gameObject.transform.position.x-2.5f)+Mathf.Abs(gameObject.transform.position.y-2.5f)>6f))
        {
            //gameObject.SetActive(false);
            if (Main.tunnelParts.IndexOf(gameObject) > -1)
            {
                Main.tunnelParts.Remove(gameObject);
            }
            if (Main.createdObstacles.IndexOf(gameObject) > -1)
            {
                Main.createdObstacles.Remove(gameObject);
                Destroy(gameObject);
            }

            if (Main.createdMedals.IndexOf(gameObject) > -1)
            {
                Main.createdMedals.Remove(gameObject);
                Destroy(gameObject);
            }
        }        
        
    }
}
