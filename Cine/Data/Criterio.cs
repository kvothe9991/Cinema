using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cine.Data
{
    public enum Criterio
    {
        MasVistas, MasGustadas, InteresEconomico, Aleatorio
    }

    public enum CriterioEst
    {
        Actor, Filme, Genero, Nacionalidad, Periodo, Rating
    }

    public static class CriterioActual
    {
        public static Criterio Criterio = Criterio.MasVistas;
    }
}