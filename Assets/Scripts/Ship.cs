using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NathanHoward
{
    public class Ship : MonoBehaviour
    {
        //Creation of the 2 lists
        [SerializeField] List<string> currentCrewNames;
        [SerializeField] List<string> currentCrewHobbies;

        [SerializeField] GameObject mainCanvas;
        [SerializeField] GameObject bloodSplatter;

        private int currentCrewCount = 0;

        private void Update()
        {
            if (bloodSplatter.GetComponent<CanvasGroup>().alpha > 0f)
            {
                bloodSplatter.GetComponent<CanvasGroup>().alpha -= 0.001f;
            }
        }

        // Public method to add crewmembers to the ship
        public void AddToShip(bool isAlien, string newCrewName, string newCrewHobby)
        {
            // Checking to see if the new crew member is an alien
            if (isAlien == false)
            {
                // Add the new crew member to the list along with their hobby
                currentCrewNames.Add(newCrewName);
                currentCrewHobbies.Add(newCrewHobby);

                currentCrewCount += 1;

                //Debug.Log(currentCrewCount);

                if (currentCrewCount == 10)
                {
                    mainCanvas.SetActive(false);
                }
            }
            else
            {
                // Code that calls the killing of a random amount of Crew Members
                EliminateCrewmates(Random.Range(1,3));
            }
        }

        // Method used to Destroy the Crewmates
        // Needs input from AddToShip
        private void EliminateCrewmates(int amountKilled)
        {
            
            //Debug.Log(amountKilled);

            // Sifting through to delete a random number of crewmates
            for (int i = 0; i < amountKilled; i++)
            {
                // Creation of a random int to track which crewmate to delete
                int currentCrewIndex = Random.Range(1, currentCrewCount);
                
                //Debug.Log(currentCrewIndex);
               
                // Removal of the crew names and hobbies
                currentCrewNames.RemoveAt(currentCrewIndex);
                currentCrewHobbies.RemoveAt(currentCrewIndex);

                //Debug.Log("End of for i");
                //Debug.Log("i = " + i);

                currentCrewCount -= amountKilled;
                
                //Debug.Log(currentCrewCount);
                bloodSplatter.GetComponent<CanvasGroup>().alpha = 1;
            }

            Debug.Log("Alien Detected! You have just lost " + amountKilled + " crewmates!");
        }

        public void ShowCrewmates()
        {

        }
    }
}
