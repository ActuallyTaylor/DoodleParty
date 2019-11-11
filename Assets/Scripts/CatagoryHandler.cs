using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CatagoryHandler : MonoBehaviour
{
    public TextMeshProUGUI catagoryText;
    public TextMeshProUGUI timeText;

    public float waitTime = 10.0f;
    private string[] catagories = new string[] { "Tree", "House", "Ball", "Horse", "Monkey", "Giraffe","Shark","Dog","Cat","Pencil","Toothbrush","Computer","Pen","Phone","Paintbrush"
    ,"Bed","Pillow","School","God","Devil","Teapot","Garden","Spongebob","Chair","Beach","Furniture","Rollercoaster","Octopus","Fish","Kid","Adult","Dinosaur","camera","airplane",
    "america", "otter","dishes","emoji","tank","Chicken","Diamond","Cupcake","Man","Women","Popcorn","Movies","skeleton","treasure","jellyfish","snowboard","Landscape","Space",
    "umbrella"};
    private int currentPlayer = 1;
    // Start is called before the first frame update
    void Start()
    {
        int amountOfPlayers = PlayerPrefs.GetInt("amountOfPlayers");
        string randomString = catagories[Random.Range (0, catagories.Length)];
        catagoryText.text = "Player 1 your Catagory is: " + randomString;
        
    }

    // Update is called once per frame
    void Update()
    {
        int amountOfPlayers = PlayerPrefs.GetInt("amountOfPlayers");
        waitTime -= Time.deltaTime;
        timeText.text = "Time till next player category... " + (int)waitTime;
        if (waitTime <= 0.0f)
        {
            currentPlayer ++;
            
            if (currentPlayer > amountOfPlayers) {
                SceneManager.LoadScene (1);
            }

            string randomString = catagories[Random.Range (0, catagories.Length)];
            catagoryText.text = "Player " + currentPlayer + " your Catagory is: " + randomString;
            waitTime = 10.0f;
        }

    }
}
