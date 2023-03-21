using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItens : MonoBehaviour
{
    [Header("Amounts")]
    [SerializeField] int _currentwood;
    [SerializeField] int _currentcarrots;
    [SerializeField] float _currentWater;
    [SerializeField] float _currentFishes;

    public int currentWood { get => _currentwood; set => _currentwood = value; }
    public float currentWater { get => _currentWater; set => _currentWater = value; }
    public int currentCarrots { get => _currentcarrots; set => _currentcarrots = value; }
    public float currentFishes { get => _currentFishes; set => _currentFishes = value; }

    [Header("Limits")]
    [SerializeField] float waterLimit = 50f;
    [SerializeField] float woodLimit = 5f;
    [SerializeField] float carrotLimit = 10f;
    [SerializeField] float fishesLimit = 3f;

    public float WaterLimit { get => waterLimit; set => waterLimit = value; }
    public float WoodLimit { get => woodLimit; set => woodLimit = value; }
    public float CarrotLimit { get => carrotLimit; set => carrotLimit = value; }
    public float FishesLimit { get => fishesLimit; set => fishesLimit = value; }

    public void Waterlimit(float water)
    {
        if (currentWater <= WaterLimit)
        {
            currentWater += water;
        }
    }


}
