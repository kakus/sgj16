using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathByCollision : MonoBehaviour
{

    public float ToWait = 1f;
    public AudioSource explosionAS;
    Animator Anim;
    void Start()
    {
        Anim = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Bullet(Clone)" /*|| col.gameObject.name == "Character"*/)
        {
            // Destroy(gameObject);
            // GetComponent<Renderer>().enabled = false;
            //restartCurrentScene();
            Anim.SetTrigger("Dead");
            Anim.SetBool("CanControl", false);
            SetAllCollidersStatus(false);
            Destroy(col.gameObject);
            explosionAS.Play();
            StartCoroutine(Wait());
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.name == "Bullet(Clone)" /*|| col.gameObject.name == "Character"*/)
        {
            // Destroy(gameObject);
            // GetComponent<Renderer>().enabled = false;
            //restartCurrentScene();
            Anim.SetTrigger("Dead");
            Anim.SetBool("CanControl", false);
            SetAllCollidersStatus(false);
            Destroy(col.gameObject);

            explosionAS.Play();
            StartCoroutine(Wait());
        }
    }
    public void SetAllCollidersStatus(bool active)
    {
        foreach (BoxCollider2D c in GetComponents<BoxCollider2D>())
        {
            c.enabled = active;
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        restartCurrentScene();
    }

    public void restartCurrentScene()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}