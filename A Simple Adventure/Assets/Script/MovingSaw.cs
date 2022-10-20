using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSaw : MonoBehaviour
{
    [SerializeField] GameObject[] waypoint;
    private int index;

    [SerializeField] float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(waypoint[index].transform.position,transform.position) < 0.1f)
        {
            index++;
            if (index >= waypoint.Length)
            {
                index = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoint[index].transform.position, Time.deltaTime * speed);
    }
}
