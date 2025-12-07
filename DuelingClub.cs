using System;
using System.Collections.Generic;

namespace DuelingSimulation
{
    public class DuelingClub
    {
        private static int duelCounter = 1;

        public DuelResult HostDuel(Wizard wizard1, Wizard wizard2)
        {
            if (wizard1.KnownSpells.Count == 0 || wizard2.KnownSpells.Count == 0)
            {
                Console.WriteLine($"Неможливо провести дуель між {wizard1.Name} і {wizard2.Name}");
                return null;
            }

            wizard1.RestoreHealth();
            wizard2.RestoreHealth();

            List<string> turnLog = new List<string>();
            Random rnd = new Random();

            while (wizard1.Health > 0 && wizard2.Health > 0)
            {
                var spell1 = wizard1.CastRandomSpell();
                wizard2.TakeDamage(spell1.Damage);
                turnLog.Add($"{wizard1.Name} кастує {spell1.Name} ({spell1.Damage} шкоди) — {wizard2.Name} має {wizard2.Health} HP");

                if (wizard2.Health <= 0)
                    break;

                var spell2 = wizard2.CastRandomSpell();
                wizard1.TakeDamage(spell2.Damage);
                turnLog.Add($"{wizard2.Name} кастує {spell2.Name} ({spell2.Damage} шкоди) — {wizard1.Name} має {wizard1.Health} HP");
            }

            Wizard winner = wizard1.Health > 0 ? wizard1 : wizard2;
            Wizard loser = wizard1.Health <= 0 ? wizard1 : wizard2;

            DuelResult duelResult = new DuelResult(
                duelId: duelCounter.ToString(),
                contestants: new List<Wizard> { wizard1, wizard2 },
                winner: winner,
                loser: loser,
                turnLog: turnLog
            );

            wizard1.AddDuelToHistory(duelResult);
            wizard2.AddDuelToHistory(duelResult);

            duelCounter++;
            return duelResult;
        }
    }
}
