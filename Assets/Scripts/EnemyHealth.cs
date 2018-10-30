using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int Health = 3;

    private SaplingAttack SaplingAttack;

    private void Awake()
    {
        this.SaplingAttack = GetComponent<SaplingAttack>();
    }

    public void FixedUpdate()
    {
        if (this.Health <= 0)
        {
            SaplingAttack.IsAlive = false;
            Destroy(this.gameObject, 1.5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "PlayerBullet")
        {
            //damage
            this.Health -= 1;
        }
    }
}
