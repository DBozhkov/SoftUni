using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            string result = string.Empty;

            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }

            else if (racerOne.IsAvailable() == false)
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }

            else if (racerTwo.IsAvailable() == false)
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }

            else
            {
                var firstChanceOfWinning = 0.0;
                var secondChanceOfWinning = 0.0;
                var firstMultiplier = 0.0;
                var secondMultiplier = 0.0;

                if (racerOne.RacingBehavior == "strict")
                {
                    firstMultiplier = 1.2;
                }
                else if (racerOne.RacingBehavior == "aggressive")
                {
                    firstMultiplier = 1.1;
                }

                if (racerTwo.RacingBehavior == "strict")
                {
                    secondMultiplier = 1.2;
                }
                else if (racerTwo.RacingBehavior == "aggressive")
                {
                    secondMultiplier = 1.1;
                }

                racerOne.Race();
                racerTwo.Race();

                firstChanceOfWinning = racerOne.Car.HorsePower * racerOne.DrivingExperience * firstMultiplier;
                secondChanceOfWinning = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * secondMultiplier;

                if (firstChanceOfWinning > secondChanceOfWinning)
                {
                    result = $"{racerOne.Username} has just raced against {racerOne.Username}! {racerOne.Username} is the winner!";
                }

                else
                {
                    result = $"{racerTwo.Username} has just raced against {racerTwo.Username}! {racerTwo.Username} is the winner!";
                }
            }


            return result;
        }
    }
}
