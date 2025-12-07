using DuelingSimulation;

namespace DuelingSimulation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Створення заклять");
            Spell expelliarmus = new Spell("Експеліармус", 15, SpellEffect.Disarming);
            Spell stupify = new Spell("Ступефай", 10, SpellEffect.Stunning);
            Spell reducto = new Spell("Редукто", 25, SpellEffect.Damage);
            Spell sectumsempra = new Spell("Сектумсемпра", 35, SpellEffect.Damage);
            Spell protego = new Spell("Протего", 0, SpellEffect.Disarming);
            Spell bombardia = new Spell("Бомбарда", 20, SpellEffect.Damage);

            Console.WriteLine("Створення чарівників");
            Wizard harry = new Wizard("Гаррі Поттер", "Грифіндор");
            Wizard draco = new Wizard("Драко Мелфой", "Слизерин");
            Wizard hermione = new Wizard("Герміона Грейнджер", "Грифіндор");

            Console.WriteLine("Навчання чарівників закляттям");

            harry.LearnSpell(expelliarmus);
            harry.LearnSpell(stupify);
            harry.LearnSpell(reducto);
            harry.LearnSpell(bombardia);

            draco.LearnSpell(stupify);
            draco.LearnSpell(sectumsempra);
            draco.LearnSpell(protego);
            draco.LearnSpell(bombardia);

            hermione.LearnSpell(expelliarmus);
            hermione.LearnSpell(stupify);
            hermione.LearnSpell(reducto);
            hermione.LearnSpell(protego);

            DuelingClub club = new DuelingClub();

            Console.WriteLine("\n--- ПОЧАТОК ДУЕЛЕЙ ---\n");

            DuelResult result1 = club.HostDuel(harry, draco);
            if (result1 != null)
                Console.WriteLine(result1.ToString());

            DuelResult result2 = club.HostDuel(draco, hermione);
            if (result2 != null)
                Console.WriteLine(result2.ToString());

            DuelResult result3 = club.HostDuel(harry, hermione);
            if (result3 != null)
                Console.WriteLine(result3.ToString());

            Console.WriteLine("--- КІНЕЦЬ ДУЕЛЕЙ ---\n");

            Console.WriteLine("ІСТОРІЯ ДУЕЛЕЙ");
            harry.GetDuelHistory();
            draco.GetDuelHistory();
            hermione.GetDuelHistory();
        }
    }
}