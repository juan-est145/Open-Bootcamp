using EjemploFlujoAsync;
using System.Diagnostics;
using System.Runtime;

//Iniciamos un contador de tiempo - Síncrona
Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

Console.WriteLine("\n****************************************************");
Console.WriteLine("\nBienvenido a la Calculadora de Hipotecas Síncrona");
Console.WriteLine("\n****************************************************");

var añosVidaLaboral = CalculadoraHipotecaSync.ObtenerAñosVidaLaboral();
Console.WriteLine($"Años de Vida Laboral Obtenidos: {añosVidaLaboral}");

var esTipoContratoIndefinido = CalculadoraHipotecaSync.EsTipoContratoIndefinido();
Console.WriteLine($"\nTipo de contrato indefinido: {esTipoContratoIndefinido}");

var sueldoNeto = CalculadoraHipotecaSync.ObtenerSueldoNeto();
Console.WriteLine($"\nSueldo neto obtenido: {sueldoNeto} euros");

var gastosMensuales = CalculadoraHipotecaSync.ObtenerGastosMensuales();
Console.WriteLine($"\nGastos mensuales obtenidos: {gastosMensuales}");

var hipotecaConcencida = CalculadoraHipotecaSync.AnalizarInformacionParaConcederHipoteca(añosVidaLaboral, esTipoContratoIndefinido, sueldoNeto, gastosMensuales, cantidadSolicitada: 50000, añosAPagar: 30);

var resultado = hipotecaConcencida ? "Aprobada" : "Denegada";

Console.WriteLine($"\nAnálisis finalizado. Su solicitud de hipoteca ha sido {resultado}");

stopwatch.Stop();

Console.WriteLine($"\nLa operación síncrona ha durado: {stopwatch.Elapsed}");

//Reiniciamos un contador de tiempo -ASÍNCRONA
stopwatch.Restart();
Console.WriteLine("\n****************************************************");
Console.WriteLine("\nBienvenido a la Calculadora de Hipotecas Asíncrona");
Console.WriteLine("\n****************************************************");

Task<int> añosVidaLaboralTask = CalculadoraHipotecaAsync.ObtenerAñosVidaLaboral();

Task<bool> esTipoContratoIndefinidoTask = CalculadoraHipotecaAsync.EsTipoContratoIndefinido();

Task<int> sueldoNetoTask = CalculadoraHipotecaAsync.ObtenerSueldoNeto();

Task<int> gastosMensualesTask = CalculadoraHipotecaAsync.ObtenerGastosMensuales();


var analisisHipotecaTasks = new List<Task>
{
    añosVidaLaboralTask,
    esTipoContratoIndefinidoTask,
    sueldoNetoTask,
    gastosMensualesTask
};

while(analisisHipotecaTasks.Any())
{
    Task tareaFinalizada = await Task.WhenAny(analisisHipotecaTasks);

    if(tareaFinalizada == añosVidaLaboralTask)
    {
        Console.WriteLine($"Años de Vida Laboral Obtenidos: {añosVidaLaboralTask.Result}");
    }
    else if(tareaFinalizada == esTipoContratoIndefinidoTask)
    {
        Console.WriteLine($"\nTipo de contrato indefinido: {esTipoContratoIndefinidoTask.Result}");
    }
    else if(tareaFinalizada == sueldoNetoTask)
    {
        Console.WriteLine($"\nSueldo neto obtenido: {sueldoNetoTask.Result} euros");
    }
    else if(tareaFinalizada == gastosMensualesTask)
    {
        Console.WriteLine($"\nGastos mensuales obtenidos: {gastosMensualesTask.Result}");
    }

    analisisHipotecaTasks.Remove(tareaFinalizada); //eliminamos de la lista de tareas para ir vaciando y salir del While.
}

var hipotecaAsyncConcencida = CalculadoraHipotecaAsync.AnalizarInformacionParaConcederHipoteca(añosVidaLaboralTask.Result, esTipoContratoIndefinidoTask.Result, sueldoNetoTask.Result, gastosMensualesTask.Result, cantidadSolicitada: 50000, añosAPagar: 30);

var resultadoAsync = hipotecaAsyncConcencida ? "Aprobada" : "Denegada";


Console.WriteLine($"\nAnálisis finalizado. Su solicitud de hipoteca ha sido {resultadoAsync}");

stopwatch.Stop();

Console.WriteLine($"\nLa operación asíncrona ha durado: {stopwatch.Elapsed}");