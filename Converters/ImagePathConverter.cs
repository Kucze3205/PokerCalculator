using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.IO;

namespace PokerCalculatorWPF.Converters
{
    public class ImagePathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value?.ToString())
            {
                case "h2": { return "/Graphics/2_of_hearts.png"; }
                case "h3": { return "/Graphics/3_of_hearts.png"; }
                case "h4": { return "/Graphics/4_of_hearts.png"; }
                case "h5": { return "/Graphics/5_of_hearts.png"; }
                case "h6": { return "/Graphics/6_of_hearts.png"; }
                case "h7": { return "/Graphics/7_of_hearts.png"; }
                case "h8": { return "/Graphics/8_of_hearts.png"; }
                case "h9": { return "/Graphics/9_of_hearts.png"; }
                case "h10": { return "/Graphics/10_of_hearts.png"; }
                case "h11": { return "/Graphics/jack_of_hearts.png"; }
                case "h12": { return "/Graphics/queen_of_hearts.png"; }
                case "h13": { return "/Graphics/king_of_hearts.png"; }
                case "h14": { return "/Graphics/ace_of_hearts.png"; }
                case "d2": { return "/Graphics/2_of_diamonds.png"; }
                case "d3": { return "/Graphics/3_of_diamonds.png"; }
                case "d4": { return "/Graphics/4_of_diamonds.png"; }
                case "d5": { return "/Graphics/5_of_diamonds.png"; }
                case "d6": { return "/Graphics/6_of_diamonds.png"; }
                case "d7": { return "/Graphics/7_of_diamonds.png"; }
                case "d8": { return "/Graphics/8_of_diamonds.png"; }
                case "d9": { return "/Graphics/9_of_diamonds.png"; }
                case "d10": { return "/Graphics/10_of_diamonds.png"; }
                case "d11": { return "/Graphics/jack_of_diamonds.png"; }
                case "d12": { return "/Graphics/queen_of_diamonds.png"; }
                case "d13": { return "/Graphics/king_of_diamonds.png"; }
                case "d14": { return "/Graphics/ace_of_diamonds.png"; }
                case "s2": { return "/Graphics/2_of_spades.png"; }
                case "s3": { return "/Graphics/3_of_spades.png"; }
                case "s4": { return "/Graphics/4_of_spades.png"; }
                case "s5": { return "/Graphics/5_of_spades.png"; }
                case "s6": { return "/Graphics/6_of_spades.png"; }
                case "s7": { return "/Graphics/7_of_spades.png"; }
                case "s8": { return "/Graphics/8_of_spades.png"; }
                case "s9": { return "/Graphics/9_of_spades.png"; }
                case "s10": { return "/Graphics/10_of_spades.png"; }
                case "s11": { return "/Graphics/jack_of_spades.png"; }
                case "s12": { return "/Graphics/queen_of_spades.png"; }
                case "s13": { return "/Graphics/king_of_spades.png"; }
                case "s14": { return "/Graphics/ace_of_spades.png"; }
                case "c2": { return "/Graphics/2_of_clubs.png"; }
                case "c3": { return "/Graphics/3_of_clubs.png"; }
                case "c4": { return "/Graphics/4_of_clubs.png"; }
                case "c5": { return "/Graphics/5_of_clubs.png"; }
                case "c6": { return "/Graphics/6_of_clubs.png"; }
                case "c7": { return "/Graphics/7_of_clubs.png"; }
                case "c8": { return "/Graphics/8_of_clubs.png"; }
                case "c9": { return "/Graphics/9_of_clubs.png"; }
                case "c10": { return "/Graphics/10_of_clubs.png"; }
                case "c11": { return "/Graphics/jack_of_clubs.png"; }
                case "c12": { return "/Graphics/queen_of_clubs.png"; }
                case "c13": { return "/Graphics/king_of_clubs.png"; }
                case "c14": { return "/Graphics/ace_of_clubs.png"; }

                default: { return "/Graphics/3044691_app_essential_interface_question_ui_icon.png"; }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
