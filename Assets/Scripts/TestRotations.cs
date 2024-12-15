using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotations : MonoBehaviour
{
    public CubeRotator cubeRotator;
    private Vector3[] rotations = new Vector3[6];

    private Vector3 downPivot = new Vector3(-1, 0, 0);
    private Vector3 upPivot = new Vector3(-1, 2, 0);
    private Vector3 leftPivot = new Vector3(-1, 1, -1);
    private Vector3 rightPivot = new Vector3(-1, 1, 1);
    private Vector3 frontPivot = new Vector3(0, 1, 0);
    private Vector3 backPivot = new Vector3(-2, 1, 0);

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RotateUpFace()
    {
        cubeRotator.RotateFace(upPivot, 90f, 'U');
    }

    public void RotateRightFace()
    {
        cubeRotator.RotateFace(rightPivot, 90f, 'R');
    }
}
