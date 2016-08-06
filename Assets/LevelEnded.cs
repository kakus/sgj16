using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelEnded : MonoBehaviour {

    // Use this for initialization

    public GameObject label;
    private float startTime = 0;

    void Start () {
	    if(Main.score>=100 && Main.health>0)
        {
            label.GetComponent<Text>().text = "Level Completed! \n Press \"1\" To Coninue";


        }
        else
        {
            label.GetComponent<Text>().text = "Level Failed! \n Press \"1\" To Restart";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (HugoInput.GetInputForPlayer(0).ButttonJustPressed(EHugoButton.Key_4))
        {
            if (Main.score >= 100 && Main.health > 0)
            {

                Application.LoadLevel("Scene2");
            }
            else
            {

                Application.LoadLevel("Scene1");
            }
        }
    }
}
