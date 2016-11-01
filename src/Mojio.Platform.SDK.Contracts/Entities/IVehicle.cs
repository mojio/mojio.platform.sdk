using System;
using System.Collections.Generic;

namespace Mojio.Platform.SDK.Contracts.Entities
{
    public enum RiskSeverity
    {
        Unknown,
        Low,
        Medium,
        High,
        None
    }

    public enum VehicleState
    {
        Green,
        Yellow,
        Red
    }

    public interface IVehicle
    {
        VehicleState VehicleState { get; }
        bool Selected { get; set; }
        IImage Image { get; set; }
        string Name { get; set; }
        string VIN { get; set; }
        Guid MojioId { get; set; }
        DateTimeOffset LastContactTime { get; set; }
        List<IDiagnosticCode> DiagnosticCodes { get; set; }
        IMeasurement Accelerometer { get; set; }
        IMeasurement Acceleration { get; set; }
        IMeasurement Deceleration { get; set; }
        IMeasurement Speed { get; set; }
        IOdometer Odometer { get; set; }
        IMeasurement RPM { get; set; }
        IMeasurement FuelEfficiency { get; set; }
        string FuelEfficiencyCalculationMethod { get; set; }
        IRiskMeasurement FuelLevel { get; set; }
        string FuelType { get; set; }
        DateTimeOffset GatewayTime { get; set; }
        IState HarshEventState { get; set; }
        IState IdleState { get; set; }
        IState IgnitionState { get; set; }
        IBattery Battery { get; set; }
        IHeading Heading { get; set; }
        ILocation Location { get; set; }
        IState AccidentState { get; set; }
        IVinCommon VinDetails { get; set; }
        IState TowState { get; set; }
        IState ParkedState { get; set; }
        IList<string> Tags { get; set; }
        IList<string> OwnerGroups { get; set; }
        string Id { get; set; }
        DateTimeOffset CreatedOn { get; set; }
        DateTimeOffset LastModified { get; set; }
        IDictionary<string, string> Links { get; set; }
        string LicensePlate { get; set; }
        bool MilStatus { get; set; }

        string CurrentTrip { get; set; }
        IState DisturbanceState { get; set; }

        IVirtualodometer VirtualOdometer { get; set; }
        DateTimeOffset Time { get; set; }
        IMeasurement VirtualFuelConsumption { get; set; }
        IMeasurement VirtualFuelEfficiency { get; set; }
    }

    public interface IVehiclesResponse
    {
        IList<IVehicle> Data { get; set; }
        int Results { get; set; }
        IDictionary<string, string> Links { get; set; }
    }

    public interface IAccelerometer
    {
        IMeasurement X { get; set; }
        IMeasurement Y { get; set; }
        IMeasurement Z { get; set; }
        IMeasurement Magnitude { get; set; }
        IMeasurement SamplingInterval { get; set; }
    }

    public interface IMeasurement
    {
        string BaseUnit { get; set; }
        float BaseValue { get; set; }
        DateTimeOffset Timestamp { get; set; }
        string Unit { get; set; }
        float Value { get; set; }
    }

    public interface IRiskMeasurement : IMeasurement
    {
        RiskSeverity RiskSeverity { get; set; }
    }

    public interface IOdometer : IMeasurement
    {
        long RolloverValue { get; set; }
    }

    public interface IBattery : IRiskMeasurement
    {
        bool Connected { get; set; }
        IMeasurement LowVoltageDuration { get; set; }
        IMeasurement HighVoltageDuration { get; set; }

        string BaseUnit { get; set; }
        DateTimeOffset Timestamp { get; set; }
        float BaseValue { get; set; }
        string Unit { get; set; }
        float Value { get; set; }
    }

    public interface IHeading : IMeasurement
    {
        string Direction { get; set; }
        bool LeftTurn { get; set; }
    }

    public interface ILocation
    {
        IAddress Address { get; set; }
        DateTimeOffset Timestamp { get; set; }
        double Lat { get; set; }
        double Lng { get; set; }
        string Status { get; set; }
        double Dilution { get; set; }
        double Altitude { get; set; }
        string GeoHash { get; set; }
    }

    public interface IAddress
    {
        string HouseNumber { get; set; }
        string Road { get; set; }
        string Neighbourhood { get; set; }
        string Suburb { get; set; }
        string City { get; set; }
        string County { get; set; }
        string State { get; set; }
        string PostCode { get; set; }
        string Country { get; set; }
        string CountryCode { get; set; }
        string FormattedAddress { get; set; }
    }

    public interface IVinSummary : IVinCommon
    {
        string Engine { get; set; }
        string Transmission { get; set; }
    }

    public interface IVinCommon
    {
        DateTimeOffset Timestamp { get; set; }
        string Vin { get; set; }
        int Year { get; set; }
        string Make { get; set; }
        string Model { get; set; }
        int Cylinders { get; set; }
        IMeasurement TotalFuelCapacity { get; set; }
        string FuelType { get; set; }
        double CityFuelEfficiency { get; set; }
        double HighwayFuelEfficiency { get; set; }
        double CombinedFuelEfficiency { get; set; }
        bool Success { get; set; }
    }

    public interface ITransmission
    {
        string Name { get; set; }
        string Type { get; set; }
        string DetailType { get; set; }
        string Gears { get; set; }
    }

    public interface IVinDetails : IVinCommon
    {
        string Market { get; set; }
        string VehicleType { get; set; }
        string BodyType { get; set; }
        string DriveType { get; set; }
        float FuelTankSize { get; set; }
        ITransmission Transmission { get; set; }
        IEngine EngineDetails { get; set; }
        IList<IWarranty> Warranties { get; set; }
        IList<IRecall> Recalls { get; set; }
        IList<IServiceBulletin> ServiceBulletins { get; set; }
    }

    public interface IState
    {
        DateTimeOffset Timestamp { get; set; }
        bool Value { get; set; }
    }

    public interface IDiagnosticCode
    {
        string Code { get; set; }
        string Description { get; set; }
        DateTimeOffset Timestamp { get; set; }
        string Severity { get; set; }
        string Instructions { get; set; }
    }

    public interface IEngine
    {
        string Name { get; set; }
        string Cylinders { get; set; }
        float Displacement { get; set; }
        string FuelInduction { get; set; }
        string FuelQuality { get; set; }
        string FuelType { get; set; }
        string MaxHp { get; set; }
        string MaxHpAt { get; set; }
    }

    public interface IWarranty
    {
        string Name { get; set; }
        string Type { get; set; }
        string Months { get; set; }
        float Km { get; set; }
    }

    public interface IRecall
    {
        string Title { get; set; }
        string NHTSACampaignNumber { get; set; }
        string MFRCampaignNumber { get; set; }
        string ComponentDescription { get; set; }
        string ReportManufacturer { get; set; }
        string ManufacturingStartDate { get; set; }
        string ManufacturingEndDate { get; set; }
        string RecallTypeCode { get; set; }
        string PotentialUnitsAffected { get; set; }
        string OwnerNotificationDate { get; set; }
        string RecallInitiator { get; set; }
        string ProductManufacturer { get; set; }
        string ReportReceivedDate { get; set; }
        string RecordCreationDate { get; set; }
        string RegulationPartNumber { get; set; }
        string FMVVSNumber { get; set; }
        string DefectSummary { get; set; }
        string ConsequenceSummary { get; set; }
        string CorrectiveAction { get; set; }
        string Notes { get; set; }
        string RecalledComponentId { get; set; }
    }

    public interface IServiceBulletin
    {
        string ItemNumber { get; set; }
        string BulletinNumber { get; set; }
        string ReplacementBulletinNumber { get; set; }
        string DateAdded { get; set; }
        string Component { get; set; }
        string BulletinDate { get; set; }
        string Summary { get; set; }
    }

    public interface IVehicleLocationResponse
    {
        IList<ILocation> Data { get; set; }
        int Results { get; set; }
        IDictionary<string, string> Links { get; set; }
    }

    public interface IVehiclesHistoryStatesResponse
    {
        IList<IVehicle> Data { get; set; }
        int Results { get; set; }
        Links Links { get; set; }
    }

    public interface Links
    {
        string Self { get; set; }
        string Next { get; set; }
        string First { get; set; }
    }

    public interface IFuellevel
    {
        string BaseUnit { get; set; }
        string RiskSeverity { get; set; }
        DateTimeOffset Timestamp { get; set; }
        float BaseValue { get; set; }
        string Unit { get; set; }
        float Value { get; set; }
    }

    public interface IVirtualodometer : IMeasurement
    {
        float RolloverValue { get; set; }
    }
}