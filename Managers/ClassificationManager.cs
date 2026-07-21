using data_guard.ClassificateEmails;
using data_guard.Interfaces;
using data_guard.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace data_guard.Managers;

abstract class ClassificationManager
{
    public IEmailsTraningReader EmailsTraningReader { get; }
    public ILogger Logger { get; }

    public EmailClassificator EmailClassificator { get; }

    public IModelExtractor ModelExtractor { get; }

    public string RawDataName { get; }

    public List<Dictionary<string, string>> Rows { get; set; }

    public Model? Model { get; }

    protected ClassificationManager(IEmailsTraningReader emailsReader, ILogger logger, EmailClassificator classificator, IModelExtractor modelExtractor, string rawDataName)
    {
        EmailsTraningReader = emailsReader;
        Logger = logger;
        EmailClassificator = classificator;
        ModelExtractor = modelExtractor;
        RawDataName = rawDataName;
        Rows = new();
    }

    public abstract void Execut();


}

