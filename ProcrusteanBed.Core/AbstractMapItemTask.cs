using ProcrusteanBed.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProcrusteanBed.Core
{
   [DataContract]
   public abstract class AbstractMapItemTask : AbstractTask, IMapItemTask
   {
        private int mapItemId = -1;

        [DataMember]
        public int MapItemId
        {
            get { return mapItemId; }
            set
            {
                if (mapItemId != value)
                {
                    mapItemId = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
   }
}
