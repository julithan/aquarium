using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_FishAct : MonoBehaviour
{
    [Header("Setting")]
    public int movespeed;
    public int moveclimb;
    public int movedescent;
    public int hp;
    public GameObject centerposition;

    private  Vector3 startPos;

    private bool isArrive;

    public bool moveToX;
    public bool moveToY;
    public bool diagonal;
    public bool diagonalReversal;
    public bool circle;
    public bool moveToz;

    private Vector3 endPosX;
    private Vector3 endPosY;
    private Vector3 endPosXY;

    public float dis;
    public float speed;
    private float step;
    public float waitTime;

    //원운동
    private float leftAndRightSpeed;
    private float upAndDownSpeed;


    private void Awake()
    {
        this.startPos = this.transform.localPosition;

        this.upAndDownSpeed = 0;
        this.leftAndRightSpeed = 2;

        this.isArrive = true;

    }

    void Start()
    {
        //나중에 적용 예정 부분 Bong
        //StartCoroutine(Move());
    }

    void Update()
    {
        Rotation();

        // 자유로운 방향으로 이동하게 하는 부분 나중에 적용 예정 Bong        
        /*
        this.step = this.speed * Time.deltaTime;

        this.endPosY = new Vector3(this.transform.localPosition.x, this.startPos.y + this.dis);
        this.endPosX = new Vector3(this.startPos.x - this.dis, this.transform.localPosition.y);

        if (this.diagonalReversal == true)
            this.endPosXY = new Vector3(this.startPos.x - this.dis, this.startPos.y + this.dis);

        else if (this.diagonalReversal == false)
            this.endPosXY = new Vector3(this.startPos.x + this.dis, this.startPos.y + this.dis);
        */
    }

    void Rotation()
    {
        if(moveToz == true)
        {
            this.transform.RotateAround(centerposition.transform.position, Vector3.up, speed * Time.deltaTime);
        }
        else
        {
            this.transform.RotateAround(centerposition.transform.position, Vector3.down, speed * Time.deltaTime);
        }

    }

    IEnumerator CircleMoveLeftAndRight()
    {
        StartCoroutine(CircleMoveUpAndDown());

        while (true)
        {
            while (true)
            {
                this.transform.Translate(Vector3.left * leftAndRightSpeed * 0.05f);
                leftAndRightSpeed -= Time.deltaTime;

                yield return null;

                if (leftAndRightSpeed <= -2) break;
            }

            while (true)
            {
                this.transform.Translate(Vector3.left * leftAndRightSpeed * 0.05f);
                leftAndRightSpeed += Time.deltaTime;

                yield return null;

                if (leftAndRightSpeed >= 2) break;
            }
        }
    }

    IEnumerator CircleMoveUpAndDown()
    {
        while (true)
        {
            while (true)
            {
                this.transform.Translate(Vector3.up * upAndDownSpeed * 0.05f);
                upAndDownSpeed += Time.deltaTime;
                yield return null;
                if (upAndDownSpeed >= 2) break;
            }

            while (true)
            {
                this.transform.Translate(Vector3.up * upAndDownSpeed * 0.05f);
                upAndDownSpeed -= Time.deltaTime;
                yield return null;
                if (upAndDownSpeed <= -2) break;
            }
        }
    }

    IEnumerator Move()
    {
        //원운동
        if (this.circle)
        {
            StartCoroutine(CircleMoveLeftAndRight());
        }

        //대각선 이동
        else if (this.diagonal && this.diagonalReversal)
        {
            //좌상, 우하로 이동됨
            while (true)
            {
                if (isArrive)
                {
                    while (true)
                    {
                        var dis = Vector3.Distance(this.transform.localPosition, this.endPosXY);

                        if (this.dis < 0)
                        {
                            this.transform.Translate(Vector3.right * this.step);
                            this.transform.Translate(Vector3.down * this.step);
                        }

                        else if (this.dis > 0)
                        {
                            this.transform.Translate(Vector3.left * this.step);
                            this.transform.Translate(Vector3.up * this.step);
                        }

                        if (dis <= 0.8f) break;

                        yield return null;
                    }
                    this.isArrive = false;
                }

                else
                {
                    while (true)
                    {
                        var dis = Vector3.Distance(this.transform.localPosition, this.startPos);

                        if (this.dis < 0)
                        {
                            this.transform.Translate(-Vector3.right * this.step);
                            this.transform.Translate(-Vector3.down * this.step);
                        }


                        else if (this.dis > 0)
                        {
                            this.transform.Translate(-Vector3.left * this.step);
                            this.transform.Translate(-Vector3.up * this.step);
                        }
                        yield return null;

                        if (dis <= 0.8f) break;
                    }
                    this.isArrive = true;
                }
                yield return new WaitForSeconds(waitTime);
            }
        }

        else if (this.diagonal && !this.diagonalReversal)
        {
            while (true)
            {
                if (isArrive)
                {
                    while (true)
                    {
                        var dis = Vector3.Distance(this.transform.localPosition, this.endPosXY);

                        if (this.dis < 0)
                        {
                            this.transform.Translate(-Vector3.right * this.step);
                            this.transform.Translate(Vector3.down * this.step);
                        }


                        else if (this.dis > 0)
                        {
                            this.transform.Translate(-Vector3.left * this.step);
                            this.transform.Translate(Vector3.up * this.step);
                        }

                        yield return null;

                        if (dis <= 0.8f) break;
                    }
                    this.isArrive = false;
                }

                else
                {
                    while (true)
                    {
                        var dis = Vector3.Distance(this.transform.localPosition, this.startPos);

                        if (this.dis < 0)
                        {
                            this.transform.Translate(Vector3.right * this.step);
                            this.transform.Translate(-Vector3.down * this.step);
                        }


                        else if (this.dis > 0)
                        {
                            this.transform.Translate(Vector3.left * this.step);
                            this.transform.Translate(-Vector3.up * this.step);
                        }
                        yield return null;

                        if (dis <= 0.8f) break;
                    }
                    this.isArrive = true;
                }
                yield return new WaitForSeconds(waitTime);
            }
        }

        //좌우 이동
        else if (this.moveToX)
        {
            while (true)
            {
                if (isArrive)
                {
                    while (true)
                    {
                        var dis = Vector3.Distance(this.transform.localPosition, this.endPosX);

                        if (this.dis < 0)
                            this.transform.Translate(Vector3.right * this.step);


                        else if (this.dis > 0)
                            this.transform.Translate(Vector3.left * this.step);

                        if (dis <= 0.5f) break;

                        yield return null;
                    }
                    this.isArrive = false;
                }

                else
                {
                    while (true)
                    {
                        var dis = Vector3.Distance(this.transform.localPosition, this.startPos);

                        if (this.dis < 0)
                            this.transform.Translate(-Vector3.right * this.step);

                        if (this.dis > 0)
                            this.transform.Translate(-Vector3.left * this.step);

                        yield return null;

                        if (dis <= 0.5f) break;
                    }
                    this.isArrive = true;
                }
                yield return new WaitForSeconds(waitTime);
            }
        }

        //상하 이동
        else if (this.moveToY)
        {
            while (true)
            {
                if (isArrive)
                {
                    while (true)
                    {
                        var dis = Vector3.Distance(this.transform.localPosition, this.endPosY);

                        if (this.dis < 0)
                            this.transform.Translate(Vector3.down * this.step);


                        else if (this.dis > 0)
                            this.transform.Translate(Vector3.up * this.step);

                        if (dis <= 0.5f) break;

                        yield return null;
                    }
                    this.isArrive = false;
                }

                else
                {
                    while (true)
                    {
                        var dis = Vector3.Distance(this.transform.localPosition, this.startPos);

                        if (this.dis < 0)
                            this.transform.Translate(-Vector3.down * this.step);

                        if (this.dis > 0)
                            this.transform.Translate(-Vector3.up * this.step);

                        yield return null;

                        if (dis <= 0.5f) break;
                    }
                    this.isArrive = true;
                }
                yield return new WaitForSeconds(waitTime);
            }
        }

        //좌우 이동
        else if (this.moveToz)
        {
            while (true)
            {
                if (isArrive)
                {
                    while (true)
                    {
                        var dis = Vector3.Distance(this.transform.localPosition, this.endPosX);

                        if (this.dis < 0)
                            this.transform.Translate(Vector3.right * this.step);


                        else if (this.dis > 0)
                            this.transform.Translate(Vector3.left * this.step);

                        if (dis <= 0.5f) break;

                        yield return null;
                    }
                    this.isArrive = false;
                }

                else
                {
                    while (true)
                    {
                        var dis = Vector3.Distance(this.transform.localPosition, this.startPos);

                        if (this.dis < 0)
                            this.transform.Translate(-Vector3.right * this.step);

                        if (this.dis > 0)
                            this.transform.Translate(-Vector3.left * this.step);
                           

                        yield return null;

                        if (dis <= 0.5f) break;
                    }
                    this.isArrive = true;
                }
                yield return new WaitForSeconds(waitTime);
            }
        }
    }
}
