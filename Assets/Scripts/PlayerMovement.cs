using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 5f;

    void FixedUpdate(){
        if (DialogueManager.Instance.isDialogueActive) return;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.up * y;
        transform.position += move * speed * Time.deltaTime;
    }
}
