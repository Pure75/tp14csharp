using System;

namespace Morpion
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Game game = Game.load_game("___o_ox_x", 2);
            Console.WriteLine(game.state());
            game.play();
            Console.WriteLine(game.state());
            Console.WriteLine(game.stop());*/
            Play();
        }
        
        // start the game
        static public void Play()
        {
            Console.WriteLine("Choose a difficulty between 1 and 3 inclusive :");
            int niv = Console.ReadLine()[0] % '0';
            uint prof = 0;
            switch (niv)
            {
                case 1 :
                    prof = 1;
                    break;
                case 2 :
                    prof = 2;
                    break;
                case 3 :
                    prof = 5;
                    break;
                default:
                    prof = 2;
                    break;
            }
            string board = "_________";
            Game game = Game.load_game(board, prof);
            int resultat = 0;
            Console.WriteLine(game.state());
            while (resultat == 0)
            {
                game.play();
                Console.WriteLine(game.state());
                resultat = game.stop();
            }
            if (resultat == 1) Console.WriteLine("Player Won !");
            else if (resultat == 2) Console.WriteLine("IA won !");
            else Console.WriteLine("It's a tie !");
            Console.WriteLine("Do you want to play another game ? :");
            string res = Console.ReadLine();
            if (res == "yes")
            {
                if (! Console.IsOutputRedirected) Play();
            }
        }
    }
}