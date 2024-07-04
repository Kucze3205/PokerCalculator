using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace PokerCalculatorWPF.Model
{
    public class Card : IEquatable<Card>
    {
        public delegate void MainUserControlMethod(string message);
        public MainUserControlMethod method;

        public string Id { get; set; }
        public int type { get; set; }
        public int value { get; set; }

        public ICommand GetId { get; set; }

        public Card(string id)
        {
            Id = id;

            if (Id[0] == 'h') type = 0;
            else if (Id[0] == 'd') type = 1;
            else if (Id[0] == 'c') type = 2;
            else if (Id[0] == 's') type = 3;
            else
            {
                Console.WriteLine("Card type error");
            }

            string valueC = Id.Substring(1);
            if (valueC == "T") valueC = "10";
            else if (valueC == "J") valueC = "11";
            else if (valueC == "Q") valueC = "12";
            else if (valueC == "K") valueC = "13";
            else if (valueC == "A") valueC = "14";

            value = Convert.ToInt32(valueC) - 2;

            GetId = new RelayCommand(new Action<object>(getid));
        }

        public bool Equals(Card other)
        {
            if (other == null)
                return false;
            return this.type == other.type && this.value == other.value;
        }

        public override int GetHashCode()
        {
            return (type, value).GetHashCode();
        }

        private void getid(object obj)
        {
            method(Id);
        }
    }

    public class ConvertfromJson
    {
        public string formation { get; set; }
        public int value { get; set; }
    }


}
