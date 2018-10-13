using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatableBackround : MonoBehaviour
{

    Vector3 ScaleofBackRound;

    public float speed = 105f;

    //when the backround pass the camera we will reset the backround 
    Vector3 defaultBackRound = new Vector3(18, 0, 0);

    // Use this for initialization
    void Start()
    {
        ScaleofBackRound = transform.localScale;


    }

    // Update is called once per frame
    void Update()
    {
        // print(ScaleofBackRound.x);
        // print(transform.name);

        transform.position += Vector3.left;

        if(Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
        {
            print("dead");

            transform.position += Vector3.left * speed * Time.deltaTime ;
        }

        //if backround position is in the negative 
        if (transform.position.x == -ScaleofBackRound.x)
        {
            UpdateBackRound();
        }

    }

    void UpdateBackRound()
    {
        transform.position = defaultBackRound;
    }

}
