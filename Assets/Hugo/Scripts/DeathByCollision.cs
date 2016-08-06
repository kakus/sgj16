using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathByCollision : MonoBehaviour {

    public AudioSource youfuckedup;
    public float ToWait = 3f;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (/*col.gameObject.name == "Bullet(Clone)" /*|| */col.gameObject.name == "Character")
        {
            youfuckedup.Play();
            Destroy(col.gameObject);
            Destroy(gameObject);
            restartCurrentScene();
            //StartCoroutine(Wait());
        }
    }
   /* IEnumerator Wait()
    {
        yield return new WaitForSeconds(ToWait);
        restartCurrentScene();
    }
    */
    public void restartCurrentScene()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
