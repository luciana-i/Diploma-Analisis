using System;
using System.Collections.Generic;

namespace SagradoCorazon.Admision
{
    // ==========================================
    // UI Layer
    // ==========================================
    public class GestionEpisodioForm
    {
        public void CargarEpisodiosActivos() { }
        public void SeleccionarEpisodio(long idEpisodio) { }
        public void SolicitarConfirmacionAbandono() { }
        public void ConfirmarAbandono(long idEpisodio, string motivo) { }
        public void CancelarOperacion() { }
        public void MostrarConfirmacion(string mensaje) { }
        public void MostrarError(string mensaje) { }
    }

    // ==========================================
    // BLL Layer
    // ==========================================
    public class EpisodioBLL
    {
        private EpisodioDAL episodioDAL;

        public List<Episodio> ObtenerEpisodiosActivos() { return null; }
        public bool ValidarEstadoParaAbandono(long idEpisodio) { return false; }
        public bool RegistrarAbandono(long idEpisodio, string motivo, long idUsuario) { return false; }
    }

    // ==========================================
    // BE / Domain Layer
    // ==========================================
   
    public class Usuario : Persona
    {
        private string legajo;
        private string rol;

        public string GetLegajo() { return string.Empty; }
        public string GetRol() { return string.Empty; }
    }


}