using System;
using System.Collections.Generic;
using R4G.App.Models;

namespace R4G.App.Data.Static
{
    public static class ProximasCarrerasData
    {
        private static readonly List<ProximaCarrera> _carrerasAragon = new()
        {
            new ProximaCarrera
            {
                Nombre = "Papanoelada Zaragoza",
                Fecha = new DateTime(2025, 12, 21),
                Ciudad = "Zaragoza",
                Comunidad = "Aragón",
                Lugar = "Centro de Zaragoza",
                Hora = "11:00",
                ImagenUrl = "/img/papa-noel.jpg",
                Enlace = "https://www.carrerapapanoelzaragoza.es/",
                Descripcion = "Papanoelada solidaria en Zaragoza. Ambiente festivo navideño y familiar.",
                DistanciaKm = 5
            },
            new ProximaCarrera
            {
                Nombre = "San Silvestre Zaragoza",
                Fecha = new DateTime(2025, 12, 31),
                Ciudad = "Zaragoza",
                Comunidad = "Aragón",
                Lugar = "Paseo Independencia",
                Hora = "18:00",
                ImagenUrl = "/img/san-silvestre.jpg",
                Enlace = "https://www.avaibooksports.com/inscripcion/xx-san-silvestre-zaragoza-el-rincon-2025/?lang=es",
                Descripcion = "La clásica San Silvestre zaragozana para despedir el año corriendo.",
                DistanciaKm = 5
            },
            new ProximaCarrera
            {
                Nombre = "10K del Roscón Zaragoza",
                Fecha = new DateTime(2026, 1, 25),
                Ciudad = "Zaragoza",
                Comunidad = "Aragón",
                Lugar = "Parque del Agua",
                Hora = "10:00",
                ImagenUrl = "/img/10k-roscon.jpeg",
                Enlace = "https://osandarines.com/secciones-atletismo/",
                Descripcion = "10K popular para quemar el roscón de Reyes en el Parque del Agua.",
                DistanciaKm = 10
            },
            new ProximaCarrera
            {
                Nombre = "Carrera del Ebro",
                Fecha = new DateTime(2026, 2, 22),
                Ciudad = "Zaragoza",
                Comunidad = "Aragón",
                Lugar = "Campus de la Defensa",
                Hora = "10:00",
                ImagenUrl = "/img/carrera-del-ebro.png",
                Enlace = "https://carreradelebro.org",
                Descripcion = "Trail urbano y de monte por la ribera del Ebro. Muy popular y exigente.",
                DistanciaKm = 12
            },
            new ProximaCarrera
            {
                Nombre = "Media Maratón de Zaragoza",
                Fecha = new DateTime(2026, 3, 15),
                Ciudad = "Zaragoza",
                Comunidad = "Aragón",
                Lugar = "Zona Expo",
                Hora = "9:00",
                ImagenUrl = "/img/media-maraton-zgz.png",
                Enlace = "https://www.mediamaratonzaragoza.com",
                Descripcion = "Media maratón rápida por el centro de Zaragoza.",
                DistanciaKm = 21.097
            }
        };

        private static readonly List<ProximaCarrera> _carrerasEspana = new()
        {
            new ProximaCarrera
            {
                Nombre = "San Silvestre Vallecana",
                Fecha = new DateTime(2025, 12, 31),
                Ciudad = "Madrid",
                Comunidad = "Comunidad de Madrid",
                Lugar = "Barrio de Vallecas / centro de Madrid",
                Hora = "20:00",
                Enlace = "https://www.sansilvestrevallecana.com",
                Descripcion = "Una de las San Silvestres más famosas del mundo.",
                DistanciaKm = 10
            },
            new ProximaCarrera
            {
                Nombre = "Cursa dels Nassos",
                Fecha = new DateTime(2025, 12, 31),
                Ciudad = "Barcelona",
                Comunidad = "Cataluña",
                Lugar = "Zona litoral de Barcelona",
                Hora = "17:30",
                Enlace = "https://www.cursadenassos.barcelona/es",
                Descripcion = "10K rapidísimo por Barcelona.",
                DistanciaKm = 10
            },
            new ProximaCarrera
            {
                Nombre = "10K Valencia Ibercaja",
                Fecha = new DateTime(2026, 1, 11),
                Ciudad = "Valencia",
                Comunidad = "Comunidad Valenciana",
                Lugar = "Avenida del Puerto",
                Hora = "9:00",
                Enlace = "https://www.10kvalencia.com",
                Descripcion = "10K muy rápido y multitudinario.",
                DistanciaKm = 10
            },
            new ProximaCarrera
            {
                Nombre = "EDP Medio Maratón de Sevilla",
                Fecha = new DateTime(2026, 1, 25),
                Ciudad = "Sevilla",
                Comunidad = "Andalucía",
                Lugar = "Zona centro de Sevilla",
                Hora = "9:00",
                Enlace = "https://www.mediomaratondesevilla.es/",
                Descripcion = "Media maratón llana y rapidísima.",
                DistanciaKm = 21.097
            },
            new ProximaCarrera
            {
                Nombre = "Zurich Maratón de Sevilla",
                Fecha = new DateTime(2026, 2, 22),
                Ciudad = "Sevilla",
                Comunidad = "Andalucía",
                Lugar = "Centro de Sevilla",
                Hora = "8:30",
                Enlace = "https://www.zurichmaratonsevilla.es",
                Descripcion = "Maratón rápido ideal para MMP.",
                DistanciaKm = 42.195
            },
            new ProximaCarrera
            {
                Nombre = "Media Maratón de Barcelona",
                Fecha = new DateTime(2026, 2, 8),
                Ciudad = "Barcelona",
                Comunidad = "Cataluña",
                Lugar = "Zona Fira / Diagonal",
                Hora = "8:30",
                Enlace = "https://edreamsmitjabarcelona.com",
                Descripcion = "Media maratón rápida en Barcelona.",
                DistanciaKm = 21.097
            },
            new ProximaCarrera
            {
                Nombre = "Zurich Marató Barcelona",
                Fecha = new DateTime(2026, 3, 15),
                Ciudad = "Barcelona",
                Comunidad = "Cataluña",
                Lugar = "Plaza España y centro",
                Hora = "8:30",
                Enlace = "https://www.zurichmaratobarcelona.es",
                Descripcion = "Maratón turístico por Barcelona.",
                DistanciaKm = 42.195
            },
            new ProximaCarrera
            {
                Nombre = "Movistar Medio Maratón de Madrid",
                Fecha = new DateTime(2026, 4, 12),
                Ciudad = "Madrid",
                Comunidad = "Comunidad de Madrid",
                Lugar = "Paseo de la Castellana",
                Hora = "9:00",
                Enlace = "https://www.mediomaratonmadrid.es/",
                Descripcion = "Media maratón masiva de Madrid.",
                DistanciaKm = 21.097
            },
            new ProximaCarrera
            {
                Nombre = "Rock 'n' Roll Madrid Marathon",
                Fecha = new DateTime(2026, 4, 26),
                Ciudad = "Madrid",
                Comunidad = "Comunidad de Madrid",
                Lugar = "Castellana / Cibeles / Retiro",
                Hora = "9:00",
                Enlace = "https://rocknrollmadridrun.com/",
                Descripcion = "Maratón con música y ambientazo.",
                DistanciaKm = 42.195
            },
            new ProximaCarrera
            {
                Nombre = "Media Maratón de Granada",
                Fecha = new DateTime(2026, 5, 3),
                Ciudad = "Granada",
                Comunidad = "Andalucía",
                Lugar = "Centro de Granada",
                Hora = "9:00",
                Enlace = "https://www.mediamaratondegranada.es",
                Descripcion = "Media maratón con desnivel.",
                DistanciaKm = 21.097
            },
            new ProximaCarrera
            {
                Nombre = "Behobia - San Sebastián",
                Fecha = new DateTime(2026, 11, 8),
                Ciudad = "San Sebastián",
                Comunidad = "País Vasco",
                Lugar = "Desde Behobia a Donostia",
                Hora = "10:00",
                Enlace = "https://www.behobia-sansebastian.com",
                Descripcion = "Clásica de 20 km con ambientazo.",
                DistanciaKm = 20
            },
            new ProximaCarrera
            {
                Nombre = "Maratón Valencia Trinidad Alfonso",
                Fecha = new DateTime(2025, 12, 7),
                Ciudad = "Valencia",
                Comunidad = "Comunidad Valenciana",
                Lugar = "Ciudad de las Artes",
                Hora = "8:30",
                Enlace = "https://www.maratonvalencia.com",
                Descripcion = "El maratón más rápido del mundo.",
                DistanciaKm = 42.195
            },
            new ProximaCarrera
            {
                Nombre = "Medio Maratón Valencia",
                Fecha = new DateTime(2026, 10, 18),
                Ciudad = "Valencia",
                Comunidad = "Comunidad Valenciana",
                Lugar = "Ciudad de las Artes",
                Hora = "8:30",
                Enlace = "https://www.mediamaratonvalencia.com",
                Descripcion = "Media maratón récord mundial.",
                DistanciaKm = 21.097
            },
            new ProximaCarrera
            {
                Nombre = "Maratón de Málaga",
                Fecha = new DateTime(2025, 12, 14),
                Ciudad = "Málaga",
                Comunidad = "Andalucía",
                Lugar = "Paseo marítimo",
                Hora = "8:30",
                Enlace = "https://zurichmaratonmalaga.es",
                Descripcion = "Maratón llano junto al Mediterráneo.",
                DistanciaKm = 42.195
            },
            new ProximaCarrera
            {
                Nombre = "Medio Maratón de Málaga",
                Fecha = new DateTime(2026, 3, 22),
                Ciudad = "Málaga",
                Comunidad = "Andalucía",
                Lugar = "Paseo marítimo",
                Hora = "9:00",
                Enlace = "https://www.mediamaratonmalaga.com",
                Descripcion = "Media maratón rápida por la costa.",
                DistanciaKm = 21.097
            },
            new ProximaCarrera
            {
                Nombre = "Maratón Nocturna de Bilbao",
                Fecha = new DateTime(2026, 10, 17),
                Ciudad = "Bilbao",
                Comunidad = "País Vasco",
                Lugar = "Centro de Bilbao",
                Hora = "20:00",
                Enlace = "https://www.edpmaratonbilbao.org",
                Descripcion = "Maratón nocturno espectacular.",
                DistanciaKm = 42.195
            },
            new ProximaCarrera
            {
                Nombre = "Maratón de San Sebastián",
                Fecha = new DateTime(2026, 11, 29),
                Ciudad = "San Sebastián",
                Comunidad = "País Vasco",
                Lugar = "Centro de Donostia",
                Hora = "9:00",
                Enlace = "https://www.maratondonostia.com",
                Descripcion = "Maratón costero rápido.",
                DistanciaKm = 42.195
            }
        };

        public static IReadOnlyList<ProximaCarrera> CarrerasAragon => _carrerasAragon;
        public static IReadOnlyList<ProximaCarrera> CarrerasEspana => _carrerasEspana;
    }
}
