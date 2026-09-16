using System.Collections;
using TMPro;
using UnityEngine;

public class keydialogue_system : MonoBehaviour
{
    [System.Serializable]
    public class DialogueLine
    {
        public string name;

        [TextArea(2, 5)]
        public string dialogue;
    }

    [Header("Dialogue Content")]
    [SerializeField] private DialogueLine[] dialogue;

    Transform keydialogue_box;
    TextMeshProUGUI keydialogue_name;
    TextMeshProUGUI keydialogue_text;

    [SerializeField] private float textSpeed = 0.05f;
    [SerializeField] private bool keydialogue_trigger;

    int index;
    bool isTyping;


    void Start()
    {
        keydialogue_box = transform.Find("keydialogue_box");

        keydialogue_text = keydialogue_box.Find("text").GetComponent<TextMeshProUGUI>();
        keydialogue_name = keydialogue_box.Find("name").GetComponent<TextMeshProUGUI>();

        keydialogue_text.text = string.Empty;
        keydialogue_name.text = string.Empty;

        keydialogue_box.gameObject.SetActive(false);

        keydialogue_trigger = false;
    }


    void Update()
    {
        if (keydialogue_trigger == true)
        {
            keydialogue_box.gameObject.SetActive(true);

            bool BtnPress = Input.GetKeyDown(KeyCode.F);

            if (BtnPress)
            {
                // Text is still typing
                if (isTyping)
                {
                    StopAllCoroutines();

                    keydialogue_name.text = dialogue[index].name;
                    keydialogue_text.text = dialogue[index].dialogue;

                    isTyping = false;
                }
                else
                {
                    NextLine();
                }
            }
        }
    }


    public void StartDialogue()
    {
        if (dialogue == null || dialogue.Length == 0)
        {
            Debug.LogWarning("Key Dialogue has no dialogue lines!");
            return;
        }

        // Start from first dialogue
        index = 0;

        keydialogue_trigger = true;

        keydialogue_box.gameObject.SetActive(true);

        keydialogue_text.text = string.Empty;

        StartCoroutine(LinebyLine());
    }


    IEnumerator LinebyLine()
    {
        isTyping = true;

        keydialogue_name.text = dialogue[index].name;
        keydialogue_text.text = string.Empty;

        foreach (char c in dialogue[index].dialogue.ToCharArray())
        {
            keydialogue_text.text += c;

            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
    }


    void NextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;

            keydialogue_text.text = string.Empty;

            StartCoroutine(LinebyLine());
        }
        else
        {
            EndDialogue();
        }
    }


    void EndDialogue()
    {
        StopAllCoroutines();

        isTyping = false;
        keydialogue_trigger = false;

        keydialogue_name.text = string.Empty;
        keydialogue_text.text = string.Empty;

        keydialogue_box.gameObject.SetActive(false);

        playermanager.instance.ActionAllow = true;
    }


    public void TriggerToTrue(bool status)
    {
        keydialogue_trigger = status;
    }
}