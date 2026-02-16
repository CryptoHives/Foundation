| Description                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-256-CBC (OS)           | 128B         |     261.5 ns |     2.46 ns |     2.18 ns |     128 B |
| Decrypt · AES-256-CBC (Managed)      | 128B         |     560.2 ns |     5.77 ns |     5.12 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 128B         |     957.4 ns |     5.68 ns |     5.32 ns |    1512 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-256-CBC (OS)           | 128B         |     315.2 ns |     1.90 ns |     1.77 ns |     128 B |
| Encrypt · AES-256-CBC (Managed)      | 128B         |     505.9 ns |     4.60 ns |     4.30 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 128B         |     862.5 ns |     5.57 ns |     5.21 ns |    1496 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-256-CBC (OS)           | 1KB          |     326.6 ns |     1.09 ns |     0.91 ns |     128 B |
| Decrypt · AES-256-CBC (Managed)      | 1KB          |   3,988.7 ns |    31.65 ns |    29.61 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 1KB          |   5,011.0 ns |    40.84 ns |    38.21 ns |    3304 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-256-CBC (OS)           | 1KB          |     909.6 ns |     2.81 ns |     2.49 ns |     128 B |
| Encrypt · AES-256-CBC (Managed)      | 1KB          |   4,011.6 ns |    37.76 ns |    35.32 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 1KB          |   4,927.4 ns |    34.49 ns |    32.26 ns |    3288 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-256-CBC (OS)           | 8KB          |     944.3 ns |     4.97 ns |     4.65 ns |     128 B |
| Decrypt · AES-256-CBC (Managed)      | 8KB          |  31,496.7 ns |   289.89 ns |   256.98 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 8KB          |  37,185.0 ns |   358.93 ns |   318.19 ns |   17640 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-256-CBC (OS)           | 8KB          |   5,906.5 ns |    17.16 ns |    16.05 ns |     128 B |
| Encrypt · AES-256-CBC (Managed)      | 8KB          |  31,854.5 ns |   205.69 ns |   182.34 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 8KB          |  37,150.0 ns |   270.01 ns |   239.35 ns |   17624 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-256-CBC (OS)           | 128KB        |  11,309.5 ns |    45.16 ns |    42.24 ns |     128 B |
| Decrypt · AES-256-CBC (Managed)      | 128KB        | 501,619.7 ns | 4,496.59 ns | 3,986.11 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 128KB        | 639,865.8 ns | 3,486.04 ns | 3,090.28 ns |  263428 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-256-CBC (OS)           | 128KB        |  91,374.3 ns |   446.82 ns |   396.10 ns |     128 B |
| Encrypt · AES-256-CBC (Managed)      | 128KB        | 510,648.4 ns | 4,109.53 ns | 3,431.64 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 128KB        | 643,966.9 ns | 3,463.39 ns | 3,239.65 ns |  263412 B |