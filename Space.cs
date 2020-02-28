using System;
using UnityEngine;


public class Space : MonoBehaviour
{
    void OnMouseDown()
    {
        Create.space = true;
        Create.spaceTranslate = true;
        Create.I = Create.part.Length;
        Create.i = Create.pieceForPartForGeometricFigures.Length;
        if (Create.partForGeometricFigures != null)
            Create.partForGeometricFigures.name = "PartForGeometricFigures";
        for (Create.s = 0; Create.s < Create.i; Create.s++)
            Destroy(Create.pieceForPartForGeometricFigures[Create.s].gameObject);
        for (Create.s = 0; Create.s < Create.I; Create.s++)
        {
            if (Create.move.GetLength(0) > 0)
            {
                Create.localScale.Set(Create.move[Create.s, 0], Create.move[Create.s, 1], Create.move[Create.s, 2]);
                Create.localPosition.Set(Create.move[Create.s, 3], Create.move[Create.s, 4], Create.move[Create.s, 5]);
                Create.localEulerAngles.Set(Create.move[Create.s, 6], Create.move[Create.s, 7], Create.move[Create.s, 8]);
                Create.part[Create.s].transform.localScale = Create.localScale;
                Create.part[Create.s].transform.localPosition = Create.localPosition;
                Create.part[Create.s].transform.localEulerAngles = Create.localEulerAngles;
            }
            if (Create.parent[0, Create.s] - 1 != -1)
                Create.part[Create.s].transform.SetParent(Create.part[(int)Create.parent[0, Create.s] - 1].transform);
        }
        Array.Clear(Create.pieceForPartForGeometricFigures, 0, Create.i);
        Create.pieceForPartForGeometricFigures = new Piece[0];
    }
}
