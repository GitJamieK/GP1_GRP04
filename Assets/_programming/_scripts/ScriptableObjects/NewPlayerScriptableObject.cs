using UnityEngine;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "NewPlayerScriptableObject", menuName = "Scriptable Objects/NewPlayerScriptableObject", order = 2)]
public class NewPlayerScriptableObject : ScriptableObject
{
    [Header("Movement values")]
    [Range(0f, 5f)] public float MoveSpeed = 4f;
    
    [Header("Jump force values")]
    [Range(0f, 100f)] public float UpwardJumpForce = 10f;
    [Range(0f, 100f)]public float DownwardJumpForce = 20f;
    [Range(0f, 100f)]public float Velocity = 20f;
    
    [Header("Physics values")]
    [Range(0f, 5f)]public float GroundSphereCastDistance = 1f;
}
