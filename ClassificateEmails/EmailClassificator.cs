using Microsoft.VisualBasic;
using System.Reflection.Emit;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace data_guard.ClassificateEmails;
class EmailClassificator
{
	public string GetClasification(Model model, Dictionary<string, string> email)
	{

		string bestLabel = null;
		double bestScore = double.NegativeInfinity;
		foreach (var label in model.Labels)
		{
			double score = model.Priors[label];
			foreach (var (feature, value) in email)
			{
				double prob;
                var condKey = (label, feature, value);

                if (model.Cond.TryGetValue(condKey, out double condProb))
                {
                    prob = condProb;
                }
				else
				{
					prob = model.Unseen[(label, feature)];
				}
				score *= prob;
			}

			if (score > bestScore)
			{
				bestScore = score;
				bestLabel = label;
			}
		}
		return bestLabel;
	}
}