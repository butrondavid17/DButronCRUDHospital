using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Hospital
    {
        public static Dictionary<string, object> Add(ML.Hospital hospital)
        {
            string excepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Excepcion", excepcion }, { "Resultado", false } };
            try
            {
                using (DL.DbutronHospitalContext context = new DL.DbutronHospitalContext())
                {
                    int filasAfectadas = context.Database.ExecuteSqlRaw($"HospitalAdd '{hospital.Nombre}', '{hospital.Direccion}', '{hospital.AnioConstruccion}', {hospital.Capacidad}, {hospital.Especialidad.IdEspecialidad}");
                    if (filasAfectadas > 0)
                    {
                        diccionario["Resultado"] = true;
                    }
                    else
                    {
                        diccionario["Resultado"] = false;
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }
            return diccionario;
        }
        public static Dictionary<string, object> GetAll()
        {
            ML.Hospital hospital = new ML.Hospital();
            string excepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Hospital", hospital }, { "Excepcion", excepcion }, { "Resultado", false } };
            try
            {
                using (DL.DbutronHospitalContext context = new DL.DbutronHospitalContext())
                {
                    var listaUsuarios = (from tableHospital in context.Hospitals
                                         join tableEspecialidad in context.Especialidads on tableHospital.IdEspecialidad equals tableEspecialidad.IdEspecialidad
                                         select new
                                         {
                                             IdHospital = tableHospital.IdHospital,
                                             Nombre = tableHospital.Nombre,
                                             Direccion = tableHospital.Direccion,
                                             AnioConstruccion = tableHospital.AnioConstruccion,
                                             Capacidad = tableHospital.Capacidad,
                                             IdEspecialidad = tableEspecialidad.IdEspecialidad,
                                             TipoEspecialidad = tableEspecialidad.Nombre
                                         }).ToList();
                    if (listaUsuarios.Count > 0)
                    {
                        hospital.Hospitales = new List<object>();
                        foreach (var registro in listaUsuarios)
                        {
                            ML.Hospital centroMedico = new ML.Hospital();
                            centroMedico.IdHospital = registro.IdHospital;
                            centroMedico.Nombre = registro.Nombre;
                            centroMedico.Direccion = registro.Direccion;
                            centroMedico.AnioConstruccion = registro.AnioConstruccion;
                            centroMedico.Capacidad = registro.Capacidad;
                            centroMedico.Especialidad = new ML.Especialidad();
                            centroMedico.Especialidad.IdEspecialidad = registro.IdEspecialidad;
                            centroMedico.Especialidad.Nombre = registro.TipoEspecialidad;
                            hospital.Hospitales.Add(centroMedico);
                        }
                        diccionario["Resultado"] = true;
                        diccionario["Hospital"] = hospital;
                    }
                    else
                    {
                        diccionario["Resultado"] = false;
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }
            return diccionario;
        }
        public static Dictionary<string, object> GetById(int IdHospital)
        {
            ML.Hospital hospital = new ML.Hospital();
            string excepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Hospital", hospital }, { "Excepcion", excepcion }, { "Resultado", false } };
            try
            {
                using (DL.DbutronHospitalContext context = new DL.DbutronHospitalContext())
                {
                    var objHospital = (from tableHospital in context.Hospitals
                                       join tableEspecialidad in context.Especialidads on tableHospital.IdEspecialidad equals tableEspecialidad.IdEspecialidad
                                       where tableHospital.IdHospital == IdHospital
                                       select new
                                       {
                                           IdHospital = tableHospital.IdHospital,
                                           Nombre = tableHospital.Nombre,
                                           Direccion = tableHospital.Direccion,
                                           AnioConstruccion = tableHospital.AnioConstruccion,
                                           Capacidad = tableHospital.Capacidad,
                                           IdEspecialidad = tableEspecialidad.IdEspecialidad,
                                           TipoEspecialidad = tableEspecialidad.Nombre
                                       }).FirstOrDefault();
                    if (objHospital != null)
                    {
                        hospital.IdHospital = objHospital.IdHospital;
                        hospital.Nombre = objHospital.Nombre;
                        hospital.Direccion = objHospital.Direccion;
                        hospital.AnioConstruccion = objHospital.AnioConstruccion;
                        hospital.Capacidad = objHospital.Capacidad;
                        hospital.Especialidad = new ML.Especialidad();
                        hospital.Especialidad.IdEspecialidad = objHospital.IdEspecialidad;
                        hospital.Especialidad.Nombre = objHospital.TipoEspecialidad;
                        diccionario["Resultado"] = true;
                        diccionario["Hospital"] = hospital;
                    }
                    else
                    {
                        diccionario["Resultado"] = false;
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }
            return diccionario;
        }
        public static Dictionary<string, object> Delete(int IdHospital)
        {
            string excepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Resultado", false }, { "Excepcion", excepcion } };
            try
            {
                using (DL.DbutronHospitalContext context = new DL.DbutronHospitalContext())
                {
                    int filasAfectadas = context.Database.ExecuteSql($"HospitalDelete {IdHospital}");
                    if (filasAfectadas > 0)
                    {
                        diccionario["Resultado"] = true;
                    }
                    else
                    {
                        diccionario["Resultado"] = false;
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Execepcion"] = ex.Message;
            }
            return diccionario;
        }
        public static Dictionary<string, object> Update(ML.Hospital hospital)
        {
            string excepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Excepcion", excepcion}, {"Resultado", false} };
            try
            {
                using (DL.ConnectionDB.GetConnection())
                {

                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }
            return diccionario;
        }
    }
}