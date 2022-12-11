using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionArrow : MonoBehaviour
{
  private RectTransform rect;
  [SerializeField]private RectTransform[] options;
  [SerializeField]private AudioClip changeSound;
  [SerializeField]private AudioClip interactSound;
  private int currentPosition;

  private void Awake() {
    rect = GetComponent<RectTransform>();
  }
  private void Update() {
    if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
      ChangePosition(-1);
    else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
      ChangePosition(1);
  }
  private void ChangePosition(int _change)
  {
    currentPosition += _change;
    if(_change != 0 )
      SoundManager.instance.Playsound(changeSound);

    if (currentPosition < 0)
      currentPosition = options.Length -1;
    else if ( currentPosition > options.Length -1)
      currentPosition = 0;
    rect.position = new Vector3(rect.position.x, options[currentPosition].position.y, 0 );

  }
}