using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIService : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    
    public void UpdateSeedsCollected(int seeds) => _scoreText.text = seeds.ToString();
}
