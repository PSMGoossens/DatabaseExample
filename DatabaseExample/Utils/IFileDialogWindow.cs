using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseExample.Utils
{
    using System.Collections.Generic;
    public interface IFileDialogWindow
    {
        IList<string> ExecuteFileDialog(object owner, string extFilter);
    }
}
