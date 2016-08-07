using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TweenPos : MonoBehaviour {

    public Vector3 targetv3;
    public GameObject scoreLabel;
	// Use this for initialization
	void Start () {
       
	    scoreLabel = GameObject.FindGameObjectWithTag("ScoreLabel");
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, targetv3, .05f);
        if(((targetv3 - transform.position).magnitude < 0.1)||(transform.localPosition.z<0))
        {
           
            //if (gameObject.tag=="Medal")
            {
                Main.score += 1;
                scoreLabel.GetComponent<Text>().text = "" + Main.score.ToString()+"/100";

                Main.createdMedals.Remove(gameObject);
                Destroy(gameObject);

                if (Main.score >= 100)
                {
                   // Application.LoadLevel("Fin");
                }
            }
        }
	}
}
