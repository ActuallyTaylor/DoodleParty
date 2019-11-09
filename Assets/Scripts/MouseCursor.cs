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
        public Drawable DrawArea;
        public DrawingSettings DrawSettings;
        private int markerSize = 5;
        public int speed;
        bool drew = false;
        bool onCanvas = false;
        int color = 0;
        Color c = Color.black;
    // Start is called before the first frame update
        void Start() {
            sr.color = Color.black;

        }

        // Update is called once per frame
        void Update() {
            Vector3 movement = new Vector3(Input.GetAxis("MoveHorizontal"), Input.GetAxis("MoveVerticle"),0.0f);
            transform.position = transform.position + movement * Time.deltaTime * speed;

            if (Input.GetButton("Draw")) {
                //Drawing Stuff
                if (!drew) {
                    Collider2D hit = Physics2D.OverlapPoint(transform.position + movement * Time.deltaTime, Drawing_Layers.value);

                    if (hit != null && hit.transform != null) {
                        DrawArea.BrushTemplate(transform.position + movement * Time.deltaTime);
                        onCanvas = true;
                    } else {
                        onCanvas = false;
                    }
                }
                //UI Stuff
                Collider2D hit2 = Physics2D.OverlapPoint(transform.position + movement * Time.deltaTime, UI_Layers.value);

                if (hit2 != null && hit2.transform != null) {
                    print("Yeet");
                } else {

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