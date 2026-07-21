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
		base(emailsTraningReader, logger, classificator, modelExtractor, rawDataName) { }

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

        for (int i = 0; i < Model.RawTable.Count -1; i++)
		{
			Console.WriteLine($"enter next value: ");
			string? userInput = Console.ReadLine();
			if (userInput == null) { return null; }

            emailStringList.Add(userInput);
        }

		return string.Join(',', emailStringList);
	}
}