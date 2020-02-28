using System;
using UnityEngine;


public class GeometricFigure : MonoBehaviour
{
    public PrimitiveType primitiveType;

    void OnMouseDown()
    {
        Create.localScale.Set(5, 5, 5);
        Create.GameObject = GameObject.CreatePrimitive(primitiveType);
        Create.S = (short)Create.pieceForPartForGeometricFigures.Length;
        Create.localPosition.Set(transform.localPosition.x - 65, 25, 10);
        Create.GameObject.transform.SetParent(Create.partForGeometricFigures.transform);
        Create.GameObject.GetComponent<Renderer>().material.color = Color.black;
        Create.GameObject.transform.localPosition = Create.localPosition;
        Create.GameObject.transform.localScale = Create.localScale;
        Create.GameObject.name = $"{(Create.S + 1).ToString()}";
        Create.pieces = new Piece[Create.S + 1];
        for (Create.s = 0; Create.s < Create.S; Create.s++)
            Create.pieces[Create.s] = Create.pieceForPartForGeometricFigures[Create.s];
        Create.pieces[Create.S] = Create.GameObject.AddComponent<Piece>().GetData(primitiveType, true);
        Array.Clear(Create.pieceForPartForGeometricFigures, 0, Create.S);
        Create.pieceForPartForGeometricFigures = Create.pieces;
    }

    public void MyUpdate()
    {
        transform.Rotate(0, 0.5f, 0);
    }

    public GeometricFigure GetData(PrimitiveType primitiveType)
    {
        this.primitiveType = primitiveType;
        return this;
    }
}
