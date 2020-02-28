using UnityEngine;


public class RGB : MonoBehaviour
{
    byte min = 0;
    byte max = 1;
    float step = 0.01f;

    void OnMouseDrag()
    {
        if (Create.Piece == null)
            return;
        switch (name)
        {
            case "R+":
                Create.Piece.color.r += step;
                if (Create.Piece.color.r > max)
                    Create.Piece.color.r = max;
                break;
            case "R-":
                Create.Piece.color.r -= step;
                if (Create.Piece.color.r < min)
                    Create.Piece.color.r = min;
                break;
            case "G+":
                Create.Piece.color.g += step;
                if (Create.Piece.color.g > max)
                    Create.Piece.color.g = max;
                break;
            case "G-":
                Create.Piece.color.g -= step;
                if (Create.Piece.color.g < min)
                    Create.Piece.color.g = min;
                break;
            case "B+":
                Create.Piece.color.b += step;
                if (Create.Piece.color.b > max)
                    Create.Piece.color.b = max;
                break;
            case "B-":
                Create.Piece.color.b -= step;
                if (Create.Piece.color.b < min)
                    Create.Piece.color.b = min;
                break;
        }
        Create.Piece.material.color = Create.Piece.color;
    }
}
