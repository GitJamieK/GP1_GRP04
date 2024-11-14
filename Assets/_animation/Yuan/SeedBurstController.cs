using UnityEngine;
using UnityEngine.VFX;

public class SeedBurstController : MonoBehaviour
{
    [SerializeField] VisualEffect _SeedBurst;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AE_SeedBurst()
    {
        _SeedBurst.SendEvent("kaboom");



    }
}
