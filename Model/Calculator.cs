using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PokerCalculatorWPF.Model
{
    public class Calculator
    {
        public List<int> combination = new List<int>();
        public Dictionary<string, int> Full_hierarhy = null;
        //public object[][] Full_hierarhy { get; set; }

        public Calculator() {
            string jsonContent = File.ReadAllText("full_hierarhytest1.json");
            Full_hierarhy = JsonConvert.DeserializeObject<Dictionary<string, int>>(jsonContent);
            //Full_hierarhy = Full_hierarhy.OrderBy(f => f.Value).ToArray();
            
            Card[] hand = { new Card("d9"), new Card("d3") };
            Card[] hand1 = { new Card("h9"), new Card("h3") };
            Card[] hand2 = { new Card("c9"), new Card("c3") };
            Card[] hand3 = { new Card("s9"), new Card("s3") };

            Card[] table = { new Card("d10"), new Card("d12"), new Card("s5"), new Card("d7"), new Card("c7") };    

            Console.WriteLine(probabilityWith2(new Card("c14"), new Card("d14")));
            
            //Console.WriteLine(probabilityWith5(hand[0], hand[1], table));
            //Console.WriteLine(probabilityWith7(hand[0], hand[1], table));
        }
        public double probabilityWith2(Card first, Card second)
        {
            const double average = 5556.77734 * 2;
            long sum = 0, amount = 0;
            //string firstCard_inString = CardToString(first);
            //string secondCard_inString = CardToString(second);

            var valueOfFirst = Full_hierarhy.Where(x =>
            x.Key.Contains(first.Id));

            sum += valueOfFirst.Sum(x => x.Value);
            amount += valueOfFirst.Count();

            var valueOfsecond = Full_hierarhy.Where(x =>
            x.Key.Contains(second.Id));

            sum += valueOfsecond.Sum(x => x.Value);
            amount += valueOfsecond.Count();

            var valueOf2 = valueOfFirst.Where(x => x.Key.Contains(second.Id));

            sum += valueOf2.Sum(x => x.Value);
            amount += valueOf2.Count();

            

            double handval = (double)sum / amount;

            //if (counter != 19600) Console.WriteLine("lol");

            #region Oldsolution

            //combination = new List<int>{ 0, 1, 2};

            //do
            //{
            //    Tuple<int, int>[] k = new Tuple<int, int>[3];
            //    int d = 0;

            //    foreach(int index in combination)
            //    {
            //        k[d] = convert_togrid(index);
            //        d++;
            //    }

            //    if (k[0].Equals(firstCard) || k[1].Equals(firstCard) || k[2].Equals(firstCard)) continue;
            //    if (k[0].Equals(secondCard) || k[1].Equals(secondCard) || k[2].Equals(secondCard)) continue;

            //    List<Tuple<int, int>> Sortedformation = new List<Tuple<int, int>> { firstCard, secondCard, k[0], k[1], k[2] };
            //    Sortedformation.Sort();
            //    string idofformation = MakeID(Sortedformation);

            //    //JObject formation = FindObjectInJson("full_hierarhy.json", idofformation);
            //    //int actVal = Convert.ToInt32(formation.Last.Last);
            //    //sumofValue += actVal;

            //    testamount++;
            //    Console.WriteLine(testamount);
            //    if(testamount == 19598)
            //    {
            //        Console.WriteLine(sumofValue / 19600);
            //    }
            //} while (next_combination(combination, 3, 52));
            #endregion

            return 1 - handval / average;
        }
        //public float probabilityWith5(Card first, Card second, Card[] table)
        //{
        //    string[] table_inString = new string[3];
        //    List<Tuple<int, int>> myformation = new List<Tuple<int, int>>();

        //    for (int i = 0; i < 3; i++)
        //    {
        //        table_inString[i] = CardToString(table[i]);

        //        myformation.Add(new Tuple<int, int>(table[i].type, table[i].value));
        //    }
        //    myformation.Add(new Tuple<int, int>(first.type, first.value));
        //    myformation.Add(new Tuple<int, int>(second.type, second.value));
        //    myformation.Sort();

        //    string myformation_inString = MakeID(myformation);
        //    string firstCard_inString = CardToString(first);
        //    string secondCard_inString = CardToString(second);

        //    ConvertfromJson getValue = Full_hierarhy.FirstOrDefault(f => f.formation == myformation_inString);
        //    int myValue = getValue.value;

        //    int ilosc_slabszych = 0;
        //    const int calosc = 1175;

        //    var posibilities = Full_hierarhy.Where(f =>
        //        f.formation.Contains(table_inString[0]) &&
        //        f.formation.Contains(table_inString[1]) &&
        //        f.formation.Contains(table_inString[2]));

        //    foreach (ConvertfromJson f in posibilities)
        //    {
        //        if (getValue == f) continue;
        //        if (f.value > myValue) ilosc_slabszych++;
        //    }

        //    return (float)ilosc_slabszych / 1175;
        //}
        //public float probabilityWith6(Card first, Card second)
        //{

        //    return 0;
        //}
        //public float probabilityWith7(Card first, Card second, Card[] table)
        //{
        //    string[] table_inString = new string[5];
        //    List<Tuple<int, int>> onTableFormation = new List<Tuple<int, int>>();

        //    for (int i = 0; i < 5; i++)
        //    {
        //        table_inString[i] = CardToString(table[i]);

        //        onTableFormation.Add(new Tuple<int, int>(table[i].type, table[i].value));
        //    }

        //    onTableFormation.Sort();
        //    string myFormation_inString = MakeID(onTableFormation);
        //    int actVal = Full_hierarhy.FirstOrDefault(f => f.formation == myFormation_inString).value;
        //    int BestVal = FindBestValue(first, second, onTableFormation, actVal);

        //    string type = "hdcs";
        //    string value = "23456789TJQKA";
        //    int ilosc_slabszych = 0;
        //    int amount = 0;

        //    foreach (char t1 in type)
        //        foreach (char v1 in value)
        //        {
        //            Card hand1 = new Card(t1.ToString() + v1.ToString());

        //            if (!checkHand(hand1, first, second, table)) continue;

        //            foreach (char t2 in type)
        //                foreach (char v2 in value)
        //                {
        //                    Card hand2 = new Card(t2.ToString() + v2.ToString());

        //                    if (hand1.type == hand2.type && hand1.value == hand2.value) continue;
        //                    if (!checkHand(hand2, first, second, table)) continue;

        //                    int getValue = FindBestValue(hand1, hand2, onTableFormation, actVal);
        //                    if (getValue > BestVal) ilosc_slabszych++;
        //                    amount++;
        //                }
        //        }

        //    return (float)ilosc_slabszych / amount;
        //}

        bool checkHand(Card hand, Card first, Card second, Card[] table)
        {
            bool result = true;

            if (hand.type == first.type && hand.value == first.value) result = false;
            else if (hand.type == second.type && hand.value == second.value) result = false;
            foreach (Card t in table)
            {
                if (hand.type == t.type && hand.value == t.value)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        //int FindBestValue(Card first, Card second, List<Tuple<int, int>> formation, int actVal)
        //{
        //    int BestVal = actVal;

        //    for (int i = 0; i < 5; i++)
        //    {
        //        List<Tuple<int, int>> actFormation = formation.ToList();
        //        actFormation[i] = new Tuple<int, int>(first.type, first.value);
        //        actFormation.Sort();
        //        string actFormation_inString = MakeID(actFormation);

        //        actVal = Full_hierarhy.FirstOrDefault(f => f.formation == actFormation_inString).value;

        //        if (actVal < BestVal) BestVal = actVal;
        //    }

        //    for (int i = 0; i < 5; i++)
        //    {
        //        List<Tuple<int, int>> actFormation = formation.ToList();
        //        actFormation[i] = new Tuple<int, int>(second.type, second.value);
        //        actFormation.Sort();
        //        string actFormation_inString = MakeID(actFormation);

        //        actVal = Full_hierarhy.FirstOrDefault(f => f.formation == actFormation_inString).value;

        //        if (actVal < BestVal) BestVal = actVal;
        //    }
        //    return BestVal;
        //}

        //string MakeID(List<Tuple<int, int>> formation)
        //{
        //    string result = string.Empty;
        //    foreach (Tuple<int, int> t in formation)
        //    {
        //        if (t.Item1 == 'h') type = 0;
        //        else if (t.Item1 == 'd') type = 1;
        //        else if (t.Item1 == 's') type = 2;
        //        else if (t.Item1 == 'c') type = 3;
        //        else
        //        {
        //            Console.WriteLine("Card type error");
        //        }

        //        result += t.Item1.ToString();               

        //        result += t.Item2.ToString();
        //        result += "_";
        //    }
        //    return result;
        //}

        string CardToString(Card card)
        {
            string firstCard_inString = "0" + card.type;
            if (card.value < 10) firstCard_inString += "0";
            firstCard_inString += card.value;

            return firstCard_inString;
        }

        Tuple<int, int> convert_togrid(int index)
        {
            index = 52 - index;
            int val = (index % 4 == 0) ? -1 : 0;
            val += index / 4;

            int type = (index + 3) % 4;

            //type = index - val * (type + 1) - 1;

            return new Tuple<int, int> ( type, val );
        }

        static JObject FindObjectInJson(string filePath, string targetId)
        {
            StreamReader file = File.OpenText(filePath);
            JsonTextReader reader = new JsonTextReader(file);
            {
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        JObject obj = JObject.Load(reader);
                        JToken idToken = obj["formation"];
                        if (idToken != null && idToken.Type == JTokenType.String && idToken.ToString() == targetId)
                        {
                            return obj;
                        }
                    }
                }
            }

            return null;
        }

        bool next_combination(List<int> elements, int k, int n)
        {
            List<int> baze = new List<int>();
            
            for (int i = n - k; i < n; i++) baze.Add(i);

            if (elements == baze) return false;

            while (elements.Last() == n - (k - elements.Count()) - 1)
            {
                if(elements.Count() != 0) elements.RemoveAt(elements.Count() - 1);
            }
            int el = elements.Last();
            elements.RemoveAt(elements.Count() - 1);

            elements.Add(++el);

            while (elements.Count() != k)
            {
                elements.Add(++el);
            }

            return true;

        }
    }
}
