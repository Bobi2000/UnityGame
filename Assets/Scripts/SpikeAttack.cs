using UnityEngine;

public class SpikeAttack : MonoBehaviour
{
    public Transform Player;
    int MoveSpeed = 4;
    int MaxDist = 10;
    int MinDist = 5;

    void Update()
    {
        //transform.LookAt(Player);

        //if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        //{
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
        {
            //Here Call any function U want Like Shoot at here or something
			
			//Calling method for attack.
        }
        //}
    }
}
