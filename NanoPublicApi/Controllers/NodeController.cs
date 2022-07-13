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
            /* 05 */ nameof(account_info) => await account_info(To<AccountInfoRequest>(request)),
            /* 06 */ nameof(account_key) => await account_key(To<AccountKeyRequest>(request)),
            /* 07 */ nameof(account_representative) => await account_representative(To<AccountRepresentativeRequest>(request)),
            /* 08 */ nameof(account_weight) => await account_weight(To<AccountWeightRequest>(request)),
            /* 09 */ nameof(accounts_balances) => await accounts_balances(To<AccountsBalancesRequest>(request)),
            /* 10 */ nameof(accounts_frontiers) => await accounts_frontiers(To<AccountsFrontiersRequest>(request)),
            /* 11 */ nameof(accounts_pending) => await accounts_pending(To<AccountsPendingRequest>(request)),
            /* 12 */ nameof(accounts_representatives) => await accounts_representatives(To<AccountsRepresentativesRequest>(request)),
            /* 13 */ nameof(available_supply) => await available_supply(To<AvailableSupplyRequest>(request)),
            /* 14 */ nameof(block_account) => await block_account(To<BlockAccountRequest>(request)),
            /* 15 */ nameof(block_hash) => await block_hash(request),
            /* 16 */ nameof(block_info) => await block_info(To<BlockInfoRequest>(request)),
            /* 17 */ nameof(blocks) => await blocks(To<BlocksRequest>(request)),
            /* 18 */ nameof(blocks_info) => await blocks_info(To<BlocksInfoRequest>(request)),
            /* 19 */ nameof(chain) => await chain(To<ChainRequest>(request)),
            /* 20 */ nameof(delegators) => await delegators(To<DelegatorsRequest>(request)),
            /* 21 */ nameof(delegators_count) => await delegators_count(To<DelegatorsCountRequest>(request)),
            /* 22 */ nameof(frontier_count) => await frontier_count(To<FrontierCountRequest>(request)),
            /* 23 */ nameof(frontiers) => await frontiers(To<FrontiersRequest>(request)),
            /* 24 */ nameof(receivable) => await receivable(To<ReceivableRequest>(request)),
            /* 25 */ nameof(receivable_exists) => await receivable_exists(To<ReceivableExistsRequest>(request)),
            /* 26 */ nameof(representatives) => await representatives(To<RepresentativesRequest>(request)),
            /* 27 */ nameof(representatives_online) => await representatives_online(To<RepresentativesOnlineRequest>(request)),
            /* 28 */ nameof(successors) => await successors(To<SuccessorsRequest>(request)),
            _ => Error(string.IsNullOrWhiteSpace(parsed.Action) ? "missing action" : $"{parsed.Action} not supported")
        };
    }

    #endregion
    
    #region " Friendly "

    [HttpPost("proxy/account_balance")]
    [ProducesResponseType(typeof(AccountBalance), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> account_balance([FromBody] AccountBalanceRequest request)
    {
        return await Call(nameof(account_balance), request);
    }
    
    [HttpPost("proxy/account_block_count")]
    [ProducesResponseType(typeof(AccountBlockCount), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> account_block_count([FromBody] AccountBlockCountRequest request)
    {
        return await Call(nameof(account_block_count), request);
    }

    [HttpPost("proxy/account_get")]
    [ProducesResponseType(typeof(AccountGet), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> account_get([FromBody] AccountGetRequest request)
    {
        return await Call(nameof(account_get), request);
    }

    [HttpPost("proxy/account_history")]
    [ProducesResponseType(typeof(AccountHistory), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> account_history([FromBody] AccountHistoryRequest request)
    {
        return await Call(nameof(account_history), request);
    }

    [HttpPost("proxy/account_info")]
    [ProducesResponseType(typeof(AccountInfo), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> account_info([FromBody] AccountInfoRequest request)
    {
        return await Call(nameof(account_info), request);
    }

    [HttpPost("proxy/account_key")]
    [ProducesResponseType(typeof(AccountKey), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> account_key([FromBody] AccountKeyRequest request)
    {
        return await Call(nameof(account_key), request);
    }

    [HttpPost("proxy/account_representative")]
    [ProducesResponseType(typeof(AccountRepresentative), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> account_representative([FromBody] AccountRepresentativeRequest request)
    {
        return await Call(nameof(account_representative), request);
    }

    [HttpPost("proxy/account_weight")]
    [ProducesResponseType(typeof(AccountWeight), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> account_weight([FromBody] AccountWeightRequest request)
    {
        return await Call(nameof(account_weight), request);
    }

    [HttpPost("proxy/accounts_balances")]
    [ProducesResponseType(typeof(AccountsBalances), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> accounts_balances([FromBody] AccountsBalancesRequest request)
    {
        return await Call(nameof(accounts_balances), request);
    }

    [HttpPost("proxy/accounts_frontiers")]
    [ProducesResponseType(typeof(AccountsFrontiers), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> accounts_frontiers([FromBody] AccountsFrontiersRequest request)
    {
        return await Call(nameof(accounts_frontiers), request);
    }

    [HttpPost("proxy/accounts_pending")]
    [ProducesResponseType(typeof(AccountsPending), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> accounts_pending([FromBody] AccountsPendingRequest request)
    {
        return await Call(nameof(accounts_pending), request);
    }

    [HttpPost("proxy/accounts_representatives")]
    [ProducesResponseType(typeof(AccountsRepresentatives), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> accounts_representatives([FromBody] AccountsRepresentativesRequest request)
    {
        return await Call(nameof(accounts_representatives), request);
    }

    [HttpPost("proxy/available_supply")]
    [ProducesResponseType(typeof(AvailableSupply), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> available_supply([FromBody] AvailableSupplyRequest request)
    {
        return await Call(nameof(available_supply), request);
    }

    [HttpPost("proxy/block_account")]
    [ProducesResponseType(typeof(BlockAccount), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> block_account([FromBody] BlockAccountRequest request)
    {
        return await Call(nameof(block_account), request);
    }

    #region " block_hash "
    
    private async Task<IActionResult> block_hash(string request)
    {
        var parsed = To<BlockHashRequest>(request);
        if (bool.TryParse(parsed.JsonBlock, out bool json) && json) // json_block defaults to false
        {
            return await block_hash(To<BlockHashRequest.BlockHashRequest_Json>(request));
        }

        return await block_hash(To<BlockHashRequest.BlockHashRequest_String>(request));
    }
    
    [HttpPost("proxy/block_hash_string")]
    [ProducesResponseType(typeof(BlockHash), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> block_hash([FromBody] BlockHashRequest.BlockHashRequest_String request)
    {
        return await Call(nameof(block_hash), request);
    }
    
    [HttpPost("proxy/block_hash_json")]
    [ProducesResponseType(typeof(BlockHash), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> block_hash([FromBody] BlockHashRequest.BlockHashRequest_Json request)
    {
        return await Call(nameof(block_hash), request);
    }

    #endregion

    [HttpPost("proxy/block_info")]
    [ProducesResponseType(typeof(BlockInfo), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> block_info([FromBody] BlockInfoRequest request)
    {
        return await Call(nameof(block_info), request);
    }

    [HttpPost("proxy/blocks")]
    [ProducesResponseType(typeof(Blocks), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> blocks([FromBody] BlocksRequest request)
    {
        return await Call(nameof(blocks), request);
    }

    [HttpPost("proxy/blocks_info")]
    [ProducesResponseType(typeof(BlocksInfo), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> blocks_info([FromBody] BlocksInfoRequest request)
    {
        return await Call(nameof(blocks_info), request);
    }

    [HttpPost("proxy/chain")]
    [ProducesResponseType(typeof(Chain), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> chain([FromBody] ChainRequest request)
    {
        return await Call(nameof(chain), request);
    }

    [HttpPost("proxy/delegators")]
    [ProducesResponseType(typeof(Delegators), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> delegators([FromBody] DelegatorsRequest request)
    {
        return await Call(nameof(delegators), request);
    }

    [HttpPost("proxy/delegators_count")]
    [ProducesResponseType(typeof(DelegatorsCount), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> delegators_count([FromBody] DelegatorsCountRequest request)
    {
        return await Call(nameof(delegators_count), request);
    }

    [HttpPost("proxy/frontier_count")]
    [ProducesResponseType(typeof(FrontierCount), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> frontier_count([FromBody] FrontierCountRequest request)
    {
        return await Call(nameof(frontier_count), request);
    }

    [HttpPost("proxy/frontiers")]
    [ProducesResponseType(typeof(Frontiers), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> frontiers([FromBody] FrontiersRequest request)
    {
        return await Call(nameof(frontiers), request);
    }

    [HttpPost("proxy/receivable")]
    [ProducesResponseType(typeof(Receivable), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> receivable([FromBody] ReceivableRequest request)
    {
       return await Call(nameof(receivable), request);
    }

    [HttpPost("proxy/receivable_exists")]
    [ProducesResponseType(typeof(ReceivableExists), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> receivable_exists([FromBody] ReceivableExistsRequest request)
    {
        return await Call(nameof(receivable_exists), request);
    }

    [HttpPost("proxy/representatives")]
    [ProducesResponseType(typeof(Representatives), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> representatives([FromBody] RepresentativesRequest request)
    {
        return await Call(nameof(representatives), request);
    }

    [HttpPost("proxy/representatives_online")]
    [ProducesResponseType(typeof(RepresentativesOnline), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> representatives_online([FromBody] RepresentativesOnlineRequest request)
    {
        return await Call(nameof(representatives_online), request);
    }

    [HttpPost("proxy/successors")]
    [ProducesResponseType(typeof(Successors), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> successors([FromBody] SuccessorsRequest request)
    {
        return await Call(nameof(successors), request);
    }

    #endregion
    
    #region " Helper Methods "
    
    private T To<T>(string serialized)
        where T : Request
    {
        return JsonConvert.DeserializeObject<T>(serialized);
    }
    
    private async Task<IActionResult> Call<T>(string name, T request)
        where T : Request
    {
        if (Options.ExcludedCalls.Contains(name)) { return Error($"{name} not supported"); }
        request.Action = name;
        return await Node.Proxy(request);
    }

    private JsonResult Error(string error)
    {
        return Json(new { error });
    }

    #endregion

}