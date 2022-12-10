using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField]private AudioClip checkpointSound;
    private Transform currentCheckpoint;
    private Health playerHealth;

    private void Awake() {
        playerHealth = GetComponent<Health>();

    }

    private void Respawn() 
    {
      transform.position = currentCheckpoint.position;  
      playerHealth.Respawn();
      Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint.parent);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.transform.tag == "Checkpoint")
        {
            currentCheckpoint = other.transform;
            SoundManager.instance.Playsound(checkpointSound);
            other.GetComponent<Collider2D>().enabled = false;
            other.GetComponent<Animator>().SetTrigger("appear");
        }
        
    }
}
