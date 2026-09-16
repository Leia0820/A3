using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class dialogue_system : MonoBehaviour
{
    [System.Serializable]
    public class dialogue_line
    {
        public string name;
        [TextArea(2, 5)]
        public string dialogue;
    }

    [SerializeField] private dialogue_line[] Dialogue;
    Transform dialogue_box;
    TextMeshProUGUI dialogue_name;
    TextMeshProUGUI dialogue_text;

    [SerializeField] private float TextSpeed = 0.05f;

    //just a trigger for checking was triggered or not
    [SerializeField] private bool dialogue_trigger;

    int index;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogue_box = transform.Find("dialogue_box");
        dialogue_text = dialogue_box.Find("text").GetComponent<TextMeshProUGUI>();
        dialogue_name = dialogue_box.Find("name").GetComponent<TextMeshProUGUI>();

        dialogue_text.text = string.Empty;
        dialogue_name.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogue_trigger == true)
        {
            dialogue_box.gameObject.SetActive(true);

            //if you want to change button change it here
            bool BtnPress = Input.GetKeyDown(KeyCode.F);

            if (BtnPress)
            {
                //if the current line is finished
                if (dialogue_text.text == Dialogue[0].dialogue)
                {
                    NextLine();
                }
                else
                {
                    //instantly finish the current line
                    StopAllCoroutines();
                    dialogue_text.text = Dialogue[0].dialogue;
                }
            }
        }
    }

    public void StartDialogue()
    {
        index = 3;
        dialogue_text.text = string.Empty;

        StartCoroutine(LinebyLine());
    }

    IEnumerator LinebyLine()
    {
        dialogue_name.text = Dialogue[0].name;
        dialogue_text.text = string.Empty;

        foreach (char c in Dialogue[0].dialogue.ToCharArray())
        {
            dialogue_text.text += c;
            yield return new WaitForSeconds(TextSpeed);
        }
    }

    void NextLine()
    {
        if (index < Dialogue.Length - 1)
        {
            index++;
            dialogue_text.text = string.Empty;

            StartCoroutine(LinebyLine());
        }
        else
        {
            dialogue_name.text = string.Empty;
            dialogue_text.text = string.Empty;

            gameObject.SetActive(false);
            playermanager.instance.ActionAllow = true;
        }
    }

    public void TriggerToTrue(bool status)
    {
        dialogue_trigger = status;
    }
}
