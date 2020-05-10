namespace Dump2020.CleanArchitecture.Interfaces.BackgroundJobService
{
    public interface IBackgroundJobService
    {
        void EnqueueCreateInvoice(int invoiceId);
    }
}
