﻿using Autodesk.AutoCAD.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace PipeInfo
{
    public delegate void DataGetEventHandler(string data);
    public partial class Winform_SpoolInfor_DB_Path : Form
    {
        public DataGetEventHandler DataSendEvent;
        public string db_path;
        public Winform_SpoolInfor_DB_Path()
        {
            InitializeComponent();
        }
        private void button_db_find_path_Click(object sender, EventArgs e)
        {
            //db파일 경로를 변수에 넘겨준다. 
            db_path = showFileDialog();
        }

        private void button_db_path_ok_Click(object sender, EventArgs e)
        {
            if(textBox_db.Text != "")
            {
            this.DialogResult = DialogResult.OK;
            DataSendEvent(db_path);
            this.Close();
            }
            else
            {

            }
        }
  
 
        public string showFileDialog()
        {
            var ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.Filter = "DDWorks DatabaseFile(*.db)|*.db";
            if (ofd.ShowDialog().ToString() == "OK")
            {
                textBox_db.Text = ofd.FileName;
                return ofd.FileName;
            }
            else if (ofd.ShowDialog().ToString() == "CANCEL")
            {
                return "";
            }
            return "";
        }

        private void Winform_SpoolInfor_DB_Path_Load(object sender, EventArgs e)
        {

        }
    }
}
