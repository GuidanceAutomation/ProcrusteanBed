﻿using Microsoft.Win32;
using ProcrusteanBed.Core.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProcrusteanBed.Core.Controls
{
    public static class DialogFactory
    {
        public static SaveFileDialog GetSaveJsonDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.Title = ("Open .json file");

            return saveFileDialog;
        }

        public static CreateDirectiveDialog GetCreateDirectiveDialog()
        {
            return new CreateDirectiveDialog();
        }

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
