| Description                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-256-CBC (OS)           | 128B         |     252.7 ns |     1.33 ns |     1.18 ns |     128 B |
| Decrypt · AES-256-CBC (Managed)      | 128B         |     556.1 ns |     3.91 ns |     3.47 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 128B         |     875.3 ns |     3.54 ns |     2.95 ns |    1024 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-256-CBC (OS)           | 128B         |     312.7 ns |     2.63 ns |     2.34 ns |     128 B |
| Encrypt · AES-256-CBC (Managed)      | 128B         |     501.7 ns |     3.95 ns |     3.69 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 128B         |     792.5 ns |     5.77 ns |     5.40 ns |    1024 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-256-CBC (OS)           | 1KB          |     329.2 ns |     1.97 ns |     1.74 ns |     128 B |
| Decrypt · AES-256-CBC (Managed)      | 1KB          |   3,979.7 ns |    45.11 ns |    42.19 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 1KB          |   4,807.1 ns |    39.83 ns |    37.26 ns |    1024 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-256-CBC (OS)           | 1KB          |     896.2 ns |     3.26 ns |     3.05 ns |     128 B |
| Encrypt · AES-256-CBC (Managed)      | 1KB          |   3,980.0 ns |    25.27 ns |    22.40 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 1KB          |   4,741.7 ns |    34.49 ns |    32.26 ns |    1024 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-256-CBC (OS)           | 8KB          |     932.2 ns |     2.85 ns |     2.67 ns |     128 B |
| Decrypt · AES-256-CBC (Managed)      | 8KB          |  31,241.2 ns |   231.66 ns |   216.69 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 8KB          |  36,101.9 ns |   233.97 ns |   207.40 ns |    1024 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-256-CBC (OS)           | 8KB          |   5,901.2 ns |    23.46 ns |    20.80 ns |     128 B |
| Encrypt · AES-256-CBC (Managed)      | 8KB          |  31,819.3 ns |   315.09 ns |   294.73 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 8KB          |  36,236.3 ns |   396.65 ns |   371.03 ns |    1024 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-256-CBC (OS)           | 128KB        |  11,318.5 ns |    47.69 ns |    44.61 ns |     128 B |
| Decrypt · AES-256-CBC (Managed)      | 128KB        | 509,930.4 ns | 3,178.26 ns | 2,817.44 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 128KB        | 571,019.4 ns | 4,449.11 ns | 3,944.02 ns |    1024 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-256-CBC (OS)           | 128KB        |  91,293.7 ns |   330.29 ns |   308.95 ns |     128 B |
| Encrypt · AES-256-CBC (Managed)      | 128KB        | 511,123.7 ns | 5,662.85 ns | 4,728.73 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 128KB        | 574,778.4 ns | 3,964.20 ns | 3,708.12 ns |    1024 B |