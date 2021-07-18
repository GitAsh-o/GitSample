using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    [SerializeField] private GameObject dummyObjtPref = default;

    [SerializeField] private Transform dummyObjtParent = default;

    [SerializeField] private Vector3 v0 = default;

    [SerializeField] private int dummyCount = 10;

    [SerializeField] private float secInterval = 0.2f;

    private List<GameObject> dummySphereList = new List<GameObject>();
    private Rigidbody2D rigid = default;

    private bool drow = true;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        if (!rigid) rigid = gameObject.AddComponent<Rigidbody2D>();
        rigid.isKinematic = true;

        dummyObjtParent.transform.position = transform.position;

        for(int i = 0; i < dummyCount; i++)
        {
            var obj = (GameObject)Instantiate(dummyObjtPref, dummyObjtParent);
            dummySphereList.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!drow) return;

        for(int i = 0; i < dummyCount; i++)
        {
            var t = i * secInterval;
            var x = t * v0.x;
            var z = t * v0.z;
            var y = (v0.y * t) - 0.5f * (-Physics.gravity.y) * Mathf.Pow(t, 2.0f);
            dummySphereList[i].transform.localPosition = new Vector3(x,y,z);
        }

        if (Input.GetMouseButtonDown(0))
        {
            drow = false;
            rigid.isKinematic = false;
        }
    }

    /*void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("wall"))
        {
            drow = false;
            rigid.isKinematic = false;
        }
    }*/
    
    public void Set(Vector3 v3)
    {
        v0 = v3;
    }
}
