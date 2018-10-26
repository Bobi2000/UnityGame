using UnityEngine;

public class GrassMovment : MonoBehaviour
{
    public BoxCollider2D Grass;

    private Animator anim;

    public void Update()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (Grass)
        {
            anim.SetInteger("Dist", 1);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (Grass)
        {
            anim.SetInteger("Dist", 0);
        }

    }
}