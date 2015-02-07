using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boytrix.UI.Common.Utilities.Infrastructure
{
    public interface ICatalogEx
    {
        AggregateCatalog GetAggregateCatalog();
    }
}
