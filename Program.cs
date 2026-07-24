using data_guard.ClassificateEmails;
using data_guard.Interfaces;
using data_guard.loggers;
using data_guard.Managers;
using data_guard.Storage;

namespace data_guard
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Initialize dependencies
            ILogger logger = new ConsoleLogger();
            PathCreator pathCreator = new PathCreator();
            IModelExtractor modelExtractor = new ModelExtractor();
            IEmailsTraningReader emailTraningReader = new EmailsTraningReader();
            EmailClassificator classificator = new EmailClassificator();
            //string[] args = ["Job_Promotion_Train.csv"];

            switch (args.Length)
            {
                case 1:
                    ClassificationManager interactivManeger = new InteractiveClassificationManager(logger, emailTraningReader, classificator, modelExtractor, args[0]);
                    interactivManeger.Execut();
                    break;

                case 2:
                    IEmailsInputReader bachInputReader = new EmailsInputReader(logger);
                    IEmailsWriter uotputWriter = new EmailsWriter();
                    string uotputPath = "predictions.csv";
                    ClassificationManager bachManeger = new BatchClassificationManager(logger, emailTraningReader, uotputWriter, bachInputReader, classificator, modelExtractor, args[0], args[1], uotputPath);
                    bachManeger.Execut();
                    break;

                default:
                    Console.WriteLine("Cannot run the program, it must receive 1 or 2 arguments");
                    break;

            }
            Console.WriteLine("exiting program");
        }
    }
}