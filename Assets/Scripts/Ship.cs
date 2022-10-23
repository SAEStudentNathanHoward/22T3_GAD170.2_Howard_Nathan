using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NathanHoward
{
    public class Ship : MonoBehaviour
    {
        //Creation of the 2 lists
        List<string> currentCrewNames;
        List<string> currentCrewHobbies;

        //public method to add crewmembers to the ship
        public void AddToShip(bool isAlien, string newCrewName, string newCrewHobby)
        {
            //Checking to see if the new crew member is an alien
            if (isAlien == false)
            {
                //Add the new crew member to the list along with their hobby
                currentCrewNames.Add(newCrewName);
                currentCrewHobbies.Add(newCrewHobby);
            }
            else
            {
                //Code that calls the killing of a random amount of Crew Members
                EliminateCrewmates(Random.Range(1,3));
            }
        }
        private void EliminateCrewmates(int amountKilled)
        {
            Debug.Log("Alien Detected! You have just lost " + amountKilled + " crewmates!");
        }
    }
}
