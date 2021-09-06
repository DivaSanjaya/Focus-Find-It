using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectControl : MonoBehaviour
{
    private float startPosX, startPosY;
    private bool isHold;
    private Vector3 screenPoint;
    private Vector3 offset;

    Collider2D cd;
    
    // Start is called before the first frame update
    void Start()
    {
       cd = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHold == true)
        {
            Vector3 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);

            if (hit.collider)
            {
                Debug.Log("Hitting: " + hit.collider.name);

                if (hit.collider.CompareTag("Object"))
                {
                    hit.collider.gameObject.SetActive(false);
                    Data.m_totalItem -= 1;
                    //Get Name
                    Debug.Log("Clicked obj: " + hit.collider.gameObject.name);
                    //Debug.Log("object aktiv= " + activeObj);
                }
                if (hit.collider.CompareTag("Obstacle"))
                {
                    this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
                }
            }
        }

        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        Vector3 mousePos;
        //        mousePos = Input.mousePosition;
        //        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        //        startPosX = mousePos.x - this.transform.localPosition.x;
        //        startPosY = mousePos.y - this.transform.localPosition.y;

        //        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
        //        if(isHold && hit.collider && hit.collider.CompareTag("Obstacle"))
        //        {
        //           this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
        //        }

        //        Debug.Log("Object: " + mousePos);
        //        isHold = true;
        //        if (hit.collider)
        //        {
        //            Debug.Log("Hitting: " + hit.collider.name);

        //            if (hit.collider.CompareTag("Object"))
        //            {
        //                hit.collider.gameObject.SetActive(false);
        //                Data.m_totalItem -= 1;
        //                //Get Name
        //                Debug.Log("Clicked obj: " + hit.collider.gameObject.name);
        //                //Debug.Log("object aktiv= " + activeObj);
        //            }
        //            if (hit.collider.CompareTag("Obstacle"))
        //            {
        //                this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
        //            }
        //        }

        //        if (Input.GetMouseButtonUp(0))
        //        {
        //            Debug.Log("Mouse is not clicked");
        //        }
        //    }


     }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isHold = true;
        }
        //offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 mousePos;
        //    mousePos = Input.mousePosition;
        //    mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        //    startPosX = mousePos.x - this.transform.localPosition.x;
        //    startPosY = mousePos.y - this.transform.localPosition.y;

        //    Debug.Log("Object: " + mousePos);

        //    isHold = true;
        //}
    }



    private void OnMouseUp()
    {
        isHold = false;
        //private void WinCondition()
        //{
        //    isEnd = true;
        //    Debug.Log("you win");
        //    GameObject.Find("Canvas/Panel").SetActive(true);
        //}
    }


}
