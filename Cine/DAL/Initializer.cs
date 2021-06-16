using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Cine.Models;

namespace Cine.DAL
{
    public class Initializer : DropCreateDatabaseAlways<CineContext>
    {
        protected override void Seed(CineContext context)
        {
            var horarios = new List<Horario>
            {
                new Horario
                {
                    HorarioID = 1,
                    HH = 2,
                    MM = 0
                },
                new Horario
                {
                    HorarioID = 2,
                    HH = 6,
                    MM = 0
                }
            };
            horarios.ForEach(s => context.Horarios.Add(s));
            context.SaveChanges();

            var salas = new List<Sala>
            {
                new Sala
                {
                    SalaID = 1,
                },
                new Sala
                {
                    SalaID = 2,
                },
                new Sala
                {
                    SalaID = 3,
                },
            };
            salas.ForEach(s => context.Salas.Add(s));
            context.SaveChanges();

            var filmes = new List<Filme>
            {
                new Filme
                {
                    Disponible = true,
                    Nombre = "Nomadland",
                    Genero = "Drama",
                    Pais = "Estados Unidos",
                    actor = "Frances McDormand"
                },
                new Filme
                {
                    Disponible = true,
                    Nombre = "Sound of Metal",
                    Genero = "Drama",
                    Pais = "Estados Unidos",
                    actor = "Riz Ahmed",
                },
                new Filme
                {
                    Disponible = true,
                    Nombre = "Judas and The Black Messiah",
                    Genero = "Drama Histórico",
                    Pais = "Estados Unidos",
                    actor = "Daniel Kaluuya",
                },
                new Filme
                {
                    Disponible = true,
                    Nombre = "The Matrix",
                    Genero = "Ciencia Ficción",
                    Pais = "Estados Unidos",
                    actor = "Keanu Reeves",
                },
                new Filme
                {
                    Disponible = false,
                    Nombre = "Child's Play",
                    Genero = "Terror",
                    Pais = "Estados Unidos",
                    actor = "Catherine Hicks",
                },
                new Filme
                {
                    Disponible = true,
                    Nombre = "El Cuerno de la Abundancia",
                    Genero = "Comedia",
                    Pais = "Cuba",
                    actor = "Jorge Perugorría",
                },
                new Filme
                {
                    Disponible = true,
                    Nombre = "Vampiros en La Habana",
                    Genero = "Animación",
                    Pais = "Cuba",
                    actor = "Manuel Marín",
                },
                new Filme
                {
                    Disponible = true,
                    Nombre = "Pájaros de Verano",
                    Genero = "Drama",
                    Pais = "Colombia",
                    actor = "Carmiña Martínez",
                },
                new Filme
                {
                    Disponible = true,
                    Nombre = "American Pie",
                    Genero = "Comedia Romántica",
                    Pais = "Estados Unidos",
                    actor = "Jason Biggs",
                },
                new Filme
                {
                    Disponible = true,
                    Nombre = "The Shawshank Redemption",
                    Genero = "Drama",
                    Pais = "Estados Unidos",
                    actor = "Tim Robbins",
                },
                new Filme
                {
                    Disponible = true,
                    Nombre = "The Dark Knight Rises",
                    Genero = "Acción",
                    Pais = "Estados Unidos",
                    actor = "George Clooney"
                }
            };

            filmes.ForEach(f => context.Filmes.Add(f));
            context.SaveChanges();

            var socios = new List<Socio>
            {
                new Socio
                {
                    Puntos = 60,
                    Filmes = new List<Filme>
                    {
                        filmes[0],
                        filmes[2],
                        filmes[3],
                        filmes[9]
                    }
                },
                new Socio
                {
                    Puntos = 40,
                    Filmes = new List<Filme>
                    {
                        filmes[0],
                        filmes[7]
                    }
                },
                new Socio
                {
                    Puntos = 100,
                    Filmes = new List<Filme>
                    {
                        filmes[0],
                        filmes[1],
                        filmes[4],
                        filmes[5],
                        filmes[6],
                        filmes[7]
                    }
                },
                new Socio
                {
                    Puntos = 60,
                    Filmes = new List<Filme>
                    {
                        filmes[3],
                        filmes[8],
                        filmes[9]
                    }
                },
                new Socio
                {
                    Puntos = 0,
                    Filmes = new List<Filme> {}
                }
            };

            socios.ForEach(s => context.Socios.Add(s));
            context.SaveChanges();
        }
    }
}