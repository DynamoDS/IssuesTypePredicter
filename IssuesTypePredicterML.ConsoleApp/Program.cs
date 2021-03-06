// This file was auto-generated by ML.NET Model Builder. 

using System;
using IssuesTypePredicterML.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IssuesTypePredicterML.ConsoleApp
{
    class Program
    {
        /// <summary>
        /// This is the main method that will execute the Model prediction in order to know if is wishlist or not
        /// </summary>
        /// <param name="args">The only parameter passed is a json string in the next format
        /// "{\"Number\":23,\"Title\":\"Testingtitle\",\"Description\":\"TestingDescription\"}"
        /// </param>
        static void Main(string[] args)
        {
            int isWishList = -1;

            if (args.Length > 0)//Means that the json string parameter was provided
            {
                IssueData issue = null;
                try
                {
                    //Try to parse the received json string just to see if is well formed
                    var obj = JToken.Parse(args[0]);
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    Console.WriteLine(jex.Message);
                }
                catch (Exception ex) //some other exception
                {
                    Console.WriteLine(ex.ToString());
                }

                try
                {
                    issue = JsonConvert.DeserializeObject<IssueData>(args[0]);
                    // Create single instance of sample data from first line of dataset for model input
                    ModelInput sampleData = new ModelInput()
                    {
                        Title = issue.Title,
                        Description = issue.Description,
                    };

                    // Make a single prediction on the sample data and print results
                    var predictionResult2 = ConsumeModel.Predict(sampleData);

                    isWishList = int.Parse(predictionResult2.Prediction);
                    Console.WriteLine("IsWishlist:"+isWishList);
                }
                catch (JsonReaderException ex)
                {
                    Console.WriteLine(args[0]);
                    Console.WriteLine(ex.Message);
                    throw;
                }                       
            }
            else
            {
                Console.WriteLine("No Arguments Provided");
            }
        }
    }
}
