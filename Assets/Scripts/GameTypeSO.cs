using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Assets/ScriptableObjects/gameGenre")]
public class GameTypeSO : ScriptableObject
{

    public string gameGenre;

    public int optimumGraphics;
    public int optimumSound;
    public int optimumGameplay;
    public int optimumContent;    
    public int optimumControls;
    
    public int audienceRating_kids;
    public int audienceRating_teenagers;
    public int audienceRating_adults;
    public int audienceRating_seniors;
    public int audienceRating_everyone;

    public bool isBooming;

    public List<GameTypeSO> fittingSubgenres;

    public List<string> fittingThemes;

    private void CalculateAudienceRatingEveryone()
    {
         audienceRating_everyone = (audienceRating_kids + audienceRating_teenagers + audienceRating_adults + audienceRating_seniors) / 4;
    }
}
