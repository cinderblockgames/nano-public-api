using System.Net;
using Microsoft.AspNetCore.Mvc;
using NanoPublicApi.Config;
using NanoPublicApi.Connectors;
using NanoPublicApi.Entities;
using NanoPublicApi.Entities.Input;
using NanoPublicApi.Entities.Output;
using Newtonsoft.Json;

namespace NanoPublicApi.Controllers;

[ApiController]
[Route("node")]
[Produces("application/json")]
public class NodeController : Controller
{
    
    private NodeConnector Node { get; }
    private Options Options { get; }

    public NodeController(NodeConnector node, Options options)
    {
        Node = node;
        Options = options;
    }
    
    #region " Proxy "
    
    [HttpPost("proxy")]
    public async Task<IActionResult> Proxy([FromBody] dynamic json)
    {
        var request = json.ToString();
        var parsed = To<Request>(request);
        return parsed.Action switch
        {
            /* 01 */ nameof(account_balance) => await account_balance(To<AccountBalanceRequest>(request)),
            /* 02 */ nameof(account_block_count) => await account_block_count(To<AccountBlockCountRequest>(request)),
            /* 03 */ nameof(account_get) => await account_get(To<AccountGetRequest>(request)),
            /* 04 */ nameof(account_history) => await account_history(To<AccountHistoryRequest>(request)),
            /* 05 */ 
            /* 06 */ nameof(account_key) => await account_key(To<AccountKeyRequest>(request)),
            /* 07 */ nameof(account_representative) => await account_representative(To<AccountRepresentativeRequest>(request)),
            /* 08 */ nameof(account_weight) => await account_weight(To<AccountWeightRequest>(request)),
            /* 09 */ nameof(accounts_balances) => await accounts_balances(To<AccountsBalancesRequest>(request)),
            /* 10 */ nameof(accounts_frontiers) => await accounts_frontiers(To<AccountsFrontiersRequest>(request)),
            /* 11 */ 
            /* 12 */ nameof(accounts_representatives) => await accounts_representatives(To<AccountsRepresentativesRequest>(request)),
            /* 13 */ nameof(available_supply) => await available_supply(To<AvailableSupplyRequest>(request)),
            /* 14 */ nameof(block_account) => await block_account(To<BlockAccountRequest>(request)),
            /* 15 */ 
            /* 16 */ nameof(block_info) => await block_info(To<BlockInfoRequest>(request)),
            /* 17 */ nameof(blocks) => await blocks(To<BlocksRequest>(request)),
            /* 18 */ 
            /* 19 */ nameof(chain) => await chain(To<ChainRequest>(request)),
            /* 20 */ 
            /* 21 */ nameof(delegators_count) => await delegators_count(To<DelegatorsCountRequest>(request)),
            /* 22 */ nameof(frontier_count) => await frontier_count(To<FrontierCountRequest>(request)),
            /* 23 */ nameof(frontiers) => await frontiers(To<FrontiersRequest>(request)),
            /* 24 */ 
            /* 25 */ nameof(receivable_exists) => await receivable_exists(To<ReceivableExistsRequest>(request)),
            /* 26 */ nameof(representatives) => await representatives(To<RepresentativesRequest>(request)),
            /* 27 */ 
            /* 28 */ 
            _ => Json(new { error = $"{parsed.Action} not supported" })
        };
    }

    private T To<T>(string serialized)
        where T : Request
    {
        return JsonConvert.DeserializeObject<T>(serialized);
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
    [ProducesResponseType(typeof(AccountHistory), (int)HttpStatusCode.OK)]
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
    [ProducesResponseType(typeof(AccountRepresentative), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> account_representative([FromBody] AccountRepresentativeRequest request)
    {
        request.Action = "account_representative";
        return await Node.Proxy(request);
    }

    [HttpPost("proxy/account_weight")]
    [ProducesResponseType(typeof(AccountWeight), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> account_weight([FromBody] AccountWeightRequest request)
    {
        request.Action = "account_weight";
        return await Node.Proxy(request);
    }

    [HttpPost("proxy/accounts_balances")]
    [ProducesResponseType(typeof(AccountsBalances), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> accounts_balances([FromBody] AccountsBalancesRequest request)
    {
        request.Action = "accounts_balances";
        return await Node.Proxy(request);
    }

    [HttpPost("proxy/accounts_frontiers")]
    [ProducesResponseType(typeof(AccountsFrontiers), (int)HttpStatusCode.OK)]
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
    [ProducesResponseType(typeof(AccountsRepresentatives), (int)HttpStatusCode.OK)]
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
    [ProducesResponseType(typeof(BlockAccount), (int)HttpStatusCode.OK)]
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

    [HttpPost("proxy/block_info")]
    [ProducesResponseType(typeof(BlockInfo), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> block_info([FromBody] BlockInfoRequest request)
    {
        request.Action = "block_info";
        return await Node.Proxy(request);
    }

    [HttpPost("proxy/blocks")]
    [ProducesResponseType(typeof(Blocks), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> blocks([FromBody] BlocksRequest request)
    {
        request.Action = "blocks";
        return await Node.Proxy(request);
    }

    [HttpPost("proxy/blocks_info")]
    //[ProducesResponseType(typeof(BlocksInfo), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> blocks_info([FromBody] BlocksInfoRequest request)
    {
        request.Action = "blocks_info";
        return await Node.Proxy(request);
    }

    [HttpPost("proxy/chain")]
    [ProducesResponseType(typeof(Chain), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> chain([FromBody] ChainRequest request)
    {
        request.Action = "chain";
        return await Node.Proxy(request);
    }

    [HttpPost("proxy/delegators")]
    [ProducesResponseType(typeof(Delegators), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> delegators([FromBody] DelegatorsRequest request)
    {
        request.Action = "delegators";
        return await Node.Proxy(request);
    }

    [HttpPost("proxy/delegators_count")]
    [ProducesResponseType(typeof(DelegatorsCount), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> delegators_count([FromBody] DelegatorsCountRequest request)
    {
        if (!Options.ExpandedList) { return Json(new { error = "delegators_count not supported" }); }
        request.Action = "delegators_count";
        return await Node.Proxy(request);
    }

    [HttpPost("proxy/frontier_count")]
    [ProducesResponseType(typeof(FrontierCount), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> frontier_count([FromBody] FrontierCountRequest request)
    {
        request.Action = "frontier_count";
        return await Node.Proxy(request);
    }

    [HttpPost("proxy/frontiers")]
    [ProducesResponseType(typeof(Frontiers), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> frontiers([FromBody] FrontiersRequest request)
    {
        request.Action = "frontiers";
        return await Node.Proxy(request);
    }

    // [HttpPost("proxy/receivable")]
    // [ProducesResponseType(typeof(Receivable), (int)HttpStatusCode.OK)]
    // public async Task<IActionResult> receivable([FromBody] ReceivableRequest request)
    // {
    //     request.Action = "receivable";
    //     return await Node.Proxy(request);
    // }

    [HttpPost("proxy/receivable_exists")]
    [ProducesResponseType(typeof(ReceivableExists), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> receivable_exists([FromBody] ReceivableExistsRequest request)
    {
        request.Action = "receivable_exists";
        return await Node.Proxy(request);
    }

    [HttpPost("proxy/representatives")]
    [ProducesResponseType(typeof(Representatives), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> representatives([FromBody] RepresentativesRequest request)
    {
        request.Action = "representatives";
        return await Node.Proxy(request);
    }

    [HttpPost("proxy/representatives_online")]
    [ProducesResponseType(typeof(RepresentativesOnline), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> representatives_online([FromBody] RepresentativesOnlineRequest request)
    {
        request.Action = "representatives_online";
        return await Node.Proxy(request);
    }

    // [HttpPost("proxy/successors")]
    // [ProducesResponseType(typeof(Successors), (int)HttpStatusCode.OK)]
    // public async Task<IActionResult> successors([FromBody] SuccessorsRequest request)
    // {
    //     request.Action = "successors";
    //     return await Node.Proxy(request);
    // }

    #endregion
    
}