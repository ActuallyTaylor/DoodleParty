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
    public float waitTime = 3.0f;
    private float wait;
    private string[] catagories = new string[] { "Tree", "House", "Ball", "Horse", "Monkey", "Giraffe","Shark","Dog","Cat","Pencil","Toothbrush","Computer","Pen","Phone","Paintbrush"
    ,"Bed","Pillow","School","God","Devil","Teapot","Garden","Spongebob","Chair","Beach","Furniture","Rollercoaster","Octopus","Fish","Kid","Adult","Dinosaur","camera","airplane",
    "america", "otter","dishes","emoji","tank","Chicken","Diamond","Cupcake","Man","Women","Popcorn","Movies","skeleton","treasure","jellyfish","snowboard","Landscape","Space",
    "umbrella"};
    private string[] pack1 = new string[] { "Tree", "House", "Garden", "Phone", "Soccer Ball", "Football", "Book", "Fish", "Emoji", "Stick Figure", "Pizza", "Pen", "Paint brush"
    , "Skeleton", "Teapot", "Beach", "Cupcake", "Bed", "Snow", "Hill", "River", "Car", "America", "Dishwasher", "Movie Theater", "Pillow", "Camera", "Water Bottle" };
    private string[] pack2 = new string[] {"Dinosaur", "Console", "Keyboard", "Microphone", "Football", "Charizard", "Minecraft", "Walrus", "Shark", "Mars" , "Backpack",
     "Double Decker Bus", "Refrigerator", "Airplane, Sword", "Squidward", "Obama", "Snail", "Pelican", "Superhero", "Lamp", "Skull", "Painting", "Fedora", "Racecar",
     "Bow and Arrow", "Landline Phone", "Highway", "Space Alien", "Gumball Machine", };
    private string[] pack3 = new string[] {"Bike", "Space", "Spongebob", "Squidward", "Squirrel", "Pokemon", "Treasure", "Octopus", "Tank", "Spaceship", "Dragon", "Castle",
    "Diamond Armor", "Pickaxe", "Gun", "Shield", "Furniture", "Popcorn", "Chicken", "Dog", "Cat", "Pencil", "Backpack", "jellyfish","snowboarding", "skiing", "germany", "europe",
     "africa", "asia"};
    private string[] nsfw = new string[] {"9/11", "sex", "Penis", "Mommy and Daddy", "Kinky", "Hitler", "Stalin"," Armenian Genocide", "Suicide", "Wine", "Beer", "Dildo",
    "Buttplug", "Anal Beads", "Vagina", "Cock and Ball Torture", "Circumcision", "Erection", "Nudes", "Masturbation", "Weed", "Meth", "Heroin", "Sexual Fantasy", "FanFic",
    "Orgy"," Premarital sex", "Hand-holding", "kissing", "Porn", "Eye Contact", "Ankles", "Shrek", "Herpes", "Gang-bang", "Cum Shot", "Lesbian", "Cuckold", "Creampie", "Bondage",
    "Stripper", "Strip club", "Playboy", "Virgins", "Oral", "Anal", "Titty-fuck", "Nipples", "Missing Persons Report", "Gay", "Straight", "The person to your left",
    "Jahseh Onfroy", "Dragon Dildo", "Pubes", "Beastiality"};
    private int currentPlayer = 1;
    // Start is called before the first frame update
    void Start()
    {
        int amountOfPlayers = PlayerPrefs.GetInt("amountOfPlayers");
        string SelectedCat = PlayerPrefs.GetString("Cat");
        string randomString = "";

        if (SelectedCat.Equals("Easy"))
        {
            randomString = pack1[Random.Range(0, catagories.Length)];

        }
        else if (SelectedCat.Equals("Medium"))
        {
            randomString = pack2[Random.Range(0, catagories.Length)];

        }
        else if (SelectedCat.Equals("Hard"))
        {
            randomString = pack3[Random.Range(0, catagories.Length)];

        }
        else if (SelectedCat.Equals("NSFW"))
        {
            randomString = nsfw[Random.Range(0, catagories.Length)];

        }
        catagoryText.text = "Player 1 your Catagory is: " + randomString;
        PlayerPrefs.SetString("Player1Catagory", randomString);
        print(PlayerPrefs.GetString("Player1Catagory"));
        wait = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        int amountOfPlayers = PlayerPrefs.GetInt("amountOfPlayers");
        waitTime -= Time.deltaTime;
        timeText.text = "Time till next player category... " + (int)waitTime;

        if (Input.GetButtonDown("Draw"))
        {
            waitTime = 0.0f;
        }

        if (waitTime <= 0.0f)
        {
            currentPlayer++;
            if (currentPlayer > amountOfPlayers)
            {
                SceneManager.LoadScene(1);
            }

            if (currentPlayer <= amountOfPlayers)
            {
                string SelectedCat = PlayerPrefs.GetString("Cat");
                string randomString = "";
                if (SelectedCat.Equals("Easy"))
                {
                    randomString = pack1[Random.Range(0, catagories.Length)];

                }
                else if (SelectedCat.Equals("Medium"))
                {
                    randomString = pack2[Random.Range(0, catagories.Length)];

                }
                else if (SelectedCat.Equals("Hard"))
                {
                    randomString = pack3[Random.Range(0, catagories.Length)];

                }
                else if (SelectedCat.Equals("NSFW"))
                {
                    randomString = nsfw[Random.Range(0, catagories.Length)];

                }
                catagoryText.text = "Player " + currentPlayer + " your Catagory is: " + randomString;
                waitTime = wait;
                PlayerPrefs.SetString("Player" + currentPlayer + "Catagory", randomString);
                print(PlayerPrefs.GetString("Player" + currentPlayer + "Catagory"));
            }

        }

    }
}
