using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace FreeDraw {
    public class MouseCursorStart : MonoBehaviour {
        public LayerMask Start_Layers;
        public LayerMask Help_Layers;
        public LayerMask Settings_Layers;
        public int speed;

        // Start is called before the first frame update
        void Start () {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }

        // Update is called once per frame
        void Update () {

            Vector3 movement = new Vector3 (Input.GetAxis ("MoveHorizontal"), Input.GetAxis ("MoveVerticle"), 0.0f);
            transform.position = transform.position + movement * Time.deltaTime * speed;

            if (Input.GetButtonDown ("Draw")) {
                //Here is wher you want to put all of your UI Stuff
                Collider2D hitUI = Physics2D.OverlapPoint (transform.position + movement * Time.deltaTime, Start_Layers.value);
                Collider2D hitHelp = Physics2D.OverlapPoint (transform.position + movement * Time.deltaTime, Help_Layers.value);
                Collider2D hitSettings = Physics2D.OverlapPoint (transform.position + movement * Time.deltaTime, Settings_Layers.value);

                if (hitUI != null && hitUI.transform != null) {
                    Debug.Log ("Starting");
                    SceneManager.LoadScene (1);
                } else {

                }
                if (hitHelp != null && hitHelp.transform != null) {
                    SceneManager.LoadScene (3);

                }
                if (hitSettings != null && hitSettings.transform != null) {
                    SceneManager.LoadScene (2);

                } 
            }
        }
    }
}