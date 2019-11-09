using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeDraw
{
    public class MouseCursor : MonoBehaviour
    {                
        SpriteRenderer sr;
        public LayerMask Drawing_Layers;
        public Drawable DrawArea;
        public DrawingSettings DrawSettings;
        private int markerSize = 5;
        public int speed;
        bool drew = false;
        int color = 0;
        Color c = Color.black;

    // Start is called before the first frame update
        void Start() {
            sr = GetComponent<SpriteRenderer>();
            sr.color = Color.black;

        }

        // Update is called once per frame
        void Update() {
            Vector3 movement = new Vector3(Input.GetAxis("MoveHorizontal"), Input.GetAxis("MoveVerticle"),0.0f);
            transform.position = transform.position + movement * Time.deltaTime * speed;

            if (Input.GetButton("Draw") && !drew) {
                Collider2D hit = Physics2D.OverlapPoint(transform.position + movement * Time.deltaTime, Drawing_Layers.value);

                if (hit != null && hit.transform != null) {
                    DrawArea.BrushTemplate(transform.position + movement * Time.deltaTime);
                }
                
            }
            if (Input.GetButtonUp("Draw")) {
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