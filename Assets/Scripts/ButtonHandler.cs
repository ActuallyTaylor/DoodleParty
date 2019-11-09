using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeDraw
{
    public class ButtonHandler : MonoBehaviour
    {
        private int markerSize = 5;
        public Drawable DrawArea;
        public DrawingSettings DrawSettings;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        public void increase() {
            markerSize += 1;
            DrawSettings.SetMarkerWidth(markerSize);
        }

        public void decrease() {
            markerSize -= 1;
            if (markerSize > 0) {
                DrawSettings.SetMarkerWidth(markerSize);
            }
        }
    }
}