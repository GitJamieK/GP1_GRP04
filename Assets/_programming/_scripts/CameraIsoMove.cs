using UnityEngine;

public class CameraIsoMove : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float cameraPanRate;
    [SerializeField] private float offsetMagnitude;

    private Vector3 vectorTowardsCamera;
    private bool cameraMovementDone = false;
    private float positionOnUnitCircle;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vectorTowardsCamera = transform.position - target.transform.position;
        vectorTowardsCamera.Normalize();
        positionOnUnitCircle = Mathf.Atan2(vectorTowardsCamera.y, vectorTowardsCamera.x) * Mathf.Rad2Deg;

    }

    // Update is called once per frame
    void Update()
    {
        if (cameraMovementDone)
            return;
        
        positionOnUnitCircle += cameraPanRate * Time.deltaTime;
        transform.position = new Vector3(Mathf.Cos(positionOnUnitCircle), 0f, Mathf.Sin(positionOnUnitCircle)) * offsetMagnitude;
        transform.LookAt(target.transform.position);
    }
}
