using AutoMapper;
using GoingTo.API.Resources.Accounts;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services;
using GoingTo_API.Extensions;
using GoingTo_API.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoingTo.API.Controllers.Accounts
{
    [Route("/api/[controller]")]
    public class WalletsController : Controller
    {
        private readonly IWalletService _walletService;
        private readonly IMapper _mapper;

        public WalletsController(IWalletService walletService, IMapper mapper)
        {
            _walletService = walletService;
            _mapper = mapper;
        }


        //GET
        [HttpGet]
        public async Task<IEnumerable<WalletResource>> GetAllAsync()
        {
            var wallets = await _walletService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Wallet>, IEnumerable<WalletResource>>(wallets);
            return resource;
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveWalletResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var wallet = _mapper.Map<SaveWalletResource, Wallet>(resource);
            var result = await _walletService.SaveAsync(wallet);

            if (!result.Success)
                return BadRequest(result.Message);

            var walletResource = _mapper.Map<Wallet, WalletResource>(result.Resource);
            return Ok(walletResource);
        }

        //PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveWalletResource resource)
        {
            var wallet = _mapper.Map<SaveWalletResource, Wallet>(resource);
            var result = await _walletService.UpdateAsync(id, wallet);

            if (!result.Success)
                return BadRequest(result.Message);

            var walletResource = _mapper.Map<Wallet, WalletResource>(result.Resource);
            return Ok(walletResource);
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _walletService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var walletResource = _mapper.Map<Wallet, WalletResource>(result.Resource);
            return Ok(walletResource);
        }
    }
}
