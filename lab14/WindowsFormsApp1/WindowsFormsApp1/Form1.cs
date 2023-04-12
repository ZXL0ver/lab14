using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string[] arr = { "banana", "apple", "cherry", "date", "fig", "elderberry" };
        private SortingThread insertionThread, selectionThread, bubbleThread;
        public Form1()
        {
            InitializeComponent();
            insertionThread = new SortingThread(arr, "insertion");
            selectionThread = new SortingThread(arr, "selection");
            bubbleThread = new SortingThread(arr, "bubble");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insertionThread.Start();
            selectionThread.Start();
            bubbleThread.Start();
            insertionThread.Join();
            selectionThread.Join();
            bubbleThread.Join();
            label1.Text = string.Join(", ", arr);
        }
    }
}
