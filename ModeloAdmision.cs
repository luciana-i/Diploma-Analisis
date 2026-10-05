using System;

namespace SagradoCorazon.Admision
{
    // ==========================================
    // UI Layer
    // ==========================================
    public class AdmisionForm
    {
        public void IngresarDni(string dni) { }
        public void MostrarDatosPaciente(Paciente paciente) { }
        public void MostrarFormularioNuevoPaciente() { }
        public void ConfirmarAltaPaciente(string nombre, string apellido, DateTime fechaNac, string tel) { }
        public void ConfirmarIngreso(string motivo) { }
        public void MostrarConfirmacion(long idEpisodio) { }
        public void MostrarError(string mensaje) { }
    }

    // ==========================================
    // BLL Layer
    // ==========================================
    public class AdmisionService
    {
        private PacienteDAO pacienteDAO;
        private EpisodioDAO episodioDAO;

        public Paciente BuscarPacientePorDni(string dni) { return null; }
        public Paciente RegistrarNuevoPaciente(string dni, string nombre, string apellido, DateTime fechaNac, string tel) { return null; }
        public Episodio AbrirEpisodio(long idPaciente, long idRecepcionista, string motivo) { return null; }
    }

    // ==========================================
    // BE / Domain Layer
    // ==========================================
    public abstract class Persona
    {
        protected long idPersona;
        protected string dni;
        protected string nombre;
        protected string apellido;
        protected string telefono;

        public string GetNombreCompleto() { return string.Empty; }
        public string GetDni() { return string.Empty; }
    }

    public class Paciente : Persona
    {
        private DateTime fechaNacimiento;

        public int CalcularEdad() { return 0; }
    }

    public class Recepcionista : Persona
    {
        private string legajo;

        public string GetLegajo() { return string.Empty; }
    }

    public class Episodio
    {
        private long idEpisodio;
        private DateTime fechaHoraIngreso;
        private string motivoConsulta;
        private string estado;

        public long GetIdEpisodio() { return 0; }
        public string GetEstado() { return string.Empty; }
        public void CambiarEstado(string nuevoEstado) { }
    }

    // ==========================================
    // DAL Layer
    // ==========================================
    public class PacienteDAO
    {
        public Paciente GetByDni(string dni) { return null; }
        public long Insert(Paciente paciente) { return 0; }
        public bool ExistsByDni(string dni) { return false; }
    }

    public class EpisodioDAO
    {
        public long Insert(Episodio episodio) { return 0; }
        public Episodio GetEpisodioActivoByPaciente(long idPaciente) { return null; }
    }
}