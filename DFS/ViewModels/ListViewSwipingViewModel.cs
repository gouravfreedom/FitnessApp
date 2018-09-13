using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFS
{
    public class ListViewSwipingViewModel
    {
        #region Fields

        private ObservableCollection<ListViewInboxInfo> inboxInfo;

        #endregion

        #region Constructor

        public ListViewSwipingViewModel()
        {
            GenerateSource();
        }

        #endregion

        #region Properties

        public ObservableCollection<ListViewInboxInfo> InboxInfo
        {
            get { return inboxInfo; }
            set { this.inboxInfo = value; }
        }

        #endregion

        #region Generate Source

        private void GenerateSource()
        {
            ListViewInboxInfoRepository inboxinfo = new ListViewInboxInfoRepository();
            inboxInfo = inboxinfo.GetInboxInfo();
        }

        #endregion
    }
}
