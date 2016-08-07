using UnityEngine;
using System.Collections;

using UnityEngine.UI;
public class PlayerHitBehavior : MonoBehaviour
{

    public bool hit = false;
    public float upwardForce = 10;
    public float forwardForce = 10;
    public GameObject scoreLabel;
    public GameObject healthLabel;
    public GameObject glowScr;

    public AudioSource runningAS;
    public AudioSource hitAS;
    public AudioSource coinAS;
    public AudioSource musicAS;
    public AudioSource levelFailAS;
    public AudioSource levelWinAS;
    private Animator anim;

    // Use this for initialization
    void Start()
    {

        anim = GetComponentInChildren<Animator>();

        anim.SetInteger("IsWin", 0);
        anim.SetInteger("IsLost", 0);
        musicAS.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!runningAS.isPlaying)
        {
            runningAS.Play(1);
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
            if ((other.tag == "Obstacle") && ( Time.time- PlayerControl2.lastHitTime>2) &&(Main.score < 100))
            {
                other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                //other.gameObject.GetComponent<OutOfBounds>().enabled = false;

                other.gameObject.GetComponent<Rigidbody>().AddForce(((Camera.main.transform.forward + randForward) * forwardForce + (Vector3.up + randUp) * upwardForce), ForceMode.Impulse);
                other.gameObject.GetComponent<Rigidbody>().useGravity = true;
                other.gameObject.GetComponent<Collider>().enabled = false;
                other.gameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(-300, 300), Random.Range(-300, 300), Random.Range(-300, 300)), ForceMode.Impulse);
                
                hitAS.Play(1);

                Main.health -= 1;
                healthLabel.GetComponent<Text>().text = "" + Main.health.ToString() + "/3";
                Main.screenShakeStarted = Time.time;

               /* RawImage rndr = glowScr.GetComponent<RawImage>();
                Color c = Color.white;
                c.a = 1;

                rndr.color = c;*/

                if (Main.health <= 0)
                {
                    //Application.LoadLevel("Scene3");
                    //levelFailAS.Play();

                    //anim.SetInteger("IsLost", 1);
                    if (Main.outroStartTime == 0)
                    {
                        Main.outroStartTime = Time.time + 3.0f;

                        GetComponent<Rigidbody>().velocity = Vector3.zero;
                    }
                }
                else
                {
                    PlayerControl2.lastHitTime = Time.time;
                    
                    
                }
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

                if (Main.score >= 99)
                {
                    //levelWinAS.Play();

                    if (Main.outroStartTime == 0)
                    {
                        Main.outroStartTime = Time.time + 3.0f;
                        GetComponent<Rigidbody>().velocity = Vector3.zero;
                    }
                }
                

                //GameObject scoreLabel = GameObject.FindGameObjectWithTag("ScoreLabel");
                //scoreLabel.GetComponent<Text>().text = "MEDALE: 5";

                //Destroy(other.gameObject);
                //Main.createdObstacles.Remove(other.gameObject);
            }
        }
    }
}
