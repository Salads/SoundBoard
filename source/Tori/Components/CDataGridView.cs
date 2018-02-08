using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soundboard.GUI.Controls.Components
{
    public partial class CDataGridView : DataGridView
    {
        public CDataGridView()
        {
            InitializeComponent();
        }

        public CDataGridView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
