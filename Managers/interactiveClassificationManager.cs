using data_guard.ClassificateEmails;
using data_guard.Exceptions;
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
    private void DefineModel()
    {
        Rows = EmailsTraningReader.Read(RawDataName);
        Model = ModelExtractor.GetModel(Rows);
    }
    public override void Execut()
    {
        try
        {
            DefineModel();
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
                    string result = EmailClassificator.GetClasification(Model, email);
                    Logger.WriteLog($"Prediction: {result}");
                }
            }
        }
        catch (UnClassificationTable ex)
        {
            Logger.WriteLog(ex.Message);
        }
        catch (FileNotFoundException ex)
        {
            Logger.WriteLog(ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            Logger.WriteLog(ex.Message);
        }
        catch (FileIsEmptyException ex)
        {
            Logger.WriteLog(ex.Message);
        }
        catch (IOException ex)
        {
            Logger.WriteLog(ex.Message);
        }
    }

    private Dictionary<string, string>? getEmail()
    {
        Dictionary<string, string?> emailDict = new Dictionary<string, string?>();
        List<string> featuers = Rows[0].Keys.ToList();

        for (int i = 0; i < featuers.Count - 1; i++)
        {
            Console.WriteLine($"{featuers[i]}: ");
            string? userInput = Console.ReadLine();
            if (string.IsNullOrEmpty(userInput) && (i == 0)) { return null; }

            emailDict.Add(featuers[i], userInput);
        }

        return emailDict;
    }
}