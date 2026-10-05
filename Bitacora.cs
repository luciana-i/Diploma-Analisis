using System;

namespace SagradoCorazon.Dominio
{
    public class Bitacora
    {
        private DateTime fechaUTC;
        private long usuarioId;
        private string usuarioUsername;
        private string accion;
        private string mensaje;
        private string detalle;
        private string origen;
        private string host;
        private string ip;
        private string severidad;

        public DateTime GetFechaUTC() { return fechaUTC; }
        public void SetFechaUTC(DateTime fechaUTC) { }

        public long GetUsuarioId() { return usuarioId; }
        public void SetUsuarioId(long usuarioId) { }

        public string GetUsuarioUsername() { return string.Empty; }
        public void SetUsuarioUsername(string usuarioUsername) { }

        public string GetAccion() { return string.Empty; }
        public void SetAccion(string accion) { }

        public string GetMensaje() { return string.Empty; }
        public void SetMensaje(string mensaje) { }

        public string GetDetalle() { return string.Empty; }
        public void SetDetalle(string detalle) { }

        public string GetOrigen() { return string.Empty; }
        public void SetOrigen(string origen) { }

        public string GetHost() { return string.Empty; }
        public void SetHost(string host) { }

        public string GetIP() { return string.Empty; }
        public void SetIP(string ip) { }

        public string GetSeveridad() { return string.Empty; }
        public void SetSeveridad(string severidad) { }
    }

    public class BitacoraBL
    {
        public BitacoraBL() { }

        private Bitacora GenerarObjetoBitacora()
        {
            string nombreHost = Dns.GetHostName();
            string ipLocal = "127.0.0.1";
            Bitacora nuevaBitacora = new Bitacora
            {
                FechaUTC = DateTime.UtcNow,
                Usuario_ID = 0,
                Usuario_Username = string.Empty,
                Accion = string.Empty,
                Mensaje = string.Empty,
                Detalle = string.Empty,
                Origen = "SistemaTurnos",
                Host = nombreHost,
                IP = ipLocal
            };
            return nuevaBitacora;
        }
        public void IngresarBitacora(int idUsuario, string nombre, string accion, string mensaje, string detalle, SeveridadLog sev)
        {
            Bitacora bitacora = GenerarObjetoBitacora();
            bitacora.Usuario_ID = idUsuario;
            bitacora.Accion = accion;
            bitacora.Usuario_Username = nombre;
            bitacora.Mensaje = mensaje;
            bitacora.Detalle = detalle;
            bitacora.Severidad= sev;
            BitacoraDAL.Insertar(bitacora);
        }

        public List<Bitacora> ObtenerBitacora()
        {
            return BitacoraDAL.ObtenerBitacora();
        }
    }
    public class BitacoraDAL
    {
      
        public static void Insertar(Bitacora bitacora)
        {
            DAO dao = new DAO();

            string fechaFormateada = bitacora.FechaUTC.ToString("yyyy-MM-dd HH:mm:ss");
            string severidadValor = bitacora.Severidad.HasValue? ((int)bitacora.Severidad.Value).ToString(): "NULL";

            string sqlInsert = $@"
            INSERT INTO Bitacora (
                FechaUTC,
                Usuario_ID,
                Usuario_Username,
                Accion,
                Mensaje,
                Detalle,
                Origen,
                Host,
                IP,
                Severidad
            )
            VALUES (
                '{fechaFormateada}',
                {bitacora.Usuario_ID},
                N'{dao.Esc(bitacora.Usuario_Username)}',
                N'{dao.Esc(bitacora.Accion)}',
                N'{dao.Esc(bitacora.Mensaje)}',
                N'{dao.Esc(bitacora.Detalle)}',
                N'{dao.Esc(bitacora.Origen)}',
                N'{dao.Esc(bitacora.Host)}',
                N'{dao.Esc(bitacora.IP)}',
                {severidadValor}
            );";

            dao.ExecuteNonQueryFuntion(sqlInsert);
        }
        public static List<Bitacora> ObtenerBitacora()
        {
            DAO dao = new DAO();

            var lista = new List<Bitacora>();
            string sql = "SELECT * FROM dbo.Bitacora";

            // Usamos tu método del DAO base
            DataSet ds = dao.ExecuteDataSet(sql);

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var bitacora = new Bitacora
                    {
                        // Los campos que NO son null en la BD se asignan directo
                        FechaUTC = Convert.ToDateTime(row["FechaUTC"]),
                        Usuario_ID = Convert.ToInt32(row["Usuario_ID"]),

                        Usuario_Username = row["Usuario_Username"] == DBNull.Value ? null : row["Usuario_Username"].ToString(),
                        Accion = row["Accion"] == DBNull.Value ? null : row["Accion"].ToString(),
                        Mensaje = row["Mensaje"] == DBNull.Value ? null : row["Mensaje"].ToString(),
                        Detalle = row["Detalle"] == DBNull.Value ? null : row["Detalle"].ToString(),
                        Origen = row["Origen"] == DBNull.Value ? null : row["Origen"].ToString(),
                        Host = row["Host"] == DBNull.Value ? null : row["Host"].ToString(),
                        IP = row["IP"] == DBNull.Value ? null : row["IP"].ToString(),
                        Severidad = row["Severidad"] == DBNull.Value ? null : (SeveridadLog?)Convert.ToInt32(row["Severidad"])
                    };

                    lista.Add(bitacora);
                }
            }

            return lista;
        }
    }
}