using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    //Change positions
    if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
      ChangePosition(-1);
    else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
      ChangePosition(1);

    //Interact with options
    if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.E))
      Interact();
  }

  private void Interact()
  {
    SoundManager.instance.Playsound(interactSound);

    options[currentPosition].GetComponent<Button>().onClick.Invoke();

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
