using System;
using System.Collections.Generic;

namespace DuelingSimulation
{
    public class Wizard
    {
        private const int InitialHealth = 100;

        public string Name { get; set; }
        public string House { get; set; }
        public int Health { get; private set; }
        public List<Spell> KnownSpells { get; private set; }
        private List<DuelResult> duelHistory;

        public Wizard(string name, string house)
        {
            Name = name;
            House = house;
            Health = InitialHealth;
            KnownSpells = new List<Spell>();
            duelHistory = new List<DuelResult>();
        }

        public void LearnSpell(Spell spell)
        {
            KnownSpells.Add(spell);
        }

        public Spell CastRandomSpell()
        {
            if (KnownSpells.Count == 0)
                return null;

            Random rnd = new Random();
            int index = rnd.Next(KnownSpells.Count);
            return KnownSpells[index];
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
                Health = 0;
        }

        public void RestoreHealth()
        {
            Health = InitialHealth;
        }

        public void AddDuelToHistory(DuelResult duelRecord)
        {
            duelHistory.Add(duelRecord);
        }

        public void GetDuelHistory()
        {
            Console.WriteLine($"Історія дуелей чарівника {Name}:");
            if (duelHistory.Count == 0)
            {
                Console.WriteLine("Немає записів про дуелі.\n");
                return;
            }

            foreach (var duel in duelHistory)
                Console.WriteLine(duel.ToString());
        }
    }
}
