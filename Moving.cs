using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float blendSpeed = 5f;

    private float inputVertical;
    private float inputHorizontal;
    private bool isRunning = false;
    private GameController controller;

    // Start is called before the first frame update
     void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        controller.animator.SetFloat(controller.horizontal, inputHorizontal);

        if(Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") > 0) {
            isRunning = true;
            inputVertical += blendSpeed * Time.deltaTime;
            controller.animator.SetFloat(controller.vertical, inputVertical);
        } else {
            isRunning = false;
            inputVertical = 1;
        }

        if(!isRunning) {
            controller.animator.SetFloat(controller.vertical, Input.GetAxis("Vertical"));
        }
    }
}
