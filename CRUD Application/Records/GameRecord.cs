namespace CRUD_Application.Records;

public record GameRecord(Guid Id,
    string Name,
    string Description,
    decimal Price,
    Guid? DeveloperId);