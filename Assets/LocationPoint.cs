using UnityEngine;

public enum LocationType 
{ 
    Lab1, // 제1연구실
    Lab2, // 제2연구실
    ChemicalLab, // 화학 실험실
    SterileLab, // 멸균 세척실
    DangerLab, // 위험물 저장소
    FantasyLab, // 환상재료 양자역학 합성실
    Toilet, // 화장실
    GrowingRoom, // 실내 재배실
}

public class LocationPoint : MonoBehaviour
{
    public LocationType LocationType;
    public string ItemName;
}