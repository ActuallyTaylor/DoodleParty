using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    public TextMeshProUGUI player1score;
    public TextMeshProUGUI player2score;
    public TextMeshProUGUI player3score;
    public TextMeshProUGUI player4score;
    public TextMeshProUGUI currentCategory;
    public SpriteRenderer player3;
    public SpriteRenderer player4;

    // Start is called before the first frame update
    void Start()
    {
        int amountOfPlayers = PlayerPrefs.GetInt("amountOfPlayers");

        if (amountOfPlayers == 2) {
            player1score.enabled = true;
            player2score.enabled = true;
            player3score.enabled = false;
            player4score.enabled = false;
            player3.enabled = false;
            player4.enabled = false;
            
        } else if (amountOfPlayers == 3) {
            player1score.enabled = true;
            player2score.enabled = true;
            player3score.enabled = true;
            player4score.enabled = false; 
            player3.enabled = true;
            player4.enabled = false;

        } else if (amountOfPlayers == 4) {
            player1score.enabled = true;
            player2score.enabled = true;
            player3score.enabled = true;
            player4score.enabled = true;
            player3.enabled = true;
            player4.enabled = true;
        }
        player1score.text = PlayerPrefs.GetInt("Player1Score").ToString();
        player2score.text = PlayerPrefs.GetInt("Player2Score").ToString();
        player3score.text = PlayerPrefs.GetInt("Player3Score").ToString();
        player4score.text = PlayerPrefs.GetInt("Player4Score").ToString();

    }

    // Update is called once per frame
    void Update()
    {
        int currentPlayer =  PlayerPrefs.GetInt("currentPlayer");
        currentCategory.text = "Current Category: " + PlayerPrefs.GetString("Player" + currentPlayer +"Catagory");
        
        int player1 = PlayerPrefs.GetInt("Player1Score");
        int player2 = PlayerPrefs.GetInt("Player2Score");
        int player3 = PlayerPrefs.GetInt("Player3Score");
        int player4 = PlayerPrefs.GetInt("Player4Score");
        
        player1score.text = PlayerPrefs.GetInt("Player1Score").ToString();
        player2score.text = PlayerPrefs.GetInt("Player2Score").ToString();
        player3score.text = PlayerPrefs.GetInt("Player3Score").ToString();
        player4score.text = PlayerPrefs.GetInt("Player4Score").ToString();
        if (player1 >= 5) {

        }
    
        if (player2 >= 5) {

        }   

        if (player3 >= 5) {

        }    
        
        if (player4 >= 5) {

        }
    }
}
