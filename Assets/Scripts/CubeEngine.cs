using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEngine : MonoBehaviour
{
    public ScrambleGenerator scrambleGenerator;
    public CubeRotator cubeRotator;

    private Vector3 downPivot = new Vector3(-1, 0, 0);
    private Vector3 upPivot = new Vector3(-1, 2, 0);
    private Vector3 leftPivot = new Vector3(-1, 1, -1);
    private Vector3 rightPivot = new Vector3(-1, 1, 1);
    private Vector3 frontPivot = new Vector3(0, 1, 0);
    private Vector3 backPivot = new Vector3(-2, 1, 0);

    public float delay = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string DisplayScramble()
    {
        string scramble = scrambleGenerator.GenerateScramble();
        Debug.Log(scramble);
        return scramble;
    }


    public void Scramble()
    {
        StartCoroutine(ScrambleWithDelay());
    }

    public IEnumerator ScrambleWithDelay()
    {
        string scramble = DisplayScramble();
        Debug.Log("The scramble is: " + scramble);

        string[] moves = scramble.Split(' ');

        foreach (string move in moves)
        {
            
            int count = 0;
            while (CubeRotator.isRotating)
            {
                count++;
                if (count > 1000)
                {
                    Debug.Log(count);
                    break;
                }
            }
            

            switch (move)
            {
                case "R":
                    cubeRotator.RotateFace(rightPivot, 90f, 'R');
                    break;
                case "R'":
                    cubeRotator.RotateFace(rightPivot, -90f, 'R');
                    break;
                case "R2":
                    cubeRotator.RotateFace(rightPivot, 180f, 'R');
                    break;

                case "U":
                    cubeRotator.RotateFace(upPivot, 90f, 'U');
                    break;
                case "U'":
                    cubeRotator.RotateFace(upPivot, -90f, 'U');
                    break;
                case "U2":
                    cubeRotator.RotateFace(upPivot, 180f, 'U');
                    break;

                case "F":
                    cubeRotator.RotateFace(frontPivot, 90f, 'F');
                    break;
                case "F'":
                    cubeRotator.RotateFace(frontPivot, -90f, 'F');
                    break;
                case "F2":
                    cubeRotator.RotateFace(frontPivot, 180f, 'F');
                    break;

                case "L":
                    cubeRotator.RotateFace(leftPivot, 90f, 'L');
                    break;
                case "L'":
                    cubeRotator.RotateFace(leftPivot, -90f, 'L');
                    break;
                case "L2":
                    cubeRotator.RotateFace(leftPivot, 180f, 'L');
                    break;

                case "D":
                    cubeRotator.RotateFace(downPivot, 90f, 'D');
                    break;
                case "D'":
                    cubeRotator.RotateFace(downPivot, -90f, 'D');
                    break;
                case "D2":
                    cubeRotator.RotateFace(downPivot, 180f, 'D');
                    break;

                case "B":
                    cubeRotator.RotateFace(downPivot, 90f, 'B');
                    break;
                case "B'":
                    cubeRotator.RotateFace(downPivot, -90f, 'B');
                    break;
                case "B2":
                    cubeRotator.RotateFace(downPivot, 180f, 'B');
                    break;

                default:
                    Debug.Log("Not R!");
                    break;
            }

            yield return new WaitForSeconds(delay);
        }


    }
}
