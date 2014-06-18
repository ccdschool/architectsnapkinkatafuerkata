using System;
using System.Windows;
using System.Windows.Controls;
using appfragen.contracts;

namespace appfragen.dialoge
{
    public partial class FragebogenDialog : Window
    {
        public FragebogenDialog() {
            InitializeComponent();

            btnAuswerten.Click += (o, e) => Auswerten();
            btnStart.Click += (o, e) => Befragung_starten();
        }

        public void Antwortbogen_anzeigen(Antwortbogen antwortbogen) {
            btnAuswerten.IsEnabled = antwortbogen.IstAuswertbar;
            panel.Children.Clear();

            var antwortIndex = 0;

            foreach (var fragestellung in antwortbogen.Fragestellungen) {
                var stackPanel = new StackPanel();
                var groupBox = new GroupBox {
                    Header = fragestellung.Frage,
                    Content = stackPanel
                };
                panel.Children.Add(groupBox);

                foreach (var antwortmöglichkeit in fragestellung.Antwortmöglichkeiten) {
                    var radioButton = new RadioButton {
                        Content = antwortmöglichkeit
                    };
                    var i = antwortIndex++;
                    radioButton.Click += (o, e) => Antwort_gegeben(i);
                    stackPanel.Children.Add(radioButton);
                }
            }
        }

        public event Action Befragung_starten;
        public event Action<int> Antwort_gegeben;
        public event Action Auswerten;
    }
}