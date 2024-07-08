using PokerCalculatorWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
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
        public Simulator simulator = new Simulator();
        private string result;
        private bool addCards = true;

        Thread simulatingInBackGround = null;
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
        public bool AddCards
        {
            get { return addCards; }
            set
            {
                addCards = value;
                RaisePropertyChanged(nameof(AddCards));
            }

        }
        public int PlayersNum { get; set; }

        #endregion

        #region Commands
        public ICommand ResetButton { get; set; }

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

            simulator.sendValue = reseveValue;
            ResetButton = new RelayCommand(new Action<object>(reset));
        }
        #endregion

        #region Methods
        private void Getid(string str)
        {                      
            if (simulatingInBackGround != null && simulatingInBackGround.IsAlive) 
            {
                simulatingInBackGround.Abort();
            }                              

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
            if (CardsOnTable.Count == 5) AddCards = false;

            if (_Hand.Count == 2)
            {

                simulatingInBackGround = new Thread(new ThreadStart(() =>
                {
                    simulator.probability(_Hand[0], _Hand[1], _inGameCards, PlayersNum);
                }));
                simulatingInBackGround.Start();
            }                                
        }

        private void reset(object obj)
        {
            _inGameCards.Clear();
            _Hand.Clear();
            CardsOnTable.Clear();
            MyCards.Clear();
            Result = "";
            AddCards = true;

            if (simulatingInBackGround != null && simulatingInBackGround.IsAlive)
            {
                simulatingInBackGround.Abort();
            }

            foreach (Card card in Deck) 
            {
                card.Visibility = true;
            }
        }

        private void reseveValue(float value)
        {
            Result = Math.Round(value * 100, 2) + "%";
            Thread.Sleep(350);
        }
        #endregion
    }
}
