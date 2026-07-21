using data_guard.ClassificateEmails;
using data_guard.Interfaces;
using data_guard.Storage;
using System.Reflection.Metadata;
using System.Threading.Tasks.Dataflow;

namespace data_guard.Managers;

class InteractiveClassificationManager : ClassificationManager
{
    public InteractiveClassificationManager(ILogger logger, IEmailsTraningReader EmailsTraningReader, EmailClassificator classificator,
        IModelExtractor modelExtractor, string rawDataName) :
        base(EmailsTraningReader, logger, classificator, modelExtractor, rawDataName)
    { }

    public override void Execut()
    {
        bool runFlag = true;

        while (runFlag)
        {
            string? email = getEmailString();

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

    private string? getEmailString()
    {
        List<string?> emailStringList = new List<string?>();
        List<string> featuers = Rows[0].Keys.ToList();
        foreach (string feature in featuers)
        {
            Console.WriteLine($"{feature}: ");
            string? userInput = Console.ReadLine();
            if (userInput == null) { return null; }

            emailStringList.Add(userInput);
        }

        return string.Join(',', emailStringList);
    }
}