using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salarify.DataLayer.Models
    {
    public static class SatisfactionBonus
        {
        public static int GetBonusPercentage (SatisfactionScore score)
            {
            switch ( score )
                {
                case SatisfactionScore.VerySatisfied:
                    return 20;
                case SatisfactionScore.Satisfied:
                    return 15;
                case SatisfactionScore.AboveAverage:
                    return 7;
                case SatisfactionScore.BelowAverage:
                    return 2;
                case SatisfactionScore.Unsatisfied:
                case SatisfactionScore.VeryUnsatisfied:
                default:
                    return 0;
                }
            }
        }
    }
