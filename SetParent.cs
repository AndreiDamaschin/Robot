using UnityEngine;


public class SetParent : MonoBehaviour
{
    void OnMouseDown()
    {
        if (Create.pieceForPartForGeometricFigures.Length > 0 && Create.partForGeometricFigures.name != "PartForGeometricFigures")
            Create.setParent = true;
    }
}
