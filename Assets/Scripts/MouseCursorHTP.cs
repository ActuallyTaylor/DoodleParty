using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace FreeDraw
{

public class MouseCursorHTP : MonoBehaviour
    {                
        public LayerMask Back_Layers;
        public int speed;
        public int previousLevel;

    // Start is called before the first frame update
        void Start() {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }

        // Update is called once per frame
        void Update() {
            int previousLevel = PlayerPrefs.GetInt("previousLevel");

            Vector3 movement = new Vector3(Input.GetAxis("MoveHorizontal"), Input.GetAxis("MoveVerticle"),0.0f);
            transform.position = transform.position + movement * Time.deltaTime * speed;

            if (Input.GetButtonDown("Draw")) {
                //Here is wher you want to put all of your UI Stuff
                Collider2D hitBack = Physics2D.OverlapPoint(transform.position + movement * Time.deltaTime, Back_Layers.value);
                
                if (hitBack != null && hitBack.transform != null) {
                    Debug.Log("Going Back");
                    SceneManager.LoadScene(previousLevel);
                } else {


                }

            }
        }
    }  
}
