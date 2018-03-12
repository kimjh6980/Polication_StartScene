using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotateScene : MonoBehaviour {

    private bool ing;
    private int scenenum = 0;
    private string Scenename = "scene1";


    public Transform scene5;
    // Use this for initialization
    void Start () {
        ing = false;
	}
	
	// Update is called once per frame
	void Update () {
        // 씬 전환
        if(!ing)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                scenenum = (scenenum+1)%5;
                ing = true;
                scene5.transform.Rotate(Vector3.up * 72);
                StartCoroutine(WaitForIt());
                Debug.Log(scenenum);
            }
            if (Input.GetKey(KeyCode.E))
            {
                scenenum -= 1;
                if(scenenum <0)
                {
                    scenenum += 5;
                }
                scenenum = scenenum% 5;
                ing = true;
                scene5.transform.Rotate(Vector3.down * 72);
                StartCoroutine(WaitForIt());
                Debug.Log(scenenum);
            }
        }

        // 씬 진입
        if (Input.GetKey(KeyCode.Return))
        {
            switch (scenenum)
            {
                case 0:
                    Scenename = "scene1";
                    break;
                case 1:
                    Scenename = "scene2";
                    break;
                case 2:
                    Scenename = "scene3";
                    break;
                case 3:
                    Scenename = "scene4";
                    break;
                case 4:
                    Scenename = "scene5";
                    break;
            }
            SceneManager.LoadScene(Scenename);
        }
    }
   
    // 씬 전환시의 딜레이
    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(1.0f);
        ing = false;
    }
}
