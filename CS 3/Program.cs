using System;

namespace CS_3
{
    internal class Program
    {

        struct Answer
        {
            public string answer;
            public bool isTrue;

            public Answer(string answer, bool isTrue = false)
            {
                this.answer = answer;
                this.isTrue = isTrue;
            }

            public override string ToString()
            {
                return answer;
            }

        }
        struct Question
        {
            public string question;
            public Answer[] answers;


            public Question(string question, Answer[] answers)
            {
                this.question = question;
                this.answers = answers;
            }

            public override string ToString()
            {
                return question;
            }
        }

        static int[] RandomAnswers()
        {
            bool checker;
            int rand;
            int[] arr = new int[3];
            Random random = new Random();

            for (int i = 0; i < 3;)
            {
                checker = true;
                rand = random.Next(1, 4);
                for (int k = 0; k < 3; k++)
                {
                    if (arr[k] == rand)
                    {
                        checker = false;
                        break;
                    }
                }
                if (checker)
                    arr[i++] = rand;
            }
            return arr;
        }

        static uint Play(ref Question[] questions)
        {
            Console.Clear();

            bool nextQuestion = false;
            sbyte upDown = 0, next = 0;
            uint score = 0;
            ConsoleKey console;

            int[] randArray = RandomAnswers();
            Console.WriteLine($"Question {next + 1} : " + questions[next].question);
            for (int k = 0; k < questions[next].answers.Length; k++)
            {
                if (k == upDown)
                    Console.WriteLine($"{k + 1}. {questions[next].answers[randArray[k] - 1]}  <<");
                else
                    Console.WriteLine($"{k + 1}. {questions[next].answers[randArray[k] - 1]}");
            }


            while (true)
            {
                if (nextQuestion)
                {
                    if (Console.ReadKey(true).Key == ConsoleKey.RightArrow)
                    {
                        console = ConsoleKey.RightArrow;
                        
                    }
                    else
                        console = ConsoleKey.LeftArrow;
                }
                else
                    console = Console.ReadKey(true).Key;
                switch (console)
                {
                    case ConsoleKey.UpArrow:
                        if (upDown > 0)
                        {
                            Console.Clear();
                            upDown--;
                            Console.WriteLine($"Question {next + 1} : " + questions[next].question);
                            for (int k = 0; k < questions[next].answers.Length; k++)
                            {
                                if (k == upDown)
                                    Console.WriteLine($"{k + 1}. {questions[next].answers[randArray[k] - 1]}  <<");
                                else
                                    Console.WriteLine($"{k + 1}. {questions[next].answers[randArray[k] - 1]}");
                            }

                        }
                        else
                            Console.Beep();

                        break;

                    case ConsoleKey.DownArrow:
                        if (upDown < 2)
                        {
                            Console.Clear();
                            upDown++;
                            Console.WriteLine($"Question {next + 1} : " + questions[next].question);
                            for (int k = 0; k < questions[next].answers.Length; k++)
                            {
                                if (k == upDown)
                                    Console.WriteLine($"{k + 1}. {questions[next].answers[randArray[k] - 1]}  <<");
                                else
                                    Console.WriteLine($"{k + 1}. {questions[next].answers[randArray[k] - 1]}");
                            }
                        }
                        else
                            Console.Beep();

                        break;

                    case ConsoleKey.RightArrow:
                        
                        if (next < 9 && nextQuestion)
                        {
                            upDown = 0;
                            Console.Clear();
                            randArray = RandomAnswers();
                            next++;
                            Console.WriteLine($"Question {next + 1} : " + questions[next].question);
                            for (int k = 0; k < questions[next].answers.Length; k++)
                            {
                                if (k == upDown)
                                    Console.WriteLine($"{k + 1}. {questions[next].answers[randArray[k] - 1]}  <<");
                                else
                                    Console.WriteLine($"{k + 1}. {questions[next].answers[randArray[k] - 1]}");
                            }
                            nextQuestion = false;
                        }
                        else if(next == 9)
                        {
                            Console.Clear();
                            return score;
                        }
                        else
                            Console.Beep();

                        break;

                    case ConsoleKey.Enter:
                        nextQuestion = true;

                        Console.Clear();
                        Console.WriteLine($"Question {next + 1} : " + questions[next].question);
                        for (int k = 0; k < questions[next].answers.Length; k++)
                        {
                            if (k == upDown)
                            {
                                if (questions[next].answers[randArray[k] - 1].isTrue)
                                {
                                    score += 10;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"{k + 1}. {questions[next].answers[randArray[k] - 1]}  <<");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"{k + 1}. {questions[next].answers[randArray[k] - 1]}  <<");
                                    if ((score - 10) >= 0)
                                        score -= 10;
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{k + 1}. {questions[next].answers[randArray[k] - 1]}");
                            }
                        }

                        Console.WriteLine("\nPress right arrow for next question...");

                        break;

                    default:
                        break;
                }
            }

        }

        static void Main(string[] args)
        {

            Answer[] answers1 = { new("Kepenek"), new("Ceyirtge", true), new("Qarisqa") };
            Answer[] answers2 = { new("889"), new("899"), new("879", true) };
            Answer[] answers3 = { new("80"), new("100", true), new("120") };
            Answer[] answers4 = { new("60 - 150 min", true), new("30 - 450 min"), new("80 - 300 min") };
            Answer[] answers5 = { new("50", true), new("40"), new("70") };
            Answer[] answers6 = { new("52"), new("72"), new("79", true) };
            Answer[] answers7 = { new("-11", true), new("-5"), new("-25") };
            Answer[] answers8 = { new("34"), new("27"), new("28", true) };
            Answer[] answers9 = { new("mahni - musiqi"), new("naraziliq - sikayet", true), new("agac - taxta") };
            Answer[] answers10 = { new("91", true), new("101"), new("81") };

            Question q1 = new("Hansi canlinin qani beyazdir ? ", answers1);
            Question q2 = new("Azadliq heykelinin ayaq nomresi ? ", answers2);
            Question q3 = new("Qargalarin orta hesabla yasi ne qederdir ? ", answers3);
            Question q4 = new("Insan basinda texmini ne qeder sac olur ? ", answers4);
            Question q5 = new("Pisiklerin maksimal sureti saatda nece kilometrdir ? ", answers5);
            Question q6 = new("3, 8, 11, 19, 30, 49 ? sual iseresinin yerine hansi reqem olar ? ", answers6);
            Question q7 = new("2-5×4+7=?", answers7);
            Question q8 = new("27, 31, ?, 32, 29, 33, 30", answers8);
            Question q9 = new("Sozler arasindaki mentiqi elaqeni tapin. Keder - Goz yasi ", answers9);
            Question q10 = new("44, 24, 37, 39, ? ", answers10);

            Question[] questions = { q1, q2, q3, q4, q5, q6, q7, q8, q9, q10 };
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t\t\t\tQuizze Game\n");
            Console.WriteLine("Play <<");
            Console.WriteLine("Exit");

            string nickName;
            sbyte upDown = 0;

            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        if (upDown > 0)
                        {
                            --upDown;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\t\t\t\t\tQuizze Game\n");
                            Console.WriteLine("Play <<");
                            Console.WriteLine("Exit");
                        }
                        else
                            Console.Beep();
                        break;

                    case ConsoleKey.DownArrow:
                        if (upDown < 1)
                        {
                            ++upDown;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\t\t\t\t\tQuizze Game\n");
                            Console.WriteLine("Play");
                            Console.WriteLine("Exit <<");
                        }
                        else
                            Console.Beep();
                        break;

                    case ConsoleKey.Enter:
                        if (upDown == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Enter your nickname : ");
                            nickName = Console.ReadLine();
                            Console.WriteLine($"Your nick name is -> {nickName}\nYour score is -> {Play(ref questions)}");
                            return;
                        }
                        else
                            return;
                        break;
                }
            }
        }
    }
}
