using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [Header("ITENS")]
    [SerializeField] Image waterUIBar;
    [SerializeField] Image woodUIBar;
    [SerializeField] Image carrotUIBar;
    [SerializeField] Image fishUIBar;

    [Header("TOOLS")]
    // [SerializeField] Image axeUI;
    // [SerializeField] Image shoveUI;
    // [SerializeField] Image bucketUI;
    public List<Image> toolsUI = new List<Image>();
    [SerializeField] Color selectColor;
    [SerializeField] Color alphaColor;

    PlayerItens playerItens;
    Player player;

    void Awake()
    {
        player = FindObjectOfType<Player>();
        playerItens = player.GetComponent<PlayerItens>();
    }

    void Start()
    {
        waterUIBar.fillAmount = 0f;
        woodUIBar.fillAmount = 0f;
        carrotUIBar.fillAmount = 0f;
        fishUIBar.fillAmount = 0f;
    }

    void Update()
    {
        waterUIBar.fillAmount = playerItens.currentWater / playerItens.WaterLimit;
        woodUIBar.fillAmount = playerItens.currentWood / playerItens.WoodLimit;
        carrotUIBar.fillAmount = playerItens.currentCarrots / playerItens.CarrotLimit;
        fishUIBar.fillAmount = playerItens.currentFishes / playerItens.FishesLimit;

        toolsUI[player.handlingObj].color = selectColor;

        for (int i = 0; i < toolsUI.Count; i++)
        {
            if (i == player.handlingObj)
            {
                toolsUI[i].color = selectColor;
            }
            else
            {
                toolsUI[i].color = alphaColor;
            }
        }
    }
}
