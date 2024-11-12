using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "Scriptable Objects/PlayerScriptableObject")]
public class PlayerScriptableObject : ScriptableObject
{
    public float MoveSpeed;
    public float JumpForce;
    public float GroundSphereCastDistance;
}
