using System;
using System.Collections.Generic;
using System.Linq;

namespace ulearn_game_YoungRevolutioneerGame
{
    public static class Spells
    {
        public enum OutcomeType
        {
            AlliesMood,
            FoesMood,
            Poaching,
            MurderFoes,
            MurderAllies
        }

        public static SpellOutcome[] EvaluateOutcome(Spell spell)
        {
            var rand = new Random();
            return spell.PossibleOutcomes
                .SelectMany(x => rand.Next(100) <= x.PrimaryProbabilityPercentage ? x.Primary : x.Secondary)
                .Select(x => new SpellOutcome { Type = x.Type, Value = x.ValueMin + rand.Next(x.ValueMax - x.ValueMin) })
                .ToArray();
        }
    }

    public class SpellPossibleOutcome
    {
        public Spells.OutcomeType Type;
        public int ValueMin;
        public int ValueMax;
    }

    public class SpellOutcome
    {
        public Spells.OutcomeType Type;
        public int Value;
    }


    public class OutcomeFork
    {
        public int PrimaryProbabilityPercentage;
        public SpellPossibleOutcome[] Primary;
        public SpellPossibleOutcome[] Secondary;
    }


    public class Spell
    {
        public string Name;
        public OutcomeFork[] PossibleOutcomes;
    }
}
