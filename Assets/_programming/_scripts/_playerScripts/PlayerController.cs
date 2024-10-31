using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementVector = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += moveSpeed * Time.deltaTime * movementVector;
    }
}
