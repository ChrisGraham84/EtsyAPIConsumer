using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtsyApiConsumer.Models
{
    public class DynamicEntity : DynamicObject
    {
        private Dictionary<string,string> _values;

        public DynamicEntity(Dictionary<string, string> Values)
        {
            _values = Values;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if(_values.ContainsKey(binder.Name))
            {
                result = _values[binder.Name];
                return (true);
            }
            result = null;
            return (false);
        }
    }
}
