using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Bogus;
using Dl.Implementations;
using Dl.Model;
using LoadData.Model;
using ReactiveUI;
using System.Transactions;

namespace LoadData.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        private readonly EFContext _db = new EFContext();
        private bool _stopTranzaction;




        public MainViewModel()
        {
            GenerateBogus();
            
           // ProgressChanged = ReactiveCommand.Create(ProgressChangedHandler);
            LoadToDataBase = ReactiveCommand.Create(LoadToDataBaseHandler);
            StopLoad = ReactiveCommand.Create(StopLoadHandler);

        }
        private ObservableCollection<GoodView> _goods = new ObservableCollection<GoodView>();
        public ObservableCollection<GoodView> Good
        {
            get => _goods;
            set => this.RaiseAndSetIfChanged(ref _goods, value);
        }
        private  double  _currentProgress;
        public  double CurrentProgress
        {
            get =>  _currentProgress;
            set => this.RaiseAndSetIfChanged(ref  _currentProgress, value);
        }
        private double _maxValueBar;
        public double MaxValueBar
        {
            get => _maxValueBar;
            set => this.RaiseAndSetIfChanged(ref _maxValueBar, value);
        }

        private bool _stopLoadEnable = false;
        private bool StopLoadEnable
        {
            get => _stopLoadEnable;
            set => this.RaiseAndSetIfChanged(ref _stopLoadEnable, value);
        }

        private string _countLoad;
        public  string CountLoad
        {
            get => _countLoad;
             set => this.RaiseAndSetIfChanged(ref _countLoad, value);
        }
        private  void GenerateBogus()
        {

            StopLoadEnable = false;


            var end = DateTime.Now;
            var start = new DateTime(2016, 3, 1, 7, 0, 0, DateTimeKind.Local);


            var Model = new Faker<Good>()
                 .RuleFor(bp => bp.Id, f => f.IndexFaker)
                 .RuleFor(bp => bp.Firm, f => f.PickRandomParam(new string[] { "Acer", "Asus", "Lenovo", "Dell", "HP" }))
                 .RuleFor(bp => bp.Model, f => f.PickRandomParam(new string[] { "Inspiron 3552", "IdeaPad 320-15IAP", "X505BA-BR062", "IdeaPad 320-15ISK ", "3DP04ES" }))
                 .RuleFor(bp => bp.Group, f => f.PickRandomParam(new string[] { "Laptop", "Desktop", "Tablet" }))
                 .RuleFor(bp => bp.TehnicalInfo, f => f.PickRandomParam(new string[] { "(1366x768)/Intel Celeron Dual-Core N3350", "(1920x1080) IPS Touch/Intel Atom x5-Z8300", "(1366x768)/Intel Celeron Dual-Core N3350", "(1366x768)/Intel Core i5-4288U ", "(1920x1080)/Intel Core i3-6006U" }))
                 .RuleFor(bp => bp.Price, f => f.Random.Number(100, 200))
                 .RuleFor(bp => bp.Count, f => f.Random.Number(1, 10))
                 .RuleFor(bp => bp.Warranty, f => f.PickRandomParam(new int[] { 3, 6, 9, 12, 24, 36 }))
                 .RuleFor(bp => bp.DateReception, f => f.Date.Between(start, end))
                 .RuleFor(bp => bp.Status, f => f.PickRandomParam(new string[] { "Promotion", "New", "PriceDown", "PriceUp" }));

            var NewGood = Model.Generate(1000);
            MaxValueBar += NewGood.Count;



            for (int i = 0; i < NewGood.Count; i++)
            {

                Good.Add(new GoodView
                {
                    Id = NewGood[i].Id,
                    Firm = NewGood[i].Firm,
                    Model = NewGood[i].Model,
                    Group = NewGood[i].Group,
                    TehnicalInfo = NewGood[i].TehnicalInfo,
                    Price = NewGood[i].Price,
                    Count = NewGood[i].Count,
                    Warranty = NewGood[i].Warranty,
                    DateReception = NewGood[i].DateReception,
                    Status = NewGood[i].Status

                });

            }
            CountLoad = $"{CurrentProgress} / {MaxValueBar}";

        }
        public ICommand LoadToDataBase { get; set; }
        public ICommand StopLoad { get; set; }
         public ICommand ProgressChanged { get; set; }

        private void StopLoadHandler()
        {
             _stopTranzaction = true;
        }




        private async void LoadToDataBaseHandler()
        {
            _stopTranzaction = false;

            _db.Database.Log = Console.Write;

            using (TransactionScope scope = new TransactionScope())
            {
                try
                    {
                        
                        foreach (var item in _goods)
                        {

                            Good goods = new Good
                            {
                                Id = item.Id,
                                Group = item.Group,
                                Firm = item.Firm,

                                Model = item.Model,

                                TehnicalInfo = item.TehnicalInfo,
                                Price = item.Price,
                                Count = item.Count,
                                Warranty = item.Warranty,
                                Status = item.Status,
                                DateReception = item.DateReception


                            };
                            

                        _db.Goods.Add(goods);
                            await _db.SaveChangesAsync();
                           
                            CurrentProgress++;
                            CountLoad = $"{CurrentProgress} / {MaxValueBar}";
                            if (_stopTranzaction == true)
                            {
                                MessageBox.Show("Otmena tranzakcii");
                                CurrentProgress = 0;
                                return;


                            }

                    }


                        
                    scope.Complete();
                        CurrentProgress = 0;


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    MessageBox.Show("Add data = good!");
                CurrentProgress = 0;
            }
            

            
            

           
           
           
        }
        //
        //private  void  CurrentProcessBar(object x)
        //{
        //    CurrentProgress++;
        //}

    }
}
