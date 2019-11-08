using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer> ();
        Debug.DrawLine(Vector3.zero, new Vector3(5, 0, 0), Color.white, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Mouse0)) {
            
        }
    }
}
