using PokerCalculatorWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokerCalculatorWPF.ViewModel.UserControls
{
    public class MainUserControlViewModel : ViewModelBase
    {
        #region Fields
        private ObservableCollection<Card> _deck;
        private ObservableCollection<Card> _myCards;
        private ObservableCollection<Card> _cardsOnTable;
        private List<Card> _inGameCards = new List<Card>();
        private List<Card> _Hand = new List<Card>();
        private Card[] deck2 = new Card[52];
        private Simulator simulator = new Simulator();
        private string result;

        #endregion

        #region Properties

        public ObservableCollection<Card> Deck
        {
            get
            {
                if (_deck == null)
                {
                    _deck = new ObservableCollection<Card>();
                }
                return _deck;
            }
        }

        public ObservableCollection<Card> MyCards
        {
            get
            {
                if (_myCards == null)
                {
                    _myCards = new ObservableCollection<Card>();
                }
                return _myCards;
            }
        }

        public ObservableCollection<Card> CardsOnTable
        {
            get
            {
                if (_cardsOnTable == null)
                {
                    _cardsOnTable = new ObservableCollection<Card>();
                }
                return _cardsOnTable;
            }
        }

        public string Result
        {
            get { return result; }
            set
            {
                result = value;
                RaisePropertyChanged(nameof(Result));
            }
        }

        #endregion
        public ICommand ResetButton { get; set; }
        #region Commands

        #endregion

        #region Constructor
        public MainUserControlViewModel()
        {
            int index = 0;
            string type = "hdcs";
            foreach(char t in type)
            {
                for (int i = 2; i < 15; i++)
                {
                    deck2[index] = new Card(t + i.ToString());
                    deck2[index].method = Getid;
                    Deck.Add(deck2[index]);
                    index++;
                }
            }

            ResetButton = new RelayCommand(new Action<object>(reset));
        }
        #endregion

        #region Methods
        private void Getid(string str)
        {

            if (_Hand.Count == 2)
            {
                _inGameCards.Add(new Card(str));
                CardsOnTable.Add(new Card(str));
            }
            else
            {
                _Hand.Add(new Card(str));
                MyCards.Add(new Card(str));
            }          

            double percent = 0;
            if (_Hand.Count == 2)
            {
                percent = simulator.probability(_Hand[0], _Hand[1], _inGameCards, 3);
                percent *= 100;
                percent = Math.Round(percent, 3);
                Result = percent + "%";
            }
                
        }

        private void reset(object obj)
        {
            _inGameCards.Clear();
            _Hand.Clear();
            CardsOnTable.Clear();
            MyCards.Clear();
            Result = "";
        }
        #endregion
    }
}
