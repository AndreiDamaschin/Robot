using System;
using UnityEngine;


public class NewPart : MonoBehaviour
{
    void OnMouseDown()
    {
        if (!Create.geometricFigures.activeSelf && Create.partForGeometricFigures != null)
            Create.geometricFigures.SetActive(true);
        else if (Create.partForGeometricFigures == null)
        {
            Create.localEulerAngles.Set(0, 0, 0);
            Create.localPosition.Set(65, -40, -45);
            Create.geometricFigures.SetActive(true);
            Create.GameObject = new GameObject("PartForGeometricFigures");
            Create.partForGeometricFigures = Create.GameObject.AddComponent<Part>();
            Create.GameObject.transform.SetParent(Create.geometricFigures.transform);
            Create.GameObject.transform.localEulerAngles = Create.localEulerAngles;
            Create.GameObject.transform.localPosition = Create.localPosition;
            Create.GameObject.AddComponent<MeshRenderer>();
            Create.GameObject.AddComponent<MeshFilter>();
        }
        else if (Create.pieceForPartForGeometricFigures.Length > 0)
        {
            Create.i = Create.pieceForPartForGeometricFigures.Length;
            if (Create.partForGeometricFigures.name != "PartForGeometricFigures")
                Create.partForGeometricFigures.name = "PartForGeometricFigures";
            Create.partForGeometricFigures.transform.localEulerAngles.Set(0, 0, 0);
            for (Create.s = 0; Create.s < Create.i; Create.s++)
                Destroy(Create.pieceForPartForGeometricFigures[Create.s].gameObject);
            Array.Clear(Create.pieceForPartForGeometricFigures, 0, Create.i);
            Create.pieceForPartForGeometricFigures = new Piece[0];
        }
    }
}
