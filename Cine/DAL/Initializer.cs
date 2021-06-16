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
                    actor = "Frances McDormand",
                    Horarios = new List<Horario>
                    {
                        horarios[0],
                        horarios[1]
                    },
                    Salas = new List<Sala>
                    {
                        salas[0],
                        salas[1],
                        salas[2]
                    }
                },
                new Filme
                {
                    Disponible = true,
                    Nombre = "Sound of Metal",
                    Genero = "Drama",
                    Pais = "Estados Unidos",
                    actor = "Riz Ahmed",
                    Horarios = new List<Horario>
                    {
                        horarios[0],
                        horarios[1]
                    },
                    Salas = new List<Sala>
                    {
                        salas[0],
                        salas[1],
                        salas[2]
                    }
                },
                new Filme
                {
                    Disponible = true,
                    Nombre = "Judas and The Black Messiah",
                    Genero = "Drama Histórico",
                    Pais = "Estados Unidos",
                    actor = "Daniel Kaluuya",
                    Horarios = new List<Horario>
                    {
                        horarios[0],
                        horarios[1]
                    },
                    Salas = new List<Sala>
                    {
                        salas[0],
                        salas[1],
                        salas[2]
                    }
                },
                new Filme
                {
                    Disponible = true,
                    Nombre = "The Matrix",
                    Genero = "Ciencia Ficción",
                    Pais = "Estados Unidos",
                    actor = "Keanu Reeves",
                    Horarios = new List<Horario>
                    {
                        horarios[0],
                        horarios[1]
                    },
                    Salas = new List<Sala>
                    {
                        salas[0],
                        salas[2]
                    }
                },
                new Filme
                {
                    Disponible = false,
                    Nombre = "Child's Play",
                    Genero = "Terror",
                    Pais = "Estados Unidos",
                    actor = "Catherine Hicks",
                    Horarios = new List<Horario>
                    {
                        horarios[0],
                        horarios[1]
                    },
                    Salas = new List<Sala>
                    {
                        salas[1],
                        salas[2],
                    }
                },
                new Filme
                {
                    Disponible = true,
                    Nombre = "El Cuerno de la Abundancia",
                    Genero = "Comedia",
                    Pais = "Cuba",
                    actor = "Jorge Perugorría",
                    Horarios = new List<Horario>
                    {
                        horarios[0],
                        horarios[1]
                    },
                    Salas = new List<Sala>
                    {
                        salas[0],
                        salas[1],
                        salas[2]
                    }
                },
                new Filme
                {
                    Disponible = true,
                    Nombre = "Vampiros en La Habana",
                    Genero = "Animación",
                    Pais = "Cuba",
                    actor = "Manuel Marín",
                    Horarios = new List<Horario>
                    {
                        horarios[0],
                        horarios[1]
                    },
                    Salas = new List<Sala>
                    {
                        salas[0],
                        salas[2]
                    }
                },
                new Filme
                {
                    Disponible = true,
                    Nombre = "Pájaros de Verano",
                    Genero = "Drama",
                    Pais = "Colombia",
                    actor = "Carmiña Martínez",
                    Horarios = new List<Horario>
                    {
                        horarios[0],
                        horarios[1]
                    },
                    Salas = new List<Sala>
                    {
                        salas[0],
                        salas[1],
                        salas[2]
                    }
                },
                new Filme
                {
                    Disponible = true,
                    Nombre = "American Pie",
                    Genero = "Comedia Romántica",
                    Pais = "Estados Unidos",
                    actor = "Jason Biggs",
                    Horarios = new List<Horario>
                    {
                        horarios[0],
                        horarios[1]
                    },
                    Salas = new List<Sala>
                    {
                        salas[1],
                        salas[2]
                    }
                },
                new Filme
                {
                    Disponible = true,
                    Nombre = "The Shawshank Redemption",
                    Genero = "Drama",
                    Pais = "Estados Unidos",
                    actor = "Tim Robbins",
                    Horarios = new List<Horario>
                    {
                        horarios[0],
                        horarios[1]
                    },
                    Salas = new List<Sala>
                    {
                        salas[1],
                        salas[2]
                    }
                },
                new Filme
                {
                    Disponible = true,
                    Nombre = "The Dark Knight Rises",
                    Genero = "Acción",
                    Pais = "Estados Unidos",
                    actor = "George Clooney",
                    Horarios = new List<Horario>
                    {
                        horarios[0],
                        horarios[1]
                    },
                    Salas = new List<Sala>
                    {
                        salas[0],
                        salas[2]
                    }
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
                        filmes[1],
                        filmes[2],
                        filmes[3],
                        filmes[4],
                        filmes[5],
                        filmes[6],
                        filmes[7],
                        filmes[8],
                        filmes[9]
                    }, 
                    UsuarioDescuento = "Jubilado"
                },
                new Socio
                {
                    Puntos = 40,
                    Filmes = new List<Filme>
                    {
                        filmes[1],
                        filmes[3]
                    },
                    UsuarioDescuento = "Jubilado"
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
                        filmes[1],
                        filmes[9]
                    }
                },
                new Socio
                {
                    Puntos = 0,
                    Filmes = new List<Filme> {},
                    UsuarioDescuento = "Estudiante"
                }
            };

            socios.ForEach(s => context.Socios.Add(s));
            context.SaveChanges();

            var entradas = new List<Entrada>
            {
                new Entrada
                {
                    Socio = socios[3],
                    Filme = filmes[1], //mismo filme
                    Calificacion = 8,
                    Precio = 20, //no recibe descuento
                    HoraCompra = new DateTime(2020, 2, 10, 10, 30, 15),
                    Horario = new DateTime(2020, 2, 10, 2, 0, 0),
                    Sala = 1,
                    Butaca = 10
                },
                new Entrada
                {
                    Socio = socios[1],
                    Filme = filmes[1], //mismo filme
                    Calificacion = 7,
                    Precio = 18, //recibe descuento por jubilado
                    HoraCompra = new DateTime(2020, 2, 10, 11, 35, 05),
                    Horario = new DateTime(2020, 2, 10, 2, 0, 0),
                    Sala = 1,
                    Butaca = 12
                },
                new Entrada
                {
                    Socio = socios[3],
                    Filme = filmes[3], 
                    Calificacion = 10,
                    Precio = 20, 
                    HoraCompra = new DateTime(2020, 5, 20, 12, 30, 00),
                    Horario = new DateTime(2020, 5, 20, 10, 0, 0),
                    Sala = 3,
                    Butaca = 5
                },
                new Entrada
                {
                    Socio = socios[0],
                    Filme = filmes[0],
                    Calificacion = 8,
                    Precio = 18, //recibe descuento por jubilado
                    HoraCompra = new DateTime(2020, 5, 5, 9, 30, 00),
                    Horario = new DateTime(2020, 5, 10, 2, 0, 0),
                    Sala = 1,
                    Butaca = 5
                },
                new Entrada
                {
                    Socio = socios[0],
                    Filme = filmes[0],
                    Calificacion = 8,
                    Precio = 18, //recibe descuento por jubilado
                    HoraCompra = new DateTime(2020, 6, 5, 9, 30, 00),
                    Horario = new DateTime(2020, 6, 10, 2, 0, 0),
                    Sala = 2,
                    Butaca = 5
                },
                new Entrada
                {
                    Socio = socios[0],
                    Filme = filmes[0],
                    Calificacion = 8,
                    Precio = 18, //recibe descuento por jubilado
                    HoraCompra = new DateTime(2020, 6, 5, 9, 30, 00),
                    Horario = new DateTime(2020, 6, 10, 2, 0, 0),
                    Sala = 3,
                    Butaca = 5
                },
                new Entrada
                {
                    Socio = socios[2],
                    Filme = filmes[6],
                    Calificacion = 6,
                    Precio = 20,
                    HoraCompra = new DateTime(2020, 1, 10, 10, 30, 00),
                    Horario = new DateTime(2020, 1, 10, 10, 0, 0),
                    Sala = 3,
                    Butaca = 1
                },
                new Entrada
                {
                    Socio = socios[2],
                    Filme = filmes[0],
                    Calificacion = 10,
                    Precio = 20,
                    HoraCompra = new DateTime(2021, 3, 12, 9, 35, 00),
                    Horario = new DateTime(2021, 3, 12, 10, 0, 0),
                    Sala = 1,
                    Butaca = 10
                },
                new Entrada
                {
                    Socio = socios[2],
                    Filme = filmes[4],
                    Calificacion = 8,
                    Precio = 20,
                    HoraCompra = new DateTime(2021, 3, 13, 10, 00, 00),
                    Horario = new DateTime(2021, 3, 13, 10, 0, 0),
                    Sala = 3,
                    Butaca = 15
                },
                new Entrada
                {
                    Socio = socios[2],
                    Filme = filmes[5],
                    Calificacion = 10,
                    Precio = 20,
                    HoraCompra = new DateTime(2021, 5, 5, 12, 30, 00),
                    Horario = new DateTime(2021, 5, 5, 10, 0, 0),
                    Sala = 2,
                    Butaca = 2
                },
                new Entrada
                {
                    Socio = socios[2],
                    Filme = filmes[7],
                    Calificacion = 10,
                    Precio = 20,
                    HoraCompra = new DateTime(2021, 5, 10, 10, 30, 00),
                    Horario = new DateTime(2021, 5, 10, 10, 0, 0),
                    Sala = 1,
                    Butaca = 12
                },
                new Entrada
                {
                    Socio = socios[0],
                    Filme = filmes[1],
                    Calificacion = 5,
                    Precio = 18, //recibe descuento por jubilado
                    HoraCompra = new DateTime(2020, 6, 3, 9, 30, 00),
                    Horario = new DateTime(2020, 6, 3, 2, 0, 0),
                    Sala = 3,
                    Butaca = 5
                },
                new Entrada
                {
                    Socio = socios[0],
                    Filme = filmes[2],
                    Calificacion = 7,
                    Precio = 18, //recibe descuento por jubilado
                    HoraCompra = new DateTime(2021, 5, 10, 9, 30, 00),
                    Horario = new DateTime(2021, 5, 10, 2, 0, 0),
                    Sala = 3,
                    Butaca = 5
                },
                new Entrada
                {
                    Socio = socios[0],
                    Filme = filmes[3],
                    Calificacion = 10,
                    Precio = 18, //recibe descuento por jubilado
                    HoraCompra = new DateTime(2020, 6, 6, 9, 30, 00),
                    Horario = new DateTime(2020, 6, 6, 2, 0, 0),
                    Sala = 3,
                    Butaca = 5
                },
                new Entrada
                {
                    Socio = socios[0],
                    Filme = filmes[4],
                    Calificacion = 9,
                    Precio = 18, //recibe descuento por jubilado
                    HoraCompra = new DateTime(2021, 2, 20, 9, 30, 00),
                    Horario = new DateTime(2021, 2, 20, 2, 0, 0),
                    Sala = 3,
                    Butaca = 5
                },
                new Entrada
                {
                    Socio = socios[0],
                    Filme = filmes[5],
                    Calificacion = 9,
                    Precio = 18, //recibe descuento por jubilado
                    HoraCompra = new DateTime(2021, 3, 25, 9, 30, 00),
                    Horario = new DateTime(2021, 3, 25, 2, 0, 0),
                    Sala = 3,
                    Butaca = 5
                },
                new Entrada
                {
                    Socio = socios[0],
                    Filme = filmes[6],
                    Calificacion = 7,
                    Precio = 18, //recibe descuento por jubilado
                    HoraCompra = new DateTime(2021, 1, 10, 9, 30, 00),
                    Horario = new DateTime(2021, 1, 10, 2, 0, 0),
                    Sala = 3,
                    Butaca = 5
                },
                new Entrada
                {
                    Socio = socios[0],
                    Filme = filmes[7],
                    Calificacion = 6,
                    Precio = 18, //recibe descuento por jubilado
                    HoraCompra = new DateTime(2021, 3, 5, 9, 30, 00),
                    Horario = new DateTime(2021, 3, 5, 2, 0, 0),
                    Sala = 3,
                    Butaca = 5
                },
                new Entrada
                {
                    Socio = socios[0],
                    Filme = filmes[8],
                    Calificacion = 6,
                    Precio = 18, //recibe descuento por jubilado
                    HoraCompra = new DateTime(2021, 4, 5, 9, 30, 00),
                    Horario = new DateTime(2021, 4, 5, 2, 0, 0),
                    Sala = 3,
                    Butaca = 5
                },
                new Entrada
                {
                    Socio = socios[0],
                    Filme = filmes[8],
                    Calificacion = 10,
                    Precio = 18, //recibe descuento por jubilado
                    HoraCompra = new DateTime(2021, 3, 22, 9, 30, 00),
                    Horario = new DateTime(2021, 3, 22, 2, 0, 0),
                    Sala = 3,
                    Butaca = 5
                },
                new Entrada
                {
                    Socio = socios[0],
                    Filme = filmes[9],
                    Calificacion = 10,
                    Precio = 18, //recibe descuento por jubilado
                    HoraCompra = new DateTime(2021, 5, 27, 9, 30, 00),
                    Horario = new DateTime(2021, 5, 27, 2, 0, 0),
                    Sala = 3,
                    Butaca = 5
                },
            };
            entradas.ForEach(s => context.Entradas.Add(s));
            context.SaveChanges();
        }
    }
}