# Nano Public API
This API sits in front of your Nano node RPC endpoint to provide access to only the public
readonly calls available.  The API excludes all deprecated calls, control calls, calls
that write to the network, and calls that provide information about the node itself.

The calls available against the v23.3 node are listed below:

- [account_balance](https://docs.nano.org/commands/rpc-protocol/#account_balance)
- [account_block_count](https://docs.nano.org/commands/rpc-protocol/#account_block_count)
- [account_get](https://docs.nano.org/commands/rpc-protocol/#account_get)
- [account_history](https://docs.nano.org/commands/rpc-protocol/#account_history)
- [account_info](https://docs.nano.org/commands/rpc-protocol/#account_info)
- [account_key](https://docs.nano.org/commands/rpc-protocol/#account_key)
- [account_representative](https://docs.nano.org/commands/rpc-protocol/#account_representative)
- [account_weight](https://docs.nano.org/commands/rpc-protocol/#account_weight)
- [accounts_balances](https://docs.nano.org/commands/rpc-protocol/#accounts_balances)
- [accounts_frontiers](https://docs.nano.org/commands/rpc-protocol/#accounts_frontiers)
- [accounts_pending](https://docs.nano.org/commands/rpc-protocol/#accounts_pending)
- [accounts_representatives](https://docs.nano.org/commands/rpc-protocol/#accounts_representatives)
- [available_supply](https://docs.nano.org/commands/rpc-protocol/#available_supply)
- [block_account](https://docs.nano.org/commands/rpc-protocol/#block_account)
- [block_hash](https://docs.nano.org/commands/rpc-protocol/#block_hash)
- [block_info](https://docs.nano.org/commands/rpc-protocol/#block_info)
- [blocks](https://docs.nano.org/commands/rpc-protocol/#blocks)
- [blocks_info](https://docs.nano.org/commands/rpc-protocol/#blocks_info)
- [chain](https://docs.nano.org/commands/rpc-protocol/#chain)
- [delegators](https://docs.nano.org/commands/rpc-protocol/#delegators)
- [delegators_count](https://docs.nano.org/commands/rpc-protocol/#delegators_count)
- [frontier_count](https://docs.nano.org/commands/rpc-protocol/#frontier_count)
- [frontiers](https://docs.nano.org/commands/rpc-protocol/#frontiers)
- [receivable](https://docs.nano.org/commands/rpc-protocol/#receivable)
- [receivable_exists](https://docs.nano.org/commands/rpc-protocol/#receivable_exists)
- [representatives](https://docs.nano.org/commands/rpc-protocol/#representatives)
- [representatives_online](https://docs.nano.org/commands/rpc-protocol/#representatives_online)
- [successors](https://docs.nano.org/commands/rpc-protocol/#successors)

The API provides a [Swagger](https://swagger.io/) interface for ad-hoc requests, but
it also provides a proxy method that can be used as a replacement for a node in normal
interfacing.  Basically, instead of providing http://node.example.com:7076 as your RPC endpoint,
you would provide https://api.node.example.com/node/proxy and still have access to the methods
listed above.

NOTE: Not all API instances will provide access to all of the calls listed above; use
https://api.node.exmaple/api/supported_calls or https://api.node.exmaple/api/excluded_calls
to verify which calls are supported by the instance you are using.

### Docker-Compose Example

```
version: '3.8'

services:

  node:
    image: 'nanocurrency/nano:V##.#'
    networks:
      - nano
    ... clipped for brevity ...
    
  monitor:
    image: 'nanotools/nanonodemonitor:v##'
    networks:
      - traefik
      - nano
    ... clipped for brevity ...
    
  api:
    image: 'cinderblockgames/nano-public-api:V##.#.#'
    environment:
      # optional; port on which to listen; default value provided
      - 'ASPNETCORE_URLS=http://+:2022'
      # optional; url of node rpc; default value provided
      - 'NODE=http://node:7076'
      # optional; opens CORS; default value provided
      - 'DISABLE_CORS=true'
      # optional; specifies which calls to remove from support; default value provided
      - 'EXCLUDED_CALLS=delegators;delegators_count'
    networks:
      - traefik
      - nano
    deploy:
      mode: replicated
      replicas: 2
      labels:
        - 'traefik.enable=true'
        - 'traefik.docker.network=traefik'
        - 'traefik.http.routers.nano-api.rule=Host(`api.nano.kga.earth`)'
        - 'traefik.http.routers.nano-api.entrypoints=web-secure'
        - 'traefik.http.routers.nano-api.tls'
        - 'traefik.http.services.nano-api.loadbalancer.server.port=2022'

networks:
  traefik:
    external: true
  nano:
    external: true
```