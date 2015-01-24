using UnityEngine;
using System.Collections;
using System; //This allows the IComparable Interface

//This is the class you will be storing
//in the different collections. In order to use
//a collection's Sort() method, this class needs to
//implement the IComparable interface.
public class levelsailo : IComparable<levelsailo>
{
    public string name;
    public bool pelattu;

    public levelsailo(string newName, bool newPelattu)
    {
        name = newName;
        pelattu = newPelattu;
    }

    //This method is required by the IComparable
    //interface. 
    public int CompareTo(levelsailo other)
    {
        if (other == null)
        {
            return 1;
        }

        //Return the difference in power.
        return 0;
    }
}