using System;
using UnityEngine;


public class SetPosition : MonoBehaviour
{
    void OnMouseDown()
    {
        if (Create.part.Length == 0)
            return;
        Create.i = Create.part.Length;
        Create.I = Create.move.GetLength(0);
        Create.Move = new float[Create.I + Create.i, 9];
        for (Create.s = 0; Create.s < Create.I; Create.s++)
        {
            Create.Move[Create.s, 0] = Create.move[Create.s, 0];
            Create.Move[Create.s, 1] = Create.move[Create.s, 1];
            Create.Move[Create.s, 2] = Create.move[Create.s, 2];
            Create.Move[Create.s, 3] = Create.move[Create.s, 3];
            Create.Move[Create.s, 4] = Create.move[Create.s, 4];
            Create.Move[Create.s, 5] = Create.move[Create.s, 5];
            Create.Move[Create.s, 6] = Create.move[Create.s, 6];
            Create.Move[Create.s, 7] = Create.move[Create.s, 7];
            Create.Move[Create.s, 8] = Create.move[Create.s, 8];
        }
        for (Create.S = 0; Create.S < Create.i; Create.S++, Create.s++)
        {
            Create.Move[Create.s, 0] = Create.part[Create.S].transform.localScale.x;
            Create.Move[Create.s, 1] = Create.part[Create.S].transform.localScale.y;
            Create.Move[Create.s, 2] = Create.part[Create.S].transform.localScale.z;
            Create.Move[Create.s, 3] = Create.part[Create.S].transform.localPosition.x;
            Create.Move[Create.s, 4] = Create.part[Create.S].transform.localPosition.y;
            Create.Move[Create.s, 5] = Create.part[Create.S].transform.localPosition.z;
            Create.Move[Create.s, 6] = Create.part[Create.S].transform.localEulerAngles.x;
            Create.Move[Create.s, 7] = Create.part[Create.S].transform.localEulerAngles.y;
            Create.Move[Create.s, 8] = Create.part[Create.S].transform.localEulerAngles.z;
        }
        Array.Clear(Create.move, 0, Create.I);
        Create.move = Create.Move;
    }
}
                                         
                                         