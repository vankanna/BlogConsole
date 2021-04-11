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
    

        static string mainMenu() {
            Console.Write("Please Choose a Menu Item.");
            Console.Write(" - 1) Display all blogs");
            Console.Write(" - 2) Add Blog");
            Console.Write(" - 3) Create Post");
            Console.Write(" - 4) Display Posts");
            Console.Write(" - 0) Exit Application");

            return Console.ReadLine();
        }

        static Blog createBlogWorkflow() {
            Console.Write("Enter a name for a new Blog: ");
            var name = Console.ReadLine();
            logger.Info("Blog added - {name}", name);
            return new Blog { Name = name };
        }

        static Post createPostWorkflow() {
            Console.Write("Enter a title for the new Post:");

            Console.Write("Enter content for the new Post");
        }

        static void displayAllBlogs(BloggingContext db) {
            var query = db.Blogs.OrderBy(b => b.Name);

            Console.WriteLine("All blogs in the database:");
            foreach (var item in query)
            {
                Console.WriteLine(item.Name);
            }
        }
        static void Main(string[] args)
        {
            logger.Info("Program started");

            try
            {
                var db = new BloggingContext();
                string choice = mainMenu();
                switch (choice)
                {
                    case "1":
                    // Display All Blogs, pass in database context
                        displayAllBlogs(db);
                        break;
                    case "2":
                    // Add Blog
                        db.AddBlog(createBlogWorkflow());
                        break;
                    case "3":
                    // Create Post
                        break;
                    case "4":
                    // Display Posts
                        break;
                    case "0":
                    // Exit 
                        break;
                    default:
                        Console.WriteLine("Please Enter A Valid Option.");
                        break;
                }

                // // 3. Create Post - Prompt the user to select the Blog they are posting to

                // // Once the Blog is selected, the Post details can be entered
                // // Posts should be saved to the Posts table
                // // All user errors must be handled





                // // 4. select the Blog whose posts they want to view

                // // Once the Blog is selected, all Posts related to the selected blog should be display as well as the number of Posts

                // // Display Posts, display the Blog name, Post title and Post content
                // var query1 = db.Posts.OrderBy(b => b.PostId);

                // Console.WriteLine("All Posts in this Blog:"); // certain blog name
                // foreach (var item in query1)
                // {
                //     Console.WriteLine(item.Title);
                // }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

            logger.Info("Program ended");
        
        }
    }
}
