using UnityEngine;

[CreateAssetMenu(fileName = "CameraScriptableObject", menuName = "Scriptable Objects/CameraScriptableObject", order = 0)]
public class CameraScriptableObject : ScriptableObject
{
    public PlayerController Target;
    public float RotationRadius;
    public float RotationSpeed;
    public float Y_Offset;
    public float RotationOffsetAlongXAxis;
}
