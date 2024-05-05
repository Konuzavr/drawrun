using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWithMouse : MonoBehaviour
{
    public GameObject DrawPrefab;
    private LineRenderer line;
    GameObject theTrail;
    Plane planeObj;
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        planeObj = new Plane(Camera.main.transform.forward * -1, this.transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
        {
            theTrail = (GameObject)Instantiate(DrawPrefab, this.transform.position, Quaternion.identity);
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float _dis;
            if (planeObj.Raycast(mouseRay, out _dis))
            {
                startPos = mouseRay.GetPoint(_dis);
            }
            else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetMouseButton(0))
            {
                Ray mouseRays = Camera.main.ScreenPointToRay(Input.mousePosition);
                 
                if (planeObj.Raycast(mouseRay, out _dis))
                {
                    theTrail.transform.position = mouseRays.GetPoint(_dis);
                }
            }
        }
    }
}


