using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotator : MonoBehaviour
{
    public Transform cube;
    public float rotationSpeed;

    private bool isRotating = false;
    private Transform facePivot;

    private Vector3 downPivot = new Vector3(-1, 0, 0);
    private Vector3 upPivot = new Vector3(-1, 2, 0);
    private Vector3 leftPivot = new Vector3(-1, 1, -1);
    private Vector3 rightPivot = new Vector3(-1, 1, 1);
    private Vector3 frontPivot = new Vector3(0, 1, 0);
    private Vector3 backPivot = new Vector3(-2, 1, 0);

    // Start is called before the first frame update
    void Start()
    {
        facePivot = new GameObject("FacePivot").transform;
    }

    public void RotateFace(Vector3 faceNormal, float angle, char Side)
    {
        if (isRotating)
        {
            return;
        }


        int counter = 0;
        isRotating = true;

        Vector3 rotVector = new Vector3(0, 0, 0);
        switch (Side)
        {
            case 'U':
                facePivot.position = upPivot;
                rotVector = Vector3.up;
                break;
            case 'R':
                facePivot.position = rightPivot;
                rotVector = Vector3.back;
                break;
        }

        for (int i = cube.childCount - 1; i >= 0; i--)
        {
            /*
            if (IsOnFace(cubie.localPosition, faceNormal))
            {
                cubie.SetParent(facePivot);
            }
            */
            counter++;  
            Transform cubie = cube.GetChild(i);

            Vector3 currentPos = cubie.localPosition;
            Vector3 roundedPos = new Vector3(
                Mathf.Round(currentPos.x),
                Mathf.Round(currentPos.y),
                Mathf.Round(currentPos.z));
            cubie.localPosition = roundedPos;

            switch (Side)
            {
                case 'U':
                    if (cubie.localPosition.y > 1)
                    {
                        cubie.SetParent(facePivot);
                    }
                    break;
                case 'R':
                    if (cubie.localPosition.z > 0.9 && cubie.localPosition.z < 1.1)
                    {
                        cubie.SetParent(facePivot);
                    }
                    break;
            }
            

        }

        Debug.Log(counter);

        //facePivot.position = cube.position;
        //facePivot.position = upPivot;
        StartCoroutine(RotateOverTime(facePivot, angle, rotVector));

    }

    private bool IsOnFace(Vector3 localPos, Vector3 faceNormal)
    {
        const float threshold = 0.2f;
        Debug.Log(Vector3.Dot(localPos.normalized, faceNormal.normalized));
        return Mathf.Abs(Vector3.Dot(localPos.normalized, faceNormal.normalized)) >= 1 - threshold;
    }

    private IEnumerator RotateOverTime(Transform pivot, float angle, Vector3 rotVector)
    {
        Vector3 curr_angles = pivot.eulerAngles;
        curr_angles.y += angle;
        float rotated = 0;
        while (rotated < Mathf.Abs(angle))
        {
            float step = Mathf.Min(rotationSpeed * Time.deltaTime, Mathf.Abs(angle) - rotated);
            pivot.Rotate(rotVector, step * Mathf.Sign(angle), Space.World);
            rotated += step;
            yield return null;
        }

        //pivot.eulerAngles = curr_angles;

        Debug.Log(pivot.childCount);
        for (int i = pivot.childCount - 1; i >= 0; i--)
        {
            Transform cubie = pivot.GetChild(i);
            
            Vector3 currentPos = cubie.localPosition;
            Vector3 roundedPos = new Vector3(
                Mathf.Round(currentPos.x),
                Mathf.Round(currentPos.y),
                Mathf.Round(currentPos.z));
            cubie.localPosition = roundedPos;



            cubie.SetParent(cube);
        }

        isRotating = false;
    }

}