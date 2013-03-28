using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Project423
{
    public class CrudFolderModel : PropertyChangedHandler
    {
        #region /********************** fields ********************/
        
        string _folderName;
        
        #endregion

        #region /************** properties *******************/

        public string FolderName
        {
            get { return _folderName; }
            set
            {
                _folderName = value;
                OnPropertyChanged("FolderName");
            }
        }


        #endregion
        
    }
}
