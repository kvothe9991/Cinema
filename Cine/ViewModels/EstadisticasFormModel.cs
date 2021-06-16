using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cine.Data;

namespace Cine.ViewModels
{
    public class EstadisticasFormModel
    {
        public CriterioEst criterio;
        public DateTime desde, hasta;
    }

    public class EstadisticasShowModel
    {
        public CriterioEst criterio;
        public IEnumerable<KeyValuePair<string, int>> data;
    }
}