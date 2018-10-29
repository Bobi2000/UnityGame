using System.Collections.Generic;
using UnityEngine;

public class SaplingAttack : MonoBehaviour
{
    public static bool IsAlive = true;

    public int MoveSpeed = 3;

    private int distance = 10;

    Vector3 velocity = Vector3.zero;
    private float SmoothTime = 0.3f;

    private Transform Target;
    private GameObject PointParent;

    private List<Transform> Points = new List<Transform>();

    private Vector2 GoalPos;

    private bool Pause = false;
    private float PauseTime = 0;
    private float CheckIfStucked = 0;
    
    private void Start()
    {
        this.PointParent = GameObject.Find("Points");
        this.Target = GameObject.Find("Character").transform;

        foreach (Transform child in PointParent.transform)
        {
            this.Points.Add(child);
        }

        this.GoalPos = this.Points[Random.Range(0, this.Points.Count - 1)].position;
    }

    private void FixedUpdate()
    {
        if (IsAlive)
        {
            if (Vector3.Distance(this.Target.position, this.gameObject.transform.position) < 3)
            {
                Vector3 goalPos = Target.position;

                //transform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, SmoothTime, this.MoveSpeed);
                // transform.position += transform.forward * MoveSpeed * Time.deltaTime;

                transform.position = Vector2.MoveTowards(transform.position, goalPos, this.MoveSpeed * Time.deltaTime);
            }
            else if (this.Pause)
            {
                if (this.PauseTime > 0)
                {
                    this.PauseTime -= Time.deltaTime;
                }
                else
                {
                    this.Pause = false;
                }
            }
            else
            {
                var speedToPoint = 0;

                //Changing point
                if (Vector2.Distance(this.GoalPos, this.transform.position) <= Random.Range(0.01f, 2.2f))
                {
                    if (Random.Range(0, 100) > 75)
                    {
                        Debug.Log("PAUSE");
                        this.Pause = true;
                        this.PauseTime = Random.Range(0.4f, 1f);
                    }

                    this.GoalPos = Points[Random.Range(0, this.Points.Count - 1)].position;
                }

                //Slowing down near point
                if (Vector2.Distance(this.GoalPos, this.transform.position) <= 1.5f)
                {
                    speedToPoint = 1;
                }

                transform.position = Vector2.MoveTowards(transform.position, this.GoalPos, (this.MoveSpeed - 0.5f - speedToPoint) * Time.deltaTime);

            }
        }
    }
}
