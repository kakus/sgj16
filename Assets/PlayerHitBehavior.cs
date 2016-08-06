using UnityEngine;
using System.Collections;

using UnityEngine.UI;
public class PlayerHitBehavior : MonoBehaviour
{

    public bool hit = false;
    public float upwardForce = 10;
    public float forwardForce = 10;
    public GameObject scoreLabel;
    
    public AudioSource runningAS;
    public AudioSource hitAS;
    public AudioSource coinAS;
    public AudioSource musicAS;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!runningAS.isPlaying)
        {
            runningAS.Play();
        }

    }
    public void OnTriggerEnter(Collider other)
    {
        if (!hit)
        {
            GameObject otherParent = null;
            Vector3 randUp = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
            Vector3 randForward = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));

            randUp *= 0.1f;
            randForward *= 0.1f;
            if (other.tag == "Obstacle")
            {
                other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                //other.gameObject.GetComponent<OutOfBounds>().enabled = false;

                other.gameObject.GetComponent<Rigidbody>().AddForce(((Camera.main.transform.forward + randForward) * forwardForce + (Vector3.up + randUp) * upwardForce), ForceMode.Impulse);
                other.gameObject.GetComponent<Rigidbody>().useGravity = true;
                other.gameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(-300, 300), Random.Range(-300, 300), Random.Range(-300, 300)), ForceMode.Impulse);
                
                hitAS.Play();
            }
            if (other.tag == "Medal")
            {
                //Destroy(other.gameObject);
                // Main.createdMedals.Remove(other.gameObject);
                // other.gameObject.transform.position = Camera.main.ScreenToWorldPoint(scoreLabel.transform.position);
               
                //other.gameObject.transform.position = Camera.main.transform.position+ new Vector3(-2,0.6f,1.4f);
                other.gameObject.GetComponent<OutOfBounds>().enabled = false;
                other.gameObject.GetComponent<TweenPos>().targetv3 = Camera.main.transform.position + new Vector3(-2, 2.6f, 1.4f);
                other.gameObject.GetComponent<TweenPos>().enabled = true;
                other.gameObject.transform.parent = Camera.main.transform;

                coinAS.Play();
                

                //GameObject scoreLabel = GameObject.FindGameObjectWithTag("ScoreLabel");
                //scoreLabel.GetComponent<Text>().text = "MEDALE: 5";

                //Destroy(other.gameObject);
                //Main.createdObstacles.Remove(other.gameObject);
            }
        }
    }
}
