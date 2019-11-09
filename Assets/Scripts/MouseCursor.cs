using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeDraw
{
    public class MouseCursor : MonoBehaviour
    {                
        public LayerMask Drawing_Layers;
        public Drawable DrawArea;
        public int speed;

    // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 movement = new Vector3(Input.GetAxis("MoveHorizontal"), Input.GetAxis("MoveVerticle"),0.0f);
            transform.position = transform.position + movement * Time.deltaTime * speed;

            if (Input.GetButton("Draw")) {
                Collider2D hit = Physics2D.OverlapPoint(transform.position + movement * Time.deltaTime, Drawing_Layers.value);

                if (hit != null && hit.transform != null)
                {
                    DrawArea.BrushTemplate(transform.position + movement * Time.deltaTime);
                }
            }
        }
    }  
}