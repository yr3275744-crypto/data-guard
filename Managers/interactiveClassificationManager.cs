using data_guard.ClassificateEmails;
using data_guard.Interfaces;
using data_guard.Storage;
using System.Threading.Tasks.Dataflow;

namespace data_guard.Managers;

class InteractiveClassificationManager : ClassificationManager
{
	public InteractiveClassificationManager(ILogger logger, IEmailsReader emailsReader, EmailClassificator classificator,
		IModelExtractor modelExtractor, string rawDataName) :
		base(logger, emailsReader, classificator, modelExtractor, rawDataName) { }

	public override void Execut() 
	{
		bool runFlag = true;

		while (runFlag)
		{
			string email = getEmailString();


        }
	}

	private string getEmailString()
	{
		List<string?> emailStringList = new List<string?>();

        for (int i = 0; i < Model.RawTable.Count -1; i++)
		{
			Console.WriteLine($"enter next value: ");
			emailStringList.Add(Console.ReadLine());
		}
		return string.Join(',', emailStringList);
	}
}