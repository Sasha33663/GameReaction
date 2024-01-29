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
        public Guid  Id {  get; set; }
        public int MoneyAmount { get; set; }
        public List <Game> Games { get; set; }
        public User (string username, Guid id , int moneyAmount, List<Game> games)
        {
            UserName= username;
            Id = id;
            MoneyAmount = moneyAmount;
            Games = [];
        }
    }
}
