using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MouseCursorVoting : MonoBehaviour
{
    public int speed;
    public TextMeshProUGUI player1;
    public TextMeshProUGUI player2;
    public TextMeshProUGUI player3;
    public TextMeshProUGUI player4;
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

        int amountOfPlayers = PlayerPrefs.GetInt("amountOfPlayers");

        if (amountOfPlayers == 2) {
            player1.text = PlayerPrefs.GetString("Player1Catagory");
            player2.text = PlayerPrefs.GetString("Player2Catagory");
            player3.text = "N/A";
            player4.text = "N/A";
        } else if (amountOfPlayers == 3) {
            player1.text = PlayerPrefs.GetString("Player1Catagory");
            player2.text = PlayerPrefs.GetString("Player2Catagory");
            player3.text = PlayerPrefs.GetString("Player3Catagory");
            player4.text = "N/A";          
        } else if (amountOfPlayers == 4) {
            player1.text = PlayerPrefs.GetString("Player1Catagory");
            player2.text = PlayerPrefs.GetString("Player2Catagory");
            player3.text = PlayerPrefs.GetString("Player3Catagory");
            player4.text = PlayerPrefs.GetString("Player4Catagory");
        }
                
        int player1score = PlayerPrefs.GetInt("Player1Score");
        int player2score = PlayerPrefs.GetInt("Player2Score");
        int player3score = PlayerPrefs.GetInt("Player3Score");
        int player4score = PlayerPrefs.GetInt("Player4Score");
        int infiniteMode = PlayerPrefs.GetInt("InfiniteMode");

        if (player1score >= 5 && infiniteMode != 1) {
            PlayerPrefs.SetInt("Winner",1);
            SceneManager.LoadScene(6);

        }
    
        if (player2score >= 5 && infiniteMode != 1) {
            PlayerPrefs.SetInt("Winner",2);
            SceneManager.LoadScene(6);

        }   

        if (player3score >= 5 && infiniteMode != 1) {
            PlayerPrefs.SetInt("Winner",3);
            SceneManager.LoadScene(6);

        }    
        
        if (player4score >= 5 && infiniteMode != 1) {
            PlayerPrefs.SetInt("Winner",4);
            SceneManager.LoadScene(6);

        }
    }
}
