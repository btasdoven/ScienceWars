using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.IGUI;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Game
{
    class GCashAndIncomeInfo : IncomingMessageImp
    {
        public override void processMessage(NetWorker.Utilities.RawMessage message)
        {
            int cash = message.getInt("c");
            int income = message.getInt("i");

            PlayerMe.cash = cash;
            PlayerMe.income = income;

            Runner.Graphics.updateCashAndIncome();
        }
    }
}
