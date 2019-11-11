using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TurnText : MonoBehaviour
{
    // Start is called before the first frame update
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = PlayerPrefs.GetString("TurnText");
    }
}
