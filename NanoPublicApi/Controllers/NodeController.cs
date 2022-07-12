using System.Net;
using Microsoft.AspNetCore.Mvc;
using NanoPublicApi.Connectors;
using NanoPublicApi.Entities;
using NanoPublicApi.Entities.Input;
using NanoPublicApi.Entities.Output;
using Newtonsoft.Json.Linq;

namespace NanoPublicApi.Controllers;

[ApiController]
[Route("node")]
[Produces("application/json")]
public class NodeController : Controller
{
    
    private NodeConnector Node { get; }

    public NodeController(NodeConnector node)
    {
        Node = node;
    }
    
    #region " Proxy "
    
    [HttpPost("proxy")]
    public async Task<IActionResult> Proxy([FromBody] JObject request)
    {
        var parsed = request.ToObject<Request>();
        return parsed.Action switch
        {
            nameof(available_supply) => await available_supply(request.ToObject<AvailableSupplyRequest>()),
            _ => throw new ArgumentOutOfRangeException("action", parsed.Action, "Unsupported action.")
        };
    }
    
    #endregion
    
    #region " Friendly "

    [HttpPost("proxy/account_balance")]
    [ProducesResponseType(typeof(AccountBalance), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> account_balance([FromBody] AccountBalanceRequest request)
    {
        request.Action = "account_balance";
        return await Node.Proxy(request);
    }
    
    [HttpPost("proxy/account_block_count")]
    [ProducesResponseType(typeof(AccountBlockCount), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> account_block_count([FromBody] AccountBlockCountRequest request)
    {
        request.Action = "account_block_count";
        return await Node.Proxy(request);
    }

    [HttpPost("proxy/account_get")]
    [ProducesResponseType(typeof(AccountGet), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> account_get([FromBody] AccountGetRequest request)
    {
        request.Action = "account_get";
        return await Node.Proxy(request);
    }

    [HttpPost("proxy/account_history")]
    //[ProducesResponseType(typeof(AccountHistory), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> account_history([FromBody] AccountHistoryRequest request)
    {
        request.Action = "account_history";
        return await Node.Proxy(request);
    }

    [HttpPost("proxy/account_info")]
    //[ProducesResponseType(typeof(AccountInfo), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> account_info([FromBody] AccountInfoRequest request)
    {
        request.Action = "account_info";
        return await Node.Proxy(request);
    }

    [HttpPost("proxy/account_key")]
    [ProducesResponseType(typeof(AccountKey), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> account_key([FromBody] AccountKeyRequest request)
    {
        request.Action = "account_key";
        return await Node.Proxy(request);
    }

    [HttpPost("proxy/account_representative")]
    //[ProducesResponseType(typeof(AccountRepresentative), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> account_representative([FromBody] AccountRepresentativeRequest request)
    {
        request.Action = "account_representative";
        return await Node.Proxy(request);
    }

    [HttpPost("proxy/account_weight")]
    //[ProducesResponseType(typeof(AccountWeight), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> account_weight([FromBody] AccountWeightRequest request)
    {
        request.Action = "account_weight";
        return await Node.Proxy(request);
    }

    [HttpPost("proxy/accounts_balances")]
    //[ProducesResponseType(typeof(AccountsBalances), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> accounts_balances([FromBody] AccountsBalancesRequest request)
    {
        request.Action = "accounts_balances";
        return await Node.Proxy(request);
    }

    [HttpPost("proxy/accounts_frontiers")]
    //[ProducesResponseType(typeof(AccountsFrontiers), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> accounts_frontiers([FromBody] AccountsFrontiersRequest request)
    {
        request.Action = "accounts_frontiers";
        return await Node.Proxy(request);
    }

    [HttpPost("proxy/accounts_pending")]
    //[ProducesResponseType(typeof(AccountsPending), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> accounts_pending([FromBody] AccountsPendingRequest request)
    {
        request.Action = "accounts_pending";
        return await Node.Proxy(request);
    }

    [HttpPost("proxy/accounts_representatives")]
    //[ProducesResponseType(typeof(AccountsRepresentatives), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> accounts_representatives([FromBody] AccountsRepresentativesRequest request)
    {
        request.Action = "accounts_representatives";
        return await Node.Proxy(request);
    }

    [HttpPost("proxy/available_supply")]
    [ProducesResponseType(typeof(AvailableSupply), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> available_supply([FromBody] AvailableSupplyRequest request)
    {
        request.Action = "available_supply";
        return await Node.Proxy(request);
    }

    [HttpPost("proxy/block_account")]
    //[ProducesResponseType(typeof(BlockAccount), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> block_account([FromBody] BlockAccountRequest request)
    {
        request.Action = "block_account";
        return await Node.Proxy(request);
    }

    // [HttpPost("proxy/block_hash")]
    // [ProducesResponseType(typeof(BlockHash), (int)HttpStatusCode.OK)]
    // public async Task<IActionResult> block_hash([FromBody] BlockHashRequest request)
    // {
    //     request.Action = "block_hash";
    //     return await Node.Proxy(request);
    // }

    // [HttpPost("proxy/block_info")]
    // [ProducesResponseType(typeof(BlockInfo), (int)HttpStatusCode.OK)]
    // public async Task<IActionResult> block_info([FromBody] BlockInfoRequest request)
    // {
    //     request.Action = "block_info";
    //     return await Node.Proxy(request);
    // }

    // [HttpPost("proxy/blocks")]
    // [ProducesResponseType(typeof(Blocks), (int)HttpStatusCode.OK)]
    // public async Task<IActionResult> blocks([FromBody] BlocksRequest request)
    // {
    //     request.Action = "blocks";
    //     return await Node.Proxy(request);
    // }

    // [HttpPost("proxy/blocks_info")]
    // [ProducesResponseType(typeof(BlocksInfo), (int)HttpStatusCode.OK)]
    // public async Task<IActionResult> blocks_info([FromBody] BlocksInfoRequest request)
    // {
    //     request.Action = "blocks_info";
    //     return await Node.Proxy(request);
    // }

    // [HttpPost("proxy/chain")]
    // [ProducesResponseType(typeof(Chain), (int)HttpStatusCode.OK)]
    // public async Task<IActionResult> chain([FromBody] ChainRequest request)
    // {
    //     request.Action = "chain";
    //     return await Node.Proxy(request);
    // }

    // [HttpPost("proxy/delegators")]
    // [ProducesResponseType(typeof(Delegators), (int)HttpStatusCode.OK)]
    // public async Task<IActionResult> delegators([FromBody] DelegatorsRequest request)
    // {
    //     request.Action = "delegators";
    //     return await Node.Proxy(request);
    // }

    [HttpPost("proxy/delegators_count")]
    //[ProducesResponseType(typeof(DelegatorsCount), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> delegators_count([FromBody] DelegatorsCountRequest request)
    {
        request.Action = "delegators_count";
        return await Node.Proxy(request);
    }

    [HttpPost("proxy/frontier_count")]
    //[ProducesResponseType(typeof(FrontierCount), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> frontier_count([FromBody] FrontierCountRequest request)
    {
        request.Action = "frontier_count";
        return await Node.Proxy(request);
    }

    // [HttpPost("proxy/frontiers")]
    // [ProducesResponseType(typeof(Frontiers), (int)HttpStatusCode.OK)]
    // public async Task<IActionResult> frontiers([FromBody] FrontiersRequest request)
    // {
    //     request.Action = "frontiers";
    //     return await Node.Proxy(request);
    // }

    // [HttpPost("proxy/receivable")]
    // [ProducesResponseType(typeof(Receivable), (int)HttpStatusCode.OK)]
    // public async Task<IActionResult> receivable([FromBody] ReceivableRequest request)
    // {
    //     request.Action = "receivable";
    //     return await Node.Proxy(request);
    // }

    // [HttpPost("proxy/receivable_exists")]
    // [ProducesResponseType(typeof(ReceivableExists), (int)HttpStatusCode.OK)]
    // public async Task<IActionResult> receivable_exists([FromBody] ReceivableExistsRequest request)
    // {
    //     request.Action = "receivable_exists";
    //     return await Node.Proxy(request);
    // }

    [HttpPost("proxy/representatives")]
    //[ProducesResponseType(typeof(Representatives), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> representatives([FromBody] RepresentativesRequest request)
    {
        request.Action = "representatives";
        return await Node.Proxy(request);
    }

    // [HttpPost("proxy/representatives_online")]
    // [ProducesResponseType(typeof(RepresentativesOnline), (int)HttpStatusCode.OK)]
    // public async Task<IActionResult> representatives_online([FromBody] RepresentativesOnlineRequest request)
    // {
    //     request.Action = "representatives_online";
    //     return await Node.Proxy(request);
    // }

    // [HttpPost("proxy/successors")]
    // [ProducesResponseType(typeof(Successors), (int)HttpStatusCode.OK)]
    // public async Task<IActionResult> successors([FromBody] SuccessorsRequest request)
    // {
    //     request.Action = "successors";
    //     return await Node.Proxy(request);
    // }

    #endregion
    
}