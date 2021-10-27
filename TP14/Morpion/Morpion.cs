using System;

namespace Morpion
{
    public class Game
    {

        public char[,] _board;
        public uint _depth;

        /*public Game(string[,] board, uint depth)
        {
            this._board = board;
            this._depth = depth;
        }*/
        // 0 1 2
        // 3 4 5
        // 6 7 8
        
        // display of the game with the numbers corresponding to the boxes
        // the display is shifted to the right in case you wish to display the board of the current game to its left
        void positions()
        {
            if (!Console.IsOutputRedirected)
            {
                int y = 0;
                Console.SetCursorPosition(20, y++);
                Console.WriteLine(" ___________");
                for (int i = 0; i < 3; i++)
                {
                    Console.SetCursorPosition(20, y++);
                    Console.WriteLine("| {0} | {1} | {2} |", i * 3, i * 3 + 1, i * 3 + 2);
                    Console.SetCursorPosition(20, y++);
                    Console.WriteLine("|___________|");
                }
            }
        }
        
        public static Game load_game(String board, uint depth)
        {
            Game game = new Game();
            char[,] gameboard = new char[3, 3];
            int j = 0;
            for (int i = 0; i < board.Length; i++)
            {
                if (i % 3 == 0 && i != 0) j++;
                gameboard[j, i%3] = board[i];
            }
            game._board = gameboard;
            game._depth = depth;
            return game;
        }
        
        
        // return the state of the board,
        // if there is a winner, draw or if the game is not over
        // 2 -> IA / 1 -> Player / 3 -> Draw / 0 -> Not finish
        public int stop()
        {
            if (_board[0,0] == _board[0, 1] && _board[0,1] == _board[0, 2] &&  _board[0,2 ]== 'x') return 2;
            if (_board[1,0] == _board[1, 1] && _board[1,1] == _board[1, 2] &&  _board[1,2 ]== 'x') return 2;
            if (_board[2,0] == _board[2, 1] && _board[2,1] == _board[2, 2] &&  _board[2,2 ]== 'x') return 2;
            if (_board[0,0] == _board[0, 1] && _board[0,1] == _board[0, 2] &&  _board[0,2 ]== 'o') return 1;
            if (_board[1,0] == _board[1, 1] && _board[1,1] == _board[1, 2] &&  _board[1,2 ]== 'o') return 1;
            if (_board[2,0] == _board[2, 1] && _board[2,1] == _board[2, 2] &&  _board[2,2 ]== 'o') return 1;
            
            if (_board[0,0] == _board[1, 0] && _board[1,0] == _board[2, 0] &&  _board[2,0 ]== 'x') return 2;
            if (_board[0,1] == _board[1, 1] && _board[1,1] == _board[2, 1] &&  _board[2,1 ]== 'x') return 2;
            if (_board[0,2] == _board[1, 2] && _board[1,2] == _board[2, 2] &&  _board[2,2 ]== 'x') return 2;
            if (_board[0,0] == _board[1, 0] && _board[1,0] == _board[2, 0] &&  _board[2,0 ]== 'o') return 1;
            if (_board[0,1] == _board[1, 1] && _board[1,1] == _board[2, 1] &&  _board[2,1 ]== 'o') return 1;
            if (_board[0,2] == _board[1, 2] && _board[1,2] == _board[2, 2] &&  _board[2,2 ]== 'o') return 1;
            
            if (_board[0,0] == _board[1, 1] && _board[1,1] == _board[2, 2] &&  _board[2,2 ]== 'x') return 2;
            if (_board[0,2] == _board[1, 1] && _board[1,1] == _board[2, 0] &&  _board[2,0 ]== 'x') return 2;
            if (_board[0,0] == _board[1, 1] && _board[1,1] == _board[2, 2] &&  _board[2,2 ]== 'o') return 1;
            if (_board[0,2] == _board[1, 1] && _board[1,1] == _board[2, 0] &&  _board[2,0 ]== 'o') return 1;
            
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (_board[i, k] == '_') return 0;
                }
            }
            return 3;
        }
        
        
        // start a game turn
        public void play()
        {
            bool res = false;
            Console.WriteLine("Choose a number between 0 and 8 :");
            while (res == false)
            {
                int cj = Console.ReadLine()[0] % '0';
                if (cj < 0 || cj > 8)
                {
                    Console.Error.WriteLine("You must play a number between 0 and 8 inclusive.");
                }
                else
                {
                    int x = cj / 3;
                    int y;
                    if (x != 0) y = cj - (x * 3);
                    else y = cj;
                    if (_board[x,y] != '_')
                    {
                        Console.Error.WriteLine("The box is already taken");
                    }
                    else
                    {
                        _board[x, y] = 'o';
                        res = true;
                    }
                }
            }
            bool res2 = false;
            if (stop() == 0) {
                while (res2 == false)
                {
                    int ci = new Random().Next(0,9);
                    int x = ci / 3;
                    int y;
                    if (x != 0) y = ci - (x * 3);
                    else y = ci; 
                    if (_board[x, y] != '_') 
                    {
                        ci = new Random().Next(0,8);
                    }
                    else 
                    { 
                        _board[x, y] = 'x'; 
                        res2 = true;
                    }
                }
            }
        }
        
        public string state()
        {
            string str = "";
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    str += _board[i, k];
                }
            }
            return str;
        }
    }
}