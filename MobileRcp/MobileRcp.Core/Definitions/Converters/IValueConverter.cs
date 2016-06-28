using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileRcp.Core.Definitions.Converters
{
    public interface IValueConverter<TModelIn, TModelOut>
    {
        TModelOut Convert(TModelIn model);
    }
}
