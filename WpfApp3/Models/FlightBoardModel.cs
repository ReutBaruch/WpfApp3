﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.ViewModels;

namespace WpfApp3.Models
{
    class FlightBoardModel : ViewModelBase
    {
        private Info info;
        private Commands commands;
        private double? lat;
        private double? lon;

        public FlightBoardModel()
        {
            this.info = Info.Instance;
            info.PropertyChanged += InfoPropertyChange;
        }

        private void InfoPropertyChange(object sender, PropertyChangedEventArgs e)
        {
            NotifyPropertyChanged(e.PropertyName);
        }

        public double? Lat
        {
            get
            {
                return this.lat;
            }

            set
            {
                this.lat = value;
                NotifyPropertyChanged("Lat");

            }
        }

        public double? Lon
        {
            get
            {
                return this.lon;
            }

            set
            {
                this.lon = value;
                NotifyPropertyChanged("Lon");

            }
        }

        public bool IsConnect()
        {
            return this.info.IsConnect;
        }

        public void Stop()
        {
            this.info.ShouldStop = true;
        }

        public void Read()
        {
            new Task(delegate ()
            {
                while (!this.info.ShouldStop)
                {
                    string[] args = this.info.GetInput();
                    lat = Convert.ToDouble(args[0]);
                    lon = Convert.ToDouble(args[1]);
                }
            }).Start();
        }

        public void Connect(string ip, int port)
        {
            this.info.StartConnect(ip, port);
            Read();
        }
    }
}
