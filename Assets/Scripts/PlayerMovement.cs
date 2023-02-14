using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class PlayerMovement : MonoBehaviour
{
  Rigidbody rb;
  public float defaultMovementSpeed;
  public float movementSpeed;
  private Vector3 movementDirection;
  

  // Start is called before the first frame update
  void Start()
  {
    Debug.Log("Starting player movement");
    rb = this.GetComponent<Rigidbody>();
  }
  // Update is called once per frame
  void Update()
  {
    float horizontalInput =  Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");
    //the total input is the hypotenuse of both vertical and horizontal.
    float totalInput = (float) System.Math.Sqrt((System.Math.Pow(horizontalInput, 2) +  System.Math.Pow(verticalInput, 2)));
    
    // Limiting the total input to be of the same magnitude (-1<=x<=1)
    if( totalInput > 1f){
      horizontalInput = (horizontalInput/totalInput);
      verticalInput = (verticalInput/totalInput);
    }

    movementDirection = new Vector3(horizontalInput, 0f, verticalInput);
    
  }
  void FixedUpdate(){
    movePlayer(movementDirection);
  }

  public void modifySpeed(float modificationPercentage){
    movementSpeed = (defaultMovementSpeed * modificationPercentage);
  }
  public void setSpeed(float speed){
    movementSpeed = speed;
  }
  private void movePlayer(Vector3 movementDirection){
    rb.velocity = (movementDirection * movementSpeed);
  }
}