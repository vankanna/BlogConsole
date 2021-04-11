using System;
using NLog.Web;
using System.IO;
using System.Linq;


namespace BlogsConsole
{
    class Program
    // create static instance of Logger
    {    
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
    
        static void Main(string[] args)
        {
            logger.Info("Program started");

            try
            {

                // Create and save a new Blog
                Console.Write("Enter a name for a new Blog: ");
                var name = Console.ReadLine();

                var blog = new Blog { Name = name };

                var db = new BloggingContext();
                db.AddBlog(blog);
                logger.Info("Blog added - {name}", name);

                // Display all Blogs from the database
                var query = db.Blogs.OrderBy(b => b.Name);

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                // 3. Create Post - Prompt the user to select the Blog they are posting to

                // Once the Blog is selected, the Post details can be entered
                // Posts should be saved to the Posts table
                // All user errors must be handled





                // 4. select the Blog whose posts they want to view

                // Once the Blog is selected, all Posts related to the selected blog should be display as well as the number of Posts

                // Display Posts, display the Blog name, Post title and Post content
                var query1 = db.Posts.OrderBy(b => b.PostId);

                Console.WriteLine("All Posts in this Blog:"); // certain blog name
                foreach (var item in query1)
                {
                    Console.WriteLine(item.Title);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

            logger.Info("Program ended");
        
        }
    }
}
