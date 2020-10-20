using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARRotate : MonoBehaviour {

    public float Speed = 150f;//旋转速度	

    public void Rotate()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.touchCount == 1)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * -Speed * Time.deltaTime);
                }
            }
        }
    }

    void Update()
    {
        Rotate();
    }
}
