using UnityEngine;

public class CharacterBullet : MonoBehaviour
{
    public float TimeToDestroy = 6;

    public ParticleSystem OnBulletDestroy;

    public void Update()
    {
        if (TimeToDestroy <= 0)
        {
            Destroy(this.gameObject);
        }
        TimeToDestroy -= Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(collision.gameObject.name == "Character"))
        {
            Debug.Log("Bullet");

            Instantiate(OnBulletDestroy, this.transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }
    }
}
