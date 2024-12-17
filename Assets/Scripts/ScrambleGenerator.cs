using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class ScrambleGenerator : MonoBehaviour
{
    private string[] faces = { "R", "L", "U", "D", "F", "B" };
    private string[] modifiers = { "", "", "'", "2" };

    public int scrambleLength = 20;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GenerateScramble()
    {
        StringBuilder scramble = new StringBuilder();
        string lastMove = "";

        for (int i = 0; i < scrambleLength; i++)
        {

            string move;
            do
            {
                move = faces[Random.Range(0, faces.Length)];
            } while (move == lastMove);

            string modifier = modifiers[Random.Range(0, modifiers.Length)];

            scramble.Append($"{move}{modifier} ");

            lastMove = move;

        }

        return scramble.ToString().Trim();
    }
}
