using System;
using UnityEngine;


public class DeletePiece : MonoBehaviour
{
    void OnMouseDown()
    {
        if (Create.pieceForPartForGeometricFigures.Length == 0 || Create.Piece == null)
            return;
        Create.i = Create.pieceForPartForGeometricFigures.Length;
        Create.pieces = new Piece[Create.i - 1];
        for(Create.s = Create.S = 0; Create.S < Create.i; Create.S++)
        {
            if (Create.pieceForPartForGeometricFigures[Create.S].name == Create.Piece.name)
            {
                Destroy(Create.pieceForPartForGeometricFigures[Create.S].gameObject);
                continue;
            }
            Create.pieces[Create.s] = Create.pieceForPartForGeometricFigures[Create.S];
            Create.s++;
        }
        Array.Clear(Create.pieceForPartForGeometricFigures, 0, Create.i);
        Create.pieceForPartForGeometricFigures = Create.pieces;
    }
}
