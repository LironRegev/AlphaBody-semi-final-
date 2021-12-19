﻿using Dal;
using Dal.DataTypes;
using Dal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.NeededCaloriesCalculators
{
    public class WeightLoseNCC : INeededCaloriesCalculator
    {
        List<GoalDefinition> goalDefinitions;
        Dictionary<ActivityLevel, int> activityCalories;
        public WeightLoseNCC()
        {
            goalDefinitions = DBOperations.GetGoalDefinitionsByGoal(Goal.WeightLose);
            activityCalories = new Dictionary<ActivityLevel, int>()
            {
                {ActivityLevel.SuperLight, -500 },
                {ActivityLevel.Light, -250 },
                {ActivityLevel.Medium, -150 },
                {ActivityLevel.Heavy, 150 },
                {ActivityLevel.SuperHeavy, 300 },
            };
        }
        private int GetHeightCalaulation(Gender gender, int height)
        {
            if (gender == Gender.Male)
            {
                if (height >= 140 && height <= 149)
                {
                    return -200;
                }
                else if (height >= 150 && height <= 159)
                {
                    return -300;
                }
                else if (height >= 160 && height <= 169)
                {
                    return -400;
                }
                else if (height >= 170 && height <= 179)
                {
                    return -500;
                }
                else if (height >= 180 && height <= 189)
                {
                    return -600;
                }
                else if (height >= 190 && height <= 200)
                {
                    return -700;
                }
                else
                {
                    return -800;
                }

            }
            if (gender == Gender.Female)
            {
                if (height >= 140 && height <= 149)
                {
                    return -150;
                }
                else if (height >= 150 && height <= 159)
                {
                    return -250;
                }
                else if (height >= 160 && height <= 169)
                {
                    return -350;
                }
                else if (height >= 170 && height <= 179)
                {
                    return -450;
                }
                else if (height >= 180 && height <= 189)
                {
                    return -550;
                }
                else if (height >= 190 && height <= 200)
                {
                    return -650;
                }
                else
                {
                    return -750;
                }

            }

            return 0;
        }
        public int CalculateNeededCalories(int age, Gender gender, int height, double weight, ActivityLevel activityLevel)
        {
            var definition = goalDefinitions.FirstOrDefault(gd => gd.MinAge <= age && gd.MaxAge >= age && gd.Gender == gender);

            var activitycalculation = activityCalories[activityLevel];

            var heightcalaulation = GetHeightCalaulation(gender, height);

            return definition.Calories + activitycalculation + heightcalaulation;
        }
    }
}
