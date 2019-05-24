using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPoint : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
            var newPos = new Vector3(target.transform.position.x, target.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.position = newPos;
       
    }
}
