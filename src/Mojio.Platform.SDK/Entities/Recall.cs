#region copyright
/******************************************************************************
* Moj.io Inc. CONFIDENTIAL
* 2017 Copyright Moj.io Inc.
* All Rights Reserved.
* 
* NOTICE:  All information contained herein is, and remains, the property of 
* Moj.io Inc. and its suppliers, if any.  The intellectual and technical 
* concepts contained herein are proprietary to Moj.io Inc. and its suppliers
* and may be covered by Patents, pending patents, and are protected by trade
* secret or copyright law.
*
* Dissemination of this information or reproduction of this material is strictly
* forbidden unless prior written permission is obtained from Moj.io Inc.
*******************************************************************************/
#endregion

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