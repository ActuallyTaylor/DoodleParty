using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinnerScripts : MonoBehaviour
{
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Winner") == 1) {
            text.text = "Player 1 has won!!";
        } else if (PlayerPrefs.GetInt("Winner") == 2) {
            text.text = "Player 1 has won!!";

        } else if (PlayerPrefs.GetInt("Winner") == 3) {
            text.text = "Player 1 has won!!";

        } else if (PlayerPrefs.GetInt("Winner") == 4) {
            text.text = "Player 1 has won!!";

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Draw")) {
            PlayerPrefs.SetInt("InfiniteMode", 1);
            SceneManager.LoadScene(5);
        }
        if (Input.GetButtonDown("B")) {
            PlayerPrefs.SetInt("InfiniteMode", 0);
            SceneManager.LoadScene(7);

        }
    }
}
