﻿
// Se crean variables y se asignan valores aleatorios
Random generador = new Random();
int energía = generador.Next(60, 76); // Energía inicial entre 60 y 75
int comida = generador.Next(25, 31); // Comida inicial entre 25 y 30
int agua = generador.Next(20, 31); // Agua inicial entre 20 y 30
int botella = 1; // Botellas iniciales
int numdia = 1; // Día inicial
int probabilidadBase = 10; // Probabilidad base para eventos nocturnos

// Instrucciones del juego
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("-----INSTRUCCIONES DEL JUEGO:-----");
Console.WriteLine("Sobrevive 10 días en la isla manteniendo la energía arriba de 1.");
Console.WriteLine("Elija una actividad al día para buscar recursos y sobrevivir.");
Console.WriteLine("Al final de cada día se consumen 20 puntos de comida y 15 de agua...");
Console.WriteLine("...si no se tienen suficientes, se resta a la energía.");
Console.WriteLine("Al final de cada día pueden haber eventos nocturnos.");
Console.WriteLine("Buena suerte.");
Console.WriteLine("");

// Se muestran los recursos iniciales
Console.WriteLine("TUS RECURSOS INICIALES SON:");
Console.WriteLine("ENERGÍA: " + energía);
Console.WriteLine("COMIDA: " + comida);
Console.WriteLine("AGUA: " + agua);
Console.WriteLine("BOTELLAS: " + botella);
Console.WriteLine("");

// Bucle principal del juego: dura 10 días o hasta que se le acabe la energia
while (numdia <= 10 && energía > 0)
{
    Console.WriteLine("");
    Console.WriteLine("---- HOY ES EL DÍA " + numdia + " ----");
    Console.WriteLine("Elige una de las cuatro opciones:");
    Console.WriteLine("Buscar comida -> 1");
    Console.WriteLine("Buscar agua -> 2");
    Console.WriteLine("Descansar -> 3");
    Console.WriteLine("Explorar la isla -> 4");

    try
    {
        int eleccion = Convert.ToInt32(Console.ReadLine());

        switch (eleccion)
        {
            case 1:
            // Opción 1: Buscar comida
                Console.WriteLine("");
                Console.WriteLine("---Eligió buscar comida.---");
                energía -= generador.Next(5, 16); // Resta energía entre 5 y 15
                int probabilidad = generador.Next(1, 101);
                
                // Probabilidad de encontrar diferentes tipos de comida
                if (probabilidad <= 30)
                {
                    Console.WriteLine("Encontraste pescado, sumas 30 puntos de comida.");
                    comida += 30;
                }
                else if (probabilidad <= 80)
                {
                    Console.WriteLine("Encontraste fruta, sumas 25 puntos de comida.");
                    comida += 25;
                }
                else
                {
                    Console.WriteLine("Encontraste semillas, sumas 10 puntos de comida.");
                    comida += 10;
                }
                Console.WriteLine("");
                break;
            case 2:
            // Opción 2: Buscar agua
                Console.WriteLine("");
                Console.WriteLine("---Eligió buscar agua.---");
                energía -= generador.Next(10, 21); // Resta energía entre 10 y 20
                int probabilidad2 = generador.Next(1, 101);
                
                if (probabilidad2 <= 20)
                {
                    Console.WriteLine("Encontraste agua contaminada, pierdes 10 puntos de energía.");
                    energía -= 10;
                }
                else
                {
                    Console.WriteLine("Encontraste agua potable, sumas 20 puntos de agua por botella.");
                    agua += (20 * botella);
                }
                Console.WriteLine("");
            
                break;
            
            case 3:
            // Opción 3: Descansar
                Console.WriteLine("");
                Console.WriteLine("---Eligió descansar, sumas 20 puntos de energía.---");
                energía += 20;
                probabilidadBase += 10; // Aumenta la probabilidad de evento nocturno
                Console.WriteLine("");

                break;
            case 4:
            // Opción 4: Explorar la isla
                Console.WriteLine("");
                Console.WriteLine("---Eligió explorar la isla.---");
                int probabilidad4 = generador.Next(1, 101);
                
                // Diferentes posibles resultados al explorar
                if (probabilidad4 <= 30)
                {
                    Console.WriteLine("Encontraste animales salvajes, pierdes 10 puntos de energía");
                    energía -= 10;
                }
                else if (probabilidad4 <= 50)
                {
                    Console.WriteLine("Encontraste terrenos peligrosos, pierdes 20 puntos de energía");
                    energía -= 20;
                }
                else
                {
                    Console.WriteLine("Encontraste una botella");
                    botella++;
                }
                Console.WriteLine("");
                break;
             default:
                Console.WriteLine("Error debe ingresar opciones del 1 al 4");
                continue;
                
        }        
        
    }
    catch (System.Exception)
    {
        Console.WriteLine("Ingrese un número válido.");
    }

    // Asegura que los valores no sean negativos
    if (comida < 0) comida = 0;
    if (agua < 0) agua = 0;
    if (energía < 0) energía = 0;

    // Mostrar recursos antes del consumo diario
    Console.WriteLine("---Antes de consumir recursos:---");
    Console.WriteLine("Energía: " + energía);
    Console.WriteLine("Comida: " + comida);
    Console.WriteLine("Agua: " + agua);

    // Consumo diario de comida
    if (comida < 20)
    {
        Console.WriteLine("No tienes suficiente comida, se restará energía.");
        energía -= (20 - comida);
        comida = 0;
    }
    else
    {
        comida -= 20;
    }

    // Consumo diario de agua
    if (agua < 15)
    {
        Console.WriteLine("No tienes suficiente agua, se restará energía.");
        energía -= (15 - agua);
        agua = 0;
    }
    else
    {
        agua -= 15;
    }

    // Evento nocturno con cierta probabilidad
    int probabilidadEvento = generador.Next(1, 101);
    if (probabilidadEvento <= probabilidadBase)
    {
        int evento = generador.Next(1, 4);
        Console.WriteLine("");
        Console.WriteLine("--Ocurre un evento nocturno.--");

        if (evento == 1)
        {
            Console.WriteLine("Ha comenzado a llover, aumentas 10 puntos de agua por botella.");
            agua += (10 * botella);
        }
        else if (evento == 2)
        {
            Console.WriteLine("Han llegado animales salvajes, pierdes 10 puntos de comida.");
            comida -= 10;
        }
        else
        {
            Console.WriteLine("Hay clima frío durante la noche, pierdes 10 puntos de energía");
            energía -= 10;
        }
    }

    // Asegura que los valores no sean negativos después del evento
    if (comida < 0) comida = 0;
    if (agua < 0) agua = 0;
    if (energía < 0) energía = 0;

    // Mostrar recursos al final del día
    Console.WriteLine("");
    Console.WriteLine("---Estos son tus recursos finales del día.---");
    Console.WriteLine("ENERGÍA: " + energía);
    Console.WriteLine("COMIDA: " + comida);
    Console.WriteLine("AGUA: " + agua);
    Console.WriteLine("BOTELLAS: " + botella);
    Console.WriteLine("");

    numdia++; // Se pasa al siguiente día
}

// Final del juego
Console.WriteLine("");
if (energía > 10)
{
    Console.WriteLine("-----FELICIDADES, GANASTE EL JUEGO.-----");
}
else
{
    Console.WriteLine("-----GAME OVER.-----");
}

