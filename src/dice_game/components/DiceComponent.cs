namespace ECS.Components
{
    // DiceComponent-klassen representerar en komponent som kan fästas vid en entitet.
    // Denna komponent simulerar en tärning med fasta värden och lagrar det aktuella tärningsvärdet.
    public class DiceComponent
    {
        // En array som representerar de möjliga värdena på tärningen.
        // Detta är en skrivskyddad egenskap som är initialiserad med värdena 1 till 6.
        public int[] dicevalues { get; } = { 1, 2, 3, 4, 5, 6 };

        // Ett fält för att lagra det aktuella värdet på tärningen.
        // Detta kan ändras för att representera resultatet av ett tärningskast.
        public int current_dicevalue = 1;
    }
}
