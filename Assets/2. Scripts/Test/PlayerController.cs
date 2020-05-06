using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerController : MonoBehaviour
{
    public SteamVR_Action_Vector2 input;
    public float speed = 1;
    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (input.axis.magnitude <= .1f) return;

        Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));
        Vector3 YAXis = new Vector3(0f, Mathf.PingPong(Time.time * 3f, 20f));

        //transform.position += speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up);
        _characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, YAXis) - new Vector3(0f, Mathf.PingPong(9.81f, 10), 0f) * Time.deltaTime);
    }
    
}