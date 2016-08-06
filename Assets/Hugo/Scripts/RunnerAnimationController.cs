using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RunnerAnimationController : MonoBehaviour {

    Animator Anim;
    bool OnGround = true;
    public Transform GroundCheck;
    float GroundRadius = 0.2f;
    public LayerMask Ground;
    public float JumpForce = 300f;
    public int time = 0;
    bool Slide = false;
	// Use this for initialization
	void Start () {
        Anim = GetComponent<Animator>();
	}
	
	void FixedUpdate () {
        OnGround = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, Ground);
        Anim.SetBool("Ground", OnGround);
        Anim.SetFloat("VerticalSpeed", GetComponent<Rigidbody2D>().velocity.y);
    }
    void Update()
    {
        if(OnGround && Input.GetKeyDown(KeyCode.W) && !Slide)
        {
            Anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpForce));
        }
        if (OnGround && Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
            Slide = true;
            Anim.SetBool("Slide", Slide);
            time = 40;
        }
        time--;
        if (time <= 0) {
            GetComponent<BoxCollider2D>().isTrigger = false;
            Anim.SetBool("Slide", Slide);
            Slide = false;
        }
    }
}
