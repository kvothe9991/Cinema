using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Cine.Models;

namespace Cine.DAL
{
    public class Initializer : DropCreateDatabaseIfModelChanges<CineContext>
    {
        protected override void Seed(CineContext context)
        {
            // aqui se rellena la base dato default
            // (explicado en tutorial de ricardo)
        }
    }
}