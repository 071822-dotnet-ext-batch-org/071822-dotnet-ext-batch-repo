using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IGamePlay
    {
        //public void NewGame();
        public Task<bool> P1NameAsync(string[] x);
        public void PlayRound();
        public bool ValidateUserChoice(string p12choiceStr);
        public int EvaluatePlayersChoices();
        internal void GetAnError();
    }
}