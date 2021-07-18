using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSc : MonoBehaviour
{
    [SerializeField] private DrawLine dLine = default;　//予測起動を表示

    [SerializeField] private GameObject Text;

    float a = 0.5f;
    float b = 0.1f;
    float c = 0.9f;
    float sita = 0;
    float speed = 7.5f;
    int jump = 0;
    public GameObject offset;
    public GameObject drawCube;

    // Start is called before the first frame update
    void Start()
    {
        offset.transform.rotation = Quaternion.Euler(0, 0, 180 * a - 90);
        sita = a * (Mathf.PI);
        drawCube = GameObject.Find("DrawLine");
    }

    // Update is called once per frame
    void Update()
    {
        if (jump == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector3(Mathf.Cos(sita) * speed, Mathf.Sin(sita) * speed, 0);
                GetComponent<Rigidbody2D>().gravityScale = 1;
                jump = 0;
                transform.parent = null;
                Text.SetActive(false);
                DeletewallSc.istouch = false;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            a += (0.75f * Time.deltaTime);
            if (a >= c)
            {
                a = c;
            }
            sita = a * (Mathf.PI);
            offset.transform.rotation = Quaternion.Euler(0, 0, 180 * a - 90);
            drawCube.GetComponent<DrawLine>().Set(new Vector3(Mathf.Cos(sita) * speed, Mathf.Sin(sita) * speed, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            a -= (0.75f * Time.deltaTime);
            if (a <= b)
            {
                a = b;
            }
            sita = a * (Mathf.PI);
            offset.transform.rotation = Quaternion.Euler(0, 0, 180 * a - 90);
            drawCube.GetComponent<DrawLine>().Set(new Vector3(Mathf.Cos(sita) * speed, Mathf.Sin(sita) * speed, 0));
        }
        if(this.gameObject.transform.position.y < -10)
        {
            SceneManager.LoadScene("gameover");
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.CompareTag("right wall"))
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            speed = 7.5f;
            jump = 1;
            a = 0f;
            b = -0.4f;
            c = 0.4f;
            sita = a * (Mathf.PI);
            offset.transform.rotation = Quaternion.Euler(0, 0, 180 * a - 90);
            Text.SetActive(true);
            Debug.Log("right");
        }
        if (col.gameObject.CompareTag("left wall"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            speed = 7.5f;
            jump = 1;
            a = 1.0f;
            b = 0.6f;
            c = 1.4f;
            sita = a * (Mathf.PI);
            offset.transform.rotation = Quaternion.Euler(0, 0, 180 * a - 90);
            Text.SetActive(true);
            Debug.Log("left");
        }
        if (col.gameObject.CompareTag("head wall"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            speed = 7.5f;
            jump = 1;
            a = 0.5f;
            b = 0.1f;
            c = 0.9f;
            sita = a * (Mathf.PI);
            offset.transform.rotation = Quaternion.Euler(0, 0, 180 * a - 90);
            Text.SetActive(true);
            Debug.Log("head");
        }
        if (col.gameObject.CompareTag("bottom wall"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            speed = 7.5f;
            jump = 1;
            a = -0.5f;
            b = -0.9f;
            c = -0.1f;
            sita = a * (Mathf.PI);
            offset.transform.rotation = Quaternion.Euler(0, 0, 180 * a - 90);
            Text.SetActive(true);
            Debug.Log("bottom");
        }
        if (col.gameObject.CompareTag("wall"))
        {
            offset.transform.rotation = Quaternion.Euler(0, 0, 180 * a - 90);
            Debug.Log("wall");
        }
        if (col.gameObject.CompareTag("moving wall"))
        {
            offset.transform.rotation = Quaternion.Euler(0, 0, 180 * a - 90);
            transform.parent = GameObject.Find("Movingwall").transform;
        }
        if (col.gameObject.CompareTag("deletewall"))
        {
            offset.transform.rotation = Quaternion.Euler(0, 0, 180 * a - 90);
            DeletewallSc.istouch = true;
            Debug.Log("ddd");
        }
        if (col.gameObject.CompareTag("floor"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            jump = 1;
            a = 0.5f;
            b = 0.1f;
            c = 0.9f;
            offset.transform.rotation = Quaternion.Euler(0, 0, 180 * a - 90);
            Text.SetActive(true);
        }
        if (col.gameObject.CompareTag("goal"))
        {
            SceneManager.LoadScene("goal");
        }
    }
}
