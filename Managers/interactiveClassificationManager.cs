using data_guard.ClassificateEmails;
using data_guard.Interfaces;
using data_guard.Storage;
using System.Reflection.Metadata;
using System.Threading.Tasks.Dataflow;

namespace data_guard.Managers;

class InteractiveClassificationManager : ClassificationManager
{
    public InteractiveClassificationManager(ILogger logger, IEmailsTraningReader emailsTraningReader, EmailClassificator classificator,
        IModelExtractor modelExtractor, string rawDataName) :
        base(emailsTraningReader, logger, classificator, modelExtractor, rawDataName)
    { }

    public override void Execut()
    {
        bool runFlag = true;

        while (runFlag)
        {
            Dictionary<string, string>? email = getEmail();

            if (email == null)
            {
                runFlag = false;
            }
            else
            {
                Logger.WriteLog(EmailClassificator.GetClasification(Model, email));
            }

        }
    }

    private Dictionary<string, string>? getEmail()
    {
        Dictionary<string, string?> emailDict = new Dictionary<string, string?>();
        List<string> featuers = Rows[0].Keys.ToList();
        foreach (string feature in featuers)
        {
            Console.WriteLine($"{feature}: ");
            string? userInput = Console.ReadLine();
            if (userInput == null) { return null; }



            emailDict.Add(feature, userInput);
        }

        return emailDict;
    }
}