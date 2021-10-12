namespace EmployeeModels.Dtos
{
    public record OrderDetail(
        int OrderId,
        int ProductId,
        string UnitPrice,
        int Quantity,
        double Discount
    );
}