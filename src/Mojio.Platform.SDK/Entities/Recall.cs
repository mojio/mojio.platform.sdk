using Mojio.Platform.SDK.Contracts.Entities;

namespace Mojio.Platform.SDK.Entities
{
    public class Recall : IRecall
    {
        public string Title { get; set; }
        public string NHTSACampaignNumber { get; set; }
        public string MFRCampaignNumber { get; set; }
        public string ComponentDescription { get; set; }
        public string ReportManufacturer { get; set; }
        public string ManufacturingStartDate { get; set; }
        public string ManufacturingEndDate { get; set; }
        public string RecallTypeCode { get; set; }
        public string PotentialUnitsAffected { get; set; }
        public string OwnerNotificationDate { get; set; }
        public string RecallInitiator { get; set; }
        public string ProductManufacturer { get; set; }
        public string ReportReceivedDate { get; set; }
        public string RecordCreationDate { get; set; }
        public string RegulationPartNumber { get; set; }
        public string FMVVSNumber { get; set; }
        public string DefectSummary { get; set; }
        public string ConsequenceSummary { get; set; }
        public string CorrectiveAction { get; set; }
        public string Notes { get; set; }
        public string RecalledComponentId { get; set; }
    }
}