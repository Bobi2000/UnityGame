using UnityEngine;

public class SaplingController : MonoBehaviour
{
    public static int CurrentSaplings = 0;

    public GameObject Sapling;

    public float TimeInBetweenSapplings = 20;

    public void Update()
    {
        if (this.TimeInBetweenSapplings <= 0)
        {
            if (CurrentSaplings == 0)
            {
                Instantiate(this.Sapling, this.transform.position, Quaternion.identity);
            }

            this.TimeInBetweenSapplings = 20;
        }
        else
        {
            this.TimeInBetweenSapplings -= Time.deltaTime;
        }

        
    }
}
