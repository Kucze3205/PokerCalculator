using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace PokerCalculatorWPF.Model
{
    public class Simulator
    {
        public delegate void MainUserControlMethod(float result);
        public MainUserControlMethod sendValue;

        public List<int> combination = new List<int>();
        public Dictionary<string, int> Full_hierarhy = null;

        public Simulator()
        {
            string jsonContent = File.ReadAllText("full_hierarhy5.json");
            Full_hierarhy = JsonConvert.DeserializeObject<Dictionary<string, int>>(jsonContent);                                    
        }

        public void probability(Card first, Card second, List<Card> table, int players)
        {           
            string type = "hdcs";
            Random rnd = new Random();
            int[,] cardsCounter = new int[15,4];
                      
            int games = 0, wins = 0;

            int counter = 0;

            while (counter++ < 100000 || true)
            {
                HashSet<Card> HandCards = new HashSet<Card> { first, second };
                bool win = true;

                List<Card> act_table = table.ToList();

                while (act_table.Count < 5)
                {
                    Card card;
                    do
                    {
                        card = new Card(type[rnd.Next(4)] + rnd.Next(2, 15).ToString());
                        cardsCounter[card.value,card.type]++;
                    } while (act_table.Contains(card) || HandCards.Contains(card));                
                    
                    act_table.Add(card);
                }
                int myValue = FindBestValue(first, second, act_table);
                
                
                for(int i = 0; i < players - 1; i++)
                {
                    Card[] opp_hand = new Card[2];

                    for(int j = 0; j < 2; j++)
                    {
                        do
                        {
                            opp_hand[j] = new Card(type[rnd.Next(4)] + rnd.Next(2, 15).ToString());
                        } while (act_table.Contains(opp_hand[j]) || HandCards.Contains(opp_hand[j]));
                        HandCards.Add(opp_hand[j]);
                    }
                    
                    int oppVal = FindBestValue(opp_hand[0], opp_hand[1], act_table);
                    if(oppVal < myValue)
                    {
                        win = false;
                        break;
                    }
                }

                games++;
                if(win) wins++;               

                if(counter % 500 == 0) sendValue((float)wins / games);      
            }          
        }

        int FindBestValue(Card first, Card second, List<Card> formation)
        {
            List<Card> sorted_f = formation.ToList(); 
            sorted_f.Add(first);
            sorted_f.Add(second);

            sorted_f = sorted_f.OrderBy(x => x.type).ThenBy(x => x.value).ToList();
            
            int BestVal = int.MaxValue;  

            for (int i = 0; i < 6; i++)
            {
                Card save1 = sorted_f[i];
                sorted_f[i] = null;

                for (int j = i + 1; j < 7; j++)
                {
                    Card save2 = sorted_f[j];
                    sorted_f[j] = null;

                    string formation_string = string.Join("", sorted_f.Where(x => x != null).Select(x => x.Id));
                    int actVal = Full_hierarhy[formation_string];

                    if (actVal < BestVal)
                    {
                        BestVal = actVal;
                    }

                    sorted_f[j] = save2;
                }

                sorted_f[i] = save1;
            }
                           
            return BestVal;
        }

        string MakeID(List<Card> formation)
        {
            string result = formation.ToString();
            
            return result;
        }

    }
}
