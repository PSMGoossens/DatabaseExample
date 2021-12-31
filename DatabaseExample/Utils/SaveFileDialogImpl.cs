using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DatabaseExample.Utils
{
    /// <summary>
    /// Class for save file dialog implementation for WPF including MVVM
    /// </summary>
    public class SaveFileDialogImpl : IFileDialogWindow
    {
        public IList<string> ExecuteFileDialog(object owner, string extFilter)
        {
            var fd = new SaveFileDialog();
            if (!string.IsNullOrWhiteSpace(extFilter))
            {
                fd.Filter = extFilter;
            }
            fd.ShowDialog(owner as Window);

            return fd.FileNames.ToList();
        }
    }
}
