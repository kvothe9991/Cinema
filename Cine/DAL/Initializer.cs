﻿using System;
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
            var filmes = new List<Filme>
            {
                new Filme
                {
                    Disponible = true,
                    Nombre = "Nomadland",
                    Genero = "Drama",
                    Pais = "Estados Unidos",
                    actores = new List<string>
                    {
                        "Frances McDormand",
                        "David Strathairn",
                        "Linda May",
                        "Charlene Swankie"
                    },
                    Calificaciones = new List<int> { 4, 8, 2 },
                    Horarios = new List<Tuple<int,int>> { Tuple.Create(3, 30), Tuple.Create(6, 45), Tuple.Create(10, 00) },
                    Salas = new List<int> { 1, 2, 3 }
                },
                new Filme
                {
                    Disponible = true,
                    Nombre = "Sound of Metal",
                    Genero = "Drama",
                    Pais = "Estados Unidos",
                    actores = new List<string>
                    {
                        "Riz Ahmed",
                        "Olivia Cooke",
                        "Paul Raci",
                        "Lauren Ridloff",
                        "Mathieu Amalric",
                        "Chelsea Lee"
                    },
                    Calificaciones = new List<int> { 7, 10, 10 },
                    Horarios = new List<Tuple<int,int>> { Tuple.Create(3, 30), Tuple.Create(6, 45), Tuple.Create(10, 00) },
                    Salas = new List<int> { 1, 2, 3 }
                },
                new Filme
                {
                    Disponible = true,
                    Nombre = "Judas and The Black Messiah",
                    Genero = "Drama Histórico",
                    Pais = "Estados Unidos",
                    actores = new List<string>
                    {
                        "Daniel Kaluuya",
                        "LaKeith Stanfeild",
                        "Jesse Plemons",
                        "Dominique Fishback"
                    },
                    Calificaciones = new List<int> { 2, 8, 9 },
                    Horarios = new List<Tuple<int,int>> { Tuple.Create(3, 30), Tuple.Create(6, 45), Tuple.Create(10, 00) },
                    Salas = new List<int> { 1, 2, 3 }
                },
                new Filme
                {
                    Disponible = true,
                    Nombre = "The Matrix",
                    Genero = "Ciencia Ficción",
                    Pais = "Estados Unidos",
                    actores = new List<string>
                    {
                        "Keanu Reeves",
                        "Laurence Fishburne",
                        "Carrie-Anne Moss",
                        "Hugo Weaving"
                    },
                    Calificaciones = new List<int> { 10, 10, 10 },
                    Horarios = new List<Tuple<int,int>> { Tuple.Create(3, 30), Tuple.Create(6, 45), Tuple.Create(10, 00) },
                    Salas = new List<int> { 1, 2, 3 }
                },
                new Filme
                {
                    Disponible = false,
                    Nombre = "Child's Play",
                    Genero = "Terror",
                    Pais = "Estados Unidos",
                    actores = new List<string>
                    {
                        "Catherine Hicks",
                        "Chris Sarandon",
                        "Alex Vincent",
                        "Brad Dourif"
                    },
                    Calificaciones = new List<int> { 7, 5, 9 },
                    Horarios = new List<Tuple<int,int>> { Tuple.Create(3, 30), Tuple.Create(6, 45), Tuple.Create(10, 00) },
                    Salas = new List<int> { 1, 2, 3 }
                },
                new Filme
                {
                    Disponible = true,
                    Nombre = "El Cuerno de la Abundancia",
                    Genero = "Comedia",
                    Pais = "Cuba",
                    actores = new List<string>
                    {
                        "Jorge Perugorría",
                        "Laura de la Uz",
                        "Enrique Molina",
                        "Annia Bú Maure",
                        "Paula Alí",
                        "Mirtha Ibarra"
                    },
                    Calificaciones = new List<int> { 7, 9, 9 },
                    Horarios = new List<Tuple<int,int>> { Tuple.Create(3, 30), Tuple.Create(6, 45), Tuple.Create(10, 00) },
                    Salas = new List<int> { 1, 2, 3 }
                },
                new Filme
                {
                    Disponible = true,
                    Nombre = "Vampiros en La Habana",
                    Genero = "Animación",
                    Pais = "Cuba",
                    actores = new List<string>
                    {
                        "Manuel Marín",
                        "Margarita Aguero",
                        "Frank González",
                        "Irela Bravo"
                    },
                    Calificaciones = new List<int> { 9, 10, 10 },
                    Horarios = new List<Tuple<int,int>> { Tuple.Create(3, 30), Tuple.Create(6, 45), Tuple.Create(10, 00) },
                    Salas = new List<int> { 1, 2, 3 }
                },
                new Filme
                {
                    Disponible = true,
                    Nombre = "Pájaros de Verano",
                    Genero = "Drama",
                    Pais = "Colombia",
                    actores = new List<string>
                    {
                        "Carmiña Martínez",
                        "Natalia Reyes",
                        "José Acosta"
                    },
                    Calificaciones = new List<int> { 9, 8, 9 },
                    Horarios = new List<Tuple<int,int>> { Tuple.Create(3, 30), Tuple.Create(6, 45), Tuple.Create(10, 00) },
                    Salas = new List<int> { 1, 2, 3 }
                },
                new Filme
                {
                    Disponible = true,
                    Nombre = "American Pie",
                    Genero = "Comedia Romántica",
                    Pais = "Estados Unidos",
                    actores = new List<string>
                    {
                        "Jason Biggs",
                        "Shannon Elizabeth",
                        "Alyson Hannigan",
                        "Chris Klein",
                        "Natasha Lyonne",
                        "Thomas Ian Nicholas",
                        "Tara Reid"
                    },
                    Calificaciones = new List<int> { 7, 7, 10 },
                    Horarios = new List<Tuple<int,int>> { Tuple.Create(3, 30), Tuple.Create(6, 45), Tuple.Create(10, 00) },
                    Salas = new List<int> { 1, 2, 3 }
                },
                new Filme
                {
                    Disponible = true,
                    Nombre = "The Shawshank Redemption",
                    Genero = "Drama",
                    Pais = "Estados Unidos",
                    actores = new List<string>
                    {
                        "Tim Robbins",
                        "Morgan Freeman",
                        "Bob Gunton",
                        "William Sadler",
                        "Clancy Brown",
                        "Gil Bellows",
                        "Mark Rolston",
                        "James Whitmore"
                    },
                    Calificaciones = new List<int>() { 7, 6, 9 },
                    Horarios = new List<Tuple<int,int>>() { Tuple.Create(3, 30), Tuple.Create(6, 45), Tuple.Create(10, 00) },
                    Salas = new List<int>() { 1, 2, 3 }
                },
                new Filme
                {
                    Disponible = true,
                    Nombre = "The Dark Knight Rises",
                    Genero = "Acción",
                    Pais = "Estados Unidos",
                    actores = new List<string>
                    {
                        "George Clooney"
                    },
                    Calificaciones = new List<int> { 7, 6, 9 },
                    Horarios = new List<Tuple<int,int>> { Tuple.Create(3, 30), Tuple.Create(6, 45), Tuple.Create(10, 00) },
                    Salas = new List<int> { 1, 2, 3 }
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