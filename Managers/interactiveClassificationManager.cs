using data_guard.ClassificateEmails;
using data_guard.Interfaces;
using data_guard.Storage;

namespace data_guard.Managers;

class InteractiveClassificationManager : ClassificationManager
{
	public InteractiveClassificationManager(ILogger logger, IEmailsReader emailsReader, EmailClassificator classificator, IModelExtractor modelExtractor, string rawDataName) : base(logger, emailsReader, classificator, modelExtractor, rawDataName) { }

public void execute() { }

	private string getEmailString()
	{
		
	}
}