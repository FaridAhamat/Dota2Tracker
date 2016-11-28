using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Dota2Stats
{
    public class PlayerMatchHistoryVM : INotifyPropertyChanged
    {
        List<PlayerMatchHistory> playerMatchHistory;
        public List<PlayerMatchHistory> PlayerMatchHistory
        {
            get
            {
                return playerMatchHistory;
            }
            set
            {
                if (playerMatchHistory != value)
                {
                    playerMatchHistory = value;
                }
                OnPropertyChanged();
            }
        }

        public INavigation Navigation
        {
            get;
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
