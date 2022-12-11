using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;

    private void Awake() {
        gameOverScreen.SetActive(true);
    }
    public void GameOver() {
        gameOverScreen.SetActive(true);
        SoundManager.instance.Playsound(gameOverSound);
        
    }
}
