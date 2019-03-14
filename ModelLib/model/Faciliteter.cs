using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib.model
{
     public class Faciliteter
    {
        private int _facilitetId;
        private String _name;
        

        public Faciliteter()
        {
        }

        public Faciliteter(int facilitetId, string name)
        {
            _facilitetId = facilitetId;
            _name = name;
            
        }

        public int FacilitetId
        {
            get => _facilitetId;
            set => _facilitetId = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }


        public override string ToString()
        {
            return $"{nameof(FacilitetId)}: {FacilitetId}, {nameof(Name)}: {Name}";
        }
    }

}

