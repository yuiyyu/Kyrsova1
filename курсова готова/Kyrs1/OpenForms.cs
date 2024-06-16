﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kyrs1
{
    public class OpenForms
    {

        private static Form activeForm = null;
        public static void OpenFormInPanel(Form form, Panel panel)
        {
            try
            {
                if (activeForm != null)
                {
                    activeForm.Close();
                }
                activeForm = form;
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                panel.Controls.Add(form);
                panel.Tag = form;
                form.BringToFront();
                form.Show();
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                Application.Restart();
            }
        }

        public static void OpenForm(Form parent, Form openForm)
        {
            parent.Hide();
            openForm.ShowDialog();
            if (openForm.DialogResult == DialogResult.OK)
            {
                Thread.Sleep(150);
                parent.Show();
            }
        }

        public static void OpenFormInNewWindow(Form form)
        {
            form.ShowDialog();
        }
    }
}
