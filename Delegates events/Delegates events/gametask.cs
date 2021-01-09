using System;
using System.Collections.Generic;
using System.Text;

namespace Delegates_events
{
    

    public enum GameType
    {
        Shooter,
        Action,
        Quest
    }

    public class Game
    {
        public string Name { get; set; }

        public GameType Gender { get; set; }

        public Game(string name, GameType gender)
        {
            Name = name;
            Gender = gender;
        }



    }

    public class GameEventArgs : EventArgs
    {
        public Game Game { get; set; }
    }

    public class GameRecorder
    {
        public event EventHandler<GameEventArgs> A;


        public void OnGameRecorded(Game game)
        {
            A?.Invoke(this, new GameEventArgs() { Game = game });
        }

        public void Record(Game game)
        {
            Console.WriteLine("Recording...");

            OnGameRecorded(game);
        }
    }

    public class ConsoleService
    {
        public void OnGameRecorded(object s, GameEventArgs args)
        {
            Console.WriteLine($"Printing from ConsoleService:  { args.Game.Name} , {args.Game.Gender}");
        }
    }

    public class MailService
    {
        public void OnGameRecorded(object s, GameEventArgs args)
        {
            Console.WriteLine($"Printing from MailService:  { args.Game.Name} , {args.Game.Gender}");
        }
    }

    public class MessageService
    {
        public void OnGameRecorded(object s, GameEventArgs args)
        {
            Console.WriteLine($"Printing from MessageService:  { args.Game.Name} , {args.Game.Gender}");
        }
    }
}
