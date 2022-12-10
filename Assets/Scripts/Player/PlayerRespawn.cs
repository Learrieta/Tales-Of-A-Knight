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
    }
}
