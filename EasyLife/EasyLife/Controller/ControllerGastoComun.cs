using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Controller
{
    public class ControllerGastoComun
    {
        public static string crearGastoComun(long edificio, int conserje, int guardia, int mantAreas, int camaras, int artAseo, int aseo, int ascensor,
            int agua, int otro, int total)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.insertGasto(edificio, conserje, guardia, mantAreas, camaras, artAseo, aseo, ascensor, agua, otro, total);
                return "Gasto Comun Creado";
            }
        }

        public static string modficarGastoComun(long gasto, long edificio, int conserje, int guardia, int mantAreas, int camaras, int artAseo, int aseo, int ascensor,
            int agua, int otro, int total)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.updateGasto(gasto, conserje, guardia, mantAreas, camaras, artAseo, aseo, ascensor, agua, otro, total);
                return "Gasto Comun Modificado";
            }
        }

        public static GASTOS_COMUNES buscarIdGastoComun(long gasto)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                GASTOS_COMUNES aux = (from u in dbc.GASTOS_COMUNES
                                      where u.ID_GASTOS == gasto
                                      select u).FirstOrDefault();
                if (aux != null)
                {
                    return aux;
                }
                else
                {
                    return null;
                }
            }
        }

        public static GASTOS_COMUNES buscarGastoComunEdificio(long edificio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                GASTOS_COMUNES aux = (from u in dbc.GASTOS_COMUNES
                                      where u.ID_EDIFICIO == edificio
                                      select u).FirstOrDefault();
                if (aux != null)
                {
                    return aux;
                }
                else
                {
                    return null;
                }
            }
        }

        public static Adapter.AdapterGastoComun buscarAdapterGastoComunEdificio(long edificio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.GASTOS_COMUNES
                            from e in dbc.EDIFICIO
                            where e.ID_EDIFICIO == edificio && u.ID_EDIFICIO == edificio &&
                            u.ID_EDIFICIO == e.ID_EDIFICIO
                            select new Adapter.AdapterGastoComun()
                            {
                                _ID_GASTOS = u.ID_GASTOS,
                                _NOMBRE_EDIFICIO = e.NOMBRE_EDIFICIO,
                                _GASTO_CONSERJE = u.GASTO_CONSERJE,
                                _GASTO_GUARDIA = u.GASTO_GUARDIA,
                                _GASTO_MANTENCION_AREAS = u.GASTO_MANTENCION_AREAS,
                                _GASTO_CAMARAS = u.GASTO_CAMARAS,
                                _GASTO_ARTICULOS_ASEO = u.GASTO_ARTICULOS_ASEO,
                                _GASTOS_ASEO = u.GASTOS_ASEO,
                                _GASTO_ASCENSOR = u.GASTO_ASCENSOR,
                                _GASTO_AGUA_CALIENTE = u.GASTO_AGUA_CALIENTE,
                                _GASTO_OTRO = u.GASTO_OTRO,
                                _MES = u.FECHA_REGISTRO_GASTO.Substring(3, 3),
                                _ANO = u.FECHA_REGISTRO_GASTO.Substring(7, 4),
                                _TOTAL_GASTO = u.TOTAL_GASTO
                            };
                if (query != null)
                {
                    return query.FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }
        }

        public static List<Adapter.AdapterGastoComun> listaGastos()
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.GASTOS_COMUNES
                            from e in dbc.EDIFICIO
                            where u.ID_EDIFICIO == e.ID_EDIFICIO
                            select new Adapter.AdapterGastoComun()
                            {
                                _ID_GASTOS = u.ID_GASTOS,
                                _NOMBRE_EDIFICIO = e.NOMBRE_EDIFICIO,
                                _GASTO_CONSERJE = u.GASTO_CONSERJE,
                                _GASTO_GUARDIA = u.GASTO_GUARDIA,
                                _GASTO_MANTENCION_AREAS = u.GASTO_MANTENCION_AREAS,
                                _GASTO_CAMARAS = u.GASTO_CAMARAS,
                                _GASTO_ARTICULOS_ASEO = u.GASTO_ARTICULOS_ASEO,
                                _GASTOS_ASEO = u.GASTOS_ASEO,
                                _GASTO_ASCENSOR = u.GASTO_ASCENSOR,
                                _GASTO_AGUA_CALIENTE = u.GASTO_AGUA_CALIENTE,
                                _GASTO_OTRO = u.GASTO_OTRO,
                                _TOTAL_GASTO = u.TOTAL_GASTO
                            };
                if (query != null)
                {
                    return query.ToList();
                }
                else
                {
                    return null;
                }
            }
        }

        public static List<Adapter.AdapterGastoComun> searchGastoComun(string parametro)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.GASTOS_COMUNES
                            from e in dbc.EDIFICIO
                            where u.ID_EDIFICIO == e.ID_EDIFICIO &&
                            (e.NOMBRE_EDIFICIO.Contains(parametro))
                            select new Adapter.AdapterGastoComun()
                            {
                                _ID_GASTOS = u.ID_GASTOS,
                                _NOMBRE_EDIFICIO = e.NOMBRE_EDIFICIO,
                                _GASTO_CONSERJE = u.GASTO_CONSERJE,
                                _GASTO_GUARDIA = u.GASTO_GUARDIA,
                                _GASTO_MANTENCION_AREAS = u.GASTO_MANTENCION_AREAS,
                                _GASTO_CAMARAS = u.GASTO_CAMARAS,
                                _GASTO_ARTICULOS_ASEO = u.GASTO_ARTICULOS_ASEO,
                                _GASTOS_ASEO = u.GASTOS_ASEO,
                                _GASTO_ASCENSOR = u.GASTO_ASCENSOR,
                                _GASTO_AGUA_CALIENTE = u.GASTO_AGUA_CALIENTE,
                                _GASTO_OTRO = u.GASTO_OTRO,
                                _TOTAL_GASTO = u.TOTAL_GASTO
                            };
                if (query != null)
                {
                    return query.ToList();
                }
                else
                {
                    return null;
                }
            }
        }

        public static List<Adapter.AdapterGastoComun> listaGastoCondominio(long condominio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.GASTOS_COMUNES
                            from e in dbc.EDIFICIO
                            where u.ID_EDIFICIO == e.ID_EDIFICIO && e.ID_CONDOMINIO == condominio
                            select new Adapter.AdapterGastoComun()
                            {
                                _ID_GASTOS = u.ID_GASTOS,
                                _NOMBRE_EDIFICIO = e.NOMBRE_EDIFICIO,
                                _GASTO_CONSERJE = u.GASTO_CONSERJE,
                                _GASTO_GUARDIA = u.GASTO_GUARDIA,
                                _GASTO_MANTENCION_AREAS = u.GASTO_MANTENCION_AREAS,
                                _GASTO_CAMARAS = u.GASTO_CAMARAS,
                                _GASTO_ARTICULOS_ASEO = u.GASTO_ARTICULOS_ASEO,
                                _GASTOS_ASEO = u.GASTOS_ASEO,
                                _GASTO_ASCENSOR = u.GASTO_ASCENSOR,
                                _GASTO_AGUA_CALIENTE = u.GASTO_AGUA_CALIENTE,
                                _GASTO_OTRO = u.GASTO_OTRO,
                                _TOTAL_GASTO = u.TOTAL_GASTO
                            };
                if (query != null)
                {
                    return query.ToList();
                }
                else
                {
                    return null;
                }
            }
        }

        public static List<Adapter.AdapterBoletaGasto> listaGastosBoleta(long persona)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.BOLETA_GASTO
                            from b in dbc.BOLETA
                            from g in dbc.GASTOS_COMUNES
                            from e in dbc.EDIFICIO
                            from d in dbc.DEPARTAMENTO
                            from p in dbc.PERSONA
                            where u.ID_BOLETA == b.ID_BOLETA && u.ID_GASTOS == g.ID_GASTOS && b.ID_PERSONA == p.ID_PERSONA && d.ID_PERSONA == p.ID_PERSONA &&
                            p.ID_PERSONA == persona && d.ID_EDIFICIO == e.ID_EDIFICIO && e.ID_GASTOS == g.ID_GASTOS && g.ID_EDIFICIO == e.ID_EDIFICIO &&
                            b.DEP == d.ID_DEPARTAMENTO
                            select new Adapter.AdapterBoletaGasto()
                            {
                                _ID_BOLETA = b.ID_BOLETA,
                                _ID_GASTOS = g.ID_GASTOS,
                                _ID_DEPARTAMENTO = d.ID_DEPARTAMENTO,
                                _ID_EDIFICIO = e.ID_EDIFICIO,
                                _FK_RUT = p.FK_RUT,
                                _NOMBRE_EDIFICIO = e.NOMBRE_EDIFICIO,
                                _NUMERO_DEP = d.NUMERO_DEP,
                                _TOTAL_GASTO = g.TOTAL_GASTO,
                                _COSTO_BOLETA = b.COSTO_BOLETA,
                                _MES = u.MES,
                                _AÑO = u.ANO
                            };
                if (query != null)
                {
                    return query.ToList();
                }
                else
                {
                    return null;
                }
            }
        }

        public static List<Adapter.AdapterBoletaGasto> listaGastosBoletaEdificio(long edificio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.BOLETA_GASTO
                            from b in dbc.BOLETA
                            from g in dbc.GASTOS_COMUNES
                            from e in dbc.EDIFICIO
                            from d in dbc.DEPARTAMENTO
                            from p in dbc.PERSONA
                            where u.ID_BOLETA == b.ID_BOLETA && u.ID_GASTOS == g.ID_GASTOS && b.ID_PERSONA == p.ID_PERSONA && d.ID_PERSONA == p.ID_PERSONA &&
                            d.ID_EDIFICIO == e.ID_EDIFICIO && e.ID_GASTOS == g.ID_GASTOS && g.ID_EDIFICIO == e.ID_EDIFICIO &&
                            b.DEP == d.ID_DEPARTAMENTO && e.ID_EDIFICIO == edificio
                            select new Adapter.AdapterBoletaGasto()
                            {
                                _ID_BOLETA = b.ID_BOLETA,
                                _ID_GASTOS = g.ID_GASTOS,
                                _ID_DEPARTAMENTO = d.ID_DEPARTAMENTO,
                                _ID_EDIFICIO = e.ID_EDIFICIO,
                                _FK_RUT = p.FK_RUT,
                                _NOMBRE_EDIFICIO = e.NOMBRE_EDIFICIO,
                                _NUMERO_DEP = d.NUMERO_DEP,
                                _TOTAL_GASTO = g.TOTAL_GASTO,
                                _COSTO_BOLETA = b.COSTO_BOLETA,
                                _MES = u.MES,
                                _AÑO = u.ANO
                            };
                if (query != null)
                {
                    return query.ToList();
                }
                else
                {
                    return null;
                }
            }
        }

        public static List<Adapter.AdapterBoletaGasto> listaSearchGastosBoletaEdificio(long edificio, string parametro)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.BOLETA_GASTO
                            from b in dbc.BOLETA
                            from g in dbc.GASTOS_COMUNES
                            from e in dbc.EDIFICIO
                            from d in dbc.DEPARTAMENTO
                            from p in dbc.PERSONA
                            where u.ID_BOLETA == b.ID_BOLETA && u.ID_GASTOS == g.ID_GASTOS && b.ID_PERSONA == p.ID_PERSONA && d.ID_PERSONA == p.ID_PERSONA &&
                            d.ID_EDIFICIO == e.ID_EDIFICIO && e.ID_GASTOS == g.ID_GASTOS && g.ID_EDIFICIO == e.ID_EDIFICIO &&
                            b.DEP == d.ID_DEPARTAMENTO && e.ID_EDIFICIO == edificio &&
                            (p.FK_RUT.Contains(parametro) || e.NOMBRE_EDIFICIO.Contains(parametro) || d.NUMERO_DEP.Contains(parametro))
                            select new Adapter.AdapterBoletaGasto()
                            {
                                _ID_BOLETA = b.ID_BOLETA,
                                _ID_GASTOS = g.ID_GASTOS,
                                _ID_DEPARTAMENTO = d.ID_DEPARTAMENTO,
                                _ID_EDIFICIO = e.ID_EDIFICIO,
                                _FK_RUT = p.FK_RUT,
                                _NOMBRE_EDIFICIO = e.NOMBRE_EDIFICIO,
                                _NUMERO_DEP = d.NUMERO_DEP,
                                _TOTAL_GASTO = g.TOTAL_GASTO,
                                _COSTO_BOLETA = b.COSTO_BOLETA,
                                _MES = u.MES,
                                _AÑO = u.ANO
                            };
                if (query != null)
                {
                    return query.ToList();
                }
                else
                {
                    return null;
                }
            }
        }

        public static List<BOLETA_GASTO> listaAños()
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = (from u in dbc.BOLETA_GASTO
                             select u).ToList();
                if (query != null)
                {
                    var lista = query.GroupBy(x => x.ANO).Select(y => y.FirstOrDefault());
                    return lista.ToList();
                }
                else
                {
                    return null;
                }
            }
        }
    }
}