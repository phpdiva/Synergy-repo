using UnityEngine;
using System.Collections;

public class Link : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (this.name == "TheirLinks")
        {
            Application.ExternalEval("window.open('http://freemusicarchive.org/music/Advent_Chamber_Orchestra/Selections_from_the_November_2006_Concert/','_blank')");
        }
        else if (this.name == "OurLinks")
        {
            Application.ExternalEval("window.open('http://www.sophiesgames.com/','_blank')");
        }
    }
}
