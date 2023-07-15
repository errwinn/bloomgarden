using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour
{
    [SerializeField] Sprite[] spriteForIntro;
    [SerializeField] GameObject imageToShow;
    [SerializeField] Manager manager;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        manager.isFirstTimePlaying = true;
        manager.difficulty = 1;
        manager.isTransactCompleted = true;
        manager.orderanBungaGambar = new Sprite[3];
        manager.orderan = new Dictionary<int, int>();
        manager.jenis_bunga = new ArrayList();
        manager.isFirstTime = true;
        textComponent.text = string.Empty;
        StartDialog();
    }

    // Update is called once per frame
    void Update()
    {
        imageToShow.GetComponent<SpriteRenderer>().sprite = spriteForIntro[index];
        foreach (Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Ended)
            {
                if (textComponent.text == lines[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialog()
    {
        index = 0;
        StartCoroutine(typeLine());
    }

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(typeLine());
        } else
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(1);
        }
    }
    IEnumerator typeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
