using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {
    Rigidbody2D rb;
    // переменные для меремещения мышью
    public float speed;
    private bool move;
    public GameObject point;
    private Vector3 target;
    private float speedx;
    private float speedy;
    //переменные для спрайтов
    public Sprite moveup;
    public Sprite movedown;
    public Sprite moveright;
    public Sprite moveleft;

    //методлы для смены спрайта
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
        this.gameObject.GetComponent<SpriteRenderer>().sprite = moveleft;
    }

    public void MoveRight()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = moveright;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        //движение игрока
        
		if(Input.GetMouseButton(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);           
            if (move == false)
                move = true;
            Instantiate(point, target, Quaternion.identity); // ЧТО ЭТО????

        }
        if (move == true)
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            target.z = transform.position.z;
        //вычисляем проекции скоростей
        speedx = (target.x - transform.position.x);
        speedy = (target.y - transform.position.y);


        //блок кода для смены спрайта в зависимости от движения
        if (speedy*speedy >= speedx*speedx)
        {
            if (speedy > 0)
                MoveUp();
            else 
                MoveDown();
        }
        else
        {
            if (speedx < 0)
                 MoveLeft(); 
            else                
                 MoveRight();
        }
        Debug.Log(speedx);

        if (transform.position == target)
            move = false;

        if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0 || Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
        {
            move = false;
            //GameObject.Destroy(Point.);
        }   


    }
}
