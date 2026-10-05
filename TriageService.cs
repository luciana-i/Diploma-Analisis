using System;

namespace HospitalManagement
{
    // =========================================================================
    // 1. BE - BUSINESS ENTITIES (Capa de Entidades de Negocio)
    // =========================================================================
    namespace BE
    {
        public enum NivelPrioridad
        {
            Nivel1_Rojo = 1,
            Nivel2_Naranja = 2,
            Nivel3_Amarillo = 3,
            Nivel4_Verde = 4,
            Nivel5_Azul = 5
        }

        public enum EstadoEpisodio
        {
            EsperaTriage = 1,
            PendienteAtencionMedica = 2,
            EnAtencion = 3,
            Finalizado = 4
        }

        
        public class ConsultaTriage
        {
            private int _id;
            private Episodio _episodio;
            private Enfermero _enfermero;
            private DateTime _fechaHora;
            private int _frecuenciaCardiaca;
            private double _temperatura;
            private int _saturacionOxigeno;
            private string _presionArterial;
            private string _motivoConsulta;
            private NivelPrioridad _prioridadSugerida;
            private NivelPrioridad _prioridadFinal;
            private string _justificacionCambio;

            public int Id
            {
                get { return _id; }
                set { _id = value; }
            }

            public Episodio episodio
            {
                get { return _episodio; }
                set { _episodio = value; }
            }

            public Enfermero enfermero
            {
                get { return enfermero; }
                set { _enfermero = value; }
            }

            public DateTime FechaHora
            {
                get { return _fechaHora; }
                set { _fechaHora = value; }
            }

            public int FrecuenciaCardiaca
            {
                get { return _frecuenciaCardiaca; }
                set { _frecuenciaCardiaca = value; }
            }

            public double Temperatura
            {
                get { return _temperatura; }
                set { _temperatura = value; }
            }

            public int SaturacionOxigeno
            {
                get { return _saturacionOxigeno; }
                set { _saturacionOxigeno = value; }
            }

            public string PresionArterial
            {
                get { return _presionArterial; }
                set { _presionArterial = value; }
            }

            public string MotivoConsulta
            {
                get { return _motivoConsulta; }
                set { _motivoConsulta = value; }
            }

            public NivelPrioridad PrioridadSugerida
            {
                get { return _prioridadSugerida; }
                set { _prioridadSugerida = value; }
            }

            public NivelPrioridad PrioridadFinal
            {
                get { return _prioridadFinal; }
                set { _prioridadFinal = value; }
            }

            public ConsultaTriage() { }
        }

        public class Episodio
        {
            private int _id;
            private DateTime _fechaIngreso;
            private EstadoEpisodio _estado;
            private Paciente _paciente;
            private ConsultaTriage _consultaTriage;

            public int Id
            {
                get { return _id; }
                set { _id = value; }
            }

            public DateTime FechaIngreso
            {
                get { return _fechaIngreso; }
                set { _fechaIngreso = value; }
            }

            public EstadoEpisodio Estado
            {
                get { return _estado; }
                set { _estado = value; }
            }

            public BE_Paciente Paciente
            {
                get { return _paciente; }
                set { _paciente = value; }
            }

            public BE_ConsultaTriage ConsultaTriage
            {
                get { return _consultaTriage; }
                set { _consultaTriage = value; }
            }

            public Episodio() { }
        }
    }

    // =========================================================================
    // 2. DAL - DATA ACCESS LAYER (Capa de Acceso a Datos)
    // =========================================================================
    namespace DAL
    {
        using BE;

        public class ConsultaTriageDAL
        {
            public void Insertar(ConsultaTriage triage)
            {
                // Firma para ingeniería inversa en EA
            }

            public ConsultaTriageDAL() { }
        }

        public class EpisodioDAL
        {
            public Episodio ObtenerPorId(int id)
            {
                // Firma para ingeniería inversa en EA
                return new Episodio();
            }

            public void ActualizarEstado(int episodioId, EstadoEpisodio nuevoEstado)
            {
                // Firma para ingeniería inversa en EA
            }

            public EpisodioDAL() { }
        }
    }

    // =========================================================================
    // 3. BLL - BUSINESS LOGIC LAYER (Capa de Lógica de Negocio)
    // =========================================================================
    namespace BLL
    {
        using BE;
        using DAL;

        public class TriageService
        {
            private ConsultaTriageDAL _triageDal;
            private EpisodioDAL _episodioDAL;

            public TriageService()
            {
                _triageDal = new ConsultaTriageDAL();
                _episodioDAL = new EpisodioDAL();
            }

            public NivelPrioridad CalcularPrioridadSugerida(int fc, double temp, int satO2, bool esTramiteAdmin)
            {
                // Firma para ingeniería inversa en EA
                return NivelPrioridad.Nivel4_Verde;
            }

            public void RegistrarTriage(ConsultaTriage triage, bool esTramiteAdmin)
            {
                // Firma para ingeniería inversa en EA
            }
        }
    }

    // =========================================================================
    // 4. UI - USER INTERFACE / PRESENTATION (Capa de Presentación)
    // =========================================================================
    namespace UI
    {
        using BE;
        using BLL;

        public class ConsultaTriageForm
        {
            private TriageService _triageService;
            private Episodio _episodio;
            private Enfermero enfermero;
            private NivelPrioridad _prioridadSugerida;

            public FormConsultaTriage(Episodio _episodio, Enfermero enfermero)
            {
                _triageService = new TriageService();
                _episodio = _episodio;
                enfermero = enfermero;
            }

            public void btnCalcular_Click(object sender, EventArgs e)
            {
                // Event handler UI
            }

            public void btnGuardar_Click(object sender, EventArgs e)
            {
                // Event handler UI
            }

            public void btnCancelar_Click(object sender, EventArgs e)
            {
                // Event handler UI
            }
        }
    }
}
```<ElicitationsGroup message="Para continuar con la documentación de CU03:">
  <Elicitation label="Modelar punto l: Diagrama de Secuencia con estas firmas" query="Diseña el punto l. Diagrama de Secuencia detallando la invocación de métodos entre FormConsultaTriage, BLL_TriageService, DAL_ConsultaTriage y DAL_Episodio."/>
  <Elicitation label="Modelar punto m: DER correspondiente a estas entidades" query="Diseña el punto m. DER indicando las tablas, columnas, claves primarias y foráneas de Paciente, Episodio y ConsultaTriage."/>
</ElicitationsGroup>