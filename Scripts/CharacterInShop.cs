using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterInShop : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    public Joystick joystick;
    [SerializeField] Manager manager;
    bool isFacingLeft;
    float speed, speedTulip, speedSaffron, speedMawar;
    [SerializeField] GameObject sellmenu, bucketOfTulip, bucketOfSaffron, bucketOfMawar, bg, meja;
    // Start is called before the first frame update
    void Start()
    {
        speedTulip = 15f;
        speedSaffron = 15f;
        speedMawar = 15f;
        anim = GetComponent<Animator>();
        isFacingLeft = false;
        speed = 8f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            sellmenu.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            sellmenu.SetActive(false);
        }

        float dirX = Input.GetAxisRaw("Horizontal");
        float dirY = Input.GetAxisRaw("Vertical");
        if (dirX != 0 || dirY != 0)
        {
            anim.SetBool("isWalkInShop", true);
        }
        else
        {
            anim.SetBool("isWalkInShop", false);
        }

        if (dirX < 0 && !isFacingLeft)
        {
            isFacingLeft = true;
            transform.Rotate(new Vector3(0, 180, 0));
            speed = -8f;

        }
        else if (dirX > 0 && isFacingLeft)
        {
            isFacingLeft = false;
            transform.Rotate(new Vector3(0, 180, 0));
            speed = 8f;
        }
        transform.Translate(new Vector2(dirX * speed * Time.deltaTime, dirY * 3f * Time.deltaTime));
    }

    public void activateMenuJual()
    {
        sellmenu.SetActive(true);
    }

    private void FixedUpdate()
    {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            anim.SetBool("isWalkInShop", true);
        }
        else
        {
            anim.SetBool("isWalkInShop", false);
        }

        if (joystick.Horizontal > 0 && isFacingLeft)
        {
            isFacingLeft = false;
            speed = 15f;
            transform.Rotate(new Vector3(0, -180, 0));
        }
        else if (joystick.Horizontal < 0 && !isFacingLeft)
        {
            isFacingLeft = true;
            speed = 15f;
            transform.Rotate(new Vector3(0, 180, 0));
        }
        rb.velocity = new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed);
    }
    public void backToGarden()
    {
        SceneManager.LoadScene(2);
    }
}