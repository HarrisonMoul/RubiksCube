using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGenerator : MonoBehaviour
{


    public string[,,] solvedState =
    {
        {
            {"Up", "Up", "Up"}, {"Up", "Up", "Up"}, {"Up", "Up", "Up"}
        },

        {
            {"Front", "Front", "Front"}, {"Front", "Front", "Front"}, {"Front", "Front", "Front"}
        },

        {
            {"Left", "Left", "Left"}, {"Left", "Left", "Left"}, {"Left", "Left", "Left"}
        },

        {
            {"Back", "Back", "Back"}, {"Back", "Back", "Back"}, {"Back", "Back", "Back"}
        },

        {
            {"Right", "Right", "Right"}, {"Right", "Right", "Right"}, {"Right", "Right", "Right"}
        },

        {
            {"Down", "Down", "Down"}, {"Down", "Down", "Down"}, {"Down", "Down", "Down"}
        }

    };

    public string[,,] currentCubeState =
    {
        {
            {"Up", "Up", "Up"}, {"Up", "Up", "Up"}, {"Up", "Up", "Up"}
        },

        {
            {"Front", "Front", "Front"}, {"Front", "Front", "Front"}, {"Front", "Front", "Front"}
        },

        {
            {"Left", "Left", "Left"}, {"Left", "Left", "Left"}, {"Left", "Left", "Left"}
        },

        {
            {"Back", "Back", "Back"}, {"Back", "Back", "Back"}, {"Back", "Back", "Back"}
        },

        {
            {"Right", "Right", "Right"}, {"Right", "Right", "Right"}, {"Right", "Right", "Right"}
        },

        {
            {"Down", "Down", "Down"}, {"Down", "Down", "Down"}, {"Down", "Down", "Down"}
        }

    };



    public Ray[,,] rays = new Ray[6, 3, 3];

    // Start is called before the first frame update
    void Start()
    {
        //The 'Up' side which corresponds to white
        rays[0, 0, 0] = new Ray(new Vector3(-4, 6, -2), new Vector3(0, -1, 0));
        rays[0, 0, 1] = new Ray(new Vector3(-4, 6, 0), new Vector3(0, -1, 0)); //edge
        rays[0, 0, 2] = new Ray(new Vector3(-4, 6, 2), new Vector3(0, -1, 0));

        rays[0, 1, 0] = new Ray(new Vector3(-2, 6, -2), new Vector3(0, -1, 0)); //edge
        rays[0, 1, 1] = new Ray(new Vector3(-2, 6, 0), new Vector3(0, -1, 0));
        rays[0, 1, 2] = new Ray(new Vector3(-2, 6, 2), new Vector3(0, -1, 0)); //edge

        rays[0, 2, 0] = new Ray(new Vector3(0, 6, -2), new Vector3(0, -1, 0));
        rays[0, 2, 1] = new Ray(new Vector3(0, 6, 0), new Vector3(0, -1, 0)); //edge
        rays[0, 2, 2] = new Ray(new Vector3(0, 6, 2), new Vector3(0, -1, 0));




        //The 'Front' side which corresponds to green
        rays[1, 0, 0] = new Ray(new Vector3(2, 4, -2), new Vector3(-1, 0, 0));
        rays[1, 0, 1] = new Ray(new Vector3(2, 4, 0), new Vector3(-1, 0, 0));   //Started with this ray
        rays[1, 0, 2] = new Ray(new Vector3(2, 4, 2), new Vector3(-1, 0, 0));

        rays[1, 1, 0] = new Ray(new Vector3(2, 2, -2), new Vector3(-1, 0, 0));
        rays[1, 1, 1] = new Ray(new Vector3(2, 2, 0), new Vector3(-1, 0, 0));
        rays[1, 1, 2] = new Ray(new Vector3(2, 2, 2), new Vector3(-1, 0, 0));

        rays[1, 2, 0] = new Ray(new Vector3(2, 0, -2), new Vector3(-1, 0, 0));
        rays[1, 2, 1] = new Ray(new Vector3(2, 0, 0), new Vector3(-1, 0, 0));
        rays[1, 2, 2] = new Ray(new Vector3(2, 0, 2), new Vector3(-1, 0, 0));




        //The 'Left' side which corresponds to orange
        rays[2, 0, 0] = new Ray(new Vector3(-4, 4, -4), new Vector3(0, 0, 1));
        rays[2, 0, 1] = new Ray(new Vector3(-2, 4, -4), new Vector3(0, 0, 1));
        rays[2, 0, 2] = new Ray(new Vector3(0, 4, -4), new Vector3(0, 0, 1));

        rays[2, 1, 0] = new Ray(new Vector3(-4, 2, -4), new Vector3(0, 0, 1));
        rays[2, 1, 1] = new Ray(new Vector3(-2, 2, -4), new Vector3(0, 0, 1));
        rays[2, 1, 2] = new Ray(new Vector3(0, 2, -4), new Vector3(0, 0, 1));

        rays[2, 2, 0] = new Ray(new Vector3(-4, 0, -4), new Vector3(0, 0, 1));
        rays[2, 2, 1] = new Ray(new Vector3(-2, 0, -4), new Vector3(0, 0, 1));
        rays[2, 2, 2] = new Ray(new Vector3(0, 0, -4), new Vector3(0, 0, 1));




        //The 'Back' side which corresponds to blue
        rays[3, 0, 0] = new Ray(new Vector3(-6, 4, 2), new Vector3(1, 0, 0));
        rays[3, 0, 1] = new Ray(new Vector3(-6, 4, 0), new Vector3(1, 0, 0));
        rays[3, 0, 2] = new Ray(new Vector3(-6, 4, -2), new Vector3(1, 0, 0));

        rays[3, 1, 0] = new Ray(new Vector3(-6, 2, 2), new Vector3(1, 0, 0));
        rays[3, 1, 1] = new Ray(new Vector3(-6, 2, 0), new Vector3(1, 0, 0));
        rays[3, 1, 2] = new Ray(new Vector3(-6, 2, -2), new Vector3(1, 0, 0));

        rays[3, 2, 0] = new Ray(new Vector3(-6, 0, 2), new Vector3(1, 0, 0));
        rays[3, 2, 1] = new Ray(new Vector3(-6, 0, 0), new Vector3(1, 0, 0));
        rays[3, 2, 2] = new Ray(new Vector3(-6, 0, -2), new Vector3(1, 0, 0));




        //The 'Right' side which corresponds to red
        rays[4, 0, 0] = new Ray(new Vector3(0, 4, 4), new Vector3(0, 0, -1));
        rays[4, 0, 1] = new Ray(new Vector3(-2, 4, 4), new Vector3(0, 0, -1));
        rays[4, 0, 2] = new Ray(new Vector3(-4, 4, 4), new Vector3(0, 0, -1));

        rays[4, 1, 0] = new Ray(new Vector3(0, 2, 4), new Vector3(0, 0, -1));
        rays[4, 1, 1] = new Ray(new Vector3(-2, 2, 4), new Vector3(0, 0, -1));
        rays[4, 1, 2] = new Ray(new Vector3(-4, 2, 4), new Vector3(0, 0, -1));

        rays[4, 2, 0] = new Ray(new Vector3(0, 0, 4), new Vector3(0, 0, -1));
        rays[4, 2, 1] = new Ray(new Vector3(-2, 0, 4), new Vector3(0, 0, -1));
        rays[4, 2, 2] = new Ray(new Vector3(-4, 0, 4), new Vector3(0, 0, -1));




        //The 'Down' side which corresponds to yellow
        rays[5, 0, 0] = new Ray(new Vector3(0, -2, -2), new Vector3(0, 1, 0));
        rays[5, 0, 1] = new Ray(new Vector3(0, -2, 0), new Vector3(0, 1, 0));
        rays[5, 0, 2] = new Ray(new Vector3(0, -2, 2), new Vector3(0, 1, 0));

        rays[5, 1, 0] = new Ray(new Vector3(-2, -2, -2), new Vector3(0, 1, 0));
        rays[5, 1, 1] = new Ray(new Vector3(-2, -2, 0), new Vector3(0, 1, 0));
        rays[5, 1, 2] = new Ray(new Vector3(-2, -2, 2), new Vector3(0, 1, 0));

        rays[5, 2, 0] = new Ray(new Vector3(-4, -2, -2), new Vector3(0, 1, 0));
        rays[5, 2, 1] = new Ray(new Vector3(-4, -2, 0), new Vector3(0, 1, 0));
        rays[5, 2, 2] = new Ray(new Vector3(-4, -2, 2), new Vector3(0, 1, 0));
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 origin = new Vector3(2, 4, 0);
        Vector3 direction = new Vector3(-1, 0 ,0);

        Ray myRay = new Ray(origin, direction);

        Debug.DrawRay(myRay.origin, myRay.direction, Color.red);
        
        if (Physics.Raycast(origin, direction, out RaycastHit hit, 10f))
        {
            Debug.Log($"Ray hit: {hit.collider.name}");
            if(hit.collider.name == "Front")
            {
                Debug.DrawRay(myRay.origin, myRay.direction, Color.green);
            }
        }
        */

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {

                    Debug.DrawRay(rays[i, j, k].origin, rays[i, j, k].direction, Color.red);

                    if (Physics.Raycast(rays[i, j, k].origin, rays[i, j, k].direction, out RaycastHit hit, 10f))
                    {
                        //Debug.Log($"Ray hit: {hit.collider.name}");

                        if (hit.collider.name == solvedState[i, j, k])
                        {
                            Debug.DrawRay(rays[i, j, k].origin, rays[i, j, k].direction, Color.green);
                        }
                        
                        currentCubeState[i, j, k] = hit.collider.name;
                        
                    }    
                }
            }
        }
    }


    public void WriteCurrentCubeState()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    Debug.Log($"Current Status of {i}, {j}, {k}: {currentCubeState[i, j, k]}");
                }
            }
        }
    }
}
