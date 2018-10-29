using System.Collections.Generic;
using UnityEngine;

public class SaplingAttack : MonoBehaviour
{
    public Transform Target;
    public int MoveSpeed = 7;

    private int distance = 10;
    
    Vector3 velocity = Vector3.zero;
    private float SmoothTime = 0.3f;

    public GameObject PointParent;

    private List<Transform> Points = new List<Transform>();

    public float TimeToDot = 0;

    private void Awake()
    {
        foreach (Transform child in PointParent.transform)
        {
            this.Points.Add(child);
        }
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(this.Target.position, this.gameObject.transform.position) < 1)
        {
            Debug.Log("Inside");

            Vector3 goalPos = Target.position;

            transform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, SmoothTime, this.MoveSpeed);

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
        else
        {
            Vector2 goalPos = null;

            if (goalPos == null)
            {
                goalPos = Points[Random.Range(0, this.Points.Count - 1)].position;
            }

            if (this.TimeToDot > 5)
            {
                goalPos = Points[Random.Range(0, this.Points.Count - 1)].position;
                this.TimeToDot = 0;
            }
            else
            {
                this.TimeToDot += Time.deltaTime;
            }
            
            
            transform.position = Vector2.MoveTowards(transform.position, goalPos, this.MoveSpeed * Time.deltaTime);
            
        }
        
    }
}
