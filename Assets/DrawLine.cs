using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    [SerializeField] private GameObject dummyObjtPref = default;

    [SerializeField] private Transform dummyObjtParent = default;

    [SerializeField] private Vector3 v0 = default;

    [SerializeField] private int dummyCount = 20;

    [SerializeField] private float secInterval = 0.15f;

    private List<GameObject> dummySphereList = new List<GameObject>();
    private Rigidbody2D rigid = default;

    public GameObject player;

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
        for(int i = 0; i < dummyCount; i++)
        {
            var t = i * secInterval;
            var x = t * v0.x;
            var z = t * v0.z;
            var y = (v0.y * t) - 0.5f * (-Physics.gravity.y) * Mathf.Pow(t, 2.0f);
            dummySphereList[i].transform.localPosition = new Vector3(x, y, z);

            Ray2D ray = new Ray2D(dummySphereList[i].transform.position,new Vector3(x,y,z));

            RaycastHit2D hit2D;
            
            int distance2D = 30;

            /*if (Physics2D.Raycast(ray,out hit2D,distance2D))
            {
                Debug.Log("aaaaaaa");
                player.GetComponent<PlayerSc>().delete();
            }*/
        }
    }
    
    public void Set(Vector3 v3)
    {
        v0 = v3;
    }
}
