using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppRx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var searchTerm = Observable.FromEventPattern<EventArgs>(
                textBox1, "TextChanged").Select(x => ((TextBox)x.Sender).Text).Where(text => text.EndsWith("."));

            searchTerm.Subscribe(trm => label1.Text = trm);

            // Linq aspect Rx
            /// Observable.Empty<>: Empty observable sequence
            /// Observable.Return<>: Observable sequence single element
            /// Observable.Throw<>: Observable sequence terminating with an exception
            /// Observable.Never<>: Non-terminating observable sequence infinite in duration
        }
    }
}
