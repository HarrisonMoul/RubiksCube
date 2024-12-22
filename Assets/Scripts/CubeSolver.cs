using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSolver : MonoBehaviour
{
    public RayGenerator rayGenerator;
    public CubeRotator cubeRotator;

    private Vector3 downPivot = new Vector3(-1, 0, 0);
    private Vector3 upPivot = new Vector3(-1, 2, 0);
    private Vector3 leftPivot = new Vector3(-1, 1, -1);
    private Vector3 rightPivot = new Vector3(-1, 1, 1);
    private Vector3 frontPivot = new Vector3(0, 1, 0);
    private Vector3 backPivot = new Vector3(-2, 1, 0);

    public float delay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isSolved()
    {
        bool solved = true;

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (rayGenerator.solvedState[i, j, k] != rayGenerator.currentCubeState[i, j, k])
                    {
                        solved = false;
                    }
                }
            }
        }

        if (solved)
        {
            Debug.Log("The cube is solved");
        }
        else
        {
            Debug.Log("The cube is not solved");
        }

        return solved;
    }


    public int[][] findWhiteEdges()
    {
        //if (isSolved()) { return; }

        int[][] edgeLocations = new int[4][];

        int edgesFound = 0;

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (Physics.Raycast(rayGenerator.rays[i, j, k].origin, rayGenerator.rays[i, j, k].direction, out RaycastHit hit, 10f))
                    {
                        if (hit.collider.name == "Up" && hit.collider.transform.parent.name == "Edge")
                        {
                            Debug.Log($"White edge found at {i}, {j}, {k}");
                            edgeLocations[edgesFound] = new int[] { i, j, k };
                            edgesFound++;
                        }
                    }
                }
            }

        }

        return edgeLocations;
    }

    public void createDaisy()
    {
        if (isSolved()) { return; }
        StartCoroutine(createDaisyWithDelay());
    }

    private IEnumerator createDaisyWithDelay()
    {

        int count = 0;


        int[][] edgeLocations = new int[4][];

        List<int[]> badEdges = new List<int[]>();
        List<int[]> goodEdges = new List<int[]>();

        do
        {
            edgeLocations = findWhiteEdges();

            for (int i = 0; i < 4; i++)
            {
                if (edgeLocations[i][0] != 5)
                {
                    Debug.Log($"Bad edge at {edgeLocations[i][0]}, {edgeLocations[i][1]}, {edgeLocations[i][2]}");
                    badEdges.Add(new int[] { edgeLocations[i][0], edgeLocations[i][1], edgeLocations[i][2] });
                }
                else
                {
                    goodEdges.Add(new int[] { edgeLocations[i][0], edgeLocations[i][1], edgeLocations[i][2] });
                }
            }

            List<int[]> edgesToRemove = new List<int[]>(); 

            foreach (int[] location in badEdges)
            {
                if (location[0] == 2 && location[1] == 1 && location[2] == 0)
                {
                    cubeRotator.RotateFace(backPivot, 90f, 'B');
                    edgesToRemove.Add(location);
                }

                yield return new WaitForSeconds(delay);
            }

            foreach (int[] edge in edgesToRemove)
            {
                badEdges.Remove(edge);
            }

            count++;

        } while (badEdges.Count != 0 && count < 5);

    }
}
