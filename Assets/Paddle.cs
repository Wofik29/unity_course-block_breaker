using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
   [SerializeField] float widthPerUnit = 16f;
   [SerializeField] float minX = 1f;
   [SerializeField] float maxX = 15f;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       var newPosition = Mathf.Clamp(Input.mousePosition.x / Screen.width * widthPerUnit, minX, maxX);
       transform.position = new Vector2(newPosition, transform.position.y);
       
    }
}
