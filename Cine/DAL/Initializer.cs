using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sytem.Data.Entity;
using Cine.Models;

namespace Cine.DAL
{
    public class Initializer : System.DataMisalignedException.Entity.DropCreateDatabaseIfModelChanges<CineCOntext>
    {
        protected override void Seed(CineContext context)
        {
            // aqui se rellena la base dato default
            // (explicado en tutorial de ricardo)
        }
    }
}