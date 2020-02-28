using UnityEngine;
using System.Threading;


public class Move : MonoBehaviour
{
    void OnMouseDrag()
    {
        Thread.Sleep(100);
        if (Create.space && Create.move != null && Create.move.GetLength(0) > 0)
        {
            Create.i = Create.part.Length;
            if (Create.m >= Create.move.GetLength(0))
                Create.m = 0;
            for (Create.s = 0; Create.s < Create.i; Create.s++, Create.m++)
            {
                Create.localScale.Set(Create.move[Create.m, 0], Create.move[Create.m, 1], Create.move[Create.m, 2]);
                Create.localPosition.Set(Create.move[Create.m, 3], Create.move[Create.m, 4], Create.move[Create.m, 5]);
                Create.localEulerAngles.Set(Create.move[Create.m, 6], Create.move[Create.m, 7], Create.move[Create.m, 8]);
                Create.part[Create.s].transform.localScale = Create.localScale;
                Create.part[Create.s].transform.localPosition = Create.localPosition;
                Create.part[Create.s].transform.localEulerAngles = Create.localEulerAngles;
            }
            Create.textMeshNrOfPosition.text = (Create.m / Create.s).ToString();
        }
    }
}