using UnityEngine;


public class Rotate : MonoBehaviour
{
    Part part;
    float x, y, z;

    void OnMouseDrag()
    {
        if (Create.pieceForPartForGeometricFigures.Length > 0)
            part = Create.partForGeometricFigures;
        else if (Create.space && Create.part.Length > 0)
            part = Create.parts;
        else
            return;
        x = part.transform.localEulerAngles.x;
        y = part.transform.localEulerAngles.y;
        z = part.transform.localEulerAngles.z;
        switch (name)
        {
            case "<":
                Create.localRotate = true;
                if (z > 170 && z < 190)
                    Create.y = Configurations.speedRotation;
                else if (z > 80 && z < 100 || z > 260 && z < 280)
                    Create.x = -Configurations.speedRotation;
                if (x > 260 && x < 280 || x > 80 && x < 100)
                    Create.z = -Configurations.speedRotation;
                else
                    Create.y = -Configurations.speedRotation;
                break;
            case ">":
                Create.localRotate = true;
                if (z > 170 && z < 190)
                    Create.y = -Configurations.speedRotation;
                else if (z > 80 && z < 100 || z > 260 && z < 280)
                    Create.x = -Configurations.speedRotation;
                if (x > 260 && x < 280 || x > 80 && x < 100)
                    Create.z = Configurations.speedRotation;
                else
                    Create.y = Configurations.speedRotation;
                break;
            case "^":
                Create.localRotate = true;
                if (y > -10 && y < 10 || y > 170 && y < 190)
                    Create.x = -Configurations.speedRotation;
                if (y > 80 && y < 100)
                    Create.z = -Configurations.speedRotation;
                if (y > 260 && y < 280)
                    Create.z = Configurations.speedRotation;
                break;
            case "+":
                Create.localRotate = true;
                if (y > -10 && y < 10 || y > 170 && y < 190)
                    Create.x = Configurations.speedRotation;
                if (y > 80 && y < 100)
                    Create.z = Configurations.speedRotation;
                if (y > 260 && y < 280)
                    Create.z = -Configurations.speedRotation;
                break;
        }
    }
}
