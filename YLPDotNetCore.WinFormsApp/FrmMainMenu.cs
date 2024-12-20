﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YLPDotNetCore.WinFormsApp
{
    public partial class FrmMainMenu : Form
    {
        public FrmMainMenu()
        {
            InitializeComponent();
        }

        private void newBlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBlog frm = new FrmBlog();
            frm.ShowDialog();
            //frm.Show();
        }

        private void blogListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBlogList frmList = new FrmBlogList();
            frmList.ShowDialog();
        }
    }
}
