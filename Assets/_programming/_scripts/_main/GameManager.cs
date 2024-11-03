using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get { return instance; }
    }

    public EventService EventService;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
        
        InitializeServices();
    }

    private void InitializeServices()
    {
        EventService = new EventService();
    }
}
