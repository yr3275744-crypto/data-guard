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
    {
        EmailsInputName = emailOutputName;
        EmailsInputReader = emailsInputReader;
        EmailsWriter = emailsWriter;
        EmailOutputName = emailOutputName;
    }
    private void DefineModel()
    {
        Rows = EmailsTraningReader.Read(RawDataName);
        Model = ModelExtractor.GetModel(Rows);
    }
    private List<Dictionary<string, string>> GetData()
    {
        string[] featuers = Rows[0].Keys.ToArray();
        return EmailsInputReader.Read(EmailsInputName, featuers);
    }
    public override void Execut()
    {
        DefineModel();
        List<Dictionary<string, string>> unClassificateData = GetData();
        List<string> resultLines = new();
        for (int i = 0; i < unClassificateData.Count; i++)
        {
            string bestLabel = EmailClassificator.GetClasification(Model, unClassificateData[i]);
            List<string> allEmaileDetiles = unClassificateData[i].Values.ToList();
            string stringLine = string.Join(",", allEmaileDetiles);
            Logger.WriteLog($"row {i}: {stringLine} -> {bestLabel}");
            stringLine += bestLabel;
            resultLines.Add(stringLine);
        }
        EmailsWriter.Write(EmailOutputName, resultLines);
    }
}
