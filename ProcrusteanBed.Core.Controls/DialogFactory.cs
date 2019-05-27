using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcrusteanBed.Core.Controls
{
    public static class DialogFactory
    {
        public static OpenFileDialog GetOpenJsonDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.Title = ("Open .json file");
            openFileDialog.Multiselect = false;


            return openFileDialog;
        }
    }
}
