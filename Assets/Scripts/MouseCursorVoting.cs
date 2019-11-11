using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseCursorVoting : MonoBehaviour
{
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 movement = new Vector3 (Input.GetAxis ("MoveHorizontal"), Input.GetAxis ("MoveVerticle"), 0.0f);
        transform.position = transform.position + movement * Time.deltaTime * speed;
        if (Input.GetButtonDown("Draw")) {
            //Pick Player 1
            PlayerPrefs.SetInt("Player1Score", PlayerPrefs.GetInt("Player1Score") + 1);
            SceneManager.LoadScene (1);

        }
        if (Input.GetButtonDown("X")) {
            //Pick Player 2
            PlayerPrefs.SetInt("Player2Score", PlayerPrefs.GetInt("Player2Score") + 1);
            SceneManager.LoadScene (1);

        }
        if (Input.GetButtonDown("Y")) {
            //Pick Player 3
            PlayerPrefs.SetInt("Player3Score", PlayerPrefs.GetInt("Player3Score") + 1);
            SceneManager.LoadScene (1);

        }
        if (Input.GetButtonDown("B")) {
            //Pick Player 4
            PlayerPrefs.SetInt("Player4Score", PlayerPrefs.GetInt("Player4Score") + 1);
            SceneManager.LoadScene (1);

        }
        
    }
}
