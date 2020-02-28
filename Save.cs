using System;
using System.IO;
using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


public class Save : MonoBehaviour
{
    void OnMouseDown()
    {
        if (!Create.space && (Create.pieceForPartForGeometricFigures.Length > 0 || Create.partForGeometricFigures.name == "Delete") || Create.space && Create.part.Length > 0)
        {
            try
            {
                if (!Create.space && Create.partForGeometricFigures.name != "Delete")
                {
                    Create.i = (short)Create.part.Length;
                    Create.Part = Instantiate(Create.partForGeometricFigures, Create.parts.transform);
                    if (Create.partForGeometricFigures.name == "PartForGeometricFigures")
                    {
                        Create.localPosition.Set(0, Create.i * -20, 0);
                        Create.m = (short)(Create.m == 0 ? 0 : Create.m + 1);
                        Create.pieces = Create.Part.GetComponentsInChildren<Piece>();
                        Create.partForGeometricFigures.name = (Create.i + 1).ToString();
                        Create.Part.transform.localPosition = Create.localPosition;
                        Create.Part.name = (Create.i + 1).ToString();
                        Create.Pieces = new Piece[Create.i + 1][];
                        Create.Parts = new Part[Create.i + 1];
                        Create.x = Create.pieces.Length;
                        for (Create.s = 0; Create.s < Create.i; Create.s++)
                        {
                            Create.Parts[Create.s] = Create.part[Create.s];
                            Create.Pieces[Create.s] = Create.piece[Create.s];
                        }
                        Create.combineInstance = new CombineInstance[(int)Create.x];
                        for (Create.s = 0; Create.s < Create.x; Create.s++)
                        {
                            Create.pieces[Create.s].GetComponent<Collider>().enabled = false;
                            Create.pieces[Create.s].name = $"{(Create.I + 1).ToString()}.{(Create.s + 1).ToString()}";
                            Create.combineInstance[Create.s].mesh = Create.pieces[Create.s].GetComponent<MeshFilter>().sharedMesh;
                            Create.combineInstance[Create.s].transform = Matrix4x4.TRS(Create.pieces[Create.s].transform.localPosition, Create.pieces[Create.s].transform.localRotation, Create.pieces[Create.s].transform.localScale);
                        }
                        Create.Parts[Create.i] = Create.Part;
                        Array.Clear(Create.part, 0, Create.i);
                        Array.Clear(Create.piece, 0, Create.i);
                        Create.Pieces[Create.i] = Create.pieces;
                        Create.piece = Create.Pieces;
                        Create.part = Create.Parts;
                        Create.ui = (short)Create.UI.Length;
                        Create.GameObject = new GameObject($"{(Create.ui - Configurations.lenghtButtonsUI + 1).ToString()}");
                        Create.GameObject.transform.SetParent(Create.UI[0].transform);
                        Create.GameObject.transform.localPosition = Create.localPosition;
                        Create.Move = new float[Create.move.GetLength(0) + (Create.move.GetLength(0) > 0 ? Create.move.GetLength(0) / Create.I : 0), 9];
                        Create.localPosition.Set(Create.part[Create.i].transform.localPosition.x - 15, Create.part[Create.i].transform.localPosition.y + 45, Create.part[Create.i].transform.localPosition.z - 45);
                        Create.Parent = new float[1, Create.i + 2];
                        for (Create.s = 0; Create.s < Create.i; Create.s++)
                            Create.Parent[0, Create.s] = Create.parent[0, Create.s];
                        TextMesh textMesh = Create.GameObject.AddComponent<TextMesh>();
                        GameObject[] UI = new GameObject[Create.ui + 1];
                        Create.x = Create.i;
                        Create.I = 0;
                        for (Create.s = 0; Create.s < Create.Move.GetLength(0); Create.s++)
                        {
                            if (Create.s < Create.i)
                            {
                                Create.Move[Create.s, 0] = Create.move[Create.s, 0];
                                Create.Move[Create.s, 1] = Create.move[Create.s, 1];
                                Create.Move[Create.s, 2] = Create.move[Create.s, 2];
                                Create.Move[Create.s, 3] = Create.move[Create.s, 3];
                                Create.Move[Create.s, 4] = Create.move[Create.s, 4];
                                Create.Move[Create.s, 5] = Create.move[Create.s, 5];
                                Create.Move[Create.s, 6] = Create.move[Create.s, 6];
                                Create.Move[Create.s, 7] = Create.move[Create.s, 7];
                                Create.Move[Create.s, 8] = Create.move[Create.s, 8];
                            }
                            else if (Create.s != 0 && (Create.s % Create.x == 0 && Create.x == Create.i || Create.s % Create.x == 0))
                            {
                                Create.I++;
                                Create.x = Create.x + Create.i + 1;
                                Create.Move[Create.s, 0] = Create.Move[Create.s, 1] = Create.Move[Create.s, 2] = Create.Move[Create.s, 3] = Create.Move[Create.s, 4] = Create.Move[Create.s, 5] = Create.Move[Create.s, 6] = Create.Move[Create.s, 8] = 1;
                            }
                            else
                            {
                                Create.Move[Create.s, 0] = Create.move[Create.s - Create.I, 0];
                                Create.Move[Create.s, 1] = Create.move[Create.s - Create.I, 1];
                                Create.Move[Create.s, 2] = Create.move[Create.s - Create.I, 2];
                                Create.Move[Create.s, 3] = Create.move[Create.s - Create.I, 3];
                                Create.Move[Create.s, 4] = Create.move[Create.s - Create.I, 4];
                                Create.Move[Create.s, 5] = Create.move[Create.s - Create.I, 5];
                                Create.Move[Create.s, 6] = Create.move[Create.s - Create.I, 6];
                                Create.Move[Create.s, 7] = Create.move[Create.s - Create.I, 7];
                                Create.Move[Create.s, 8] = Create.move[Create.s - Create.I, 8];
                            }
                        }
                        textMesh.fontSize = 20;
                        textMesh.color = Color.red;
                        textMesh.text = Create.Part.name;
                        Create.GameObject.AddComponent<Data>();
                        Create.GameObject.AddComponent<BoxCollider>();
                        for (Create.s = 0; Create.s < Create.ui; Create.s++)
                            UI[Create.s] = Create.UI[Create.s];
                        UI[Create.ui] = Create.GameObject;
                        UI[Create.ui].SetActive(false);
                        Array.Clear(Create.UI, 0, Create.ui);
                        Array.Clear(Create.parent, 0, Create.parent.Length);
                        Array.Clear(Create.move, 0, Create.move.GetLength(0));
                        Create.parent = Create.Parent;
                        Create.move = Create.Move;
                        Create.UI = UI;
                    }
                    else
                    {
                        Create.i = int.Parse(Create.partForGeometricFigures.name) - 1;
                        Create.I = Create.piece[Create.i].Length;
                        Create.localPosition.Set(0, Create.i * -20, 0);
                        for (Create.s = 0; Create.s < Create.I; Create.s++)
                            Destroy(Create.piece[Create.i][Create.s].gameObject);
                        Create.pieces = Create.Part.GetComponentsInChildren<Piece>();
                        Array.Clear(Create.piece[Create.i], 0, Create.I);
                        Create.I = Create.pieces.Length;
                        Create.combineInstance = new CombineInstance[Create.I];
                        for (Create.s = 0; Create.s < Create.I; Create.s++)
                        {
                            Create.pieces[Create.s].GetComponent<Collider>().enabled = false;
                            Create.combineInstance[Create.s].mesh = Create.pieces[Create.s].GetComponent<MeshFilter>().sharedMesh;
                            Create.combineInstance[Create.s].transform = Matrix4x4.TRS(Create.pieces[Create.s].transform.localPosition, Create.pieces[Create.s].transform.localRotation, Create.pieces[Create.s].transform.localScale);
                        }
                        Create.Part.transform.localPosition = Create.localPosition;
                        Create.Part.name = (Create.i + 1).ToString();
                        Destroy(Create.part[Create.i].gameObject);
                        Create.piece[Create.i] = Create.pieces;
                        Create.part[Create.i] = Create.Part;
                    }
                    Create.MeshFilter = Create.pieces[0].GetComponent<MeshFilter>();
                    Create.MeshFilter.mesh.CombineMeshes(Create.combineInstance);
                    Create.Part.gameObject.GetComponent<MeshFilter>().mesh = Create.MeshFilter.sharedMesh;
                    Create.MeshFilter.mesh = Create.combineInstance[0].mesh;
                    Create.Part.gameObject.AddComponent<MeshCollider>();
                }
                else if (!Create.space && Create.partForGeometricFigures.name == "Delete")
                    Create.partForGeometricFigures.name = "PartForGeometricFigures";
                Create.i = Create.piece.Length;
                Create.hashtable = new Hashtable();
                Create.robot = new float[Create.i + 2][,];
                Create.binaryFormatter = new BinaryFormatter();
                Create.fileStream = new FileStream("Robot.space", FileMode.Create);
                for (Create.s = 0; Create.s < Create.i; Create.s++)
                {
                    Create.pieces = Create.piece[Create.s];
                    Create.I = (short)Create.pieces.Length;
                    Create.robot[Create.s] = new float[Create.I, 13];
                    for (Create.S = 0; Create.S < Create.I; Create.S++)
                    {
                        Create.robot[Create.s][Create.S, 0] = (float)Create.pieces[Create.S].primitiveType;
                        Create.robot[Create.s][Create.S, 1] = Create.pieces[Create.S].transform.localScale.x;
                        Create.robot[Create.s][Create.S, 2] = Create.pieces[Create.S].transform.localScale.y;
                        Create.robot[Create.s][Create.S, 3] = Create.pieces[Create.S].transform.localScale.z;
                        Create.robot[Create.s][Create.S, 4] = Create.pieces[Create.S].transform.localPosition.x;
                        Create.robot[Create.s][Create.S, 5] = Create.pieces[Create.S].transform.localPosition.y;
                        Create.robot[Create.s][Create.S, 6] = Create.pieces[Create.S].transform.localPosition.z;
                        Create.robot[Create.s][Create.S, 7] = Create.pieces[Create.S].transform.localEulerAngles.x;
                        Create.robot[Create.s][Create.S, 8] = Create.pieces[Create.S].transform.localEulerAngles.y;
                        Create.robot[Create.s][Create.S, 9] = Create.pieces[Create.S].transform.localEulerAngles.z;
                        Create.robot[Create.s][Create.S, 10] = Create.pieces[Create.S].GetComponent<Renderer>().material.color.r;
                        Create.robot[Create.s][Create.S, 11] = Create.pieces[Create.S].GetComponent<Renderer>().material.color.g;
                        Create.robot[Create.s][Create.S, 12] = Create.pieces[Create.S].GetComponent<Renderer>().material.color.b;
                    }
                }
                Create.robot[Create.i] = Create.move;
                Create.robot[Create.i + 1] = Create.parent;
                Create.hashtable.Add("Robot", Create.robot);
                Create.binaryFormatter.Serialize(Create.fileStream, Create.hashtable);
                Array.Clear(Create.robot, 0, Create.i + 2);
            }
            catch (SerializationException ex)
            {
                Debug.Log(ex.Message);
            }
            finally
            {
                Create.x = 0;
                Create.Part = null;
                Create.fileStream.Close();
                Create.fileStream.Dispose();
                if (Create.hashtable != null)
                    Create.hashtable.Clear();
            }
        }
    }
}
