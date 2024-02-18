using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploFlujoAsync
{
    public static class CalculadoraHipotecaAsync
    {
        public static async Task<int> ObtenerAñosVidaLaboral()
        {
            Console.WriteLine("\nObteniendo años de vida laboral...");
            await Task.Delay(5000); //Esperamos cinco segundos
            return new Random().Next(1, 35); //Devolvemos un valor aleatorio entre 1 y 35
        }

        public static async Task<bool> EsTipoContratoIndefinido()
        {
            Console.WriteLine("\nVerificando si el tipo de contrato es indefinido");
            await Task.Delay(5000);
            return new Random().Next(1, 10) % 2 == 0; //Devolvemos true o false si el valor aleatorio es par/impar
        }

        public static async Task <int> ObtenerSueldoNeto()
        {
            Console.WriteLine("\nObteniendo sueldo neto...");
            await Task.Delay(5000); //Esperamos cinco segundos
            return new Random().Next(800, 6000); //Devolvemos un valor aleatorio entre 800 y 6000
        }

        public static async Task <int> ObtenerGastosMensuales()
        {
            Console.WriteLine("\nObteniendo gastos mensuales del usuario...");
            await Task.Delay(5000); //Esperamos cinco segundos
            return new Random().Next(200, 1000); //Devolvemos un valor aleatorio entre 200 y 1000
        }

        public static bool AnalizarInformacionParaConcederHipoteca(int añosVidaLaboral, bool tipoContratoEsIndefinido, int SueldoNeto, int gastosMensuales, int cantidadSolicitada, int añosAPagar)
        {
            Console.WriteLine("\nAnalizando información para conceder hipoteca...");
            if (añosVidaLaboral < 2)
            {
                return false;
            }

            //Obtener la cuota
            var cuota = (cantidadSolicitada / añosAPagar) / 12;

            if ((cuota >= SueldoNeto) || cuota > (SueldoNeto / 2))
            {
                return false;
            }

            //Obtener porcentaje de Gastos sobre el sueldo neto del usuario
            var porecentajeGastosSobreSueldo = ((gastosMensuales * 100)) / SueldoNeto;
            if (porecentajeGastosSobreSueldo > 30)
            {
                return false;
            }

            if ((cuota + gastosMensuales) >= SueldoNeto)
            {
                return false;
            }

            if (!tipoContratoEsIndefinido)
            {
                if ((cuota + gastosMensuales) > (SueldoNeto / 3))
                {
                    return false;
                }

                else
                {
                    return true;
                }
            }

            //Si no entra en ninguna de las condiciones, sí que la concedemos
            return true;
        }
    }
}
