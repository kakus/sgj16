using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RunnerAnimationController : MonoBehaviour {

    Animator Anim;
    bool OnGround = true;
    public Transform GroundCheck;
    float GroundRadius = 0.2f;
    public LayerMask Ground;
    public float JumpForce = 9000f;
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
        if (OnGround && HugoInput.GetInputForPlayer(0).ButttonJustPressed(EHugoButton.Key_2) && !Slide)
        {
            OnGround = false;
            Anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpForce));
        }
        if (OnGround && HugoInput.GetInputForPlayer(0).ButttonJustPressed(EHugoButton.Key_8))
        {
            Slide = true;
            GetComponent<BoxCollider2D>().isTrigger = true;
            Anim.SetBool("Slide", Slide);
            time = 35;
        }
        time--;
        if (time <= 0) {
            Slide = false;
            GetComponent<BoxCollider2D>().isTrigger = false;
            Anim.SetBool("Slide", Slide);
        }
    }
    
}
