using TMPro;
using UnityEngine;

public class game_ui : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score_ui;
    [SerializeField] private GameObject life_image;
    [SerializeField] private Transform life_container;
    [SerializeField] private GameObject game_over_screen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScoreUI(logic_manager.instance.score);
        logic_manager.instance.OnScoreChange += UpdateScoreUI;

        UpdateLifesUI(playermanager.instance.lifes);
        playermanager.instance.OnLifesChange += UpdateLifesUI;
    }

    public void UpdateScoreUI(int score)
    {
        score_ui.text = score.ToString();
    }

    public void UpdateLifesUI(int lifes)
    {
        if(lifes <= 0)
        {
            game_over_screen.SetActive(true);
        }

        while(life_container.childCount < lifes)
        {
            Instantiate(life_image, life_container);
        }

        while(life_container.childCount > lifes)
        {
            GameObject life = life_container.GetChild(life_container.childCount - 1).gameObject;
            life.transform.SetParent(null);
            Destroy(life);
        }
    }
}
