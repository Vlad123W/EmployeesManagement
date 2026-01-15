namespace EmployeesManagement.Application.Validators
{
    public static class EmployeeValidator
    {
        public static bool IsValidId(long actualValue, long requiedValue)
        {
            if(actualValue < requiedValue) return false;

            return true;
        }


    }
}
