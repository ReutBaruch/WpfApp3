using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Input;
//using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.Models;


namespace WpfApp3.ViewModels
{
    class AutoPilotViewModel : ViewModelBase
    {
        private string data;
        private AutoPilotModel autoModel;
        private Brush brush = Brushes.White;
        private ICommand okCommand;

        public AutoPilotViewModel()
        {
            this.autoModel = new AutoPilotModel();
        }


        public string Data
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;

                if (string.IsNullOrEmpty(Data)) Color = Brushes.Lavender;
                else if (!String.IsNullOrEmpty(Data)) Color = Brushes.Blue;
            }
        }

        public Brush Color
        {
            get
            {
                return this.brush;
            }

            set
            {
                brush = value;
                NotifyPropertyChanged("Color");
            }
        }

        public ICommand OkCommand
        {
            get
            {
                return okCommand ?? (okCommand = new CommandHandler(() =>
                 {
                     string send = Data;
                     Data = "";
                     Color = Brushes.Yellow;
                     autoModel.scriptCommands(send);
                 }));
            }
        }
    }
}
