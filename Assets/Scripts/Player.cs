using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    float movimientoHorizontal;

    // Update is called once per frame
    void Update()
    {
        movimientoHorizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movimientoHorizontal * speed * Time.deltaTime, 0f, 0f);
    }
}
