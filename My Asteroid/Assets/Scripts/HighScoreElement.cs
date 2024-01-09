using System;

[Serializable] 
public class HighscoreElement
{
    public string name;
    public int score;

    public HighscoreElement(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}