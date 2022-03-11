using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TestAppZMS
{
    /// <summary>
    /// Логика взаимодействия для ErrView.xaml
    /// </summary>
    public partial class ErrView : Window
    {
        public List<string> ErrList { get; } = new();
        public ErrView(List<string> errList)
        {
            this.ErrList.AddRange(errList);
            InitializeComponent();
        }
    }
}
