using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MouseCursorVoting : MonoBehaviour
{
    public int speed;
    public TextMeshProUGUI player1Cat;
    public TextMeshProUGUI player2Cat;
    public TextMeshProUGUI player3Cat;
    public TextMeshProUGUI player4Cat;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player1Cat.text = PlayerPrefs.GetString("Player1Catagory");
        player2Cat.text = PlayerPrefs.GetString("Player2Catagory");
        player3Cat.text = PlayerPrefs.GetString("Player3Catagory");
        player4Cat.text = PlayerPrefs.GetString("Player4Catagory");

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 movement = new Vector3 (Input.GetAxis ("MoveHorizontal"), Input.GetAxis ("MoveVerticle"), 0.0f);
        transform.position = transform.position + movement * Time.deltaTime * speed;
        if (Input.GetButtonDown("Draw")) {
            //Pick Player 1
            PlayerPrefs.SetInt("Player1Score", PlayerPrefs.GetInt("Player1Score") + 1);
            SceneManager.LoadScene (5);

        }
        if (Input.GetButtonDown("B")) {
            //Pick Player 2
            PlayerPrefs.SetInt("Player2Score", PlayerPrefs.GetInt("Player2Score") + 1);
            SceneManager.LoadScene (5);

        }
        if (Input.GetButtonDown("X")) {
            //Pick Player 3
            PlayerPrefs.SetInt("Player3Score", PlayerPrefs.GetInt("Player3Score") + 1);
            SceneManager.LoadScene (5);

        }
        if (Input.GetButtonDown("Y")) {
            //Pick Player 4
            PlayerPrefs.SetInt("Player4Score", PlayerPrefs.GetInt("Player4Score") + 1);
            SceneManager.LoadScene (5);

        }
        
    }
}
