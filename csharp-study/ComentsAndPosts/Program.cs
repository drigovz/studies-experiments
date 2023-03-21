using System;
using ComentsAndPosts.Entities;

namespace ComentsAndPosts
{
    class Program
    {
        static void Main(string[] args)
        {
            Comments comment1 = new Comments("Have a nice trip!");
            Comments comment2 = new Comments("Wow that's awesome!");

            Posts p1 = new Posts(DateTime.Parse("20/05/2020 20:47"), "Traveling to New Zeland", "I'm going to visit this wonderful country", 12);

            p1.AddComment(comment1);
            p1.AddComment(comment2);


            Comments comment3 = new Comments("Good night!");
            Comments comment4 = new Comments("May the force be with you!");

            Posts p2 = new Posts(DateTime.Parse("28/05/2020 22:50"), "Good night guys", "See you tumorrow", 5);

            p2.AddComment(comment3);
            p2.AddComment(comment4);

            Console.WriteLine(p1);
            Console.WriteLine(p2);

            Console.ReadKey();
        }
    }
}
