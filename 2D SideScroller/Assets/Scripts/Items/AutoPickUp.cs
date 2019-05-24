using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInterfaces;

public class AutoPickUp : MonoBehaviour, IAutoInteract
{

    [SerializeField]
    private float _interactRadius;
    public float interactRadius { get; set; }

    public bool inRange = false;
    public Transform target;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        interactRadius = _interactRadius;
        var cirCollider = gameObject.GetComponent<CircleCollider2D>();
        cirCollider.radius = interactRadius;
    }

    // Update is called once per frame
    void Update()
    {
        if(inRange)
        {
            float step = speed * Time.deltaTime;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(target.position.x, gameObject.transform.position.y), step);
        }
    }

    public void Interact(GameObject gameObject)
    {
        inRange = true;
        target = gameObject.transform;
    }
    public void RemoveTarget(GameObject gameObject)
    {
        target = null;
        inRange = false;
    }


}
