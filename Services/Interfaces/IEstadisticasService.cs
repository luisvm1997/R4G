using System;
using System.Collections.Generic;
using R4G.App.Models;

namespace R4G.App.Services.Interfaces
{
    public interface IEstadisticasService
    {
        double DistanciaTotal(List<Entrenamiento> entrenos);
        TimeSpan TiempoTotal(List<Entrenamiento> entrenos);
        string RitmoMedioGlobal(List<Entrenamiento> entrenos);
        double VelocidadMediaGlobal(List<Entrenamiento> entrenos);
        Entrenamiento? UltimoEntrenamiento(List<Entrenamiento> entrenos);
        string MejorMarca(List<Entrenamiento> entrenos, double distanciaObjetivo);
        Dictionary<string, double> KmsPorMes(List<Entrenamiento> entrenos);
        double KmsDelMesActual(List<Entrenamiento> entrenos);
        double KmsDeLaSemanaActual(List<Entrenamiento> entrenos);
    }
}
