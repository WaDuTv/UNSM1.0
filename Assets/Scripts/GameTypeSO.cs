using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Assets/ScriptableObjects/gameGenre")]
public class GameTypeSO : ScriptableObject
{

    public string gameGenre;

    public float optimumGraphics;
    public float optimumSound;
    public float optimumGameplay;
    public float optimumContent;    
    public float optimumControls;    
    
    public float audienceRating_kids;
    public float audienceRating_teenagers;
    public float audienceRating_adults;
    public float audienceRating_seniors;
    public float audienceRating_everyone;

    public bool isBooming;

    public List<GameTypeSO> fittingSubgenres;

    public List<string> fittingThemes;

    private void CalculateAudienceRatingEveryone()
    {
         audienceRating_everyone = (audienceRating_kids + audienceRating_teenagers + audienceRating_adults + audienceRating_seniors) / 4;
    }
}
