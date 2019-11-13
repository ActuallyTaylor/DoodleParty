using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        //Sam additions
        public LayerMask Help_Layers;
        public LayerMask Settings_Layers;
        public float targetTime = 60.0f;
        public bool drawing = false;
        private int turnCount;
        private bool waiting = false;
        public float waitTime;
        public bool gameOver = false;
        public bool paused = false;
        private int counter = 0;
        private float wait;

        // Start is called before the first frame update
        void Start()
        {
            sr.color = Color.black;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            int amountOfPlayers = PlayerPrefs.GetInt("amountOfPlayers");
            PlayerPrefs.SetInt("currentPlayer", 1);
            PlayerPrefs.SetFloat("WaitTime", waitTime);
            PlayerPrefs.SetFloat("targetTime", targetTime);
            PlayerPrefs.SetString("TurnText", "Player " + PlayerPrefs.GetInt("currentPlayer") + "'s turn");
            markerSize = 5;
            DrawSettings.SetMarkerWidth(markerSize);
            drew = false;
            drawing = false;
            waiting = false;
            //waitTime = PlayerPrefs.GetFloat("WaitTime");
            gameOver = false;
            wait = waitTime;

            turnCount = amountOfPlayers * 5;
            
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 movement = new Vector3(Input.GetAxis("MoveHorizontal"), Input.GetAxis("MoveVerticle"), 0.0f);
            transform.position = transform.position + movement * Time.deltaTime * speed;
            PlayerPrefs.SetString("TurnText", "Player " + PlayerPrefs.GetInt("currentPlayer") + "'s turn");
            
            if (turnCount <= 0)
            {
                print("Game Over");
                gameOver = true;
            }

            if (gameOver == true) {
                SceneManager.LoadScene (4);

            }
            
            if (!waiting && turnCount >= 0 && !gameOver && !paused)
            {

                if (drawing)
                {
                    targetTime -= Time.deltaTime;
                }

                if (targetTime <= 0.0f)
                {
                    turnEnded();

                }

                getDraw();
                //changeMarkerSize();
                getDrawUp();
            }
            pause();
            getDrawDown();
            isOnCanvas();
            changeColor();

            
            if (waiting && !paused)
            {
                waitTime -= Time.deltaTime;
                PlayerPrefs.SetString("TurnText", "Get Ready... " + (int)waitTime);

                if (waitTime <= 0.0f)
                {
                    drew = false;
                    drawing = false;
                    waiting = false;
                    waitTime = wait;
                }
            }
            
        }

        public void pause() {
            if (Input.GetButtonDown("Pause")) {
                counter++;
                if (counter % 2 == 1) {
                    click = true;
                    paused = true;
                    menu.enabled = true;
                } else {
                    click = false;
                    paused = false;
                    menu.enabled = false;
                }
                animator.SetBool("Click", click);

            }
        }
        public void changeColor()
        {
            if (Input.GetButtonDown("CycleColor"))
            {
                if (color == 0)
                {
                    DrawSettings.SetMarkerBlue();
                    sr.color = Color.blue;
                    color++;
                }
                else if (color == 1)
                {
                    DrawSettings.SetMarkerRed();
                    sr.color = Color.red;
                    color++;
                }
                else if (color == 2)
                {
                    DrawSettings.SetMarkerGreen();
                    sr.color = Color.green;
                    color++;

                }
                else if (color == 3)
                {
                    DrawSettings.SetMarkerBlack();
                    sr.color = Color.black;
                    color = 0;
                }
            }
        }
        public void getDrawUp()
        {
            if (Input.GetButtonUp("Draw") && onCanvas)
            {
                turnEnded();
                drawing = false;

            }

        }
        public void getDrawDown()
        {
            Vector3 movement = new Vector3(Input.GetAxis("MoveHorizontal"), Input.GetAxis("MoveVerticle"), 0.0f);

            if (Input.GetButtonDown("Draw"))
            {
                //Here is wher you want to put all of your UI Stuff
                Collider2D hitUI = Physics2D.OverlapPoint(transform.position + movement * Time.deltaTime, UI_Layers.value);
                Collider2D hitShutDown = Physics2D.OverlapPoint(transform.position + movement * Time.deltaTime, Shut_Layers.value);
                //Sam additions
                Collider2D hitHelp = Physics2D.OverlapPoint(transform.position + movement * Time.deltaTime, Help_Layers.value);
                Collider2D hitSettings = Physics2D.OverlapPoint(transform.position + movement * Time.deltaTime, Settings_Layers.value);
                if (hitHelp != null && hitHelp.transform != null)
                {
                    SceneManager.LoadScene(3);
                    PlayerPrefs.SetInt("previousLevel", 1);

                }
                if (hitSettings != null && hitSettings.transform != null)
                {
                    SceneManager.LoadScene(2);

                }

                if (hitUI != null && hitUI.transform != null)
                {
                    if (!click)
                    {
                        click = true;
                        menu.enabled = true;
                        paused = true;

                    }
                    else
                    {
                        click = false;
                        menu.enabled = false;
                        paused = false;

                    }
                    animator.SetBool("Click", click);

                }
                else
                {
                    //click = false;
                    //menu.enabled = false;
                    //animator.SetBool("Click", click);

                }
                if (hitShutDown != null && hitShutDown.transform != null)
                {
                    print("Shut Down");
                    Application.Quit();
                }
            }
        }

        public void getDraw()
        {
            Vector3 movement = new Vector3(Input.GetAxis("MoveHorizontal"), Input.GetAxis("MoveVerticle"), 0.0f);

            if (Input.GetButton("Draw") && !drew || Input.GetKey("a"))
            {
                Collider2D hit = Physics2D.OverlapPoint(transform.position + movement * Time.deltaTime, Drawing_Layers.value);

                if (hit != null && hit.transform != null)
                {
                    drawing = true;
                    DrawArea.BrushTemplate(transform.position + movement * Time.deltaTime);
                    onCanvas = true;
                }
                else
                {
                    onCanvas = false;
                    //drew = true;
                }

            }
        }
        public void isOnCanvas()
        {
            Vector3 movement = new Vector3(Input.GetAxis("MoveHorizontal"), Input.GetAxis("MoveVerticle"), 0.0f);
            Collider2D canvas = Physics2D.OverlapPoint(transform.position + movement * Time.deltaTime, Drawing_Layers.value);
            if (canvas != null && canvas.transform != null)
            {
                onCanvas = true;
                sr.enabled = true;
                speed = 3;
            }
            else
            {
                onCanvas = false;
                sr.enabled = false;
                speed = 4;
            }
        }
        public void changeMarkerSize()
        {
            if (Input.GetButton("SizeUP"))
            {
                increase();
                print(markerSize);
            }

            if (Input.GetAxis("SizeDown") == 1)
            {
                decrease();
                print(markerSize);
            }

        }
        public void increase()
        {
            markerSize += 1;
            if (markerSize <= 7)
            {
                DrawSettings.SetMarkerWidth(markerSize);
            }
            else
            {
                markerSize = 7;
            }
            DrawSettings.SetMarkerWidth(markerSize);
        }

        public void decrease()
        {
            markerSize -= 1;
            if (markerSize >= 2)
            {
                DrawSettings.SetMarkerWidth(markerSize);
            }
            else
            {
                markerSize = 2;
            }
        }

        public void turnEnded()
        {
            int amountOfPlayers = PlayerPrefs.GetInt("amountOfPlayers");
            int currentPlayer = PlayerPrefs.GetInt("currentPlayer");
            turnCount -= 1;
            print(turnCount);
            waiting = true;
            waitTime = wait;
            targetTime = PlayerPrefs.GetFloat("targetTime");
            
            if (currentPlayer < amountOfPlayers)
            {
                PlayerPrefs.SetInt("currentPlayer", currentPlayer + 1);
            }
            else
            {
                PlayerPrefs.SetInt("currentPlayer", 1);

            }
        }

    }
}
