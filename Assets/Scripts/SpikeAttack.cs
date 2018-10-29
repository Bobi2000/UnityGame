using UnityEngine;

public class SpikeAttack : MonoBehaviour
{
    public Transform Player;
    int MoveSpeed = 7;
    int MaxDist = 10;
    int MinDist = 5;

    private Vector3 spikePosition;

    private Vector3 velocity = Vector3.zero;
    private float SmoothTime = 0.3f;

    public void Update()
    {

        Vector3 goalPos = Player.position;

        //goalPos.y = transform.position.y;
        //goalPos.x = transform.position.x;

        transform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, SmoothTime, this.MoveSpeed);

        transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
        {
            //Calling method for attack.
        }
    }
}
