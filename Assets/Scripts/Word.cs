namespace Etched
{
    public class Word
    {
        public string String { get; }

        public int Score { get; }

        public Word(string word)
        {
            String = word;
            Score = LetterScore.GetScore(word);
        }
    }
}