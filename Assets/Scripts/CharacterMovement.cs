using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    float movementSpeed = 0.06f;

    public GameObject perdio;
    public GameObject gano;

    float muerte = 0;
    public int confetis;
    GameObject clone;
    GameObject clone2;

    public GameObject confeti;
    public GameObject confeti2;

    Rigidbody rb;
    public float jumpForce;
    bool hasJumped;
    public float textTime;
    float currTextTime;

    public GameObject Cilindros;
    GameObject Clon;
    // Start is called before the first frame update
    void Start()
    {
        gano.SetActive(!gano.activeInHierarchy);
        perdio.SetActive(!perdio.activeInHierarchy);
        hasJumped = true;
        rb = GetComponent<Rigidbody>();
        currTextTime = textTime;
    }

    // Update is called once per frame
    void Update()
    {
        movementSpeed = movementSpeed + 0.0005f;
        if (Time.time > muerte + 3)
        {
            int tiempo = Mathf.FloorToInt(Time.time);
            movementSpeed = movementSpeed + 0.002f;
            //movementSpeed /= 2;
            transform.position += new Vector3(0, 0, movementSpeed);
            if (Input.GetKeyDown(KeyCode.Space) && hasJumped)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                hasJumped = false;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(movementSpeed, 0, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= new Vector3(movementSpeed, 0, 0);
            }
        }

        if (perdio.activeInHierarchy || gano.activeInHierarchy)
        {
            currTextTime -= Time.deltaTime;
            if (currTextTime <= 0)
            {
                perdio.SetActive(false);
                gano.SetActive(false);
                currTextTime = textTime;
            }

        }


    }
    void OnCollisionEnter(Collision col)
    {
        movementSpeed = 0.06f;
        Debug.Log(col.gameObject.tag);

        if (col.gameObject.tag == "Ground")
        {
            Clon = Instantiate(Cilindros);
            Clon.transform.position = new Vector3(-0.01f, 32.5f, 110);
            int i = 0;
            i = +3;
            while (i > 3)
            {
                Clon = Instantiate(Cilindros);
                Clon.transform.position = new Vector3(-0.01f, 32.53f, 110);
                i = 0;
            }



            Destroy(Clon, 30);
        }
        if (col.gameObject.name == "Deathwall")
        {
            gano.SetActive(false);
            perdio.SetActive(true);
            transform.position = new Vector3(0, 1.1f, -98);
            transform.eulerAngles = new Vector3(0, 0, 0);


        }
        if (col.gameObject.tag == "Ground")
        {
            hasJumped = true;
        }
        if (col.gameObject.name == "Cylinder(Clone)")
        {
            transform.position = new Vector3(0, 1.1f, -98);
            transform.eulerAngles = new Vector3(0, 0, 0);
            perdio.SetActive(true);
            gano.SetActive(false);
        }
        if (col.gameObject.name == "Finished")
        {
            muerte = Time.time;
            transform.position = new Vector3(0, 1.1f, -98);
            transform.eulerAngles = new Vector3(0, 0, 0);
            gano.SetActive(true);
            perdio.SetActive(false);
            for (int i = 1; i < confetis; i++)
            {
                clone = Instantiate(confeti);
                clone2 = Instantiate(confeti2);
                Destroy(clone, 3);
                Destroy(clone2, 3);

            }
        }
    }
}
