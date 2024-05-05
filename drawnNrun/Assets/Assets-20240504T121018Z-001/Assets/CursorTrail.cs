//Shady
using UnityEngine;
using System.Collections.Generic;



public class CursorTrail : MonoBehaviour
{
    [SerializeField] float MinDistance;
    [SerializeField] LineRenderer trailPrefab = null;
    [SerializeField] Camera Cam,RenderCam;
    [SerializeField] float clearSpeed = 1;
    [SerializeField] float distanceFromCamera = 1;

     private LineRenderer currentTrail;
     public List<Vector3> points = new List<Vector3>();
    public List<Vector3> points2 = new List<Vector3>();
    Vector3 previousPoint,mpos;
       public bool drawing;
    [SerializeField] PlayerManager pm;
  
        private void Start()
        {
            previousPoint = transform.position;
        }
        private void Update()
        {
            mpos = Input.mousePosition;
            if (Input.GetMouseButtonDown(0))
            {
                DestroyCurrentTrail();
                CreateCurrentTrail();
                AddPoint();
            }//if end
            if (Input.GetMouseButtonUp(0))
            {
                drawing = false;
                DestroyCurrentTrail();
            }
            if (Input.GetMouseButton(0))
            {
                Vector3 mousePosition = Input.mousePosition;
                if (Vector3.Distance(mousePosition, previousPoint) > MinDistance)
                {
                    AddPoint();
                }
                else
                {
                    
                    if (!drawing)
                    {
                        
                        CreateCurrentTrail();
                        AddPoint();
                    }
                }
            }//if end
    
            UpdateTrailPoints();
    
          
        }//Update() end
 
        private void DestroyCurrentTrail()
        {
            if (currentTrail != null)
            {
            pm.ReroupUnits();
            previousPoint = mpos;
                drawing = false;
                // previousPoint = transform.position;
                Destroy(currentTrail.gameObject);
                currentTrail = null;
                points.Clear();
            points2.Clear();

            }//if end
        }//DestroyCurrentTrail() end

        private void CreateCurrentTrail()
        {
            drawing = true;
            currentTrail = Instantiate(trailPrefab);
            currentTrail.transform.SetParent(transform, true);
        }//CreateCurrentTrail() end
    [SerializeField] Camera spawnpoint;
        private void AddPoint()
        {
            Vector3 mousePosition = Input.mousePosition;
           
            points.Add(spawnpoint.ViewportToWorldPoint(new Vector3(mousePosition.x / Screen.width, mousePosition.y / Screen.height, distanceFromCamera)));
            points2.Add(RenderCam.ViewportToScreenPoint(new Vector3(mousePosition.x / Screen.width, mousePosition.y / Screen.height, distanceFromCamera)));
            previousPoint = mpos;
        }//AddPoint() end

        private void UpdateTrailPoints()
        {
            if (currentTrail != null && points2.Count > 1)
            {
                currentTrail.positionCount = points2.Count;
                currentTrail.SetPositions(points2.ToArray());
            }//if end
            else
            {
               // DestroyCurrentTrail();
            }//else end
        }//UpdateTrailPoints() end

    }//class end
//namespace end