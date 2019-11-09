using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Draw : MonoBehaviour
{
    public Transform baseDot;
    private Color black = new Color(0,0,0,1);    
    private Color white = new Color(1,1,1,1);
    Texture2D texture;

    // Start is called before the first frame update
    void Start()
    {
        var rawImage = GetComponent<RawImage>();
        texture = rawImage.texture as Texture2D;


    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if (Input.GetKey (KeyCode.Mouse0)) {
            Debug.Log("Yeet");
            texture.SetPixel((int)objPosition.x, (int)objPosition.y, black);  
            print(objPosition.x);
            print(objPosition.y);
        }
        texture.Apply();       

    }
}
