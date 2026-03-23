namespace SchoolAdmission.Domain.Utils;

public static class MessageHelper
{
    public static string CreatedSuccessfully(EntityEnum entity)
    {
        return $"{entity} created successfully!";
    }

    public static string UpdatedSuccessfully(EntityEnum entity)
    {
        return $"{entity} updated successfully!";
    }

    public static string DeletedSuccessfully(EntityEnum entity)
    {
        return $"{entity} deleted successfully!";
    }
    public static string NotFound(EntityEnum entity, object id)
    {
        return $"{entity} with Id {id} not found!";
    }
    public static string InternalServerError(EntityEnum entity)
    {
        return $"Unable to process {entity} at the moment. Please try again later.";
    }

    public static string RetrievedSuccessfully(EntityEnum entity)
    {
        return $"{entity} retrieved successfully!";
    }
}
