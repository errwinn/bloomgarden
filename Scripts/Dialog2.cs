using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialog2 : MonoBehaviour
{
    void Update()
    {
        foreach(Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Ended)
            {
                SceneManager.LoadScene(2);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(2);
        }
    }
}
