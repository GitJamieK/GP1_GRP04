using UnityEngine;
using UnityEngine.VFX;

public class CharacterVfxScrip : MonoBehaviour
{
    [SerializeField] VisualEffect _RightLegEffect;
    [SerializeField] VisualEffect _LeftLegEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }  

    public void AE_StepdustR() {

        _RightLegEffect.SendEvent("kaboom");


        //_AwesomeEffect.SendEvent(kaboom);
    }
    public void AE_StepdustL()
    {
        _LeftLegEffect.SendEvent("kaboom");
        

    }
}
