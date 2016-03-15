using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo.DesginPatterns.ActionPatterns
{
    /// <summary>
    ///  将一个请求封装为一个对象，从而使你可用不同的请求对客户进行参数化；对请求排队或记录请求日志，以及支持可撤销的操作。
    /// </summary>
    public sealed class CommandPattern
    {
        public static void Test()
        {
            AudioPlay player = new AudioPlay();

            PlayCommand playCmd = new PlayCommand(player);
            RewindCommand rewindCmd = new RewindCommand(player);
            StopCommand stopCmd = new StopCommand(player);

            //Keyboard kb = new Keyboard();
            //kb.PlayCommand = playCmd;
            //kb.RewindCommand = rewindCmd;
            //kb.StopCommand = stopCmd;
            //kb.Play();
            //kb.Rewind();
            //kb.Stop();

            IMacroCommand macroCmd = new MacroAudioCommand();
            macroCmd.Add(playCmd);
            macroCmd.Add(rewindCmd);
            macroCmd.Add(stopCmd);

            macroCmd.Execute();
        }
    }

    /// <summary>
    /// Receiver
    /// </summary>
    public class AudioPlay
    {
        public void Play()
        {
            Console.WriteLine("Play...");
        }

        public void Rewind()
        {
            Console.WriteLine("Rewind...");
        }

        public void Stop()
        {
            Console.WriteLine("Stop...");
        }
    }

    public interface ICommand
    {
        void Execute();
    }

    public class PlayCommand : ICommand
    {
        private AudioPlay _player;

        public PlayCommand(AudioPlay player)
        {
            _player = player;
        }

        public void Execute()
        {
            _player.Play();
        }
    }

    public class RewindCommand : ICommand
    {
        private AudioPlay _player;

        public RewindCommand(AudioPlay player)
        {
            _player = player;
        }

        public void Execute()
        {
            _player.Rewind();
        }
    }

    public class StopCommand : ICommand
    {

        private AudioPlay _player;

        public StopCommand(AudioPlay player)
        {
            _player = player;
        }

        public void Execute()
        {
            _player.Stop();
        }
    }

    public interface IMacroCommand : ICommand
    {
        void Add(ICommand cmd);

        void Remove(ICommand cmd);
    }

    public class MacroAudioCommand : IMacroCommand
    {
        private List<ICommand> cmdList = new List<ICommand>();

       

        public void Add(ICommand cmd)
        {
            cmdList.Add(cmd);
        }

        public void Remove(ICommand cmd)
        {
            cmdList.Remove(cmd);
        }

        public void Execute()
        {
            foreach (ICommand cmd in cmdList)
            {
                cmd.Execute();
            }
        }
    }

    /// <summary>
    /// Invoker
    /// </summary>
    public class Keyboard
    {
        private ICommand playCmd;

        private ICommand rewindCmd;

        private ICommand stopCmd;

        public ICommand PlayCommand
        {
            set
            {
                playCmd = value;
            }
        }

        public ICommand RewindCommand
        {
            set
            {
                rewindCmd = value;
            }
        }

        public ICommand StopCommand
        {
            set
            {
                stopCmd = value;
            }
        }

        public void Play()
        {
            playCmd.Execute();
        }

        public void Rewind()
        {
            rewindCmd.Execute();
        }

        public void Stop()
        {
            stopCmd.Execute();
        }
    }

}
