using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDragRotation : MonoBehaviour
{
    public CubeRotator cubeRotator;

    private Vector3 dragStart;
    private Vector3 dragEnd;

    private Vector3 preMouse;
    private Vector3 mouseDelta;

    private Transform selectedFace;
    private bool isDragging = false;

    private Vector3 downPivot = new Vector3(-1, 0, 0);
    private Vector3 upPivot = new Vector3(-1, 2, 0);
    private Vector3 leftPivot = new Vector3(-1, 1, -1);
    private Vector3 rightPivot = new Vector3(-1, 1, 1);
    private Vector3 frontPivot = new Vector3(0, 1, 0);
    private Vector3 backPivot = new Vector3(-2, 1, 0);
    private Vector3[] pivots = new Vector3[6];

    public float rotationSpeed = 500f;
    
    // Start is called before the first frame update
    void Start()
    {
        pivots[0] = upPivot;
        pivots[1] = downPivot;
        pivots[2] = leftPivot;
        pivots[3] = rightPivot;
        pivots[4] = frontPivot;
        pivots[5] = backPivot;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Cubie"))
                {
                    selectedFace = hit.transform;
                    dragStart = Input.mousePosition;
                    isDragging = true;
                }
                else if (hit.transform.CompareTag("CubieSide"))
                {
                    selectedFace = hit.transform.parent;
                    dragStart = Input.mousePosition;
                    isDragging = true;
                }
            }            
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            dragEnd = Input.mousePosition;
            isDragging = false;

            if (selectedFace != null)
            {
                HandleDrag();
                selectedFace = null;
            }
        }
    }


    private void HandleDrag()
    {
        Vector3 dragDirection = dragEnd - dragStart;

        if (dragDirection.magnitude < 10f)
        {
            return;
        }

        char center = findClosestCenter(selectedFace.localPosition);
        if (Mathf.Abs(dragDirection.x) > Mathf.Abs(dragDirection.y))
        {
            Debug.Log("Selected Cubie: " + selectedFace.localPosition);

            if (dragDirection.x > 0)
            {
                if (center == 'U' || center == 'F' || center == 'R')
                {
                    cubeRotator.RotateFace(selectedFace.localPosition, -90f, center);
                }
                else
                {
                    cubeRotator.RotateFace(selectedFace.localPosition, 90f, center);
                }
                
            }
            else
            {
                if (center == 'U' || center == 'F' || center == 'R')
                {
                    cubeRotator.RotateFace(selectedFace.localPosition, 90f, center);
                }
                else
                {
                    cubeRotator.RotateFace(selectedFace.localPosition, -90f, center);
                }
                
            }
           
        }
        else
        {
            Debug.Log("Selected Cubie: " + selectedFace.localPosition);

            if (dragDirection.y > 0)
            {
                if (center == 'U' || center == 'F' || center == 'R')
                {
                    cubeRotator.RotateFace(selectedFace.localPosition, 90f, center);
                }
                else
                {
                    cubeRotator.RotateFace(selectedFace.localPosition, -90f, center);
                }
            }
            else
            {
                if (center == 'U' || center == 'F' || center == 'R')
                {
                    cubeRotator.RotateFace(selectedFace.localPosition, -90f, center);
                }
                else
                {
                    cubeRotator.RotateFace(selectedFace.localPosition, 90f, center);
                }
            
            }
        }
    }

    private char findClosestCenter(Vector3 currentPos)
    {
        Vector3 closestPivot = pivots[0];
        ArrayList closestPivots = new ArrayList();

        for (int i = 1; i < pivots.Length; i++)
        {
            Vector3 roundedPos = new Vector3(
                Mathf.Round(currentPos.x),
                Mathf.Round(currentPos.y),
                Mathf.Round(currentPos.z));

            //Debug.Log("Distance between pivots[" + i + "] and roundedPos: ");

            if (Vector3.Distance(pivots[i], roundedPos) < Vector3.Distance(closestPivot, roundedPos))
            {
                closestPivot = pivots[i];
            }
            else if (Vector3.Distance(pivots[i], roundedPos) == Vector3.Distance(closestPivot, roundedPos))
            {
                Debug.Log("Pivot[i]: " + pivots[i] + "   closestPivot: " + closestPivot);
                closestPivots.Add(pivots[i]);
            }
        }
        
        closestPivots.Add(closestPivot);
        

        Debug.Log("Determined closest pivot to be: " + closestPivot);

        if (closestPivot == pivots[0])
        {
            Debug.Log('U');
            return 'U';
        }
        else if (closestPivot == pivots[1])
        {
            Debug.Log('D');
            return 'D';
        }
        else if (closestPivot == pivots[2])
        {
            Debug.Log('L');
            return 'L';
        }
        else if (closestPivot == pivots[3])
        {
            Debug.Log('R');
            return 'R';
        }
        else if (closestPivot == pivots[4])
        {
            Debug.Log('F');
            return 'F';
        }
        else
        {
            Debug.Log('B');
            return 'B';
        }

    }

}

