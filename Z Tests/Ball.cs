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
    public partial class Ball : Form
    {
        public Ball()
        {
            InitializeComponent();
        }

        public delegate void BallLocationChanged(int location);

        public event BallLocationChanged OnBallLocationChanged;

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
                }
            }
        }
}
}
