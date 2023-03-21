/**
    Fazer um programa para ler os dados de uma reserva de hotel contendo o número do quarto, data de entrada e data de saída
    e mostrar os dados da reserva, inclusive sua duração em dias.
    Em seguida, ler os dados de entrada e saída, atualizar a reserva, e mostrar novamente a reserva com os dados atualizados.
    O programa não deve aceitar dados inválidos para a reserva, conforme as seguintes regras:
        * Alterações de reserva só podem ocorrer para datas futuras
        * A data de saída deve ser maior que a data de entrada
*/
using System;
using HotelReservation.Entities;
using HotelReservation.Entities.Exceptions;

namespace HotelReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Room Number: ");
                int roomNumber = int.Parse(Console.ReadLine());

                Console.Write("Check-in date (dd/MM/yyyy): ");
                DateTime checkIn = DateTime.Parse(Console.ReadLine());

                Console.Write("Check-out date (dd/MM/yyyy): ");
                DateTime checkOut = DateTime.Parse(Console.ReadLine());

                Reservation reservation = new Reservation(roomNumber, checkIn, checkOut);
                Console.WriteLine(reservation);

                Console.WriteLine("\nEnter data to update the reservation: ");
                Console.Write("Check-in date (dd/MM/yyyy): ");
                checkIn = DateTime.Parse(Console.ReadLine());

                Console.Write("Check-out date (dd/MM/yyyy): ");
                checkOut = DateTime.Parse(Console.ReadLine());

                reservation.UpdateDates(checkIn, checkOut);

                Console.WriteLine("Reservation: " + reservation);
                Console.ReadKey();
            }
            catch (DomainException de)
            {
                Console.WriteLine("Error in reservation: " + de.Message);
                Console.ReadKey();
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Format error: " + fe.Message);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error: " + ex.Message);
                Console.ReadKey();
            }
        }
    }
}
