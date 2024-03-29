﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Audio;

namespace FreeDraw {
    public class MouseCursorStart : MonoBehaviour {
        public LayerMask Start_Layers;
        public LayerMask Help_Layers;
        public LayerMask Settings_Layers;
        public LayerMask Two_Layers;
        public LayerMask Three_Layers;
        public LayerMask Four_Layers;
        public LayerMask Shutdown_Layers;
        public LayerMask UI_Layers;
        public int speed;
        public Animator animator;
        public VideoPlayer vid;
        public LayerMask Easy_Lay;
        public LayerMask Medium_Lay;
        public LayerMask Hard_Lay;
        public LayerMask NSFW_Lay;
        public Toggle EasyTog;
        public Toggle MedTog;
        public Toggle HardTog;
        public Toggle NSFWTog;

        // Start is called before the first frame update
        void Start () {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            PlayerPrefs.SetInt("previousLevel", 7);
            PlayerPrefs.SetInt("Player1Score", 0);
            PlayerPrefs.SetInt("Player2Score", 0);
            PlayerPrefs.SetInt("Player3Score", 0);
            PlayerPrefs.SetInt("Player4Score", 0);
            PlayerPrefs.SetInt("amountOfPlayers", 2);
            PlayerPrefs.SetInt("InfiniteMode", 0);
            PlayerPrefs.SetString("Cat", "Easy");
            Application.targetFrameRate = 300;

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
                Collider2D hit2 = Physics2D.OverlapPoint (transform.position + movement * Time.deltaTime, Two_Layers.value);
                Collider2D hit3 = Physics2D.OverlapPoint (transform.position + movement * Time.deltaTime, Three_Layers.value);
                Collider2D hit4 = Physics2D.OverlapPoint (transform.position + movement * Time.deltaTime, Four_Layers.value);
                Collider2D shutDown = Physics2D.OverlapPoint (transform.position + movement * Time.deltaTime, Shutdown_Layers.value);
                Collider2D UIelements = Physics2D.OverlapPoint (transform.position + movement * Time.deltaTime, UI_Layers.value);
                Collider2D Easy = Physics2D.OverlapPoint (transform.position + movement * Time.deltaTime, Easy_Lay.value);
                Collider2D Medium = Physics2D.OverlapPoint (transform.position + movement * Time.deltaTime, Medium_Lay.value);
                Collider2D Hard = Physics2D.OverlapPoint (transform.position + movement * Time.deltaTime, Hard_Lay.value);
                Collider2D NSFW = Physics2D.OverlapPoint (transform.position + movement * Time.deltaTime, NSFW_Lay.value);
                
                if (Easy != null && Easy.transform != null) {
                    EasyTog.isOn = true;
                    MedTog.isOn = false;
                    HardTog.isOn = false;
                    NSFWTog.isOn = false;
                    PlayerPrefs.SetString("Cat", "Easy");
                }
                
                if (Medium != null && Medium.transform != null) {
                    EasyTog.isOn = false;
                    MedTog.isOn = true;
                    HardTog.isOn = false;
                    NSFWTog.isOn = false;
                    PlayerPrefs.SetString("Cat", "Medium");
                }
                
                if (Hard != null && Hard.transform != null) {
                    EasyTog.isOn = false;
                    MedTog.isOn = false;
                    HardTog.isOn = true;
                    NSFWTog.isOn = false;
                    PlayerPrefs.SetString("Cat", "Hard");
                }
                
                if (NSFW != null && NSFW.transform != null) {
                    EasyTog.isOn = false;
                    MedTog.isOn = false;
                    HardTog.isOn = false;
                    NSFWTog.isOn = true;
                    PlayerPrefs.SetString("Cat", "NSFW");
                }
                
                if (UIelements != null && UIelements.transform != null) {

                }

                if (hitUI != null && hitUI.transform != null) {
                    Debug.Log ("Starting");
                    SceneManager.LoadScene (5);

                } else {

                }
                if (shutDown != null && shutDown.transform != null) {
                    Application.Quit();
                }

                if (hitHelp != null && hitHelp.transform != null) {
                    SceneManager.LoadScene (3);
                    PlayerPrefs.SetInt("previousLevel", 7);   
                }

                if (hitSettings != null && hitSettings.transform != null) {
                    SceneManager.LoadScene (2);
                    PlayerPrefs.SetInt("previousLevel", 7);
                } 
                
                if (hit2 != null && hit2.transform != null) {
                    PlayerPrefs.SetInt("amountOfPlayers", 2);   
                    print("Set Players 2");

                } 

                if (hit3 != null && hit3.transform != null) {
                    PlayerPrefs.SetInt("amountOfPlayers", 3);   
                    print("Set Players 3");

                } 

                if (hit4 != null && hit4.transform != null) {
                    PlayerPrefs.SetInt("amountOfPlayers", 4);   
                     print("Set Players 4");

                } 
            }
            int numPlayers = PlayerPrefs.GetInt("amountOfPlayers");
            animator.SetInteger("Players", numPlayers);
            

        }
    }
}