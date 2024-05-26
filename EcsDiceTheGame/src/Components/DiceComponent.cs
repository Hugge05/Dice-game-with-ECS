namespace ECS.Components
{
    // DiceComponent klassen representerar en komponent som simulerar en tärning med fasta värden.
    public class DiceComponent
    {
        // Variabel för att lagra det aktuella värdet på tärningen.
        public int CurrentDiceValue { get; set; } = 1;

        // Array för att lagra de möjliga värdena på tärningen.
        public int[] DiceValues { get; } = { 1, 2, 3, 4, 5, 6 };
    }
}
