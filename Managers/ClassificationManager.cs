using data_guard.ClassificateEmails;
using data_guard.Interfaces;
using data_guard.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace data_guard.Managers;

abstract class ClassificationManager
{
    public IEmailsReader EmailsReader { get; }
    public ILogger Logger { get; }

    public EmailClassificator EmailClassificator { get; }

    public IModelExtractor ModelExtractor { get; }

    public string RawDataName { get; }

    public List<string>? Rows { get; set; }

    public Model Model { get; }

    protected ClassificationManager(IEmailsReader emailsReader, ILogger logger, EmailClassificator classificator, IModelExtractor modelExtractor, string rawDataName)
    {
        EmailsReader = emailsReader;
        Logger = logger;
        EmailClassificator = classificator;
        ModelExtractor = modelExtractor;
        RawDataName = rawDataName;
        Rows = new List<string>();
    }
 
    public abstract void Execut();

    public void Extract()
    {

    }
}

