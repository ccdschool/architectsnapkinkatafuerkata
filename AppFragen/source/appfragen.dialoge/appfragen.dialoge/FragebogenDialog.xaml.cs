﻿using System;
using System.Windows;
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

        public void Neuer_Antwortbogen(Antwortbogen antwortbogen) {
            
        }

        public event Action Befragung_starten;

        public event Action<int> Antwort_gegeben;

        public event Action Auswerten;
    }
}