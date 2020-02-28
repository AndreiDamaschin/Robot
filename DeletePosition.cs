using System;
using UnityEngine;


public class DeletePosition : MonoBehaviour
{
    void OnMouseDown()
    {
        if (Create.textMeshNrOfPosition.text == "Nr")
            return;
        Create.i = Create.part.Length;
        Create.I = Create.move.GetLength(0);
        Create.Move = new float[Create.I - Create.i, 9];
        Create.s = (short)((int.Parse(Create.textMeshNrOfPosition.text) - 1) * Create.i);
        for (Create.S = Create.d = 0; Create.S < Create.I; Create.S++)
        {
            if (Create.S >= Create.s && Create.S < Create.s + Create.i)
                continue;
            Create.Move[Create.d, 0] = Create.move[Create.S, 0];
            Create.Move[Create.d, 1] = Create.move[Create.S, 1];
            Create.Move[Create.d, 2] = Create.move[Create.S, 2];
            Create.Move[Create.d, 3] = Create.move[Create.S, 3];
            Create.Move[Create.d, 4] = Create.move[Create.S, 4];
            Create.Move[Create.d, 5] = Create.move[Create.S, 5];
            Create.Move[Create.d, 6] = Create.move[Create.S, 6];
            Create.Move[Create.d, 7] = Create.move[Create.S, 7];
            Create.Move[Create.d, 8] = Create.move[Create.S, 8];
            Create.d++;
        }
        Array.Clear(Create.move, 0, Create.I);
        Create.textMeshNrOfPosition.text = "Nr";
        Create.move = Create.Move;
    }
}
