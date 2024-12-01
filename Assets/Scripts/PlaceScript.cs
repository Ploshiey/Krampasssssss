using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlaceScript : MonoBehaviour
{
    public float xBounds = 11;
    public float yBounds = 6;
    float mouseX;
    float mouseY;

    public GameObject straightPiece;
    public GameObject leftPiece;
    public GameObject rightPiece;
    public GameObject upPiece;
    public GameObject downPiece;
    public GameObject stopPiece;

    public GameObject[] track;
    private int trackCount;
    void Start()
    {

        trackCount = 0;
    }
    void Update()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 4.7f;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mouseX = mousePos.x;
        mouseY = mousePos.y;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (mouseY > 2.5f)
                {
                    if (track[trackCount].transform.tag == "Up")
                    {
                        trackCount++;
                        track[trackCount] = Instantiate(upPiece, new Vector3(track[trackCount - 1].transform.position.x, track[trackCount - 1].transform.position.y + 1, mousePos.z), Quaternion.Euler(270f, 0, 0));
                    }
                    else if (track[trackCount].transform.tag == "Straight")
                    {
                        trackCount++;
                        track[trackCount] = Instantiate(leftPiece, new Vector3(track[trackCount - 1].transform.position.x + 1, track[trackCount - 1].transform.position.y, mousePos.z), Quaternion.Euler(270f, 0, 0));
                        track[trackCount].transform.tag = "Up";
                    }
                }
                else if (mouseY < -2.5f)
                {
                    if (track[trackCount].transform.tag == "Straight")
                    {
                        trackCount++;
                        track[trackCount] = Instantiate(rightPiece, new Vector3(track[trackCount - 1].transform.position.x + 1, track[trackCount - 1].transform.position.y, mousePos.z), Quaternion.Euler(270f, 0, 0));
                        track[trackCount].transform.tag = "Down";
                    }
                    else if (track[trackCount].transform.tag == "Down")
                    {
                        trackCount++;
                        track[trackCount] = Instantiate(downPiece, new Vector3(track[trackCount - 1].transform.position.x, track[trackCount - 1].transform.position.y - 1, mousePos.z), Quaternion.Euler(270f, 0, 0));
                    }
                }
                else if (mouseX > 0f)
                {
                    if (track[trackCount].transform.tag == "Up")
                    {
                        trackCount++;
                        track[trackCount] = Instantiate(rightPiece, new Vector3(track[trackCount - 1].transform.position.x, track[trackCount - 1].transform.position.y + 1, mousePos.z), Quaternion.Euler(270f, 0, 0));
                        track[trackCount].transform.tag = "Straight";
                    }
                    else if (track[trackCount].transform.tag == "Down")
                    {
                        trackCount++;
                        track[trackCount] = Instantiate(leftPiece, new Vector3(track[trackCount - 1].transform.position.x, track[trackCount - 1].transform.position.y - 1, mousePos.z), Quaternion.Euler(270f, 0, 0));
                        track[trackCount].transform.tag = "Straight";
                    }
                    else
                    {
                        trackCount++;
                        track[trackCount] = Instantiate(straightPiece, new Vector3(track[trackCount - 1].transform.position.x + 1, track[trackCount - 1].transform.position.y, mousePos.z), Quaternion.Euler(270f, 0, 0));
                    }
                }
                else if (mouseX <  0f)
                {
                    Destroy(track[trackCount]);
                    trackCount--;
                }
            }
        }
    }
}
