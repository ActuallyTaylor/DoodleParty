using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    private SpriteRenderer sr;

    private Texture2D t;

    private Color black = new Color(0,0,0,1);
    

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer> ();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Mouse0)) {
            Debug.Log("Mouse 0");

            t.SetPixel(Mathf.RoundToInt(Input.mousePosition.x), Mathf.RoundToInt(Input.mousePosition.y), black);
        }
    }
}
