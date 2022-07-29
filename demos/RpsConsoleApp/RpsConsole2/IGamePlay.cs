using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpsConsole2
{
    internal interface IGamePlay
    {
        public void NewGame();
        public bool P1Name(string[] x);
        public void PlayRound();
        public bool ValidateUserChoice(string p12choiceStr);
        public int EvaluatePlayersChoices();
        internal void GetAnError();
    }
}