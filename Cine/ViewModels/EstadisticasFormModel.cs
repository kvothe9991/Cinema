using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cine.Data;

namespace Cine.ViewModels
{
    public class EstadisticasFormModel
    {
        public CriterioEst Criterio { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
    }

    public class EstadisticasShowModel
    {
        public CriterioEst criterio;
        public IEnumerable<KeyValuePair<string, int>> data;
        public string Header
        {
            get
            {
                switch (this.criterio)
                {
                    case CriterioEst.Actor:
                        return "Actores";
                    case CriterioEst.Filme:
                        return "Filmes";
                    case CriterioEst.Genero:
                        return "Generos";
                    case CriterioEst.Nacionalidad:
                        return "Nacionalidad";
                    case CriterioEst.Periodo:
                        return "Periodo";
                    case CriterioEst.Rating:
                        return "Evaluación Promedio";
                    default:
                        return "Criterio";
                }
            }
        }
    }
}