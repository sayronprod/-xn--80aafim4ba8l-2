using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using тестове_xn__80aafim4ba8l_2.Data.DatabaseModels;
using тестове_xn__80aafim4ba8l_2.Data.Interfaces;
using тестове_xn__80aafim4ba8l_2.Models;

namespace тестове_xn__80aafim4ba8l_2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountsController(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountReadModel>>> GetAllAccountsAsync()
        {
            var accounts = await _accountRepository.GetAllAccountsAsync();

            if (!accounts.Any())
            {
                return NotFound("Sorry, the list of accounts is empty.");
            }

            return Ok(_mapper.Map<IEnumerable<AccountReadModel>>(accounts));
        }

        [HttpGet("{id}", Name = "GetAccountByIdAsync")]
        public async Task<ActionResult<AccountReadModel>> GetAccountByIdAsync(int id)
        {
            var account = await _accountRepository.GetAccountByIdAsync(id);

            if (account == null)
            {
                return NotFound($"Sorry. No account found for the specified id: {id}. ");
            }

            return Ok(_mapper.Map<AccountReadModel>(account));
        }

        [HttpPost]
        public async Task<ActionResult<AccountCreateModel>> CreateAccountAsync(AccountCreateModel accountCreateModel)
        {
            var accountModel = _mapper.Map<Account>(accountCreateModel);

            await _accountRepository.PostAccountAsync(accountModel);
            await _accountRepository.SaveChangesAsync();

            var accountReadModel = _mapper.Map<AccountReadModel>(accountModel);

            return CreatedAtRoute(nameof(GetAccountByIdAsync), new { accountReadModel.Id }, accountReadModel);
        }
    }
}
