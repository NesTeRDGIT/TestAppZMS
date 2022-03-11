using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using TestAppZMS.Annotations;
using TestAppZMS.WPF;
using TestAppZMS.Class;
using TestAppZMS.Entity;
using TestAppZMS.File;

namespace TestAppZMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public LoadFilesVM VM { get; }
        public MainWindow(MSSQLContext mSSQLContext, IXSDChecker xSDChecker, IConStrChecker conStrChecker)
        {
            this.VM = new LoadFilesVM(mSSQLContext, xSDChecker, conStrChecker);
            InitializeComponent();
        }
    }



    public class LoadFilesVM: INotifyPropertyChanged
    {
        private  MSSQLContext repo { get; }
        private IXSDChecker xSDChecker { get;}
        private IConStrChecker conStrChecker { get; }

        public LoadFilesVM(MSSQLContext repo, IXSDChecker xSDChecker, IConStrChecker conStrChecker)
        {
            this.repo = repo;
            this.ConnStr =  repo.Database.GetDbConnection().ConnectionString;
            this.xSDChecker = xSDChecker;
            this.conStrChecker = conStrChecker;
        }
        public ObservableCollection<FileItem> Files { get; } = new();
        private OpenFileDialog ofd = new() { Filter = "*.xml|*.xml", Multiselect = true };
        public ICommand LoadFileCommand => new Command(async obj =>
        {
            try
            {
                if (ofd.ShowDialog() == true)
                {
                    Files.Clear();
                    Files.AddRange(ofd.FileNames.Select(x => new FileItem { FilePath = x, FileName = System.IO.Path.GetFileName(x) }).ToArray());
                  
                    foreach (var item in Files)
                    {
                        await ProcessDataAsync(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        });

        private async Task ProcessDataAsync(FileItem item)
        {
            try
            {
                var err = await xSDChecker.CheckAsync(item.FilePath);
                if (err.Count != 0)
                {
                    item.Result = false;
                    item.Err = err;
                    return;
                }
                repo.ZGLV.Add(NPR_LIST.ReadFromFile(item.FilePath).ToEntity());
                await repo.SaveChangesAsync();
                item.Result = true;
            }
            catch (Exception ex)
            {
                item.Result = false;
                item.Err.Add(ex.Message);
            }
        }

        public ICommand ShowErrCommand => new Command(obj =>
        {
            try
            {
                if (obj is FileItem item)
                {
                    var win = new ErrView(item.Err);
                    win.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        });


        public ObservableCollection<Entity.ZGLV> ZglvList { get; } = new();

        private Entity.ZGLV _CurrZglv;
        public Entity.ZGLV CurrZglv
        {
            get => _CurrZglv;
            set
            {
                _CurrZglv = value;
                if (GetZapCommand.CanExecute(null))
                {
                    GetZapCommand.Execute(value);
                }
            }
        }

        public ICommand GetZGLVCommand => new Command(async obj =>
        {
            try
            {
                ZglvList.Clear();
             
                ZglvList.AddRange(await repo.ZGLV.ToArrayAsync());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        });
        public ObservableCollection<Entity.ZAP> ZapList { get; } = new();
        public ICommand GetZapCommand => new Command(async obj =>
        {
            try
            {
                if (obj is Entity.ZGLV zglv)
                {
                    ZapList.Clear();
                    ZapList.AddRange(await repo.ZAP.Where(x=>x.ZGLV_ID == zglv.ZGLV_ID).ToArrayAsync());
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        });


        private string _ConnStr;
        public string ConnStr
        {
            get => _ConnStr;
            set
            {
                _ConnStr = value;
                RaisePropertyChanged();
            }
        }
        public ICommand SetConnStringCommand => new Command(async obj =>
        {
            try
            {
                var result = conStrChecker.CheckCon(ConnStr);
                if (result.Result)
                {
                    Properties.Settings.Default.ConStr = ConnStr;
                    Properties.Settings.Default.Save();
                    repo.Database.SetConnectionString(ConnStr);
                    MessageBox.Show("OK");
                }
                else
                {
                    MessageBox.Show($"Ошибка проверки подключения: {result.Ex.Message}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        });


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

    public class FileItem: INotifyPropertyChanged
    {
        public string FileName{ get; set; }
        public string FilePath { get; set; }
        private bool? _Result;
        public bool? Result
        {
            get => _Result;
            set
            {
                _Result = value;
                RaisePropertyChanged();
            }
        }

        public List<string> Err { get; set; } = new List<string>();
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

   

}
