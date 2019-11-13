using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Boot : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoPlayer vid;
 
    void Start()
    {
        vid.loopPointReached += CheckVideoDone;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
 
    void CheckVideoDone(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(7);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
