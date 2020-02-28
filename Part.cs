using System;
using UnityEngine;


public class Part : MonoBehaviour
{
    float x, y, z;
    Transform transformData;
    public Vector3 localScale;
    public Vector3 localPosition;
    public float localRotationX, localRotationY, localRotationZ;

    void OnMouseDown()
    {
        if (!Create.space && Create.setParent)
        {
            Create.setParent = false;
            Create.s = short.Parse(name);
            Create.UI[11].GetComponent<TextMesh>().text = name;
            Create.x = int.Parse(Create.partForGeometricFigures.name) - 1;
            if (Create.x != Create.s - 1)
                Create.parent[0, (int)Create.x] = Create.s;
            Create.x = 0;
        }
        else if (!Create.space && !Create.setParent)
        {
            if (Create.pieceForPartForGeometricFigures.Length > 0)
            {
                Destroy(Create.partForGeometricFigures.gameObject);
                for (Create.s = 0; Create.s < Create.pieceForPartForGeometricFigures.Length; Create.s++)
                    Destroy(Create.pieceForPartForGeometricFigures[Create.s].gameObject);
                Array.Clear(Create.pieceForPartForGeometricFigures, 0, Create.pieceForPartForGeometricFigures.Length);
            }
            else if (!Create.geometricFigures.activeSelf && Create.partForGeometricFigures != null)
            {
                Create.geometricFigures.SetActive(true);
                Destroy(Create.partForGeometricFigures.gameObject);
            }
            else if (!Create.geometricFigures.activeSelf && Create.partForGeometricFigures == null)
                Create.geometricFigures.SetActive(true);
            else
                Destroy(Create.partForGeometricFigures.gameObject);
            Create.localEulerAngles.Set(0, 0, 0);
            Create.localPosition.Set(65, -40, -45);
            Create.partForGeometricFigures = Instantiate(gameObject, Create.geometricFigures.transform).GetComponent<Part>();
            Create.pieceForPartForGeometricFigures = Create.partForGeometricFigures.GetComponentsInChildren<Piece>();
            Create.UI[11].GetComponent<TextMesh>().text = Create.parent[0, short.Parse(name) - 1].ToString();
            Create.partForGeometricFigures.transform.localEulerAngles = Create.localEulerAngles;
            Create.partForGeometricFigures.transform.localPosition = Create.localPosition;
            Create.partForGeometricFigures.GetComponent<SphereCollider>().enabled = false;
            Create.partForGeometricFigures.name = name;
            for (Create.s = 0; Create.s < Create.pieceForPartForGeometricFigures.Length; Create.s++)
            {
                Create.pieceForPartForGeometricFigures[Create.s].name = (Create.s + 1).ToString();
                Create.pieceForPartForGeometricFigures[Create.s].GetComponent<Collider>().enabled = true;
            }
        }
    }

    void OnMouseDrag()
    {
        if (Create.space)
        {
            if (transformData == null)
            {
                if (Create.Part == null)
                    Create.Part = this;
                localScale = transform.localScale;
                localPosition = transform.localPosition;
                transformData = Create.UI[short.Parse(name) + Configurations.lenghtButtonsUI - 1].transform;
            }
            else if (Create.Part != this)
                Create.Part = this;
            else
            {
                transform.localPosition = localPosition = Create.Position(localPosition, false);
                Create.localPosition.Set(localPosition.x - 15, localPosition.y + 45, localPosition.z - 45);
                transformData.localPosition = Create.localPosition;
            }
        }
    }

    void OnMouseOver()
    {
        if (!Create.space)
            transform.Rotate(0, 5, 0);
    }
}
