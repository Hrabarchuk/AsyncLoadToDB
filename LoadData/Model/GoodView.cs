using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace LoadData.Model
{
    public class GoodView : ReactiveObject
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => this.RaiseAndSetIfChanged(ref _id, value);
        }

        private string _group;
        public string Group
        {
            get => _group;
            set => this.RaiseAndSetIfChanged(ref _group, value);

        }
        private string _firm;
        public string Firm
        {
            get => _firm;
            set => this.RaiseAndSetIfChanged(ref _firm, value);

        }
        private string _model;
        public string Model
        {
            get => _model;
            set => this.RaiseAndSetIfChanged(ref _model, value);

        }
        private string _tehnicalInfo;
        public string TehnicalInfo
        {
            get => _tehnicalInfo;
            set => this.RaiseAndSetIfChanged(ref _tehnicalInfo, value);

        }
        private int _price;
        public int Price
        {
            get => _price;
            set => this.RaiseAndSetIfChanged(ref _price, value);

        }
        private int _count;
        public int Count
        {
            get => _count;
            set => this.RaiseAndSetIfChanged(ref _count, value);

        }
        private int _warranty;
        public int Warranty
        {
            get => _warranty;
            set => this.RaiseAndSetIfChanged(ref _warranty, value);

        }
        private string _status;
        public string Status
        {
            get => _status;
            set => this.RaiseAndSetIfChanged(ref _status, value);

        }
        private DateTime _dateTime;
        public DateTime DateReception
        {
            get => _dateTime;
            set => this.RaiseAndSetIfChanged(ref _dateTime, value);

        }


    }
}
