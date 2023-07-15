using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teko : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(startAnimation());
    }

    IEnumerator startAnimation()
    {
        anim.SetBool("isWateringIcon", true);
        yield return new WaitForSeconds(1.1f);
        Destroy(gameObject);
    }
}
