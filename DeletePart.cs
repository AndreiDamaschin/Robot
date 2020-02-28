using System;
using UnityEngine;


public class DeletePart : MonoBehaviour
{
    void OnMouseDown()
    {
        if (Create.partForGeometricFigures == null || Create.partForGeometricFigures.name == "PartForGeometricFigures" || Create.partForGeometricFigures.name == "Delete")
            return;
        Create.i = Create.part.Length;
        Create.Parts = new Part[Create.i - 1];
        Create.Parent = new float[1, Create.i];
        Create.Pieces = new Piece[Create.i - 1][];
        Create.I = Create.pieceForPartForGeometricFigures.Length;
        if (Create.i == 1)
            Create.d = 0;
        else
        {
            for (Create.s = Create.S = 0; Create.S < Create.i; Create.S++)
            {
                if (Create.part[Create.S].name == Create.partForGeometricFigures.name)
                {
                    Create.d = Create.S;
                    continue;
                }
                Create.localPosition.Set(0, Create.s * -20, 0);
                Create.Parts[Create.s] = Create.part[Create.S];
                Create.Pieces[Create.s] = Create.piece[Create.S];
                Create.Parts[Create.s].name = (Create.s + 1).ToString();
                Create.Parts[Create.s].transform.localPosition = Create.localPosition;
                Create.s++;
            }
        }
        Create.pieces = Create.piece[Create.d];
        Destroy(Create.part[Create.d].gameObject);
        for (Create.s = 0; Create.s < Create.I; Create.s++)
            Destroy(Create.pieceForPartForGeometricFigures[Create.s].gameObject);
        for (Create.s = Create.S = 0; Create.S < Create.i + 1; Create.S++)
        {
            if (Create.s == Create.d)
                continue;
            if (Create.d + 1 < Create.parent[0, Create.S])
                Create.Parent[0, Create.s] = Create.parent[0, Create.S] - 1;
            else if (Create.d + 1 > Create.parent[0, Create.S])
                Create.Parent[0, Create.s] = Create.parent[0, Create.S];
            else if (Create.d + 1 == Create.parent[0, Create.S])
                Create.Parent[0, Create.s] = 0;
            Create.s++;
        }
        Array.Clear(Create.pieceForPartForGeometricFigures, 0, Create.I);
        Create.pieceForPartForGeometricFigures = new Piece[0];
        for (Create.s = 0; Create.s < Create.I; Create.s++)
            Destroy(Create.pieces[Create.s].gameObject);
        Create.partForGeometricFigures.name = "Delete";
        Array.Clear(Create.parent, 0, Create.i + 1);
        Create.geometricFigures.SetActive(false);
        Array.Clear(Create.piece, 0, Create.i);
        Array.Clear(Create.part, 0, Create.i);
        Create.parent = Create.Parent;
        Create.piece = Create.Pieces;
        Create.part = Create.Parts;
    }
}
