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
    /// Implementation for OpenFileDialog for WPF in conbination with MVVM
    /// </summary>
    public class OpenFilesDialog : IFileDialogWindow
    {
        public IList<string> ExecuteFileDialog(object owner, string extFilter)
        {
            var fd = new OpenFileDialog
            {
                Multiselect = true
            };

            if (!string.IsNullOrWhiteSpace(extFilter))
            {
                fd.Filter = extFilter;
            }
            fd.ShowDialog(owner as Window);

            return fd.FileNames.ToList();
        }
    }
}
