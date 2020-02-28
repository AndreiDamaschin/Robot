using System.IO;
using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;


public static class Create
{
    public static int i;
    public static int I;
    public static byte b;
    public static byte B;
    public static short d;
    public static short m;
    public static short s;
    public static short S;
    public static short ui;
    public static Part Part;
    public static Part parts;
    public static bool space;
    public static string name;
    public static Piece Piece;
    public static Part[] part;
    public static Part[] Parts;
    public static float[,] move;
    public static float[,] Move;
    public static float x, y, z;
    public static Piece[] pieces;
    public static bool setParent;
    public static float[,] parent;
    public static float[,] Parent;
    public static GameObject[] UI;
    public static Piece[][] piece;
    public static Piece[][] Pieces;
    public static bool localRotate;
    public static float[][,] robot;
    public static Vector3 localScale;
    public static bool editTranslate;
    public static bool spaceTranslate;
    public static Hashtable hashtable;
    public static MeshFilter meshFilter;
    public static MeshFilter MeshFilter;
    public static Vector3 localPosition;
    public static GameObject GameObject;
    static float angleX, angleY, angleZ;
    public static FileStream fileStream;
    public static Vector3 localEulerAngles;
    public static GameObject geometricFigures;
    public static Part partForGeometricFigures;
    public static TextMesh textMeshNrOfPosition;
    public static BinaryFormatter binaryFormatter;
    public static CombineInstance[] combineInstance;
    public static Piece[] pieceForPartForGeometricFigures;

    public static void Rotate()
    {
        B++;
        if (B >= 19)
        {
            B = 0;
            x = y = z = 0;
            localRotate = false;
        }
        if (!space)
            partForGeometricFigures.transform.Rotate(x, y, z);
        else
            parts.transform.Rotate(x, y, z);
    }

    public static Vector3 Position(Vector3 localPosition, bool pieceOrPart)
    {
        x = Input.GetAxis("Mouse X") * 200 * Time.deltaTime;
        y = Input.GetAxis("Mouse Y") * 200 * Time.deltaTime;
        if (pieceOrPart)
        {
            angleX = partForGeometricFigures.transform.localEulerAngles.x;
            angleY = partForGeometricFigures.transform.localEulerAngles.y;
            angleZ = partForGeometricFigures.transform.localEulerAngles.z;
        }
        else
        {
            angleX = parts.transform.localEulerAngles.x;
            angleY = parts.transform.localEulerAngles.y;
            angleZ = parts.transform.localEulerAngles.z;
        }
        if (angleY > -10 && angleY < 10)
        {
            if (angleX > 80 && angleX < 100)
            {
                localPosition.x += x;
                localPosition.z += -y;
            }
            else if (angleX > 260 && angleX < 280)
            {
                localPosition.x += x;
                localPosition.z += y;
            }
            else if (angleZ > 170 && angleZ < 190)
            {
                localPosition.x += -x;
                localPosition.y += -y;
            }
            else
            {
                localPosition.x += x;
                localPosition.y += y;
            }
        }
        else if (angleY > 80 && angleY < 100)
        {
            if (angleX > 80 && angleX < 100)
            {
                localPosition.y += x;
                localPosition.z += -y;
            }
            else if (angleX > 260 && angleX < 280)
            {
                localPosition.y += -x;
                localPosition.z += y;
            }
            else if (angleZ > 170 && angleZ < 190)
            {
                localPosition.y += -y;
                localPosition.z += x;
            }
            else
            {
                localPosition.y += y;
                localPosition.z += x;
            }
        }
        else if (angleY > 170 && angleY < 190)
        {
            if (angleX > 80 && angleX < 100)
            {
                localPosition.x += -x;
                localPosition.z += -y;
            }
            else if (angleX > 260 && angleX < 280)
            {
                localPosition.x += -x;
                localPosition.z += y;
            }
            else if (angleZ > 170 && angleZ < 190)
            {
                localPosition.y += -y;
                localPosition.x += x;
            }
            else
            {
                localPosition.y += y;
                localPosition.x += -x;
            }
        }
        else
        {
            if (angleX > 80 && angleX < 100)
            {
                localPosition.y += -x;
                localPosition.z += -y;
            }
            else if (angleX > 260 && angleX < 280)
            {
                localPosition.y += x;
                localPosition.z += y;
            }
            else if (angleZ > 170 && angleZ < 190)
            {
                localPosition.y += -y;
                localPosition.z += -x;
            }
            else
            {
                localPosition.y += y;
                localPosition.z += -x;
            }
        }
        x = y = 0;
        return localPosition;
    }
}