using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeDraw
{
    public class MouseCursor : MonoBehaviour
    {                
        public SpriteRenderer sr;
        public LayerMask Drawing_Layers;
        public LayerMask UI_Layers;
        public LayerMask Shut_Layers;
        public Drawable DrawArea;
        public DrawingSettings DrawSettings;
        private int markerSize = 5;
        public int speed;
        bool drew = false;
        bool onCanvas = false;
        int color = 0;
        Color c = Color.black;
        public bool click = false;
        public Animator animator;
        public SpriteRenderer menu;

    // Start is called before the first frame update
        void Start() {
            sr.color = Color.black;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Update is called once per frame
        void Update() {

            Vector3 movement = new Vector3(Input.GetAxis("MoveHorizontal"), Input.GetAxis("MoveVerticle"),0.0f);
            transform.position = transform.position + movement * Time.deltaTime * speed;

            if (Input.GetButton("Draw") && !drew) {
                Collider2D hit = Physics2D.OverlapPoint(transform.position + movement * Time.deltaTime, Drawing_Layers.value);

                if (hit != null && hit.transform != null) {
                    DrawArea.BrushTemplate(transform.position + movement * Time.deltaTime);
                    onCanvas = true;
                } else {
                    onCanvas = false;
                    drew = true;
                }

            }
            Collider2D canvas = Physics2D.OverlapPoint(transform.position + movement * Time.deltaTime, Drawing_Layers.value);

            if (canvas != null && canvas.transform != null) {
                onCanvas = true;
                sr.enabled = true;
            } else {
                onCanvas = false;
                sr.enabled = false;    
            }

            if (Input.GetButtonDown("Draw")) {
                //Here is wher you want to put all of your UI Stuff
                Collider2D hitUI = Physics2D.OverlapPoint(transform.position + movement * Time.deltaTime, UI_Layers.value);
                Collider2D hitShutDown = Physics2D.OverlapPoint(transform.position + movement * Time.deltaTime, Shut_Layers.value);
                
                if (hitUI != null && hitUI.transform != null) {
                    if (!click) {
                        click = true;
                        menu.enabled = true;
                    } else {
                        click = false;
                        menu.enabled = false;
                    }
                    animator.SetBool("Click", click);

                } else {
                    //click = false;
                    //menu.enabled = false;
                    //animator.SetBool("Click", click);

                }
                if (hitShutDown != null && hitShutDown.transform != null) {
                    print("Shut Down");
                    Application.Quit();
                }
            }


            if (Input.GetButtonUp("Draw") && onCanvas) {
                drew = true;
            }
            
            if(Input.GetButton("SizeUP"))   {
                increase();
                print(markerSize);
            } 

            if (Input.GetAxis("SizeDown") == 1) {
                decrease();
                print(markerSize);
            }

            if (Input.GetButtonDown("CycleColor")) {
                if (color == 0) {
                    DrawSettings.SetMarkerBlue();
                    sr.color = Color.blue;
                    color ++;
                } else if (color == 1) {
                    DrawSettings.SetMarkerRed();
                    sr.color = Color.red;
                    color ++;
                } else if (color == 2) {
                    DrawSettings.SetMarkerGreen();
                    sr.color = Color.green; 
                    color ++;

                } else if (color == 3) {
                    DrawSettings.SetMarkerBlack();
                    sr.color = Color.black;          
                    color = 0;
                }
            }
            
        }
        public void increase() {
            markerSize += 1;
            if (markerSize <= 7) {
                DrawSettings.SetMarkerWidth(markerSize);
            } else {
                markerSize = 7;
            }
            DrawSettings.SetMarkerWidth(markerSize);
        }

        public void decrease() {
            markerSize -= 1;
            if (markerSize >= 2) {
                DrawSettings.SetMarkerWidth(markerSize);
            } else {
                markerSize = 2;
            }
        }
    }  
    
}