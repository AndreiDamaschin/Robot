using System;
using System.IO;
using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


public class Robot : MonoBehaviour
{
    GameObject parts;
    TextMesh textMeshData;
    GameObject pieceOrPart;
    GeometricFigure[] GeometricFigure;
    void Awake()
    {
        Create.part = new Part[0];
        Create.move = new float[0,0];
        Create.piece = new Piece[0][];
        parts = new GameObject("Parts");
        Create.parent = new float[0, 0];
        GeometricFigure = new GeometricFigure[4];
        Create.pieceForPartForGeometricFigures = new Piece[0];
        Create.geometricFigures = new GameObject("Geometric Figures");
    }

    void Start()
    {
        Create.b = 40;
        Type Class = null;
        Color color = Color.blue;
        if (File.Exists("Robot.space"))
        {
            try
            {
                Create.binaryFormatter = new BinaryFormatter();
                Create.fileStream = new FileStream("Robot.space", FileMode.Open);
                Create.hashtable = (Hashtable)Create.binaryFormatter.Deserialize(Create.fileStream);
                IEnumerator iEnumerator = Create.hashtable.Values.GetEnumerator();
                iEnumerator.MoveNext();
                Create.robot = (float[][,])iEnumerator.Current;
                Create.i = Create.robot.Length - 2;
                Create.part = new Part[Create.i];
                Create.piece = new Piece[Create.i][];
                Create.move = Create.robot[Create.i];
                Create.parent = Create.robot[Create.i + 1];
                for (Create.s = 0; Create.s < Create.i; Create.s++)
                {
                    Create.I = Create.robot[Create.s].GetLength(0);
                    Create.localPosition.Set(0, Create.s * -20, 0);
                    Create.combineInstance = new CombineInstance[Create.I];
                    Create.GameObject = new GameObject((Create.s + 1).ToString());
                    Create.piece[Create.s] = new Piece[Create.I];
                    Create.GameObject.AddComponent<MeshRenderer>();
                    Create.GameObject.transform.SetParent(parts.transform);
                    Create.part[Create.s] = Create.GameObject.AddComponent<Part>();
                    Create.meshFilter = Create.GameObject.AddComponent<MeshFilter>();
                    Create.GameObject.transform.localPosition = Create.localPosition;
                    for (Create.S = 0; Create.S < Create.I; Create.S++)
                    {
                        Create.GameObject = GameObject.CreatePrimitive((PrimitiveType)(Create.robot[Create.s][Create.S, 0]));
                        Create.GameObject.transform.SetParent(Create.part[Create.s].transform);
                        Create.GameObject.name = $"{(Create.s + 1).ToString()}.{(Create.S + 1).ToString()}";
                        Create.combineInstance[Create.S].mesh = Create.GameObject.GetComponent<MeshFilter>().sharedMesh;
                        Create.localScale.Set(Create.robot[Create.s][Create.S, 1], Create.robot[Create.s][Create.S, 2], Create.robot[Create.s][Create.S, 3]);
                        Create.localPosition.Set(Create.robot[Create.s][Create.S, 4], Create.robot[Create.s][Create.S, 5], Create.robot[Create.s][Create.S, 6]);
                        Create.localEulerAngles.Set(Create.robot[Create.s][Create.S, 7], Create.robot[Create.s][Create.S, 8], Create.robot[Create.s][Create.S, 9]);
                        Create.piece[Create.s][Create.S] = Create.GameObject.AddComponent<Piece>().GetData((PrimitiveType)(Create.robot[Create.s][Create.S, 0]), false);
                        Create.GameObject.GetComponent<Renderer>().material.color = new Color(Create.robot[Create.s][Create.S, 10], Create.robot[Create.s][Create.S, 11], Create.robot[Create.s][Create.S, 12]);
                        Create.combineInstance[Create.S].transform = Matrix4x4.TRS(Create.localPosition, Quaternion.Euler(Create.localEulerAngles.x, Create.localEulerAngles.y, Create.localEulerAngles.z), Create.localScale);
                        Create.GameObject.transform.localEulerAngles = Create.localEulerAngles;
                        Create.GameObject.transform.localPosition = Create.localPosition;
                        Create.GameObject.transform.localScale = Create.localScale;
                    }
                    Create.MeshFilter = Create.piece[Create.s][0].GetComponent<MeshFilter>();
                    Create.MeshFilter.mesh.CombineMeshes(Create.combineInstance);
                    Create.meshFilter.mesh = Create.MeshFilter.sharedMesh;
                    Create.MeshFilter.mesh = Create.combineInstance[0].mesh;
                    Create.part[Create.s].gameObject.AddComponent<MeshCollider>();
                }
            }
            catch (SerializationException ex)
            {
                Debug.Log(ex.Message);
            }
            finally
            {
                Create.fileStream.Close();
                Create.fileStream.Dispose();
                if (Create.hashtable != null)
                {
                    Create.hashtable.Clear();
                    Array.Clear(Create.robot, 0, Create.i + 2);
                    Create.UI = new GameObject[Create.i + Configurations.lenghtButtonsUI];
                }
            }
        }
        else
        {
            Create.i = 0;
            Create.UI = new GameObject[Configurations.lenghtButtonsUI];
        }
        Create.ui = (short)Create.UI.Length;
        for (Create.s = 0; Create.s < Create.ui; Create.s++)
        {
            if (Create.s < Configurations.lenghtButtonsUI)
            {
                switch (Create.s)
                {
                    case 0:
                        Create.localPosition.Set(0, 0, 95);
                        Create.UI[Create.s] = new GameObject("UI");
                        Create.UI[Create.s].transform.SetParent(transform);
                        Create.UI[Create.s].transform.localPosition = Create.localPosition;
                        goto Continue;
                    case 1:
                        Class = typeof(NewPart);
                        Create.name = "Upload";
                        Create.localPosition.Set(-35, 50, 0);
                        break;
                    case 2:
                        Class = typeof(NewPart);
                        Create.name = "New";
                        Create.localPosition.Set(-20, 50, 0);
                        break;
                    case 3:
                        Class = typeof(DeletePart);
                        Create.name = "Delete";
                        Create.localPosition.Set(-10, 50, 0);
                        break;
                    case 4:
                        Create.name = "Save";
                        Class = typeof(Save);
                        Create.localPosition.Set(20, 50, 0);
                        break;
                    case 5:
                        Create.name = "Space";
                        Class = typeof(Space);
                        Create.localPosition.Set(35, 50, 0);
                        break;
                    case 6:
                        Create.localPosition.Set(50, 45, 0);
                        Create.UI[Create.s] = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                        Create.UI[Create.s].GetComponent<Renderer>().material.color = Color.blue;
                        Create.UI[Create.s].transform.localScale = Create.UI[0].transform.localScale * 5;
                        Create.UI[Create.s].transform.SetParent(Create.UI[0].transform);
                        Create.UI[Create.s].transform.localPosition = Create.localPosition;
                        Create.UI[Create.s].AddComponent<Scroll>();
                        Create.UI[Create.s].name = "Scroll";
                        goto Continue;
                    case 7:
                        Create.name = "Position";
                        Class = typeof(Position);
                        Create.localPosition.Set(-80, -35, 0);
                        break;
                    case 8:
                        Create.name = "X+";
                        Class = typeof(Position);
                        Create.localPosition.Set(-80, -45, 0);
                        break;
                    case 9:
                        Create.name = "X-";
                        Class = typeof(Position);
                        Create.localPosition.Set(-80, -40, 0);
                        break;
                    case 10:
                        Create.name = "Y+";
                        Class = typeof(Position);
                        Create.localPosition.Set(-75, -45, 0);
                        break;
                    case 11:
                        Create.name = "Y-";
                        Class = typeof(Position);
                        Create.localPosition.Set(-75, -40, 0);
                        break;
                    case 12:
                        Create.name = "Z+";
                        Class = typeof(Position);
                        Create.localPosition.Set(-70, -45, 0);
                        break;
                    case 13:
                        Create.name = "Z-";
                        Class = typeof(Position);
                        Create.localPosition.Set(-70, -40, 0);
                        break;
                    case 14:
                        Create.name = "Rotate";
                        Class = typeof(Rotation);
                        Create.localPosition.Set(-65, -35, 0);
                        break;
                    case 15:
                        Create.name = "X+";
                        Class = typeof(Rotation);
                        Create.localPosition.Set(-65, -45, 0);
                        break;
                    case 16:
                        Create.name = "X-";
                        Class = typeof(Rotation);
                        Create.localPosition.Set(-65, -40, 0);
                        break;
                    case 17:
                        Create.name = "Y+";
                        Class = typeof(Rotation);
                        Create.localPosition.Set(-60, -45, 0);
                        break;
                    case 18:
                        Create.name = "Y-";
                        Class = typeof(Rotation);
                        Create.localPosition.Set(-60, -40, 0);
                        break;
                    case 19:
                        Create.name = "Z+";
                        Class = typeof(Rotation);
                        Create.localPosition.Set(-55, -45, 0);
                        break;
                    case 20:
                        Create.name = "Z-";
                        Class = typeof(Rotation);
                        Create.localPosition.Set(-55, -40, 0);
                        break;
                    case 21:
                        Create.name = "Scale";
                        Class = typeof(Scale);
                        Create.localPosition.Set(-50, -35, 0);
                        break;
                    case 22:
                        Create.name = "X+";
                        Class = typeof(Scale);
                        Create.localPosition.Set(-50, -45, 0);
                        break;
                    case 23:
                        Create.name = "X-";
                        Class = typeof(Scale);
                        Create.localPosition.Set(-50, -40, 0);
                        break;
                    case 24:
                        Create.name = "Y+";
                        Class = typeof(Scale);
                        Create.localPosition.Set(-45, -45, 0);
                        break;
                    case 25:
                        Create.name = "Y-";
                        Class = typeof(Scale);
                        Create.localPosition.Set(-45, -40, 0);
                        break;
                    case 26:
                        Create.name = "Z+";
                        Class = typeof(Scale);
                        Create.localPosition.Set(-40, -45, 0);
                        break;
                    case 27:
                        Create.name = "Z-";
                        Class = typeof(Scale);
                        Create.localPosition.Set(-40, -40, 0);
                        break;
                    case 28:
                        Class = typeof(RGB);
                        Create.name = "Material";
                        Create.localPosition.Set(-35, -35, 0);
                        break;
                    case 29:
                        Create.name = "R+";
                        Class = typeof(RGB);
                        Create.localPosition.Set(-35, -45, 0);
                        break;
                    case 30:
                        Create.name = "R-";
                        Class = typeof(RGB);
                        Create.localPosition.Set(-35, -40, 0);
                        break;
                    case 31:
                        Create.name = "G+";
                        Class = typeof(RGB);
                        Create.localPosition.Set(-30, -45, 0);
                        break;
                    case 32:
                        Create.name = "G-";
                        Class = typeof(RGB);
                        Create.localPosition.Set(-30, -40, 0);
                        break;
                    case 33:
                        Create.name = "B+";
                        Class = typeof(RGB);
                        Create.localPosition.Set(-25, -45, 0);
                        break;
                    case 34:
                        Create.name = "B-";
                        Class = typeof(RGB);
                        Create.localPosition.Set(-25, -40, 0);
                        break;
                    case 35:
                        Create.name = "<";
                        Class = typeof(Rotate);
                        Create.localPosition.Set(40, -42.5f, 0);
                        break;
                    case 36:
                        Create.name = ">";
                        Class = typeof(Rotate);
                        Create.localPosition.Set(50, -42.5f, 0);
                        break;
                    case 37:
                        Create.name = "+";
                        Class = typeof(Rotate);
                        Create.localPosition.Set(45, -45, 0);
                        break;
                    case 38:
                        Create.name = "^";
                        Class = typeof(Rotate);
                        Create.localPosition.Set(45, -40, 0);
                        break;
                    case 39:
                        Create.b = 25;
                        color = Color.red;
                        Create.name = "Data";
                        Class = typeof(Rotate);
                        Create.localPosition.Set(55, -40, 0);
                        break;
                    case 40:
                        Create.b = 40;
                        color = Color.blue;
                        Class = typeof(SetParent);
                        Create.name = "Piece";
                        Create.localPosition.Set(20, -40, 0);
                        break;
                    case 41:
                        color = Color.blue;
                        Class = typeof(SetParent);
                        Create.name = "0";
                        Create.localPosition.Set(35, -40, 0);
                        break;
                    case 42:
                        color = Color.blue;
                        Class = typeof(SetParent);
                        Create.name = "Part";
                        Create.localPosition.Set(20, -45, 0);
                        break;
                    case 43:
                        Create.name = "0";
                        Class = typeof(SetParent);
                        Create.localPosition.Set(35, -45, 0);
                        break;
                    case 44:
                        color = Color.blue;
                        Create.name = "Delete";
                        Class = typeof(DeletePiece);
                        Create.localPosition.Set(20, -35, 0);
                        break;
                    case 45:
                        Create.name = "Forward";
                        Class = typeof(Move);
                        Create.localPosition.Set(15, -115, 0);
                        break;
                    case 46:
                        Create.name = "Back";
                        Class = typeof(Move);
                        Create.localPosition.Set(15, -120, 0);
                        break;
                    case 47:
                        Create.name = "Play";
                        Class = typeof(SetPosition);
                        Create.localPosition.Set(30, -115, 0);
                        Create.UI[Create.s - 1].SetActive(false);
                        break;
                    case 48:
                        Create.name = "Stop";
                        Class = typeof(SetPosition);
                        Create.localPosition.Set(30, -120, 0);
                        Create.UI[Create.s - 1].SetActive(false);
                        break;
                    case 49:
                        Create.name = "Edit";
                        Class = typeof(Edit);
                        Create.localPosition.Set(35, 125, 0);
                        Create.UI[Create.s - 1].SetActive(false);
                        break;
                    case 50:
                        Create.name = "Nr";
                        Class = typeof(UI);
                        Create.localPosition.Set(-80, 125, 0);
                        Create.UI[Create.s - 1].SetActive(false);
                        break;
                    case 51:
                        Create.name = "Reset";
                        Class = typeof(ResetPosition);
                        Create.localPosition.Set(-70, 125, 0);
                        Create.UI[Create.s - 1].SetActive(false);
                        break;
                    case 52:
                        Create.name = "Delete";
                        Class = typeof(DeletePosition);
                        Create.localPosition.Set(-55, 125, 0);
                        Create.UI[Create.s - 1].SetActive(false);
                        break;
                    case 53:
                        Class = typeof(SetPosition);
                        Create.name = "Set";
                        Create.localPosition.Set(-40, 125, 0);
                        Create.UI[Create.s - 1].SetActive(false);
                        break;
                }
            }
            else
                if (Create.i > 0)
                {
                    Create.b = 20;
                    color = Color.red;
                    Class = typeof(Data);
                    Create.UI[Create.s - 1].SetActive(false);
                    Create.name = $"{(Create.s - Configurations.lenghtButtonsUI + 1).ToString()}";
                    Create.localPosition.Set(Create.part[Create.s - Configurations.lenghtButtonsUI].transform.localPosition.x - 15, Create.part[Create.s - Configurations.lenghtButtonsUI].transform.localPosition.y + 45, Create.part[Create.s - Configurations.lenghtButtonsUI].transform.localPosition.z - 45);
                }
            Create.UI[Create.s] = new GameObject(Create.name);
            textMeshData = Create.UI[Create.s].AddComponent<TextMesh>();
            Create.UI[Create.s].transform.SetParent(Create.UI[0].transform);
            Create.UI[Create.s].transform.localPosition = Create.localPosition;
            textMeshData.fontSize = Create.b;
            textMeshData.text = Create.name;
            textMeshData.color = color;
            Create.UI[Create.s].AddComponent(Class);
            Create.UI[Create.s].AddComponent<BoxCollider>();
            Continue: continue;
        }
        Create.s = 0;
        Create.localScale.Set(-75, 45, 95);
        Create.localPosition.Set(75, 45, 50);
        parts.transform.SetParent(transform);
        Create.geometricFigures.SetActive(false);
        Create.UI[Create.ui - 1].SetActive(false);
        Create.parts = parts.AddComponent<Part>();
        parts.transform.localPosition = Create.localPosition;
        textMeshData = Create.UI[39].GetComponent<TextMesh>();
        Create.geometricFigures.transform.SetParent(transform);
        Create.geometricFigures.transform.localPosition = Create.localScale;
        Create.textMeshNrOfPosition = Create.UI[50].GetComponent<TextMesh>();
        for (Create.b = 0; Create.b < 4; Create.b++)
        {
            Create.localPosition.Set(Create.s, 0, 0);
            Create.GameObject = GameObject.CreatePrimitive((PrimitiveType)(Create.b));
            Create.GameObject.transform.localScale = Create.geometricFigures.transform.localScale * 5;
            GeometricFigure[Create.b] = Create.GameObject.AddComponent<GeometricFigure>().GetData((PrimitiveType)(Create.b));
            Create.GameObject.transform.SetParent(Create.geometricFigures.transform);
            Create.GameObject.GetComponent<Renderer>().material.color = Color.black;
            Create.GameObject.transform.localPosition = Create.localPosition;
            Create.s += 10;
        }
    }
    
    void LateUpdate()
    {
        if (Create.space && Create.Part != null)
            pieceOrPart = Create.Part.gameObject;
        else if (!Create.space && Create.Piece != null)
            pieceOrPart = Create.Piece.gameObject;
        else 
            pieceOrPart = null;
        if (Create.localRotate == true)
            typeof(Create).GetMethod("Rotate").Invoke(null, null);
        for (Create.b = 0; Create.b < 4; Create.b++)
            GeometricFigure[Create.b].MyUpdate();
        if (Create.spaceTranslate)
        {
            Create.UI[45].SetActive(true);
            Create.UI[46].SetActive(true);
            Create.UI[47].SetActive(true);
            Create.UI[48].SetActive(true);
            Create.UI[49].SetActive(true);
            Create.UI[50].SetActive(true);
            Create.UI[51].SetActive(true);
            Create.UI[52].SetActive(true);
            Create.UI[53].SetActive(true);
            Create.parts.transform.Translate(-50 * Time.deltaTime, 0, 0);
            Create.geometricFigures.transform.Translate(-50 * Time.deltaTime, 0, 0);
            for (Create.s = 1; Create.s < Configurations.lenghtButtonsUI; Create.s++)
            {
               if (Create.s > 44 && Create.s < 49)
                   Create.UI[Create.s].transform.Translate(0, 50 * Time.deltaTime, 0);
               else if(Create.s > 48 && Create.s < 54)
                   Create.UI[Create.s].transform.Translate(0, -50 * Time.deltaTime, 0);
               else if (Create.s < 45)
                {
                    if (Create.s < 6 && Create.s != 4)
                        Create.UI[Create.s].transform.Translate(0, 50 * Time.deltaTime, 0);
                    else if (Create.s > 27 && Create.s < 35 || Create.s == 40 || Create.s == 41 || Create.s == 42 || Create.s == 43 || Create.s == 44)
                        Create.UI[Create.s].transform.Translate(0, -50 * Time.deltaTime, 0);
                }
            }
            if (Create.parts.transform.localPosition.x <= 0)
            {
                Create.spaceTranslate = false;
                Create.geometricFigures.SetActive(false);
                for (Create.s = Configurations.lenghtButtonsUI; Create.s < Create.ui; Create.s++)
                    Create.UI[Create.s].SetActive(true);
                for (Create.b = 1; Create.b < Configurations.lenghtCreate; Create.b++)
                    if (Create.b > 27 && Create.b < 35 || Create.b < 6 && Create.b != 4 || Create.b == 40 || Create.b == 41 || Create.s == 42 || Create.s == 43 || Create.s == 44)
                        Create.UI[Create.b].SetActive(false);
            }
        }
        if (Create.editTranslate)
        {
            Create.parts.transform.Translate(50 * Time.deltaTime, 0, 0);
            Create.geometricFigures.transform.Translate(50 * Time.deltaTime, 0, 0);
            for (Create.b = 1; Create.b < Configurations.lenghtCreate; Create.b++)
                if (Create.b > 27 && Create.b < 35 || Create.b < 6 && Create.b != 4 || Create.b == 40 || Create.b == 41 || Create.s == 42 || Create.s == 42 || Create.s == 44)
                    Create.UI[Create.b].SetActive(true);
            for (Create.s = 1; Create.s < Configurations.lenghtButtonsUI; Create.s++)
            {
                if (Create.s > 48 && Create.s < 54)
                    Create.UI[Create.s].transform.Translate(0, 50 * Time.deltaTime, 0);
                else if (Create.s > 44 && Create.s < 49)
                    Create.UI[Create.s].transform.Translate(0, -50 * Time.deltaTime, 0);
                else if (Create.s < 45)
                {
                    if (Create.s < 6 && Create.s != 4)
                        Create.UI[Create.s].transform.Translate(0, -50 * Time.deltaTime, 0);
                    else if (Create.s > 27 && Create.s < 35 || Create.s == 40 || Create.s == 41 || Create.s == 42 || Create.s == 43 || Create.s == 44)
                        Create.UI[Create.s].transform.Translate(0, 50 * Time.deltaTime, 0);
                }
            }
            for (Create.s = Configurations.lenghtButtonsUI; Create.s < Create.ui; Create.s++)
                Create.UI[Create.s].SetActive(false);
            if (Create.parts.transform.localPosition.x >= 75)
            {
                Create.editTranslate = false;
                Create.UI[45].SetActive(false);
                Create.UI[46].SetActive(false);
                Create.UI[47].SetActive(false);
                Create.UI[48].SetActive(false);
                Create.UI[49].SetActive(false);
                Create.UI[50].SetActive(false);
                Create.UI[51].SetActive(false);
                Create.UI[52].SetActive(false);
                Create.UI[53].SetActive(false);
            }
        }
        if (pieceOrPart != null)
            textMeshData.text = $"P X:{pieceOrPart.transform.localPosition.x.ToString()}Y:{pieceOrPart.transform.localPosition.y.ToString()}Z:{pieceOrPart.transform.localPosition.z.ToString()}{Environment.NewLine}R X:{pieceOrPart.transform.localEulerAngles.x.ToString()}Y:{pieceOrPart.transform.localEulerAngles.y.ToString()}Z:{pieceOrPart.transform.localEulerAngles.z.ToString()}{Environment.NewLine}S X:{pieceOrPart.transform.localScale.x.ToString()}Y:{pieceOrPart.transform.localScale.y.ToString()}Z:{pieceOrPart.transform.localScale.z.ToString()}";
    }
}
