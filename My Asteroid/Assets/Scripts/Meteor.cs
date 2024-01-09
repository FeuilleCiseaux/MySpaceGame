using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float maxLifeTime = 3;

    void Start()
    {
        Destroy(gameObject, maxLifeTime);
        GetComponent<Rigidbody>().AddForce(new Vector3(0, -speed * 100, 0));
    }


}
