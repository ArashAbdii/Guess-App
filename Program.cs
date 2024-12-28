
namespace GuessApp;

class WordW{
    public string Word {get; set;}
    public string Description {get; set;}
    public string Hint {get; set;}

    public WordW(string word, string description, string hint){
        Word = word;
        Description = description;
        Hint = hint;
    }
}


class Program{
    static void Main(string[] args){
        List<WordW> Words = new List<WordW> {
            new WordW("APPLE", "A red Fruit", "a fruit is so healthy , people eat it in the morning"),
            new WordW("BANANA", "A Yellow Fruit", "people eat it before Exercise"),
            new WordW("PIG", "a Pink Animal", "an Animal eat its shit !")
            };

        Console.WriteLine("<<<<< Welcome to the Game >>>>>");

        Random rnd = new Random();

        WordW SelectedWord = Words[rnd.Next(0, Words.Count())];

        Console.WriteLine("The Word is Selected !");

        Console.WriteLine($"Free Hint : {SelectedWord.Description}");

        char[] WordWword = SelectedWord.Word.ToCharArray();

        char[] WordUser = new char[WordWword.Length];

        for(int i = 0; i < WordUser.Length; i++)
            WordUser[i] = '_';

        int counter = WordWword.Count() + 3;

        bool useHint2 = false;

        bool result = true;

        while(counter > 0){
            Console.WriteLine($"You have {counter} Guess");
            if(!useHint2){
                Console.WriteLine("You can use Hint 2 but you miss one guess (for using Enter 1)");
            }

            char alphabet = Convert.ToChar(Console.ReadKey().Key);
            Console.WriteLine();

            if(alphabet == '1' && !useHint2){
                Console.WriteLine($"Hint 2 : {SelectedWord.Hint}");
                useHint2 = true;
            }

            bool isFinishFlag = false;

            for(int i = 0; i < WordWword.Length; i++){
                if(WordWword[i] == Convert.ToChar((alphabet.ToString()).ToUpper()) && WordUser[i] == '_'){
                     WordUser[i] = WordWword[i];
                     isFinishFlag = true;
                     Console.WriteLine("Correct");
                     break;
                }

                if(i == WordWword.Length - 1 && !isFinishFlag && alphabet != '1'){
                    Console.WriteLine("Isn't Correct");
                }
            }

            foreach(char c in WordUser){
                Console.Write(c);
            }

            Console.WriteLine();

            bool finishedGame = true;

            for(int j = 0; j < WordWword.Length; j++){
                if(WordUser[j] != WordWword[j]){
                    finishedGame = false;
                    break;
                }
            }

            if(finishedGame){
                result = finishedGame;
                break;
            }

            counter--;
        }

        if(result){
            Console.WriteLine("You Won !!!!");
        }else{
            Console.WriteLine("You Lost");
        }
    }
}