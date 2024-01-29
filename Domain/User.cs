using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public string UserName { get; set; }  
        public Guid  ID {  get; set; }
        public int MoneyAmount { get; set; }
        public List <Game> Games { get; set; }
        public UserName (string username, Guid id , int moneyAmount, List games)
        {
            UserName= username;
            ID = id;
            MoneyAmount = moneyAmount;
            Games = [];
        }
    }
}
