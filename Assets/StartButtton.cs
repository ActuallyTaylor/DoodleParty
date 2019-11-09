using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtton : MonoBehaviour
{
    public bool click = false;
    public Animator animator;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        if (hit.collider != null && click == false) {
            Debug.Log("click");
            click = true;
}
        else if (hit.collider.tag == "start" != null && click == true) {
            Debug.Log("unclick");
            click = false;
        }

    }
    animator.SetBool("Click", click);
    transform.GetChild(0).gameObject.SetActive(click);

}
}