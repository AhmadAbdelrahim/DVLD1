using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD1
{
    public partial class Ball1 : UserControl
    {
        public delegate void BallLocationChanged(int location);

        public event BallLocationChanged OnBallLocationChanged;

        public Ball1()
        {
            InitializeComponent();
        }

        private int _location = 5;

        public int Location
        {
            get => _location;
            set
            {
                if (_location != value)
                {
                    _location = value;
                    OnBallLocationChanged?.Invoke(_location);
                    textBox1.Text = _location.ToString();
                }
            }
        }
    }
}
