using System;
using UnityEngine;

namespace SimpleLowPolyNature.Scripts
{
    public class CameraController : MonoBehaviour
    {

        public Transform player;
        public float followSpeed = 5f;
        public float rotationSpeed = 10.0f;
        public Vector3 _offset = new Vector3(0f,2f,-5f);
        
        private void LateUpdate()
        {
            Vector3 targetPosition = player.position + _offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
            transform.LookAt(targetPosition);
            //Quaternion targetRotation = Quaternion.LookRotation(player.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, player.rotation, rotationSpeed * Time.deltaTime);
        }
        
        private void Start()
        {
            
            Debug.Log("Player position: " + player.position);
            Debug.Log("Camera position: " + transform.position);
            Debug.Log("Player rotation: " + player.rotation.eulerAngles);
            Debug.Log("Camera rotation: " + transform.rotation.eulerAngles);

            _offset = transform.position - player.position;
            
            Debug.Log("eeeeee" + _offset);
        }

        // private void RotateWithPlayer()
        // {
        //     // Calculate the target rotation based on the player's rotation
        //     Quaternion targetRotation = Quaternion.LookRotation(player.forward, Vector3.up);
        //
        //     // Smoothly interpolate towards the target rotation
        //     transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        // }
    }
}