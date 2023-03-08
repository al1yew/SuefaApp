namespace SuefaApp
{
    public class UnitOfWork : IUnitOfWork
    {
        //private readonly AppUserRepository _appUserRepository;
        //private readonly VinCodeRepository _vinCodeRepository;
        //private readonly AppUserToVincodeRepository _appUserToVincodeRepository;
        //private readonly TransactionRepository _transactionRepository;
        //private readonly EventRepository _eventRepository;
        //private readonly EventMessageRepository _eventMessageRepository;
        //private readonly AppDbContext _context;

        //public UnitOfWork(AppDbContext context)
        //{
        //    _context = context;
        //}

        //public IAppUserRepository AppUserRepository => _appUserRepository ?? new AppUserRepository(_context);
        //public IVinCodeRepository VinCodeRepository => _vinCodeRepository ?? new VinCodeRepository(_context);
        //public IAppUserToVincodeRepository AppUserToVincodeRepository => _appUserToVincodeRepository ?? new AppUserToVincodeRepository(_context);
        //public ITransactionRepository TransactionRepository => _transactionRepository ?? new TransactionRepository(_context);
        //public IEventRepository EventRepository => _eventRepository ?? new EventRepository(_context);
        //public IEventMessageRepository EventMessageRepository => _eventMessageRepository ?? new EventMessageRepository(_context);


        //public int Commit()
        //{
        //    return _context.SaveChanges();
        //}

        //public async Task<int> CommitAsync()
        //{
        //    return await _context.SaveChangesAsync();
        //}
    }
}
