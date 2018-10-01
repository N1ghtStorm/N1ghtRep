using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb;
    public Sprite moveup;
    public Sprite movedown;
    public Sprite moveright;
    public Sprite moveleft;
    //private bool faceRight = true;

    // Use this for initialization
    public void MoveUp()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = moveup;
    }

    public void MoveDown()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = movedown;
    }

    public void MoveLeft()
    {
        //faceRight = !faceRight;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = moveleft;
        //transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void MoveRight()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = moveright;
    }


    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * 6f, Input.GetAxis("Vertical") * 6f); // Движение

        // Блок кода для смены позы персонажа
        if (Input.GetAxis("Vertical") > 0)
            MoveUp();
        else if (Input.GetAxis("Vertical") < 0)
            MoveDown();
        else if (Input.GetAxis("Horizontal") < 0)
            MoveLeft();
        else if (Input.GetAxis("Horizontal") > 0)
            MoveRight();

        /* if (Input.GetAxis("Horizontal") > 0)
             MoveRight();
         else if (Input.GetAxis("Horizontal") < 0)
              MoveLeft(); */



    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePos = Input.mousePosition;
            Debug.Log("MOUSE POSITION");
            Debug.Log(mousePos.x);
            Debug.Log(mousePos.y);
        }
        
        




    }

    


}
