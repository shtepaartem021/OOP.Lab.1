using System;
using System.Collections.Generic;

namespace DuelingSimulation
{
    public class DuelResult
    {
        public string DuelId { get; set; }
        public List<Wizard> Contestants { get; set; }
        public Wizard Winner { get; set; }
        public Wizard Loser { get; set; }
        public List<string> TurnLog { get; set; }

        public DuelResult(string duelId, List<Wizard> contestants, Wizard winner, Wizard loser, List<string> turnLog)
        {
            DuelId = duelId;
            Contestants = contestants;
            Winner = winner;
            Loser = loser;
            TurnLog = turnLog;
        }

        public override string ToString()
        {
            string result = $"Дуель #{DuelId}: {Winner.Name} переміг {Loser.Name}\n";
            result += "Ходи:\n";
            foreach (var log in TurnLog)
                result += "  " + log + "\n";
            return result;
        }
    }
}
