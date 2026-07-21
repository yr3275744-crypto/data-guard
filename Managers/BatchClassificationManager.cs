using data_guard.ClassificateEmails;
using data_guard.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace data_guard.Managers;

class BatchClassificationManager : ClassificationManager
{
    private IEmailsInputReader EmailsInputReader { get; set; }
    private IEmailsWriter EmailsWriter { get; set; }
    private string EmailsInputName { get; set; }
    private string EmailOutputName { get; set; }
    public BatchClassificationManager(ILogger logger,
        IEmailsTraningReader EmailsTraningReader,
        IEmailsWriter emailsWriter,
        IEmailsInputReader emailsInputReader,
        EmailClassificator classificator,
        IModelExtractor modelExtractor,
        string rawDataName,
        string emailsInputName,
        string emailOutputName) :
        base(EmailsTraningReader, logger, classificator, modelExtractor, rawDataName)
}
